using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.IO;
using System.Globalization;

#pragma warning disable IDE1006
#pragma warning disable IDE0017

namespace FieldCalibration
{
    public partial class FieldCal : Form
    {
        static string string_from_usart = "";
        static bool GotData = false;
        static Boolean port_close_flag;
        double MagXvalue, MagYvalue, MagZvalue;
        double AccXvalue, AccYvalue, AccZvalue;
        int empty_serial_data_counter;
        string curDir;
        string portName;
        string portBaud;
        bool TimerEnabled = false;
        int TimerState = 0;
        int TimerStatus = -20;
        int tcount;
        Bitmap bmp1 = new Bitmap(2400, 1200);
        Font drawFont = new Font("Courier New", (float)10, FontStyle.Regular, GraphicsUnit.Point);
        SolidBrush drawBrush = new SolidBrush(Color.Black);
        StringFormat drawFormat = new StringFormat();
        Pen FPen = new Pen(Color.Blue, 1);

        const int MaxSeries = 1000;
        int SeriesIndex = 0;
        int LastSeriesIndex = 0;
        float[,] Series = new float[6,MaxSeries];
        
        const int MaxData = 100000;
        int DataIndex = 0;
        int LastDataIndex = 0;
        double[,] Data = new double[3, MaxData];

        Bitmap bmpXY = new Bitmap(2400, 1200);
        Bitmap bmpXZ = new Bitmap(2400, 1200);
        Bitmap bmpYZ = new Bitmap(2400, 1200);

        int[,] CoverageXY = new int[10, 10];
        int[,] CoverageXZ = new int[10, 10];
        int[,] CoverageYZ = new int[10, 10];

        public FieldCal()
        {
            InitializeComponent();
        }
        private void FieldCal_FormClosing(object sender, FormClosingEventArgs e)
        {
            string DirName = curDir;
            string FilName = "Setup.txt";
            string s = comboBox1.Text + "," + comboBox2.Text;
            SaveTextFile(DirName, FilName, s, true, false);
            close_port();
        }
        private void FieldCal_Load(object sender, EventArgs e)
        {
            this.Text = "Field Compass Calibration 1.0";

            curDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);

            //current dir name
            curDir = System.IO.Path.GetDirectoryName(
            System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);

            pictureBox1.Image = bmp1;
            pictureBoxXY.Image = bmpXY;
            pictureBoxXZ.Image = bmpXZ;
            pictureBoxYZ.Image = bmpYZ;

            buttonShowRawProcessed.Enabled = false;
            buttonCalcMatrix.Enabled = false;
            buttonStartDataCollection.Enabled = true;
            buttonSaveMatrix.Enabled = false;
            buttonStopDataCollection.Enabled = false;
            buttonClose.Enabled = false;

            portName = "";
            portBaud = "115200";

            //Load previous comm port
            string FilName = curDir + "\\Setup.txt";
            string str = ReadTextFile(FilName);

            if (str.Length > 3)
            {
                string[] serial_values = str.Split(',');
                if (serial_values.Count() > 1)
                {
                    portName = serial_values[0];
                    portBaud = serial_values[1];
                }
            }
            
            int index = comboBox2.FindString(portBaud);
            if (index > 0)
            {
                comboBox2.SelectedIndex = index;
            }
            else
            {
                comboBox2.SelectedIndex = 3;
            }

            int item = 0;
            int selecteditem = 0;
            foreach (string s in SerialPort.GetPortNames())
            {
                item++;
                comboBox1.Items.Add(s);
                if (portName == s)
                {
                    comboBox1.Text = portName;
                    selecteditem = item;
                }
            }

            if (selecteditem > 0)
            {
                comboBox1.SelectedItem = selecteditem;
                buttonClose_Click(sender, e);
                buttonOpen_Click(sender, e);
            }
            //timer2.Interval = 200;
            timer2.Enabled = true;

        }
        private static string SaveTextFile(string DirName, string FilName, string strData, bool ShowError, bool Append)
        {
            DirectoryInfo di = new DirectoryInfo(DirName);
            string str = "";

            try
            {
                if (di.Exists)// Determine whether the directory exists.
                {
                    //di.Delete();// Delete the directory.
                }
                else// Try to create the directory.
                {
                    di.Create();
                }
            }
            catch
            {
                if (ShowError)
                    MessageBox.Show("No Directory. Can't save Text data!");
            }
            finally
            {
                str = DirName + "\\" + FilName;
                try
                {
                    if (Append)
                        System.IO.File.AppendAllText(str, strData);
                    else
                        System.IO.File.WriteAllText(str, strData);
                }
                catch (System.Exception ex)
                {
                    if (ShowError)
                        MessageBox.Show("Can't save Text data! " + str + " " + String.Format("exception: {0}", ex.GetType().ToString()));
                }
            }
            return str;
        }
        private static string ReadTextFile(string FilName)
        {
            String s = "";
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(FilName);
                s = sr.ReadToEnd();
                //close the file
                sr.Close();
            }
            catch { }

            return s;
        }
        private void SendCom(SerialPort Port, string txt)
        {
            if (Port.IsOpen)
            {
                string message1 = txt + '\r';
                //string message3;

                try
                {
                    Port.Write(message1);
                }
                catch { }// (System.Exception ex)
                //{
                //    message3 = String.Format("caughtC: {0}", ex.GetType().ToString());
                //}
            }
        }
        private bool ADCPStarted = false;
        private void buttonOpen_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedItem != null)
                {
                    serialPort1.PortName = comboBox1.SelectedItem.ToString();
                    //port opening
                    port_close_flag = false;
                    serialPort1.ReadTimeout = 100;
                    serialPort1.Open();
                    serialPort1.BaudRate = Convert.ToInt32(comboBox2.SelectedItem.ToString());

                    buttonClose.Enabled = true;

                    buttonOpen.Enabled = false;
                    comboBox1.Enabled = false;
                    comboBox2.Enabled = false;
                    //for the handler
                    serialPort1.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                    //timer activation
                    timer1.Enabled = true;
                    TimerEnabled = true;
                    timer1.Interval = 10;
                    //Application.DoEvents();
                    buttonStartDataCollection.Enabled = true;
                }
                else
                {
                    textBoxStatus.Text = "Serial Port Not Selected";
                }
                
            }
            catch
            {
                close_port();
                MessageBox.Show("Selected port in use", "Warning!");
            }
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            //buttonStopDataCollection_Click(sender, e);
            timer3.Enabled = false;
            //timer2.Enabled = false;
            buttonStartDataCollection.Enabled = true;
            buttonCalcMatrix.Enabled = true;
            close_port();
        }
        void close_port()
        {
            TimerEnabled = false;
            
            port_close_flag = true;
            
            buttonClose.Enabled = false;
            Thread.Sleep(500);
            serialPort1.Close();
            buttonOpen.Enabled = true;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            empty_serial_data_counter = 0;
            string_from_usart = "";
            GotData = false;
            MagXvalue = 0;
            MagYvalue = 0;
            MagZvalue = 0;
            AccXvalue = 0;
            AccYvalue = 0;
            AccZvalue = 0;
            Xlabel.Text = "X = " + MagXvalue.ToString("0.####");
            Ylabel.Text = "Y = " + MagYvalue.ToString("0.####");
            Zlabel.Text = "Z = " + MagZvalue.ToString("0.####");
            labelAccX.Text = "X = " + AccXvalue.ToString("0.####");
            labelAccY.Text = "Y = " + AccYvalue.ToString("0.####");
            labelAccZ.Text = "Z = " + AccZvalue.ToString("0.####");
            ADCPStarted = false;
            textBoxStatus.Text = "Disconnected";
            button1.BackColor = Color.FromArgb(255, 240, 240, 240);//= Color.White;
            button2.BackColor = Color.FromArgb(255, 240, 240, 240);//Color.White;

            buttonCalcMatrix.Enabled = false;
            buttonStartDataCollection.Enabled = false;
            buttonSaveMatrix.Enabled = false;
            buttonStopDataCollection.Enabled = false;
        }
        private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (!port_close_flag)
                {
                    SerialPort sp = (SerialPort)sender;
                    string indata = sp.ReadLine();
                    string_from_usart = indata;
                    GotData = true;
                }
            }
            catch
            {
                GotData = false;
            }
        }
        private void var_refresh()
        {
            string str;// = "";
            try
            {
                if (GotData)
                {
                    try
                    {
                        GotData = false;
                        str = string_from_usart;
                        if(!str.Contains("NA") && !str.Contains("ENGATT 10"))
                        { 
                            string[] serial_values = str.Split(',');
                            if (serial_values[0] != "" && serial_values[1] != "" && serial_values[2] != ""
                             && serial_values[3] != "" && serial_values[4] != "" && serial_values[5] != "")
                            {
                                try
                                {
                                    MagXvalue = double.Parse(serial_values[0]);
                                    MagYvalue = double.Parse(serial_values[1]);
                                    MagZvalue = double.Parse(serial_values[2]);
                                    AccXvalue = double.Parse(serial_values[3]);
                                    AccYvalue = double.Parse(serial_values[4]);
                                    AccZvalue = double.Parse(serial_values[5]);


                                    Data[0, DataIndex] = MagXvalue;
                                    Data[1, DataIndex] = MagYvalue;
                                    Data[2, DataIndex] = MagZvalue;

                                    DataIndex++;
                                    if (DataIndex >= MaxData)
                                        DataIndex--;

                                    Series[0, SeriesIndex] = (float)MagXvalue;
                                    Series[1, SeriesIndex] = (float)MagYvalue;
                                    Series[2, SeriesIndex] = (float)MagZvalue;
                                    Series[3, SeriesIndex] = (float)AccXvalue;
                                    Series[4, SeriesIndex] = (float)AccYvalue;
                                    Series[5, SeriesIndex] = (float)AccZvalue;

                                    SeriesIndex++;
                                    if (SeriesIndex >= MaxSeries)
                                        SeriesIndex = 0;

                                    empty_serial_data_counter = 0;
                                    textBoxStatus.Text = "Connected";
                                }
                                catch
                                {
                                    GotData = false;
                                }
                            }
                            else
                            {
                                GotData = false;
                            }
                        }
                    }
                    catch
                    {
                        GotData = false;
                    }
                }
                else
                {
                    if (string_from_usart.Contains("Timeout"))
                    {
                        textBoxStatus.Text = "IMU Timeout";
                        empty_serial_data_counter = 0;
                    }
                    else
                    {
                        empty_serial_data_counter++;
                        if (empty_serial_data_counter >= 20)
                        {
                            textBoxStatus.Text = "No serial data";
                        }
                        if (empty_serial_data_counter >= 200)
                        {
                            empty_serial_data_counter = 0;
                            ADCPStarted = false;
                            //SendCom(serialPort1, "ENGATT 10");
                        }
                    }
                }
            }
            catch
            {
                textBoxStatus.Text = "Serial port error";
                close_port();
                //MessageBox.Show("Serial port error.", "Warning!");
                ADCPStarted = false;
            }
        }
        private void indication()
        {
            Xlabel.Text = "X = " + MagXvalue.ToString("0.####");
            Ylabel.Text = "Y = " + MagYvalue.ToString("0.####");
            Zlabel.Text = "Z = " + MagZvalue.ToString("0.####");
            labelAccX.Text = "X = " + AccXvalue.ToString("0.####");
            labelAccY.Text = "Y = " + AccYvalue.ToString("0.####");
            labelAccZ.Text = "Z = " + AccZvalue.ToString("0.####");
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (TimerEnabled)
            {
                if (!ADCPStarted)
                {
                    TimerState = 0;
                    tcount = 100;
                }
                switch (TimerState)
                {
                    case 0:
                        empty_serial_data_counter = 0;
                        textBoxStatus.Text = "Starting ADCP";
                        textBoxSN.Text = "";
                        ADCPStarted = true;
                        SendCom(serialPort1, "STOP");
                        TimerState = 1;
                        break;
                    case 1:
                        tcount--;
                        if (string_from_usart.Contains("STOP" + '\u0006'))
                        {
                            TimerState = 10;
                            ADCPStarted = true;
                            tcount = 0;
                        }
                        else
                        {
                            if (tcount < 0)
                            {
                                textBoxStatus.Text = "ADCP Not Detected";
                                ADCPStarted = false;
                            }
                        }
                        break;
                    case 10:
                        textBoxStatus.Text = "Downloading Compass SN";
                        SendCom(serialPort1, "ENGBR050C00");
                        int cnt = 20;
                        while (!string_from_usart.Contains("SER#"))
                        {
                            cnt--;
                            if (cnt < 0)
                                break;
                            System.Threading.Thread.Sleep(100);
                        }
                        //ENGBR050C00+
                        //35 30 31 30 33 2D 30 30 20 52 45 56 3A 58 44 20 53 45 52 23 30 31 30 38 20 20 20 20 20 20 20 20 
                        //50103-00 REV:XD SER#0108
                        if (string_from_usart.Contains("SER#"))
                        {
                            textBoxStatus.Text = "Connected";
                            int i = string_from_usart.IndexOf("SER#");
                            i += 4;
                            string SN = string_from_usart.Substring(i, 4);

                            try
                            {
                                int iSN = Convert.ToInt32(SN);

                                textBoxSN.Text = iSN.ToString();//SN;
                            }
                            catch
                            {
                                textBoxSN.Text = SN;
                            }

                            string_from_usart = "";
                            SendCom(serialPort1, "ENGATT 10");

                            ADCPStarted = true;
                            TimerState = 12;
                        }
                        else
                        {
                            textBoxSN.Text = "NA";
                            ADCPStarted = false;
                        }
                        break;
                    case 12:
                        var_refresh();
                        indication();
                        break;
                }
                TimerStatus++;
                if (TimerStatus > 20)
                    TimerStatus = -20;
                bool ok = false;
                if (textBoxStatus.Text == "Connected")
                    ok = true;

                if (TimerStatus > 0)
                {
                    if(ok)
                        button1.BackColor = Color.Green;
                    else
                        button1.BackColor = Color.Red;
                    button2.BackColor = Color.White;
                }
                else
                {
                    if(ok)
                        button2.BackColor = Color.Green;
                    else
                        button2.BackColor = Color.Red;
                    button1.BackColor = Color.White;
                }
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            int Index = SeriesIndex;
            if (LastSeriesIndex != Index)
            {
                PlotSeries();
                pictureBox1.Refresh();
                LastSeriesIndex = Index;
            }
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            int Index = DataIndex;
            int count = Index - LastDataIndex;
            if (count > 0)
            {   
                Graphics g = Graphics.FromImage(pictureBoxXY.Image);
                float scale = pictureBoxXY.Width / 2;
                float x1;
                float y1;
                float CenterX = pictureBoxXY.Width / 2;
                float CenterY = pictureBoxXY.Height / 2;
                FPen.Color = Color.Red;
                for (int n = LastDataIndex; n < (LastDataIndex + count); n++)
                {
                    //XY
                    x1 = scale * (float)Data[0,n] + CenterX;
                    y1 = -scale * (float)Data[1, n] + CenterY;                    
                    g.DrawEllipse(FPen, x1, y1, 3, 3);
                }
                
                //XZ
                g = Graphics.FromImage(pictureBoxXZ.Image);
                scale = pictureBoxXZ.Width / 2;
                CenterX = pictureBoxXZ.Width / 2;
                CenterY = pictureBoxXZ.Height / 2;
                FPen.Color = Color.Green;
                for (int n = LastDataIndex; n < (LastDataIndex + count); n++)
                {
                    x1 = scale * (float)Data[0, n] + CenterX;
                    y1 = -scale * (float)Data[2, n] + CenterY;                    
                    g.DrawEllipse(FPen, x1, y1, 3, 3);
                }

                //YZ
                g = Graphics.FromImage(pictureBoxYZ.Image);
                scale = pictureBoxYZ.Width / 2;
                CenterX = pictureBoxYZ.Width / 2;
                CenterY = pictureBoxYZ.Height / 2;
                FPen.Color = Color.Blue;
                for (int n = LastDataIndex; n < (LastDataIndex + count); n++)
                {
                    x1 = scale * (float)Data[1, n] + CenterX;
                    y1 = -scale * (float)Data[2, n] + CenterY;
                    g.DrawEllipse(FPen, x1, y1, 3, 3);
                }

                pictureBoxXY.Refresh();
                pictureBoxXZ.Refresh();
                pictureBoxYZ.Refresh();

                textBoxDataSamples.Text = Index.ToString();
                LastDataIndex = Index;
            }
        }
        private void Graphics_PlotGridSeries(System.Drawing.Graphics g, float X1,float X2, float Y1, float Y2, string TitleStr)
        {
            int i;
            string s;
            float Vsteps = 4;
            float step = ((Y2 - Y1) / Vsteps);
            float X, Y;
            float VvalTL = 1;
            float VvalStepL = (float)-0.5;
            int NDL = 2;

            drawBrush.Color = Color.Black;

            if (TitleStr != "")
            {
                Y = Y1 + 10;
                X = X1 + (X2 - X1) / 2 - drawFont.SizeInPoints * TitleStr.Length / 2;
                g.DrawString(TitleStr, drawFont, drawBrush, X, Y, drawFormat);
            }

            //draw and label vertical grid
            for (Y = Y1; Y <= Y2; Y += step)
            {
                g.DrawLine(System.Drawing.Pens.LightGray, X1 - 5, Y, X2 + 5, Y);
                switch (NDL)
                {
                    default:
                    case 0:
                        s = VvalTL.ToString();
                        break;
                    case 1:
                        s = VvalTL.ToString("0.0");
                        break;
                    case 2:
                        s = VvalTL.ToString("0.00");
                        break;
                }
                while (s.Length < 4)
                    s = " " + s;

                g.DrawString(s, drawFont, drawBrush, X1 - drawFont.SizeInPoints * s.Length, Y - drawFont.SizeInPoints, drawFormat);

                VvalTL += VvalStepL;
            }

            //draw and label horizontal grid
            float Hsteps = 11;
            float HvalStep = MaxSeries / (Hsteps-1);
            float Hrange = MaxSeries;
            float Hscale = (X2 - X1) / Hrange;
            float Hoffset = X1;
            float HvalL = 0;

            for (i = 0; i < Hsteps; i++)
            {
                X = Hoffset + HvalL * Hscale;

                g.DrawLine(System.Drawing.Pens.LightGray, X, Y1-5, X, Y2+5);

                s = HvalL.ToString();
                g.DrawString(s, drawFont, drawBrush, X - drawFont.SizeInPoints * s.Length / 2, Y2, drawFormat);

                HvalL += HvalStep;
            }
        }
        private void PlotSeries()
        {
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            
            float X1 = 0;
            float X2 = pictureBox1.Width;
            float Y1 = 0;
            float Y2 = pictureBox1.Height;
            //erase last plot
            g.FillRectangle(Brushes.White, X1, Y1, X2 - X1, Y2 - Y1);

            X1 = 50;
            X2 = pictureBox1.Width - 20;
            Y1 = 10;
            Y2 = pictureBox1.Height - 50;
            //plot the grid
            Graphics_PlotGridSeries(g,X1,X2,Y1,Y2,"");


            float X = X1 + (X2 - X1) / 2 - 210;
            float Y = pictureBox1.Height - 20;
            //draw legend
            drawBrush.Color = Color.Red;
            g.DrawString("MagX(G)", drawFont, drawBrush, X, Y, drawFormat);
            X += 70;
            drawBrush.Color = Color.Green;
            g.DrawString("MagY(G)", drawFont, drawBrush, X, Y, drawFormat);
            X += 70;
            drawBrush.Color = Color.Blue;
            g.DrawString("MagZ(G)", drawFont, drawBrush, X, Y, drawFormat);
            X += 70;
            drawBrush.Color = Color.Magenta;
            g.DrawString("AccX(g)", drawFont, drawBrush, X, Y, drawFormat);
            X += 70;
            drawBrush.Color = Color.Black;
            g.DrawString("AccY(g)", drawFont, drawBrush, X, Y, drawFormat);
            X += 70;
            drawBrush.Color = Color.Cyan;
            g.DrawString("AccZ(g)", drawFont, drawBrush, X, Y, drawFormat);


            float Vscale = (Y2 - Y1) / 2;
            float Voffset = Y1 + (Y2 - Y1) / 2;
            int j;

            float dX = ((X2 - X1) / MaxSeries);
            float LastX;
            bool gotfirstsample;
            float LastY;

            //plot all values
            for (int n = 0; n < 6; n++)
            {
                X = X1;
                LastX = X;
                gotfirstsample = false;
                LastY = 0;

                switch (n)
                {
                    case 0:
                        FPen.Color = Color.Red;
                        break;
                    case 1:
                        FPen.Color = Color.Green;
                        break;
                    case 2:
                        FPen.Color = Color.Blue;
                        break;
                    case 3:
                        FPen.Color = Color.Magenta;
                        break;
                    case 4:
                        FPen.Color = Color.Black;
                        break;
                    case 5:
                        FPen.Color = Color.Cyan;
                        break;
                }                

                j = SeriesIndex;
                for (int i = 0; i < MaxSeries; i++)
                {
                    Y = Voffset - Vscale * Series[n, j];
                    if (Y > Y2)
                        Y = Y2;
                    if (Y < Y1)
                        Y = Y1;
                    if (gotfirstsample == false)
                    {
                        gotfirstsample = true;
                    }
                    else
                    {
                        g.DrawLine(FPen, LastX, LastY, X, Y);
                    }
                    LastX = X;
                    LastY = Y;
                    X += dX;
                    j++;
                    if (j >= MaxSeries)
                        j = 0;
                }
            }
        }
        private void buttonReadRawFile_Click(object sender, EventArgs e)
        {
            buttonCalcMatrix.Enabled = false;
            buttonStartDataCollection.Enabled = false;
            buttonSaveMatrix.Enabled = false;
            buttonStopDataCollection.Enabled = false;

            string FileName;
            string DirName;

            Stream stream;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            string exceptionmessage;
            string FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            openFileDialog1.InitialDirectory = FolderPath + "\\RTI\\FieldCompassCalibration";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*|csv files (*.csv)|*.csv";
            openFileDialog1.FilterIndex = 1;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((stream = openFileDialog1.OpenFile()) != null)
                    {
                        try
                        {   
                            string s = File.ReadAllText(openFileDialog1.FileName);
                            string[] values = s.Split('\n');
                            DataIndex = 0;
                            for (int n =0;n<values.Count();n++)
                            {
                                string[] nums = values[n].Split('\t');
                                if (nums.Count() == 3)
                                {
                                    Data[0, n] = Convert.ToDouble(nums[0]);
                                    Data[1, n] = Convert.ToDouble(nums[1]);
                                    Data[2, n] = Convert.ToDouble(nums[2]);
                                    DataIndex++;
                                }
                            }

                            DirName = openFileDialog1.FileName;
                            FileName = openFileDialog1.SafeFileName;
                            int i = DirName.IndexOf(FileName);
                            DirName = DirName.Substring(0,i);

                            textBoxDataStatus.Text = DirName + "\\" + FileName;

                            //CalcMatrix(textBoxDataStatus.Text);
                            //Application.DoEvents();

                            textBox_matrixX_x.Clear();
                            textBox_matrixX_y.Clear();
                            textBox_matrixX_z.Clear();
                            textBox_matrixY_x.Clear();
                            textBox_matrixY_y.Clear();
                            textBox_matrixY_z.Clear();
                            textBox_matrixZ_x.Clear();
                            textBox_matrixZ_y.Clear();
                            textBox_matrixZ_z.Clear();
                            textBox_biasX.Clear();
                            textBox_biasY.Clear();
                            textBox_biasZ.Clear();

                            buttonShowRawProcessed.Enabled = false;
                            buttonShowRawProcessed.Text = "Show Raw";
                            buttonShowRawProcessed_Click(sender, e);

                            PlotCircles(true);
                        }

                        catch (Exception ex)
                        {
                            exceptionmessage = String.Format("File Error A: {0}", ex.GetType().ToString());
                            MessageBox.Show(exceptionmessage);
                        }
                        stream.Close();
                    }
                }
                catch (Exception ex)
                {
                    exceptionmessage = String.Format("File Error B: {0}", ex.GetType().ToString());
                    MessageBox.Show(exceptionmessage);
                }
            }
            buttonSaveMatrix.Enabled = true;
            buttonCalcMatrix.Enabled = true;
            buttonStartDataCollection.Enabled = true;
        }
        private void buttonStartDataCollection_Click(object sender, EventArgs e)
        {
            int i, j;
            
            buttonCalcMatrix.Enabled = false;
            buttonStartDataCollection.Enabled = false;
            buttonSaveMatrix.Enabled = false;
            buttonStopDataCollection.Enabled = true;

            buttonShowRawProcessed.Enabled = false;
            buttonShowRawProcessed.Text = "Show Raw";
            buttonShowRawProcessed_Click(sender, e);

            textBox_matrixX_x.Clear();
            textBox_matrixX_y.Clear();
            textBox_matrixX_z.Clear();
            textBox_matrixY_x.Clear();
            textBox_matrixY_y.Clear();
            textBox_matrixY_z.Clear();
            textBox_matrixZ_x.Clear();
            textBox_matrixZ_y.Clear();
            textBox_matrixZ_z.Clear();
            textBox_biasX.Clear();
            textBox_biasY.Clear();
            textBox_biasZ.Clear();

            for (i = 0; i < 10; i++)
            {
                for (j = 0; j < 10; j++)
                {
                    CoverageXY[i, j] = 0;
                    CoverageXZ[i, j] = 0;
                    CoverageYZ[i, j] = 0;
                }
            }
            DataIndex = 0;
            LastDataIndex = 0;
            //DataCollectionOn = true;
            timer2.Enabled = true;

            FPen.Color = Color.Black;

            Graphics g = Graphics.FromImage(pictureBoxXY.Image);
            float X1 = 0;
            float X2 = pictureBoxXY.Width - 1;
            float Y1 = 0;
            float Y2 = pictureBoxXY.Height - 1;
            //erase last plot
            g.FillRectangle(Brushes.White, X1, Y1, X2 - X1, Y2 - Y1);
            g.DrawEllipse(FPen, X1, Y1, X2 - X1, Y2 - Y1);

            g = Graphics.FromImage(pictureBoxXZ.Image);
            X1 = 0;
            X2 = pictureBoxXZ.Width - 1;
            Y1 = 0;
            Y2 = pictureBoxXZ.Height - 1;
            //erase last plot
            g.FillRectangle(Brushes.White, X1, Y1, X2 - X1, Y2 - Y1);
            g.DrawEllipse(FPen, X1, Y1, X2 - X1, Y2 - Y1);

            g = Graphics.FromImage(pictureBoxYZ.Image);
            X1 = 0;
            X2 = pictureBoxYZ.Width - 1;
            Y1 = 0;
            Y2 = pictureBoxYZ.Height - 1;
            //erase last plot
            g.FillRectangle(Brushes.White, X1, Y1, X2 - X1, Y2 - Y1);
            g.DrawEllipse(FPen, X1, Y1, X2 - X1, Y2 - Y1);

            timer3.Enabled = true;
        }
        private void buttonStopDataCollection_Click(object sender, EventArgs e)
        {
            string FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string DirName = FolderPath + "\\RTI\\FieldCompassCalibration";
            string dtstr = DateTime.Now.ToString("yyyyMMddHHmmss");
            string FileName = textBoxSN.Text + "_Cal_" + dtstr + ".txt";

            Cursor.Current = Cursors.WaitCursor;

            string DataStr = "";
            for (int n = 0; n < DataIndex; n++)
            {
                DataStr += Data[0, n].ToString() + '\t';
                DataStr += Data[1, n].ToString() + '\t';
                DataStr += Data[2, n].ToString() + '\n';
                Application.DoEvents();
            }

            SaveTextFile(DirName, FileName, DataStr, true, false);

            Cursor.Current = Cursors.Default;

            textBoxDataStatus.Text = DirName + "\\" + FileName;

            timer3.Enabled = false;
            buttonStartDataCollection.Enabled = true;
            buttonCalcMatrix.Enabled = true;
        }
        private void buttonShowRawProcessed_Click(object sender, EventArgs e)
        {
            if (buttonShowRawProcessed.Text == "Show Cal")
            {
                buttonShowRawProcessed.Text = "Show Raw";
                groupBox1.Text = "Cal MagXY(G)";
                groupBox2.Text = "Cal MagXZ(G)";
                groupBox3.Text = "Cal MagYZ(G)";
                PlotCircles(false);
            }
            else
            {
                buttonShowRawProcessed.Text = "Show Cal";
                groupBox1.Text = "Raw MagXY(G)";
                groupBox2.Text = "Raw MagXZ(G)";
                groupBox3.Text = "Raw MagYZ(G)";
                PlotCircles(true);
            }
        }
        private void CalcMatrix(string FileName)
        {
            string strCalc = MagCal.Calc(FileName);
            try
            {
                string[] values = strCalc.Split('\r', '\n');

                textBox_biasX.Text = values[2];
                textBox_biasY.Text = values[4];
                textBox_biasZ.Text = values[6];

                string[] matStr = values[10].Split(' ');
                int i = 0;
                for (int n = 0; n < matStr.Count(); n++)
                {
                    if (matStr[n] != "")
                    {
                        switch (i)
                        {
                            case 0:
                                textBox_matrixX_x.Text = matStr[n];
                                i++;
                                break;
                            case 1:
                                textBox_matrixY_x.Text = matStr[n];
                                i++;
                                break;
                            case 2:
                                textBox_matrixZ_x.Text = matStr[n];
                                i++;
                                break;
                        }
                    }
                }
                matStr = values[12].Split(' ');
                i = 0;
                for (int n = 0; n < matStr.Count(); n++)
                {
                    if (matStr[n] != "")
                    {
                        switch (i)
                        {
                            case 0:
                                textBox_matrixX_y.Text = matStr[n];
                                i++;
                                break;
                            case 1:
                                textBox_matrixY_y.Text = matStr[n];
                                i++;
                                break;
                            case 2:
                                textBox_matrixZ_y.Text = matStr[n];
                                i++;
                                break;
                        }
                    }
                }
                matStr = values[14].Split(' ');
                i = 0;
                for (int n = 0; n < matStr.Count(); n++)
                {
                    if (matStr[n] != "")
                    {
                        switch (i)
                        {
                            case 0:
                                textBox_matrixX_z.Text = matStr[n];
                                i++;
                                break;
                            case 1:
                                textBox_matrixY_z.Text = matStr[n];
                                i++;
                                break;
                            case 2:
                                textBox_matrixZ_z.Text = matStr[n];
                                i++;
                                break;
                        }
                    }
                }
            }
            catch
            {
                textBox_matrixX_x.Clear();
                textBox_matrixX_y.Clear();
                textBox_matrixX_z.Clear();
                textBox_matrixY_x.Clear();
                textBox_matrixY_y.Clear();
                textBox_matrixY_z.Clear();
                textBox_matrixZ_x.Clear();
                textBox_matrixZ_y.Clear();
                textBox_matrixZ_z.Clear();
                textBox_biasX.Clear();
                textBox_biasY.Clear();
                textBox_biasZ.Clear();
            }
        }
        private void PlotCircles(bool raw)
        {
            double M11 = 1;
            double M12 = 0;
            double M13 = 0;

            double M21 = 0;
            double M22 = 1;
            double M23 = 0;

            double M31 = 0;
            double M32 = 0;
            double M33 = 1;

            double B1 = 0;
            double B2 = 0;
            double B3 = 0;

            if (!raw)
            {
                try
                {
                    M11 = Convert.ToSingle(textBox_matrixX_x.Text);
                    M12 = Convert.ToSingle(textBox_matrixY_x.Text);
                    M13 = Convert.ToSingle(textBox_matrixZ_x.Text);

                    M21 = Convert.ToSingle(textBox_matrixX_y.Text);
                    M22 = Convert.ToSingle(textBox_matrixY_y.Text);
                    M23 = Convert.ToSingle(textBox_matrixZ_y.Text);

                    M31 = Convert.ToSingle(textBox_matrixX_z.Text);
                    M32 = Convert.ToSingle(textBox_matrixY_z.Text);
                    M33 = Convert.ToSingle(textBox_matrixZ_z.Text);

                    B1 = Convert.ToSingle(textBox_biasX.Text);
                    B2 = Convert.ToSingle(textBox_biasY.Text);
                    B3 = Convert.ToSingle(textBox_biasZ.Text);
                }
                catch { }
            }

            double[,] CalData = new double[3, DataIndex];

            double X, Y, Z;
            for (int n = 0; n < DataIndex; n++)
            {
                X = M11 * (Data[0, n] - B1);
                X += M12 * (Data[1, n] - B1);
                X += M13 * (Data[2, n] - B1);

                Y = M21 * (Data[0, n] - B2);
                Y += M22 * (Data[1, n] - B2);
                Y += M23 * (Data[2, n] - B2);

                Z = M31 * (Data[0, n] - B3);
                Z += M32 * (Data[1, n] - B3);
                Z += M33 * (Data[2, n] - B3);

                CalData[0, n] = X;
                CalData[1, n] = Y;
                CalData[2, n] = Z;
                /*
                for (int i = 0; i < 3; i++)
                {
                    pap->Bi[i] = 0.0;
                    for (int j = 0; j < 3; j++)
                    {
                        pap->Bi[i] += pac->MagCalMat[i][j] * (par->Fi_G[j] - pac->MagOfs[i]);
                    }
                }
                */
            }

            FPen.Color = Color.Black;
            Graphics g = Graphics.FromImage(pictureBoxXY.Image);
            float X1 = 0;
            float X2 = pictureBoxXY.Width - 1;
            float Y1 = 0;
            float Y2 = pictureBoxXY.Height - 1;
            //erase last plot
            g.FillRectangle(Brushes.White, X1, Y1, X2 - X1, Y2 - Y1);
            g.DrawEllipse(FPen, X1, Y1, X2 - X1, Y2 - Y1);
            

            float scale = pictureBoxXY.Width / 2;
            float x1;
            float y1;
            float CenterX = pictureBoxXY.Width / 2;
            float CenterY = pictureBoxXY.Height / 2;

            FPen.Color = Color.Red;
            for (int n = 0; n < DataIndex; n++)
            {
                //XY
                x1 = scale * (float)CalData[0, n] + CenterX;
                y1 = -scale * (float)CalData[1, n] + CenterY;
                g.DrawEllipse(FPen, x1, y1, 3, 3);
            }
            FPen.Color = Color.Black;
            X1 = pictureBoxXY.Width / 4;
            X2 = X1 + (pictureBoxXY.Width / 2);
            Y1 = pictureBoxXY.Height / 4;
            Y2 = Y1 + (pictureBoxXY.Height / 2);
            g.DrawEllipse(FPen, X1, Y1, X2 - X1, Y2 - Y1);

            //XZ
            FPen.Color = Color.Black;
            g = Graphics.FromImage(pictureBoxXZ.Image);
            X1 = 0;
            X2 = pictureBoxXZ.Width - 1;
            Y1 = 0;
            Y2 = pictureBoxXZ.Height - 1;
            //erase last plot
            g.FillRectangle(Brushes.White, X1, Y1, X2 - X1, Y2 - Y1);
            g.DrawEllipse(FPen, X1, Y1, X2 - X1, Y2 - Y1);
            //g = Graphics.FromImage(pictureBoxXZ.Image);
            scale = pictureBoxXZ.Width / 2;
            CenterX = pictureBoxXZ.Width / 2;
            CenterY = pictureBoxXZ.Height / 2;

            FPen.Color = Color.Green;
            for (int n = 0; n < DataIndex; n++)
            {
                x1 = scale * (float)CalData[0, n] + CenterX;
                y1 = -scale * (float)CalData[2, n] + CenterY;
                g.DrawEllipse(FPen, x1, y1, 3, 3);
            }
            FPen.Color = Color.Black;
            X1 = pictureBoxXZ.Width / 4;
            X2 = X1 + (pictureBoxXZ.Width / 2);
            Y1 = pictureBoxXZ.Height / 4;
            Y2 = Y1 + (pictureBoxXZ.Height / 2);
            g.DrawEllipse(FPen, X1, Y1, X2 - X1, Y2 - Y1);

            //YZ
            FPen.Color = Color.Black;
            g = Graphics.FromImage(pictureBoxYZ.Image);
            X1 = 0;
            X2 = pictureBoxYZ.Width - 1;
            Y1 = 0;
            Y2 = pictureBoxYZ.Height - 1;
            //erase last plot
            g.FillRectangle(Brushes.White, X1, Y1, X2 - X1, Y2 - Y1);
            g.DrawEllipse(FPen, X1, Y1, X2 - X1, Y2 - Y1);
            scale = pictureBoxYZ.Width / 2;
            CenterX = pictureBoxYZ.Width / 2;
            CenterY = pictureBoxYZ.Height / 2;

            FPen.Color = Color.Blue;
            for (int n = 0; n < DataIndex; n++)
            {
                x1 = scale * (float)CalData[1, n] + CenterX;
                y1 = -scale * (float)CalData[2, n] + CenterY;
                g.DrawEllipse(FPen, x1, y1, 3, 3);
            }
            FPen.Color = Color.Black;
            X1 = pictureBoxYZ.Width / 4;
            X2 = X1 + (pictureBoxYZ.Width / 2);
            Y1 = pictureBoxYZ.Height / 4;
            Y2 = Y1 + (pictureBoxYZ.Height / 2);
            g.DrawEllipse(FPen, X1, Y1, X2 - X1, Y2 - Y1);

            pictureBoxXY.Refresh();
            pictureBoxXZ.Refresh();
            pictureBoxYZ.Refresh();
        }
        private void buttonCalcMatrix_Click(object sender, EventArgs e)
        {
            CalcMatrix(textBoxDataStatus.Text);

            //PlotCircles(false);
            buttonShowRawProcessed.Text = "Show Cal";
            buttonShowRawProcessed_Click(sender, e);

            buttonShowRawProcessed.Enabled = true;

            buttonSaveMatrix.Enabled = true;
        }
        private void buttonSaveMatrix_Click(object sender, EventArgs e)
        {
            buttonCalcMatrix.Enabled = false;
            buttonStartDataCollection.Enabled = false;
            buttonSaveMatrix.Enabled = false;
            buttonStopDataCollection.Enabled = false;

            if (serialPort1.IsOpen)
            {
                timer1.Enabled = false;
                TimerEnabled = false;
                //timer2.Enabled = false;
                timer3.Enabled = false;

                SendCom(serialPort1, "STOP");//stop adcp
                int count = 100;
                while (!string_from_usart.Contains("STOP"))
                {
                    count--;
                    if (count < 0)
                        break;
                    System.Threading.Thread.Sleep(100);
                    Application.DoEvents();
                }

                if (string_from_usart.Contains("STOP" + '\u0006'))
                {
                    string str = "ENGATT 3,";

                    str += textBox_matrixX_x.Text + ",";
                    str += textBox_matrixY_x.Text + ",";
                    str += textBox_matrixZ_x.Text + ",";

                    str += textBox_matrixX_y.Text + ",";
                    str += textBox_matrixY_y.Text + ",";
                    str += textBox_matrixZ_y.Text + ",";

                    str += textBox_matrixX_z.Text + ",";
                    str += textBox_matrixY_z.Text + ",";
                    str += textBox_matrixZ_z.Text + ",";

                    str += textBox_biasX.Text + ",";
                    str += textBox_biasY.Text + ",";
                    str += textBox_biasZ.Text;

                    SendCom(serialPort1, str);
                    System.Threading.Thread.Sleep(1000);
                    if (string_from_usart.Contains("ENGATT 3,") && string_from_usart.Contains('\u0006'))
                    {
                        SendCom(serialPort1, "ENGATT 9");
                        System.Threading.Thread.Sleep(1000);
                        if (!string_from_usart.Contains("result = 0"))
                        {
                            MessageBox.Show("ADCP NV Write Error", "Warning!");
                        }
                        else
                        {
                            //FileName = curDir + "\\" + "ATT_MAG_MATRIX_SN" + textBoxSN.Text + "_" + dtstr + ".txt";
                            //System.IO.File.WriteAllText(FileName, str);

                            string FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                            string DirName = FolderPath + "\\RTI\\FieldCompassCalibration";
                            string dtstr = DateTime.Now.ToString("yyyyMMddHHmmss");
                            string FileName = "ATT_MAG_MATRIX_SN" + textBoxSN.Text + "_" + dtstr + ".txt";                            

                            SaveTextFile(DirName, FileName, str, true, false);
                        }
                    }
                    else
                    {
                        MessageBox.Show("ADCP Magnetometer Matrix Write Error", "Warning!");
                    }
                }
                ADCPStarted = false;
                TimerEnabled = true;
            }
            else
            {
                MessageBox.Show("Port Disconnected", "Warning!");
            }
            buttonStartDataCollection.Enabled = true;
            timer1.Enabled = true;
            TimerEnabled = true;
        }
        //Help Files-------------------------------------------------------

        
        private void buttonADCPhelp_Click(object sender, EventArgs e)
        {
            dummy();
            string str = "";

            //str += "Baud Rate: " + serialPort1.BaudRate.ToString() + "\r\n\r\n";
            //str += "Data Bits: " + serialPort1.DataBits.ToString() + "\r\n\r\n";
            //str += "Stop Bits: " + serialPort1.StopBits.ToString() + "\r\n\r\n";
            //str += "Parity: " + serialPort1.Parity.ToString();

            str += " 1. Power Up ADCP.\r\n";
            str += " 2. Connect PC serial port to ADCP serial port.\r\n";
            str += " 3. If the Status box displays 'Connected' go to step 9.\r\n";
            str += " 4. Click 'Close Port'.\r\n";
            str += " 5. Select PC serial port Number and Baud rate.\r\n";
            str += " 6. Click 'Open Port'.\r\n";
            str += " 7. If the Status box displays 'Connected' go to step 9.\r\n";
            str += " 8. Go to step 4.\r\n";
            str += " 9. Ensure that the ADCP is located away from any metal stuctures that may distort the Earth's magnetic field.\r\n";
            str += "10. Ensure that there is plenty of room to move the ADCP around in various orientations.\r\n";
            str += "11. Click 'Start Cal' when ready to start collecting raw calibration data.\r\n";

            FieldCalibration.Help frm_op = new Help(ref str);
            frm_op.Text = "ADCP Serial Communications Help";
            frm_op.Owner = this;
            frm_op.ShowHelp(sender, e);
        }
        private void buttonRawFileHelp_Click(object sender, EventArgs e)
        {
            string str = "";
            str += "1. Select a Raw compass data file to read in.\r\n\r\n";
            str += "Notes:\r\n\r\n";
            str += "A. Normally the raw files are stored here:\r\n\r\n\t'Documents\\RTI\\FieldCompassCalibration'\r\n\r\n";
            FieldCalibration.Help frm_op = new Help(ref str);
            frm_op.Owner = this;
            frm_op.Text = "Raw Compass Data File Help";
            frm_op.ShowHelp(sender, e);
        }
        private void buttonStartCalHelp_Click(object sender, EventArgs e)
        {
            string str = "";
            str += " 1. Check that the ADCP Status Box, near the bottom right, indicates Connected.\r\n\r\n";
            str += " 2. Click 'Start Cal' to begin the compass calibration.\r\n\r\n";
            str += " 3. Pick up the ADCP and position it so that the transducer is pointing downward.\r\n\r\n";
            str += " 4. Roll the ADCP +- 90 degrees by tilting right and left.\r\n\r\n";
            str += " 5. At the same time, slowly rotate yourself and the ADCP around in a 360 degree circle.\r\n\r\n";
            str += " 6. After completing the circle, position the ADCP so that the transducer is facing horizontally away from you.\r\n\r\n";
            str += " 7. Roll the ADCP +- 90 degrees. Like a steering wheel.\r\n\r\n";
            str += " 8. At the same time, slowly rotate yourself and the ADCP around in a 360 degree circle.\r\n\r\n";
            str += " 9. After completing the circle, position the ADCP so that the transducer is facing upward.\r\n\r\n";
            str += "10. Roll the ADCP +- 90 degrees by tilting right and left.\r\n\r\n";
            str += "11. At the same time, slowly rotate yourself and the ADCP around in a 360 degree circle.\r\n\r\n";
            str += "12. After completing the 3rd circle click 'Stop Cal'.\r\n\r\n";
            str += "\r\n\r\n";
            str += "Notes:\r\n\r\n";
            str += "A. This button is enabled when the ADCP is Connected.\r\n\r\n";
            str += "B. The box above the 'Start Cal' button indicates the number of samples that have been collected.\r\n\r\n";
            str += "C. As long as the ADCP is continually being rotated/tilted in unique orientaions several thousand samples should be adequate.\r\n\r\n";
            str += "D. The number of samples is limited to 100,000.\r\n\r\n";

            FieldCalibration.Help frm_op = new Help(ref str);
            frm_op.Owner = this;
            frm_op.Text = "Start Calibration Help";
            frm_op.ShowHelp(sender, e);
        }
        private void buttonStopCalHelp_Click(object sender, EventArgs e)
        {
            string str = "";            
            str += "1. Click 'Stop Cal' when finished with the raw data collection.\r\n\r\n";
            str += "2. Click 'Calc Matrix' to generate the calibration matrix and offsets.\r\n\r\n";
            str += "Notes:\r\n\r\n";
            str += "A. This button is enabled after the 'Start Cal' button is clicked.\r\n\r\n";
            str += "B. The box above the 'Start Cal' button indicates the number of samples that have been collected.\r\n\r\n";
            str += "C. As long as the ADCP was continually being rotated/tilted in unique orientations several thousand samples should be adequate.\r\n\r\n";
            str += "D. 'Stop Cal' saves the raw data to a file located here:\r\n\r\n\t'Documents\\RTI\\FieldCompassCalibration'\r\n\r\n";
            str += "E. The raw data are saved in a text file. Depending on the number of samples it can take up to a minute to save all the raw data.\r\n\r\n";
            FieldCalibration.Help frm_op = new Help(ref str);
            frm_op.Owner = this;
            frm_op.Text = "Stop Calibration Help";
            frm_op.ShowHelp(sender, e);
        }
        private void buttonCalMatrixHelp_Click(object sender, EventArgs e)
        {
            string str = "";

            str += "1. Click 'Calc Matrix' to generate the calibration matrix and offsets.\r\n\r\n";
            str += "2. Click 'Save Matrix' to send the calulated values to the ADCP.\r\n\r\n";
            str += "Notes:\r\n\r\n";
            str += "A. The 'Calc Matrix' button is enabled after clicking 'Stop Cal' or selecting a saved raw data file.\r\n\r\n";
            str += "B. After clicking 'Calc Matrix' the 'Magnetometer Transformation Matrix' and the 'Magnetometer Bias' boxes will be filled in with the calculated values.\r\n\r\n";
            FieldCalibration.Help frm_op = new Help(ref str);
            frm_op.Owner = this;
            frm_op.Text = "Calculate Matrix Help";
            frm_op.ShowHelp(sender, e);
        }
        private void buttonSaveMatrixHelp_Click(object sender, EventArgs e)
        {
            string str = "";
            
            str += "1. Click 'Save Matrix' to send the calulated Matrix and Bias values to the ADCP.\r\n\r\n";
            str += "Notes:\r\n\r\n";
            str += "A. This button is enabled after the 'Calc Matrix' button is clicked.\r\n\r\n";
            str += "B. The ADCP saves the Matrix and the Bias values in a non-volatile location for use during normal compass operations.\r\n\r\n";
            FieldCalibration.Help frm_op = new Help(ref str);
            frm_op.Owner = this;
            frm_op.Text = "Save Matrix Help";
            frm_op.ShowHelp(sender, e);
        }
        private void buttonShowProcessedHelp_Click(object sender, EventArgs e)
        {
            string str = "1. Click 'Show Processed/Raw' button to toggle between the Processed and Raw data displays.\r\n\r\n";
            str += "Notes:\r\n\r\n";
            str += "A. This button is enabled after the 'Calc Matrix' button is clicked.\r\n\r\n";
            FieldCalibration.Help frm_op = new Help(ref str);
            frm_op.Owner = this;
            frm_op.Text = "Process/Raw Data Display Help";
            frm_op.ShowHelp(sender, e);
        }

        private void dummy()
        { 
        
        }

        //End
    }
}

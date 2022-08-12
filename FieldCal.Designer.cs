
namespace FieldCalibration
{
    partial class FieldCal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.MagnetometerDevice = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label45 = new System.Windows.Forms.Label();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.textBoxSN = new System.Windows.Forms.TextBox();
            this.buttonADCPHelp = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.Xlabel = new System.Windows.Forms.Label();
            this.Ylabel = new System.Windows.Forms.Label();
            this.Zlabel = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.labelAccX = new System.Windows.Forms.Label();
            this.labelAccY = new System.Windows.Forms.Label();
            this.labelAccZ = new System.Windows.Forms.Label();
            this.buttonStartDataCollection = new System.Windows.Forms.Button();
            this.buttonStopDataCollection = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.textBoxDataSamples = new System.Windows.Forms.TextBox();
            this.pictureBoxXY = new System.Windows.Forms.PictureBox();
            this.pictureBoxXZ = new System.Windows.Forms.PictureBox();
            this.pictureBoxYZ = new System.Windows.Forms.PictureBox();
            this.buttonCalcMatrix = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.buttonSaveMatrix = new System.Windows.Forms.Button();
            this.textBoxDataStatus = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_matrixZ_z = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_matrixZ_y = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_matrixZ_x = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_matrixY_z = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_matrixY_y = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_matrixY_x = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_matrixX_z = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_matrixX_y = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_matrixX_x = new System.Windows.Forms.TextBox();
            this.textBox_biasX = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox_biasY = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox_biasZ = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.buttonReadRawFile = new System.Windows.Forms.Button();
            this.buttonShowRawProcessed = new System.Windows.Forms.Button();
            this.buttonRawFileHelp = new System.Windows.Forms.Button();
            this.buttonCalMatrixHelp = new System.Windows.Forms.Button();
            this.buttonStopCalHelp = new System.Windows.Forms.Button();
            this.buttonStartCalHelp = new System.Windows.Forms.Button();
            this.buttonSaveMatrixHelp = new System.Windows.Forms.Button();
            this.buttonShowProcessedHelp = new System.Windows.Forms.Button();
            this.MagnetometerDevice.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxXY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxXZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxYZ)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MagnetometerDevice
            // 
            this.MagnetometerDevice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MagnetometerDevice.Controls.Add(this.comboBox1);
            this.MagnetometerDevice.Controls.Add(this.comboBox2);
            this.MagnetometerDevice.Controls.Add(this.label45);
            this.MagnetometerDevice.Controls.Add(this.buttonOpen);
            this.MagnetometerDevice.Controls.Add(this.button2);
            this.MagnetometerDevice.Controls.Add(this.button1);
            this.MagnetometerDevice.Controls.Add(this.textBoxStatus);
            this.MagnetometerDevice.Controls.Add(this.label44);
            this.MagnetometerDevice.Controls.Add(this.textBoxSN);
            this.MagnetometerDevice.Controls.Add(this.buttonADCPHelp);
            this.MagnetometerDevice.Controls.Add(this.buttonClose);
            this.MagnetometerDevice.Location = new System.Drawing.Point(12, 677);
            this.MagnetometerDevice.Name = "MagnetometerDevice";
            this.MagnetometerDevice.Size = new System.Drawing.Size(648, 53);
            this.MagnetometerDevice.TabIndex = 1;
            this.MagnetometerDevice.TabStop = false;
            this.MagnetometerDevice.Text = "ADCP Serial Port";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(70, 21);
            this.comboBox1.TabIndex = 9;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "921600",
            "460800",
            "230400",
            "115200",
            " 57600",
            " 38400",
            " 19200",
            "  9600",
            "  4800",
            "  2400"});
            this.comboBox2.Location = new System.Drawing.Point(82, 19);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(70, 21);
            this.comboBox2.TabIndex = 604;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(463, 24);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(40, 13);
            this.label45.TabIndex = 603;
            this.label45.Text = "Status:";
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(158, 17);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(68, 23);
            this.buttonOpen.TabIndex = 1;
            this.buttonOpen.Text = "Open Port";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(447, 32);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(10, 10);
            this.button2.TabIndex = 602;
            this.button2.TabStop = false;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(447, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(10, 10);
            this.button1.TabIndex = 601;
            this.button1.TabStop = false;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxStatus.Location = new System.Drawing.Point(509, 22);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ReadOnly = true;
            this.textBoxStatus.Size = new System.Drawing.Size(133, 20);
            this.textBoxStatus.TabIndex = 34;
            this.textBoxStatus.TabStop = false;
            this.textBoxStatus.Text = "Disconnected";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(356, 24);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(25, 13);
            this.label44.TabIndex = 33;
            this.label44.Text = "SN:";
            // 
            // textBoxSN
            // 
            this.textBoxSN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSN.Location = new System.Drawing.Point(387, 22);
            this.textBoxSN.Name = "textBoxSN";
            this.textBoxSN.ReadOnly = true;
            this.textBoxSN.Size = new System.Drawing.Size(54, 20);
            this.textBoxSN.TabIndex = 32;
            this.textBoxSN.TabStop = false;
            this.textBoxSN.Text = "NA";
            // 
            // buttonADCPHelp
            // 
            this.buttonADCPHelp.Location = new System.Drawing.Point(326, 17);
            this.buttonADCPHelp.Name = "buttonADCPHelp";
            this.buttonADCPHelp.Size = new System.Drawing.Size(24, 23);
            this.buttonADCPHelp.TabIndex = 3;
            this.buttonADCPHelp.Text = "?";
            this.buttonADCPHelp.UseVisualStyleBackColor = true;
            this.buttonADCPHelp.Click += new System.EventHandler(this.buttonADCPhelp_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(232, 17);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(88, 23);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "Close Port";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.Xlabel);
            this.groupBox4.Controls.Add(this.Ylabel);
            this.groupBox4.Controls.Add(this.Zlabel);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(326, 50);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Magnetometer(G)";
            // 
            // Xlabel
            // 
            this.Xlabel.BackColor = System.Drawing.Color.Black;
            this.Xlabel.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Xlabel.ForeColor = System.Drawing.Color.Lime;
            this.Xlabel.Location = new System.Drawing.Point(6, 16);
            this.Xlabel.Name = "Xlabel";
            this.Xlabel.Size = new System.Drawing.Size(100, 23);
            this.Xlabel.TabIndex = 0;
            this.Xlabel.Text = "X = 0.0000";
            this.Xlabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Ylabel
            // 
            this.Ylabel.BackColor = System.Drawing.Color.Black;
            this.Ylabel.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Ylabel.ForeColor = System.Drawing.Color.Lime;
            this.Ylabel.Location = new System.Drawing.Point(112, 16);
            this.Ylabel.Name = "Ylabel";
            this.Ylabel.Size = new System.Drawing.Size(100, 23);
            this.Ylabel.TabIndex = 0;
            this.Ylabel.Text = "Y = 0.0000";
            this.Ylabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Zlabel
            // 
            this.Zlabel.BackColor = System.Drawing.Color.Black;
            this.Zlabel.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Zlabel.ForeColor = System.Drawing.Color.Lime;
            this.Zlabel.Location = new System.Drawing.Point(218, 16);
            this.Zlabel.Name = "Zlabel";
            this.Zlabel.Size = new System.Drawing.Size(100, 23);
            this.Zlabel.TabIndex = 0;
            this.Zlabel.Text = "Z = 0.0000";
            this.Zlabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.labelAccX);
            this.groupBox5.Controls.Add(this.labelAccY);
            this.groupBox5.Controls.Add(this.labelAccZ);
            this.groupBox5.Location = new System.Drawing.Point(344, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(326, 50);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Accelerometer(g)";
            // 
            // labelAccX
            // 
            this.labelAccX.BackColor = System.Drawing.Color.Black;
            this.labelAccX.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAccX.ForeColor = System.Drawing.Color.Lime;
            this.labelAccX.Location = new System.Drawing.Point(6, 16);
            this.labelAccX.Name = "labelAccX";
            this.labelAccX.Size = new System.Drawing.Size(100, 23);
            this.labelAccX.TabIndex = 0;
            this.labelAccX.Text = "X = 0.0000";
            this.labelAccX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelAccY
            // 
            this.labelAccY.BackColor = System.Drawing.Color.Black;
            this.labelAccY.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAccY.ForeColor = System.Drawing.Color.Lime;
            this.labelAccY.Location = new System.Drawing.Point(112, 16);
            this.labelAccY.Name = "labelAccY";
            this.labelAccY.Size = new System.Drawing.Size(100, 23);
            this.labelAccY.TabIndex = 0;
            this.labelAccY.Text = "Y = 0.0000";
            this.labelAccY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelAccZ
            // 
            this.labelAccZ.BackColor = System.Drawing.Color.Black;
            this.labelAccZ.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAccZ.ForeColor = System.Drawing.Color.Lime;
            this.labelAccZ.Location = new System.Drawing.Point(218, 16);
            this.labelAccZ.Name = "labelAccZ";
            this.labelAccZ.Size = new System.Drawing.Size(100, 23);
            this.labelAccZ.TabIndex = 0;
            this.labelAccZ.Text = "Z = 0.0000";
            this.labelAccZ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonStartDataCollection
            // 
            this.buttonStartDataCollection.Location = new System.Drawing.Point(12, 94);
            this.buttonStartDataCollection.Name = "buttonStartDataCollection";
            this.buttonStartDataCollection.Size = new System.Drawing.Size(76, 23);
            this.buttonStartDataCollection.TabIndex = 9;
            this.buttonStartDataCollection.Text = "Start Cal";
            this.buttonStartDataCollection.UseVisualStyleBackColor = true;
            this.buttonStartDataCollection.Click += new System.EventHandler(this.buttonStartDataCollection_Click);
            // 
            // buttonStopDataCollection
            // 
            this.buttonStopDataCollection.Location = new System.Drawing.Point(12, 123);
            this.buttonStopDataCollection.Name = "buttonStopDataCollection";
            this.buttonStopDataCollection.Size = new System.Drawing.Size(76, 23);
            this.buttonStopDataCollection.TabIndex = 10;
            this.buttonStopDataCollection.Text = "Stop Cal";
            this.buttonStopDataCollection.UseVisualStyleBackColor = true;
            this.buttonStopDataCollection.Click += new System.EventHandler(this.buttonStopDataCollection_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.Location = new System.Drawing.Point(6, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(673, 148);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // textBoxDataSamples
            // 
            this.textBoxDataSamples.Location = new System.Drawing.Point(12, 68);
            this.textBoxDataSamples.Name = "textBoxDataSamples";
            this.textBoxDataSamples.ReadOnly = true;
            this.textBoxDataSamples.Size = new System.Drawing.Size(106, 20);
            this.textBoxDataSamples.TabIndex = 12;
            this.textBoxDataSamples.TabStop = false;
            this.textBoxDataSamples.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pictureBoxXY
            // 
            this.pictureBoxXY.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxXY.Location = new System.Drawing.Point(6, 19);
            this.pictureBoxXY.Name = "pictureBoxXY";
            this.pictureBoxXY.Size = new System.Drawing.Size(200, 200);
            this.pictureBoxXY.TabIndex = 13;
            this.pictureBoxXY.TabStop = false;
            // 
            // pictureBoxXZ
            // 
            this.pictureBoxXZ.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxXZ.Location = new System.Drawing.Point(6, 18);
            this.pictureBoxXZ.Name = "pictureBoxXZ";
            this.pictureBoxXZ.Size = new System.Drawing.Size(200, 200);
            this.pictureBoxXZ.TabIndex = 14;
            this.pictureBoxXZ.TabStop = false;
            // 
            // pictureBoxYZ
            // 
            this.pictureBoxYZ.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxYZ.Location = new System.Drawing.Point(6, 19);
            this.pictureBoxYZ.Name = "pictureBoxYZ";
            this.pictureBoxYZ.Size = new System.Drawing.Size(200, 200);
            this.pictureBoxYZ.TabIndex = 15;
            this.pictureBoxYZ.TabStop = false;
            // 
            // buttonCalcMatrix
            // 
            this.buttonCalcMatrix.Location = new System.Drawing.Point(12, 152);
            this.buttonCalcMatrix.Name = "buttonCalcMatrix";
            this.buttonCalcMatrix.Size = new System.Drawing.Size(76, 23);
            this.buttonCalcMatrix.TabIndex = 16;
            this.buttonCalcMatrix.Text = "Calc Matrix";
            this.buttonCalcMatrix.UseVisualStyleBackColor = true;
            this.buttonCalcMatrix.Click += new System.EventHandler(this.buttonCalcMatrix_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBoxXY);
            this.groupBox1.Location = new System.Drawing.Point(12, 236);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(212, 230);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Raw MagXY(G)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBoxXZ);
            this.groupBox2.Location = new System.Drawing.Point(230, 236);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(212, 230);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Raw MagXZ(G)";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pictureBoxYZ);
            this.groupBox3.Location = new System.Drawing.Point(448, 236);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(212, 230);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Raw MagYZ(G)";
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.pictureBox1);
            this.groupBox6.Location = new System.Drawing.Point(12, 494);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(685, 177);
            this.groupBox6.TabIndex = 20;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Time Series";
            // 
            // buttonSaveMatrix
            // 
            this.buttonSaveMatrix.Location = new System.Drawing.Point(12, 181);
            this.buttonSaveMatrix.Name = "buttonSaveMatrix";
            this.buttonSaveMatrix.Size = new System.Drawing.Size(76, 23);
            this.buttonSaveMatrix.TabIndex = 21;
            this.buttonSaveMatrix.Text = "Save Matrix";
            this.buttonSaveMatrix.UseVisualStyleBackColor = true;
            this.buttonSaveMatrix.Click += new System.EventHandler(this.buttonSaveMatrix_Click);
            // 
            // textBoxDataStatus
            // 
            this.textBoxDataStatus.Location = new System.Drawing.Point(12, 210);
            this.textBoxDataStatus.Name = "textBoxDataStatus";
            this.textBoxDataStatus.ReadOnly = true;
            this.textBoxDataStatus.Size = new System.Drawing.Size(648, 20);
            this.textBoxDataStatus.TabIndex = 25;
            this.textBoxDataStatus.TabStop = false;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label9);
            this.groupBox7.Controls.Add(this.textBox_matrixZ_z);
            this.groupBox7.Controls.Add(this.label8);
            this.groupBox7.Controls.Add(this.textBox_matrixZ_y);
            this.groupBox7.Controls.Add(this.label7);
            this.groupBox7.Controls.Add(this.textBox_matrixZ_x);
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Controls.Add(this.textBox_matrixY_z);
            this.groupBox7.Controls.Add(this.label5);
            this.groupBox7.Controls.Add(this.textBox_matrixY_y);
            this.groupBox7.Controls.Add(this.label4);
            this.groupBox7.Controls.Add(this.textBox_matrixY_x);
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Controls.Add(this.textBox_matrixX_z);
            this.groupBox7.Controls.Add(this.label2);
            this.groupBox7.Controls.Add(this.textBox_matrixX_y);
            this.groupBox7.Controls.Add(this.label1);
            this.groupBox7.Controls.Add(this.textBox_matrixX_x);
            this.groupBox7.Location = new System.Drawing.Point(124, 68);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(393, 97);
            this.groupBox7.TabIndex = 27;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Magnetometer Transformation Matrix";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(260, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 40;
            this.label9.Text = "M33 =";
            // 
            // textBox_matrixZ_z
            // 
            this.textBox_matrixZ_z.Location = new System.Drawing.Point(301, 71);
            this.textBox_matrixZ_z.Name = "textBox_matrixZ_z";
            this.textBox_matrixZ_z.ReadOnly = true;
            this.textBox_matrixZ_z.Size = new System.Drawing.Size(80, 20);
            this.textBox_matrixZ_z.TabIndex = 39;
            this.textBox_matrixZ_z.TabStop = false;
            this.textBox_matrixZ_z.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(260, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 38;
            this.label8.Text = "M23 =";
            // 
            // textBox_matrixZ_y
            // 
            this.textBox_matrixZ_y.Location = new System.Drawing.Point(301, 45);
            this.textBox_matrixZ_y.Name = "textBox_matrixZ_y";
            this.textBox_matrixZ_y.ReadOnly = true;
            this.textBox_matrixZ_y.Size = new System.Drawing.Size(80, 20);
            this.textBox_matrixZ_y.TabIndex = 37;
            this.textBox_matrixZ_y.TabStop = false;
            this.textBox_matrixZ_y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(260, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "M13 =";
            // 
            // textBox_matrixZ_x
            // 
            this.textBox_matrixZ_x.Location = new System.Drawing.Point(301, 19);
            this.textBox_matrixZ_x.Name = "textBox_matrixZ_x";
            this.textBox_matrixZ_x.ReadOnly = true;
            this.textBox_matrixZ_x.Size = new System.Drawing.Size(80, 20);
            this.textBox_matrixZ_x.TabIndex = 35;
            this.textBox_matrixZ_x.TabStop = false;
            this.textBox_matrixZ_x.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(133, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "M32 =";
            // 
            // textBox_matrixY_z
            // 
            this.textBox_matrixY_z.Location = new System.Drawing.Point(174, 71);
            this.textBox_matrixY_z.Name = "textBox_matrixY_z";
            this.textBox_matrixY_z.ReadOnly = true;
            this.textBox_matrixY_z.Size = new System.Drawing.Size(80, 20);
            this.textBox_matrixY_z.TabIndex = 33;
            this.textBox_matrixY_z.TabStop = false;
            this.textBox_matrixY_z.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(133, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "M22 =";
            // 
            // textBox_matrixY_y
            // 
            this.textBox_matrixY_y.Location = new System.Drawing.Point(174, 45);
            this.textBox_matrixY_y.Name = "textBox_matrixY_y";
            this.textBox_matrixY_y.ReadOnly = true;
            this.textBox_matrixY_y.Size = new System.Drawing.Size(80, 20);
            this.textBox_matrixY_y.TabIndex = 31;
            this.textBox_matrixY_y.TabStop = false;
            this.textBox_matrixY_y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(133, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "M12 =";
            // 
            // textBox_matrixY_x
            // 
            this.textBox_matrixY_x.Location = new System.Drawing.Point(174, 19);
            this.textBox_matrixY_x.Name = "textBox_matrixY_x";
            this.textBox_matrixY_x.ReadOnly = true;
            this.textBox_matrixY_x.Size = new System.Drawing.Size(80, 20);
            this.textBox_matrixY_x.TabIndex = 29;
            this.textBox_matrixY_x.TabStop = false;
            this.textBox_matrixY_x.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "M31 =";
            // 
            // textBox_matrixX_z
            // 
            this.textBox_matrixX_z.Location = new System.Drawing.Point(47, 71);
            this.textBox_matrixX_z.Name = "textBox_matrixX_z";
            this.textBox_matrixX_z.ReadOnly = true;
            this.textBox_matrixX_z.Size = new System.Drawing.Size(80, 20);
            this.textBox_matrixX_z.TabIndex = 27;
            this.textBox_matrixX_z.TabStop = false;
            this.textBox_matrixX_z.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "M21 =";
            // 
            // textBox_matrixX_y
            // 
            this.textBox_matrixX_y.Location = new System.Drawing.Point(47, 45);
            this.textBox_matrixX_y.Name = "textBox_matrixX_y";
            this.textBox_matrixX_y.ReadOnly = true;
            this.textBox_matrixX_y.Size = new System.Drawing.Size(80, 20);
            this.textBox_matrixX_y.TabIndex = 25;
            this.textBox_matrixX_y.TabStop = false;
            this.textBox_matrixX_y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "M11 =";
            // 
            // textBox_matrixX_x
            // 
            this.textBox_matrixX_x.Location = new System.Drawing.Point(47, 19);
            this.textBox_matrixX_x.Name = "textBox_matrixX_x";
            this.textBox_matrixX_x.ReadOnly = true;
            this.textBox_matrixX_x.Size = new System.Drawing.Size(80, 20);
            this.textBox_matrixX_x.TabIndex = 23;
            this.textBox_matrixX_x.TabStop = false;
            this.textBox_matrixX_x.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_biasX
            // 
            this.textBox_biasX.Location = new System.Drawing.Point(47, 19);
            this.textBox_biasX.Name = "textBox_biasX";
            this.textBox_biasX.ReadOnly = true;
            this.textBox_biasX.Size = new System.Drawing.Size(80, 20);
            this.textBox_biasX.TabIndex = 23;
            this.textBox_biasX.TabStop = false;
            this.textBox_biasX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 22);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(28, 13);
            this.label18.TabIndex = 24;
            this.label18.Text = "Bx =";
            // 
            // textBox_biasY
            // 
            this.textBox_biasY.Location = new System.Drawing.Point(47, 45);
            this.textBox_biasY.Name = "textBox_biasY";
            this.textBox_biasY.ReadOnly = true;
            this.textBox_biasY.Size = new System.Drawing.Size(80, 20);
            this.textBox_biasY.TabIndex = 25;
            this.textBox_biasY.TabStop = false;
            this.textBox_biasY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 48);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(28, 13);
            this.label17.TabIndex = 26;
            this.label17.Text = "By =";
            // 
            // textBox_biasZ
            // 
            this.textBox_biasZ.Location = new System.Drawing.Point(47, 71);
            this.textBox_biasZ.Name = "textBox_biasZ";
            this.textBox_biasZ.ReadOnly = true;
            this.textBox_biasZ.Size = new System.Drawing.Size(80, 20);
            this.textBox_biasZ.TabIndex = 27;
            this.textBox_biasZ.TabStop = false;
            this.textBox_biasZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 74);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(28, 13);
            this.label16.TabIndex = 28;
            this.label16.Text = "Bz =";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label16);
            this.groupBox8.Controls.Add(this.textBox_biasZ);
            this.groupBox8.Controls.Add(this.label17);
            this.groupBox8.Controls.Add(this.textBox_biasY);
            this.groupBox8.Controls.Add(this.label18);
            this.groupBox8.Controls.Add(this.textBox_biasX);
            this.groupBox8.Location = new System.Drawing.Point(523, 68);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(147, 97);
            this.groupBox8.TabIndex = 28;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Magnetometer Bias";
            // 
            // buttonReadRawFile
            // 
            this.buttonReadRawFile.Location = new System.Drawing.Point(182, 181);
            this.buttonReadRawFile.Name = "buttonReadRawFile";
            this.buttonReadRawFile.Size = new System.Drawing.Size(102, 23);
            this.buttonReadRawFile.TabIndex = 29;
            this.buttonReadRawFile.Text = "Read Raw File";
            this.buttonReadRawFile.UseVisualStyleBackColor = true;
            this.buttonReadRawFile.Click += new System.EventHandler(this.buttonReadRawFile_Click);
            // 
            // buttonShowRawProcessed
            // 
            this.buttonShowRawProcessed.Location = new System.Drawing.Point(290, 472);
            this.buttonShowRawProcessed.Name = "buttonShowRawProcessed";
            this.buttonShowRawProcessed.Size = new System.Drawing.Size(102, 23);
            this.buttonShowRawProcessed.TabIndex = 30;
            this.buttonShowRawProcessed.Text = "Show Processed";
            this.buttonShowRawProcessed.UseVisualStyleBackColor = true;
            this.buttonShowRawProcessed.Click += new System.EventHandler(this.buttonShowRawProcessed_Click);
            // 
            // buttonRawFileHelp
            // 
            this.buttonRawFileHelp.Location = new System.Drawing.Point(290, 181);
            this.buttonRawFileHelp.Name = "buttonRawFileHelp";
            this.buttonRawFileHelp.Size = new System.Drawing.Size(24, 23);
            this.buttonRawFileHelp.TabIndex = 31;
            this.buttonRawFileHelp.Text = "?";
            this.buttonRawFileHelp.UseVisualStyleBackColor = true;
            this.buttonRawFileHelp.Click += new System.EventHandler(this.buttonRawFileHelp_Click);
            // 
            // buttonCalMatrixHelp
            // 
            this.buttonCalMatrixHelp.Location = new System.Drawing.Point(94, 152);
            this.buttonCalMatrixHelp.Name = "buttonCalMatrixHelp";
            this.buttonCalMatrixHelp.Size = new System.Drawing.Size(24, 23);
            this.buttonCalMatrixHelp.TabIndex = 32;
            this.buttonCalMatrixHelp.Text = "?";
            this.buttonCalMatrixHelp.UseVisualStyleBackColor = true;
            this.buttonCalMatrixHelp.Click += new System.EventHandler(this.buttonCalMatrixHelp_Click);
            // 
            // buttonStopCalHelp
            // 
            this.buttonStopCalHelp.Location = new System.Drawing.Point(94, 123);
            this.buttonStopCalHelp.Name = "buttonStopCalHelp";
            this.buttonStopCalHelp.Size = new System.Drawing.Size(24, 23);
            this.buttonStopCalHelp.TabIndex = 33;
            this.buttonStopCalHelp.Text = "?";
            this.buttonStopCalHelp.UseVisualStyleBackColor = true;
            this.buttonStopCalHelp.Click += new System.EventHandler(this.buttonStopCalHelp_Click);
            // 
            // buttonStartCalHelp
            // 
            this.buttonStartCalHelp.Location = new System.Drawing.Point(94, 94);
            this.buttonStartCalHelp.Name = "buttonStartCalHelp";
            this.buttonStartCalHelp.Size = new System.Drawing.Size(24, 23);
            this.buttonStartCalHelp.TabIndex = 34;
            this.buttonStartCalHelp.Text = "?";
            this.buttonStartCalHelp.UseVisualStyleBackColor = true;
            this.buttonStartCalHelp.Click += new System.EventHandler(this.buttonStartCalHelp_Click);
            // 
            // buttonSaveMatrixHelp
            // 
            this.buttonSaveMatrixHelp.Location = new System.Drawing.Point(94, 181);
            this.buttonSaveMatrixHelp.Name = "buttonSaveMatrixHelp";
            this.buttonSaveMatrixHelp.Size = new System.Drawing.Size(24, 23);
            this.buttonSaveMatrixHelp.TabIndex = 35;
            this.buttonSaveMatrixHelp.Text = "?";
            this.buttonSaveMatrixHelp.UseVisualStyleBackColor = true;
            this.buttonSaveMatrixHelp.Click += new System.EventHandler(this.buttonSaveMatrixHelp_Click);
            // 
            // buttonShowProcessedHelp
            // 
            this.buttonShowProcessedHelp.Location = new System.Drawing.Point(398, 472);
            this.buttonShowProcessedHelp.Name = "buttonShowProcessedHelp";
            this.buttonShowProcessedHelp.Size = new System.Drawing.Size(24, 23);
            this.buttonShowProcessedHelp.TabIndex = 36;
            this.buttonShowProcessedHelp.Text = "?";
            this.buttonShowProcessedHelp.UseVisualStyleBackColor = true;
            this.buttonShowProcessedHelp.Click += new System.EventHandler(this.buttonShowProcessedHelp_Click);
            // 
            // FieldCal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 731);
            this.Controls.Add(this.buttonShowProcessedHelp);
            this.Controls.Add(this.buttonSaveMatrixHelp);
            this.Controls.Add(this.buttonStartCalHelp);
            this.Controls.Add(this.buttonStopCalHelp);
            this.Controls.Add(this.buttonCalMatrixHelp);
            this.Controls.Add(this.buttonRawFileHelp);
            this.Controls.Add(this.buttonShowRawProcessed);
            this.Controls.Add(this.buttonReadRawFile);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.textBoxDataStatus);
            this.Controls.Add(this.buttonSaveMatrix);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonCalcMatrix);
            this.Controls.Add(this.textBoxDataSamples);
            this.Controls.Add(this.buttonStopDataCollection);
            this.Controls.Add(this.buttonStartDataCollection);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.MagnetometerDevice);
            this.Name = "FieldCal";
            this.Text = "Field Calibration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FieldCal_FormClosing);
            this.Load += new System.EventHandler(this.FieldCal_Load);
            this.MagnetometerDevice.ResumeLayout(false);
            this.MagnetometerDevice.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxXY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxXZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxYZ)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox MagnetometerDevice;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.TextBox textBoxSN;
        private System.Windows.Forms.Button buttonADCPHelp;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label Xlabel;
        private System.Windows.Forms.Label Ylabel;
        private System.Windows.Forms.Label Zlabel;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label labelAccX;
        private System.Windows.Forms.Label labelAccY;
        private System.Windows.Forms.Label labelAccZ;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button buttonStartDataCollection;
        private System.Windows.Forms.Button buttonStopDataCollection;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.TextBox textBoxDataSamples;
        private System.Windows.Forms.PictureBox pictureBoxXY;
        private System.Windows.Forms.PictureBox pictureBoxXZ;
        private System.Windows.Forms.PictureBox pictureBoxYZ;
        private System.Windows.Forms.Button buttonCalcMatrix;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button buttonSaveMatrix;
        private System.Windows.Forms.TextBox textBoxDataStatus;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_matrixZ_z;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_matrixZ_y;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_matrixZ_x;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_matrixY_z;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_matrixY_y;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_matrixY_x;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_matrixX_z;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_matrixX_y;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_matrixX_x;
        private System.Windows.Forms.TextBox textBox_biasX;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBox_biasY;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBox_biasZ;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button buttonReadRawFile;
        private System.Windows.Forms.Button buttonShowRawProcessed;
        private System.Windows.Forms.Button buttonRawFileHelp;
        private System.Windows.Forms.Button buttonCalMatrixHelp;
        private System.Windows.Forms.Button buttonStopCalHelp;
        private System.Windows.Forms.Button buttonStartCalHelp;
        private System.Windows.Forms.Button buttonSaveMatrixHelp;
        private System.Windows.Forms.Button buttonShowProcessedHelp;
    }
}


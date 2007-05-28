namespace OptimusUI.Forms
{
  partial class Settings
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
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabGeneral = new System.Windows.Forms.TabPage();
      this.label16 = new System.Windows.Forms.Label();
      this.label15 = new System.Windows.Forms.Label();
      this.trackBar1 = new System.Windows.Forms.TrackBar();
      this.labelIdleDescription = new System.Windows.Forms.Label();
      this.labelIdle = new System.Windows.Forms.Label();
      this.pictureIdle = new System.Windows.Forms.PictureBox();
      this.checkBox2 = new System.Windows.Forms.CheckBox();
      this.checkBox1 = new System.Windows.Forms.CheckBox();
      this.label4 = new System.Windows.Forms.Label();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.tabDevice = new System.Windows.Forms.TabPage();
      this.label18 = new System.Windows.Forms.Label();
      this.label17 = new System.Windows.Forms.Label();
      this.label14 = new System.Windows.Forms.Label();
      this.trackBar3 = new System.Windows.Forms.TrackBar();
      this.radioButton7 = new System.Windows.Forms.RadioButton();
      this.radioButton6 = new System.Windows.Forms.RadioButton();
      this.radioButton5 = new System.Windows.Forms.RadioButton();
      this.radioButton4 = new System.Windows.Forms.RadioButton();
      this.radioButton3 = new System.Windows.Forms.RadioButton();
      this.radioButton2 = new System.Windows.Forms.RadioButton();
      this.radioButton1 = new System.Windows.Forms.RadioButton();
      this.label3 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.pictureBox3 = new System.Windows.Forms.PictureBox();
      this.labelContrastDescription = new System.Windows.Forms.Label();
      this.labelContrast = new System.Windows.Forms.Label();
      this.pictureContrast = new System.Windows.Forms.PictureBox();
      this.tabPlugins = new System.Windows.Forms.TabPage();
      this.label12 = new System.Windows.Forms.Label();
      this.label13 = new System.Windows.Forms.Label();
      this.label10 = new System.Windows.Forms.Label();
      this.label11 = new System.Windows.Forms.Label();
      this.labelBackgroundColor = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.pictureBox4 = new System.Windows.Forms.PictureBox();
      this.label6 = new System.Windows.Forms.Label();
      this.checkBox3 = new System.Windows.Forms.CheckBox();
      this.trackBar2 = new System.Windows.Forms.TrackBar();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.pictureBox2 = new System.Windows.Forms.PictureBox();
      this.buttonOk = new System.Windows.Forms.Button();
      this.buttonCancel = new System.Windows.Forms.Button();
      this.tabControl1.SuspendLayout();
      this.tabGeneral.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureIdle)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.tabDevice.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureContrast)).BeginInit();
      this.tabPlugins.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
      this.SuspendLayout();
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tabGeneral);
      this.tabControl1.Controls.Add(this.tabDevice);
      this.tabControl1.Controls.Add(this.tabPlugins);
      this.tabControl1.Location = new System.Drawing.Point(7, 7);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(380, 282);
      this.tabControl1.TabIndex = 0;
      // 
      // tabGeneral
      // 
      this.tabGeneral.Controls.Add(this.label16);
      this.tabGeneral.Controls.Add(this.label15);
      this.tabGeneral.Controls.Add(this.trackBar1);
      this.tabGeneral.Controls.Add(this.labelIdleDescription);
      this.tabGeneral.Controls.Add(this.labelIdle);
      this.tabGeneral.Controls.Add(this.pictureIdle);
      this.tabGeneral.Controls.Add(this.checkBox2);
      this.tabGeneral.Controls.Add(this.checkBox1);
      this.tabGeneral.Controls.Add(this.label4);
      this.tabGeneral.Controls.Add(this.pictureBox1);
      this.tabGeneral.Location = new System.Drawing.Point(4, 22);
      this.tabGeneral.Name = "tabGeneral";
      this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
      this.tabGeneral.Size = new System.Drawing.Size(372, 256);
      this.tabGeneral.TabIndex = 0;
      this.tabGeneral.Text = "General";
      this.tabGeneral.UseVisualStyleBackColor = true;
      // 
      // label16
      // 
      this.label16.AutoSize = true;
      this.label16.Location = new System.Drawing.Point(184, 156);
      this.label16.Name = "label16";
      this.label16.Size = new System.Drawing.Size(64, 13);
      this.label16.TabIndex = 18;
      this.label16.Text = "{0} seconds";
      // 
      // label15
      // 
      this.label15.AutoSize = true;
      this.label15.Location = new System.Drawing.Point(3, 156);
      this.label15.Name = "label15";
      this.label15.Size = new System.Drawing.Size(49, 13);
      this.label15.TabIndex = 17;
      this.label15.Text = "Idle time:";
      // 
      // trackBar1
      // 
      this.trackBar1.AutoSize = false;
      this.trackBar1.Location = new System.Drawing.Point(58, 152);
      this.trackBar1.Name = "trackBar1";
      this.trackBar1.Size = new System.Drawing.Size(120, 20);
      this.trackBar1.TabIndex = 16;
      // 
      // labelIdleDescription
      // 
      this.labelIdleDescription.AutoSize = true;
      this.labelIdleDescription.Location = new System.Drawing.Point(3, 136);
      this.labelIdleDescription.Name = "labelIdleDescription";
      this.labelIdleDescription.Size = new System.Drawing.Size(312, 13);
      this.labelIdleDescription.TabIndex = 15;
      this.labelIdleDescription.Text = "Specify when to turn off the device when there\'s no user activity.";
      // 
      // labelIdle
      // 
      this.labelIdle.AutoSize = true;
      this.labelIdle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelIdle.Location = new System.Drawing.Point(28, 115);
      this.labelIdle.Name = "labelIdle";
      this.labelIdle.Size = new System.Drawing.Size(28, 13);
      this.labelIdle.TabIndex = 14;
      this.labelIdle.Text = "Idle";
      // 
      // pictureIdle
      // 
      this.pictureIdle.Image = global::OptimusUI.Properties.Resources.hourglass;
      this.pictureIdle.Location = new System.Drawing.Point(6, 112);
      this.pictureIdle.Name = "pictureIdle";
      this.pictureIdle.Size = new System.Drawing.Size(16, 16);
      this.pictureIdle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      this.pictureIdle.TabIndex = 13;
      this.pictureIdle.TabStop = false;
      // 
      // checkBox2
      // 
      this.checkBox2.AutoSize = true;
      this.checkBox2.Location = new System.Drawing.Point(6, 53);
      this.checkBox2.Name = "checkBox2";
      this.checkBox2.Size = new System.Drawing.Size(165, 17);
      this.checkBox2.TabIndex = 0;
      this.checkBox2.Text = "Notify on errors via balloon tip";
      this.checkBox2.UseVisualStyleBackColor = true;
      // 
      // checkBox1
      // 
      this.checkBox1.AutoSize = true;
      this.checkBox1.Location = new System.Drawing.Point(6, 28);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new System.Drawing.Size(203, 17);
      this.checkBox1.TabIndex = 1;
      this.checkBox1.Text = "Start application when windows starts";
      this.checkBox1.UseVisualStyleBackColor = true;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(28, 9);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(70, 13);
      this.label4.TabIndex = 2;
      this.label4.Text = "Application";
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = global::OptimusUI.Properties.Resources.application;
      this.pictureBox1.Location = new System.Drawing.Point(6, 6);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(16, 16);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      this.pictureBox1.TabIndex = 9;
      this.pictureBox1.TabStop = false;
      // 
      // tabDevice
      // 
      this.tabDevice.Controls.Add(this.label18);
      this.tabDevice.Controls.Add(this.label17);
      this.tabDevice.Controls.Add(this.label14);
      this.tabDevice.Controls.Add(this.trackBar3);
      this.tabDevice.Controls.Add(this.radioButton7);
      this.tabDevice.Controls.Add(this.radioButton6);
      this.tabDevice.Controls.Add(this.radioButton5);
      this.tabDevice.Controls.Add(this.radioButton4);
      this.tabDevice.Controls.Add(this.radioButton3);
      this.tabDevice.Controls.Add(this.radioButton2);
      this.tabDevice.Controls.Add(this.radioButton1);
      this.tabDevice.Controls.Add(this.label3);
      this.tabDevice.Controls.Add(this.label5);
      this.tabDevice.Controls.Add(this.pictureBox3);
      this.tabDevice.Controls.Add(this.labelContrastDescription);
      this.tabDevice.Controls.Add(this.labelContrast);
      this.tabDevice.Controls.Add(this.pictureContrast);
      this.tabDevice.Location = new System.Drawing.Point(4, 22);
      this.tabDevice.Name = "tabDevice";
      this.tabDevice.Padding = new System.Windows.Forms.Padding(3);
      this.tabDevice.Size = new System.Drawing.Size(372, 256);
      this.tabDevice.TabIndex = 1;
      this.tabDevice.Text = "Device";
      this.tabDevice.UseVisualStyleBackColor = true;
      // 
      // label18
      // 
      this.label18.AutoSize = true;
      this.label18.Location = new System.Drawing.Point(3, 30);
      this.label18.Name = "label18";
      this.label18.Size = new System.Drawing.Size(59, 13);
      this.label18.TabIndex = 24;
      this.label18.Text = "Brightness:";
      // 
      // label17
      // 
      this.label17.AutoSize = true;
      this.label17.Location = new System.Drawing.Point(3, 55);
      this.label17.Name = "label17";
      this.label17.Size = new System.Drawing.Size(46, 13);
      this.label17.TabIndex = 23;
      this.label17.Text = "Gamma:";
      // 
      // label14
      // 
      this.label14.AutoSize = true;
      this.label14.Location = new System.Drawing.Point(194, 55);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(28, 13);
      this.label14.TabIndex = 22;
      this.label14.Text = "1.00";
      // 
      // trackBar3
      // 
      this.trackBar3.AutoSize = false;
      this.trackBar3.Location = new System.Drawing.Point(68, 51);
      this.trackBar3.Maximum = 100;
      this.trackBar3.Minimum = 30;
      this.trackBar3.Name = "trackBar3";
      this.trackBar3.Size = new System.Drawing.Size(120, 20);
      this.trackBar3.TabIndex = 21;
      this.trackBar3.TickFrequency = 10;
      this.trackBar3.Value = 65;
      // 
      // radioButton7
      // 
      this.radioButton7.AutoSize = true;
      this.radioButton7.Location = new System.Drawing.Point(183, 28);
      this.radioButton7.Name = "radioButton7";
      this.radioButton7.Size = new System.Drawing.Size(47, 17);
      this.radioButton7.TabIndex = 20;
      this.radioButton7.Text = "High";
      this.radioButton7.UseVisualStyleBackColor = true;
      // 
      // radioButton6
      // 
      this.radioButton6.AutoSize = true;
      this.radioButton6.Location = new System.Drawing.Point(119, 28);
      this.radioButton6.Name = "radioButton6";
      this.radioButton6.Size = new System.Drawing.Size(58, 17);
      this.radioButton6.TabIndex = 19;
      this.radioButton6.Text = "Normal";
      this.radioButton6.UseVisualStyleBackColor = true;
      // 
      // radioButton5
      // 
      this.radioButton5.AutoSize = true;
      this.radioButton5.Location = new System.Drawing.Point(68, 28);
      this.radioButton5.Name = "radioButton5";
      this.radioButton5.Size = new System.Drawing.Size(45, 17);
      this.radioButton5.TabIndex = 18;
      this.radioButton5.Text = "Low";
      this.radioButton5.UseVisualStyleBackColor = true;
      // 
      // radioButton4
      // 
      this.radioButton4.AutoSize = true;
      this.radioButton4.Location = new System.Drawing.Point(161, 160);
      this.radioButton4.Name = "radioButton4";
      this.radioButton4.Size = new System.Drawing.Size(58, 17);
      this.radioButton4.TabIndex = 17;
      this.radioButton4.Text = "Bottom";
      this.radioButton4.UseVisualStyleBackColor = true;
      // 
      // radioButton3
      // 
      this.radioButton3.AutoSize = true;
      this.radioButton3.Location = new System.Drawing.Point(111, 160);
      this.radioButton3.Name = "radioButton3";
      this.radioButton3.Size = new System.Drawing.Size(44, 17);
      this.radioButton3.TabIndex = 16;
      this.radioButton3.Text = "Top";
      this.radioButton3.UseVisualStyleBackColor = true;
      // 
      // radioButton2
      // 
      this.radioButton2.AutoSize = true;
      this.radioButton2.Location = new System.Drawing.Point(62, 160);
      this.radioButton2.Name = "radioButton2";
      this.radioButton2.Size = new System.Drawing.Size(43, 17);
      this.radioButton2.TabIndex = 15;
      this.radioButton2.Text = "Left";
      this.radioButton2.UseVisualStyleBackColor = true;
      // 
      // radioButton1
      // 
      this.radioButton1.AutoSize = true;
      this.radioButton1.Checked = true;
      this.radioButton1.Location = new System.Drawing.Point(6, 160);
      this.radioButton1.Name = "radioButton1";
      this.radioButton1.Size = new System.Drawing.Size(50, 17);
      this.radioButton1.TabIndex = 14;
      this.radioButton1.TabStop = true;
      this.radioButton1.Text = "Right";
      this.radioButton1.UseVisualStyleBackColor = true;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(3, 139);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(185, 13);
      this.label3.TabIndex = 13;
      this.label3.Text = "Select on which side the usb cable is.";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(28, 118);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(69, 13);
      this.label5.TabIndex = 12;
      this.label5.Text = "Orientation";
      // 
      // pictureBox3
      // 
      this.pictureBox3.Image = global::OptimusUI.Properties.Resources.orientation;
      this.pictureBox3.Location = new System.Drawing.Point(6, 115);
      this.pictureBox3.Name = "pictureBox3";
      this.pictureBox3.Size = new System.Drawing.Size(16, 16);
      this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      this.pictureBox3.TabIndex = 11;
      this.pictureBox3.TabStop = false;
      // 
      // labelContrastDescription
      // 
      this.labelContrastDescription.AutoSize = true;
      this.labelContrastDescription.Location = new System.Drawing.Point(118, 219);
      this.labelContrastDescription.Name = "labelContrastDescription";
      this.labelContrastDescription.Size = new System.Drawing.Size(239, 13);
      this.labelContrastDescription.TabIndex = 10;
      this.labelContrastDescription.Text = "Change the brightness and gamma of the device.";
      // 
      // labelContrast
      // 
      this.labelContrast.AutoSize = true;
      this.labelContrast.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelContrast.Location = new System.Drawing.Point(28, 9);
      this.labelContrast.Name = "labelContrast";
      this.labelContrast.Size = new System.Drawing.Size(134, 13);
      this.labelContrast.TabIndex = 9;
      this.labelContrast.Text = "Brightness and gamma";
      this.labelContrast.Click += new System.EventHandler(this.labelContrast_Click);
      // 
      // pictureContrast
      // 
      this.pictureContrast.Image = global::OptimusUI.Properties.Resources.contrast;
      this.pictureContrast.Location = new System.Drawing.Point(6, 6);
      this.pictureContrast.Name = "pictureContrast";
      this.pictureContrast.Size = new System.Drawing.Size(16, 16);
      this.pictureContrast.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      this.pictureContrast.TabIndex = 8;
      this.pictureContrast.TabStop = false;
      // 
      // tabPlugins
      // 
      this.tabPlugins.Controls.Add(this.label12);
      this.tabPlugins.Controls.Add(this.label13);
      this.tabPlugins.Controls.Add(this.label10);
      this.tabPlugins.Controls.Add(this.label11);
      this.tabPlugins.Controls.Add(this.labelBackgroundColor);
      this.tabPlugins.Controls.Add(this.label9);
      this.tabPlugins.Controls.Add(this.label7);
      this.tabPlugins.Controls.Add(this.label8);
      this.tabPlugins.Controls.Add(this.pictureBox4);
      this.tabPlugins.Controls.Add(this.label6);
      this.tabPlugins.Controls.Add(this.checkBox3);
      this.tabPlugins.Controls.Add(this.trackBar2);
      this.tabPlugins.Controls.Add(this.label1);
      this.tabPlugins.Controls.Add(this.label2);
      this.tabPlugins.Controls.Add(this.pictureBox2);
      this.tabPlugins.Location = new System.Drawing.Point(4, 22);
      this.tabPlugins.Name = "tabPlugins";
      this.tabPlugins.Padding = new System.Windows.Forms.Padding(3);
      this.tabPlugins.Size = new System.Drawing.Size(372, 256);
      this.tabPlugins.TabIndex = 2;
      this.tabPlugins.Text = "Plugins";
      this.tabPlugins.UseVisualStyleBackColor = true;
      // 
      // label12
      // 
      this.label12.BackColor = System.Drawing.Color.Black;
      this.label12.Location = new System.Drawing.Point(217, 190);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(16, 16);
      this.label12.TabIndex = 25;
      // 
      // label13
      // 
      this.label13.AutoSize = true;
      this.label13.Location = new System.Drawing.Point(181, 193);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(30, 13);
      this.label13.TabIndex = 24;
      this.label13.Text = "Title:";
      // 
      // label10
      // 
      this.label10.BackColor = System.Drawing.Color.Black;
      this.label10.Location = new System.Drawing.Point(149, 193);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(16, 16);
      this.label10.TabIndex = 23;
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(112, 193);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(31, 13);
      this.label11.TabIndex = 22;
      this.label11.Text = "Text:";
      // 
      // labelBackgroundColor
      // 
      this.labelBackgroundColor.BackColor = System.Drawing.Color.Black;
      this.labelBackgroundColor.Location = new System.Drawing.Point(80, 193);
      this.labelBackgroundColor.Name = "labelBackgroundColor";
      this.labelBackgroundColor.Size = new System.Drawing.Size(16, 16);
      this.labelBackgroundColor.TabIndex = 21;
      this.labelBackgroundColor.Click += new System.EventHandler(this.labelBackgroundColor_Click);
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(6, 193);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(68, 13);
      this.label9.TabIndex = 20;
      this.label9.Text = "Background:";
      // 
      // label7
      // 
      this.label7.Location = new System.Drawing.Point(6, 157);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(360, 26);
      this.label7.TabIndex = 19;
      this.label7.Text = "Specify your preferred background and text color. These settings are not mandator" +
          "y, but should generally be considered by the plugin developers.";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label8.Location = new System.Drawing.Point(28, 140);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(97, 13);
      this.label8.TabIndex = 18;
      this.label8.Text = "Preferred colors";
      // 
      // pictureBox4
      // 
      this.pictureBox4.Image = global::OptimusUI.Properties.Resources.palette;
      this.pictureBox4.Location = new System.Drawing.Point(6, 138);
      this.pictureBox4.Name = "pictureBox4";
      this.pictureBox4.Size = new System.Drawing.Size(16, 16);
      this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      this.pictureBox4.TabIndex = 17;
      this.pictureBox4.TabStop = false;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(132, 78);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(62, 13);
      this.label6.TabIndex = 16;
      this.label6.Text = "30 seconds";
      // 
      // checkBox3
      // 
      this.checkBox3.AutoSize = true;
      this.checkBox3.Location = new System.Drawing.Point(9, 102);
      this.checkBox3.Name = "checkBox3";
      this.checkBox3.Size = new System.Drawing.Size(213, 17);
      this.checkBox3.TabIndex = 15;
      this.checkBox3.Text = "Allow plugins with updates to get ahead";
      this.checkBox3.UseVisualStyleBackColor = true;
      this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
      // 
      // trackBar2
      // 
      this.trackBar2.AutoSize = false;
      this.trackBar2.Location = new System.Drawing.Point(6, 72);
      this.trackBar2.Name = "trackBar2";
      this.trackBar2.Size = new System.Drawing.Size(120, 19);
      this.trackBar2.TabIndex = 14;
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(6, 25);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(360, 39);
      this.label1.TabIndex = 13;
      this.label1.Text = "If more plugins than keys are assigned specify the interval to rotate through the" +
          " plugins. If you turn off rotation you should allow plugins with updates to get " +
          "ahead, otherwise you won\'t see them.";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(28, 8);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(101, 13);
      this.label2.TabIndex = 12;
      this.label2.Text = "Rotation interval";
      // 
      // pictureBox2
      // 
      this.pictureBox2.Image = global::OptimusUI.Properties.Resources.rotate;
      this.pictureBox2.Location = new System.Drawing.Point(6, 6);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new System.Drawing.Size(16, 16);
      this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      this.pictureBox2.TabIndex = 11;
      this.pictureBox2.TabStop = false;
      // 
      // buttonOk
      // 
      this.buttonOk.Location = new System.Drawing.Point(231, 295);
      this.buttonOk.Name = "buttonOk";
      this.buttonOk.Size = new System.Drawing.Size(75, 23);
      this.buttonOk.TabIndex = 1;
      this.buttonOk.Text = "OK";
      this.buttonOk.UseVisualStyleBackColor = true;
      // 
      // buttonCancel
      // 
      this.buttonCancel.Location = new System.Drawing.Point(312, 295);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new System.Drawing.Size(75, 23);
      this.buttonCancel.TabIndex = 2;
      this.buttonCancel.Text = "Cancel";
      this.buttonCancel.UseVisualStyleBackColor = true;
      this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
      // 
      // Settings
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(394, 325);
      this.Controls.Add(this.buttonCancel);
      this.Controls.Add(this.buttonOk);
      this.Controls.Add(this.tabControl1);
      this.DoubleBuffered = true;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Settings";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Settings";
      this.tabControl1.ResumeLayout(false);
      this.tabGeneral.ResumeLayout(false);
      this.tabGeneral.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureIdle)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.tabDevice.ResumeLayout(false);
      this.tabDevice.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureContrast)).EndInit();
      this.tabPlugins.ResumeLayout(false);
      this.tabPlugins.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabGeneral;
    private System.Windows.Forms.TabPage tabDevice;
    private System.Windows.Forms.Button buttonOk;
    private System.Windows.Forms.Button buttonCancel;
    private System.Windows.Forms.CheckBox checkBox2;
    private System.Windows.Forms.CheckBox checkBox1;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.TrackBar trackBar1;
    private System.Windows.Forms.Label labelIdleDescription;
    private System.Windows.Forms.Label labelIdle;
    private System.Windows.Forms.PictureBox pictureIdle;
    private System.Windows.Forms.TabPage tabPlugins;
    private System.Windows.Forms.Label labelContrastDescription;
    private System.Windows.Forms.Label labelContrast;
    private System.Windows.Forms.PictureBox pictureContrast;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.PictureBox pictureBox2;
    private System.Windows.Forms.TrackBar trackBar2;
    private System.Windows.Forms.CheckBox checkBox3;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.PictureBox pictureBox3;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.RadioButton radioButton4;
    private System.Windows.Forms.RadioButton radioButton3;
    private System.Windows.Forms.RadioButton radioButton2;
    private System.Windows.Forms.RadioButton radioButton1;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.PictureBox pictureBox4;
    private System.Windows.Forms.Label labelBackgroundColor;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.RadioButton radioButton7;
    private System.Windows.Forms.RadioButton radioButton6;
    private System.Windows.Forms.RadioButton radioButton5;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.TrackBar trackBar3;
    private System.Windows.Forms.Label label16;
    private System.Windows.Forms.Label label15;
    private System.Windows.Forms.Label label18;
    private System.Windows.Forms.Label label17;
  }
}
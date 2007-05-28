namespace OptimusUI
{
  partial class Form1
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.buttonConnect = new System.Windows.Forms.Button();
      this.groupSettings = new System.Windows.Forms.GroupBox();
      this.panel4 = new System.Windows.Forms.Panel();
      this.labelIdleValue = new System.Windows.Forms.Label();
      this.trackbarIdle = new System.Windows.Forms.TrackBar();
      this.label6 = new System.Windows.Forms.Label();
      this.panel3 = new System.Windows.Forms.Panel();
      this.labelGammaValue = new System.Windows.Forms.Label();
      this.trackbarGamma = new System.Windows.Forms.TrackBar();
      this.label3 = new System.Windows.Forms.Label();
      this.panel2 = new System.Windows.Forms.Panel();
      this.fieldBrightnessHigh = new System.Windows.Forms.RadioButton();
      this.label1 = new System.Windows.Forms.Label();
      this.fieldBrightnessNormal = new System.Windows.Forms.RadioButton();
      this.fieldBrightnessLow = new System.Windows.Forms.RadioButton();
      this.panel1 = new System.Windows.Forms.Panel();
      this.fieldLayoutDown = new System.Windows.Forms.RadioButton();
      this.fieldLayoutUp = new System.Windows.Forms.RadioButton();
      this.fieldLayoutLeft = new System.Windows.Forms.RadioButton();
      this.fieldLayoutRight = new System.Windows.Forms.RadioButton();
      this.label2 = new System.Windows.Forms.Label();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.buttonSuspend = new System.Windows.Forms.Button();
      this.buttonResume = new System.Windows.Forms.Button();
      this.button1 = new System.Windows.Forms.Button();
      this.labelKey2 = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.labelKey1 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.labelKey0 = new System.Windows.Forms.Label();
      this.labelConnectionState = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.groupPlugins = new System.Windows.Forms.GroupBox();
      this.buttonConfig2 = new System.Windows.Forms.Button();
      this.buttonConfig1 = new System.Windows.Forms.Button();
      this.buttonConfig0 = new System.Windows.Forms.Button();
      this.selectPlugin2 = new System.Windows.Forms.ComboBox();
      this.label11 = new System.Windows.Forms.Label();
      this.selectPlugin1 = new System.Windows.Forms.ComboBox();
      this.label10 = new System.Windows.Forms.Label();
      this.selectPlugin0 = new System.Windows.Forms.ComboBox();
      this.label8 = new System.Windows.Forms.Label();
      this.taskbarIcon = new System.Windows.Forms.NotifyIcon(this.components);
      this.selectPluginToAdd = new System.Windows.Forms.ComboBox();
      this.buttonAddPlugin = new System.Windows.Forms.Button();
      this.groupSettings.SuspendLayout();
      this.panel4.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.trackbarIdle)).BeginInit();
      this.panel3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.trackbarGamma)).BeginInit();
      this.panel2.SuspendLayout();
      this.panel1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupPlugins.SuspendLayout();
      this.SuspendLayout();
      // 
      // buttonConnect
      // 
      this.buttonConnect.Location = new System.Drawing.Point(204, 8);
      this.buttonConnect.Name = "buttonConnect";
      this.buttonConnect.Size = new System.Drawing.Size(75, 23);
      this.buttonConnect.TabIndex = 0;
      this.buttonConnect.Text = "Connect";
      this.buttonConnect.UseVisualStyleBackColor = true;
      this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
      // 
      // groupSettings
      // 
      this.groupSettings.Controls.Add(this.panel4);
      this.groupSettings.Controls.Add(this.panel3);
      this.groupSettings.Controls.Add(this.panel2);
      this.groupSettings.Controls.Add(this.panel1);
      this.groupSettings.Location = new System.Drawing.Point(10, 212);
      this.groupSettings.Name = "groupSettings";
      this.groupSettings.Size = new System.Drawing.Size(574, 124);
      this.groupSettings.TabIndex = 23;
      this.groupSettings.TabStop = false;
      this.groupSettings.Text = "Settings";
      // 
      // panel4
      // 
      this.panel4.Controls.Add(this.labelIdleValue);
      this.panel4.Controls.Add(this.trackbarIdle);
      this.panel4.Controls.Add(this.label6);
      this.panel4.Location = new System.Drawing.Point(309, 69);
      this.panel4.Name = "panel4";
      this.panel4.Size = new System.Drawing.Size(212, 47);
      this.panel4.TabIndex = 7;
      // 
      // labelIdleValue
      // 
      this.labelIdleValue.AutoSize = true;
      this.labelIdleValue.Location = new System.Drawing.Point(1, 25);
      this.labelIdleValue.Name = "labelIdleValue";
      this.labelIdleValue.Size = new System.Drawing.Size(45, 13);
      this.labelIdleValue.TabIndex = 27;
      this.labelIdleValue.Text = "300 sec";
      // 
      // trackbarIdle
      // 
      this.trackbarIdle.Location = new System.Drawing.Point(53, 3);
      this.trackbarIdle.Maximum = 300;
      this.trackbarIdle.Name = "trackbarIdle";
      this.trackbarIdle.Size = new System.Drawing.Size(122, 42);
      this.trackbarIdle.TabIndex = 26;
      this.trackbarIdle.TickFrequency = 60;
      this.trackbarIdle.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
      this.trackbarIdle.Value = 300;
      this.trackbarIdle.Scroll += new System.EventHandler(this.trackbarIdle_Scroll);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(1, 3);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(49, 13);
      this.label6.TabIndex = 0;
      this.label6.Text = "Idle time:";
      // 
      // panel3
      // 
      this.panel3.Controls.Add(this.labelGammaValue);
      this.panel3.Controls.Add(this.trackbarGamma);
      this.panel3.Controls.Add(this.label3);
      this.panel3.Location = new System.Drawing.Point(309, 12);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(212, 47);
      this.panel3.TabIndex = 6;
      // 
      // labelGammaValue
      // 
      this.labelGammaValue.AutoSize = true;
      this.labelGammaValue.Location = new System.Drawing.Point(1, 22);
      this.labelGammaValue.Name = "labelGammaValue";
      this.labelGammaValue.Size = new System.Drawing.Size(28, 13);
      this.labelGammaValue.TabIndex = 27;
      this.labelGammaValue.Text = "0.65";
      // 
      // trackbarGamma
      // 
      this.trackbarGamma.Location = new System.Drawing.Point(53, 3);
      this.trackbarGamma.Maximum = 100;
      this.trackbarGamma.Name = "trackbarGamma";
      this.trackbarGamma.Size = new System.Drawing.Size(122, 42);
      this.trackbarGamma.TabIndex = 26;
      this.trackbarGamma.TickFrequency = 10;
      this.trackbarGamma.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
      this.trackbarGamma.Value = 65;
      this.trackbarGamma.Scroll += new System.EventHandler(this.trackbarGamma_Scroll);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(1, 3);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(46, 13);
      this.label3.TabIndex = 0;
      this.label3.Text = "Gamma:";
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.fieldBrightnessHigh);
      this.panel2.Controls.Add(this.label1);
      this.panel2.Controls.Add(this.fieldBrightnessNormal);
      this.panel2.Controls.Add(this.fieldBrightnessLow);
      this.panel2.Location = new System.Drawing.Point(10, 12);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(239, 36);
      this.panel2.TabIndex = 5;
      // 
      // fieldBrightnessHigh
      // 
      this.fieldBrightnessHigh.AutoSize = true;
      this.fieldBrightnessHigh.Location = new System.Drawing.Point(181, 3);
      this.fieldBrightnessHigh.Name = "fieldBrightnessHigh";
      this.fieldBrightnessHigh.Size = new System.Drawing.Size(47, 17);
      this.fieldBrightnessHigh.TabIndex = 7;
      this.fieldBrightnessHigh.Text = "High";
      this.fieldBrightnessHigh.UseVisualStyleBackColor = true;
      this.fieldBrightnessHigh.CheckedChanged += new System.EventHandler(this.fieldBrightnessHigh_CheckedChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(1, 5);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(59, 13);
      this.label1.TabIndex = 6;
      this.label1.Text = "Brightness:";
      // 
      // fieldBrightnessNormal
      // 
      this.fieldBrightnessNormal.AutoSize = true;
      this.fieldBrightnessNormal.Location = new System.Drawing.Point(117, 3);
      this.fieldBrightnessNormal.Name = "fieldBrightnessNormal";
      this.fieldBrightnessNormal.Size = new System.Drawing.Size(58, 17);
      this.fieldBrightnessNormal.TabIndex = 5;
      this.fieldBrightnessNormal.Text = "Normal";
      this.fieldBrightnessNormal.UseVisualStyleBackColor = true;
      this.fieldBrightnessNormal.CheckedChanged += new System.EventHandler(this.fieldBrightnessNormal_CheckedChanged);
      // 
      // fieldBrightnessLow
      // 
      this.fieldBrightnessLow.AutoSize = true;
      this.fieldBrightnessLow.Checked = true;
      this.fieldBrightnessLow.Location = new System.Drawing.Point(66, 3);
      this.fieldBrightnessLow.Name = "fieldBrightnessLow";
      this.fieldBrightnessLow.Size = new System.Drawing.Size(45, 17);
      this.fieldBrightnessLow.TabIndex = 4;
      this.fieldBrightnessLow.TabStop = true;
      this.fieldBrightnessLow.Text = "Low";
      this.fieldBrightnessLow.UseVisualStyleBackColor = true;
      this.fieldBrightnessLow.CheckedChanged += new System.EventHandler(this.fieldBrightnessLow_CheckedChanged);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.fieldLayoutDown);
      this.panel1.Controls.Add(this.fieldLayoutUp);
      this.panel1.Controls.Add(this.fieldLayoutLeft);
      this.panel1.Controls.Add(this.fieldLayoutRight);
      this.panel1.Controls.Add(this.label2);
      this.panel1.Location = new System.Drawing.Point(10, 69);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(278, 32);
      this.panel1.TabIndex = 4;
      // 
      // fieldLayoutDown
      // 
      this.fieldLayoutDown.AutoSize = true;
      this.fieldLayoutDown.Location = new System.Drawing.Point(216, 0);
      this.fieldLayoutDown.Name = "fieldLayoutDown";
      this.fieldLayoutDown.Size = new System.Drawing.Size(53, 17);
      this.fieldLayoutDown.TabIndex = 13;
      this.fieldLayoutDown.Text = "Down";
      this.fieldLayoutDown.UseVisualStyleBackColor = true;
      this.fieldLayoutDown.CheckedChanged += new System.EventHandler(this.fieldLayoutDown_CheckedChanged);
      // 
      // fieldLayoutUp
      // 
      this.fieldLayoutUp.AutoSize = true;
      this.fieldLayoutUp.Location = new System.Drawing.Point(171, 0);
      this.fieldLayoutUp.Name = "fieldLayoutUp";
      this.fieldLayoutUp.Size = new System.Drawing.Size(39, 17);
      this.fieldLayoutUp.TabIndex = 12;
      this.fieldLayoutUp.Text = "Up";
      this.fieldLayoutUp.UseVisualStyleBackColor = true;
      this.fieldLayoutUp.CheckedChanged += new System.EventHandler(this.fieldLayoutUp_CheckedChanged);
      // 
      // fieldLayoutLeft
      // 
      this.fieldLayoutLeft.AutoSize = true;
      this.fieldLayoutLeft.Location = new System.Drawing.Point(122, 0);
      this.fieldLayoutLeft.Name = "fieldLayoutLeft";
      this.fieldLayoutLeft.Size = new System.Drawing.Size(43, 17);
      this.fieldLayoutLeft.TabIndex = 11;
      this.fieldLayoutLeft.Text = "Left";
      this.fieldLayoutLeft.UseVisualStyleBackColor = true;
      this.fieldLayoutLeft.CheckedChanged += new System.EventHandler(this.fieldLayoutLeft_CheckedChanged);
      // 
      // fieldLayoutRight
      // 
      this.fieldLayoutRight.AutoSize = true;
      this.fieldLayoutRight.Checked = true;
      this.fieldLayoutRight.Location = new System.Drawing.Point(66, 0);
      this.fieldLayoutRight.Name = "fieldLayoutRight";
      this.fieldLayoutRight.Size = new System.Drawing.Size(50, 17);
      this.fieldLayoutRight.TabIndex = 10;
      this.fieldLayoutRight.TabStop = true;
      this.fieldLayoutRight.Text = "Right";
      this.fieldLayoutRight.UseVisualStyleBackColor = true;
      this.fieldLayoutRight.CheckedChanged += new System.EventHandler(this.fieldLayoutRight_CheckedChanged);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(1, 2);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(42, 13);
      this.label2.TabIndex = 9;
      this.label2.Text = "Layout:";
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.buttonSuspend);
      this.groupBox2.Controls.Add(this.buttonResume);
      this.groupBox2.Controls.Add(this.button1);
      this.groupBox2.Controls.Add(this.labelKey2);
      this.groupBox2.Controls.Add(this.label9);
      this.groupBox2.Controls.Add(this.labelKey1);
      this.groupBox2.Controls.Add(this.label7);
      this.groupBox2.Controls.Add(this.labelKey0);
      this.groupBox2.Controls.Add(this.buttonConnect);
      this.groupBox2.Controls.Add(this.labelConnectionState);
      this.groupBox2.Controls.Add(this.label5);
      this.groupBox2.Controls.Add(this.label4);
      this.groupBox2.Location = new System.Drawing.Point(10, 5);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(294, 161);
      this.groupBox2.TabIndex = 24;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Status";
      // 
      // buttonSuspend
      // 
      this.buttonSuspend.Location = new System.Drawing.Point(113, 132);
      this.buttonSuspend.Name = "buttonSuspend";
      this.buttonSuspend.Size = new System.Drawing.Size(54, 23);
      this.buttonSuspend.TabIndex = 10;
      this.buttonSuspend.Text = "Suspend";
      this.buttonSuspend.UseVisualStyleBackColor = true;
      this.buttonSuspend.Click += new System.EventHandler(this.buttonSuspend_Click);
      // 
      // buttonResume
      // 
      this.buttonResume.Location = new System.Drawing.Point(169, 132);
      this.buttonResume.Name = "buttonResume";
      this.buttonResume.Size = new System.Drawing.Size(54, 23);
      this.buttonResume.TabIndex = 9;
      this.buttonResume.Text = "Resume";
      this.buttonResume.UseVisualStyleBackColor = true;
      this.buttonResume.Click += new System.EventHandler(this.buttonResume_Click);
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(225, 132);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(54, 23);
      this.button1.TabIndex = 8;
      this.button1.Text = "Keyshot";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // labelKey2
      // 
      this.labelKey2.Location = new System.Drawing.Point(125, 88);
      this.labelKey2.Name = "labelKey2";
      this.labelKey2.Size = new System.Drawing.Size(154, 13);
      this.labelKey2.TabIndex = 7;
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(7, 88);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(95, 13);
      this.label9.TabIndex = 6;
      this.label9.Text = "Key 2 latest event:";
      // 
      // labelKey1
      // 
      this.labelKey1.Location = new System.Drawing.Point(125, 65);
      this.labelKey1.Name = "labelKey1";
      this.labelKey1.Size = new System.Drawing.Size(154, 13);
      this.labelKey1.TabIndex = 5;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(7, 65);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(95, 13);
      this.label7.TabIndex = 4;
      this.label7.Text = "Key 1 latest event:";
      // 
      // labelKey0
      // 
      this.labelKey0.Location = new System.Drawing.Point(125, 42);
      this.labelKey0.Name = "labelKey0";
      this.labelKey0.Size = new System.Drawing.Size(154, 13);
      this.labelKey0.TabIndex = 3;
      // 
      // labelConnectionState
      // 
      this.labelConnectionState.AutoSize = true;
      this.labelConnectionState.Location = new System.Drawing.Point(125, 13);
      this.labelConnectionState.Name = "labelConnectionState";
      this.labelConnectionState.Size = new System.Drawing.Size(73, 13);
      this.labelConnectionState.TabIndex = 2;
      this.labelConnectionState.Text = "Disconnected";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(7, 13);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(64, 13);
      this.label5.TabIndex = 1;
      this.label5.Text = "Connection:";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(7, 42);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(95, 13);
      this.label4.TabIndex = 0;
      this.label4.Text = "Key 0 latest event:";
      // 
      // groupPlugins
      // 
      this.groupPlugins.Controls.Add(this.buttonAddPlugin);
      this.groupPlugins.Controls.Add(this.selectPluginToAdd);
      this.groupPlugins.Controls.Add(this.buttonConfig2);
      this.groupPlugins.Controls.Add(this.buttonConfig1);
      this.groupPlugins.Controls.Add(this.buttonConfig0);
      this.groupPlugins.Controls.Add(this.selectPlugin2);
      this.groupPlugins.Controls.Add(this.label11);
      this.groupPlugins.Controls.Add(this.selectPlugin1);
      this.groupPlugins.Controls.Add(this.label10);
      this.groupPlugins.Controls.Add(this.selectPlugin0);
      this.groupPlugins.Controls.Add(this.label8);
      this.groupPlugins.Location = new System.Drawing.Point(310, 5);
      this.groupPlugins.Name = "groupPlugins";
      this.groupPlugins.Size = new System.Drawing.Size(274, 161);
      this.groupPlugins.TabIndex = 25;
      this.groupPlugins.TabStop = false;
      this.groupPlugins.Text = "Plugins";
      // 
      // buttonConfig2
      // 
      this.buttonConfig2.Enabled = false;
      this.buttonConfig2.Location = new System.Drawing.Point(193, 71);
      this.buttonConfig2.Name = "buttonConfig2";
      this.buttonConfig2.Size = new System.Drawing.Size(75, 23);
      this.buttonConfig2.TabIndex = 8;
      this.buttonConfig2.Text = "Config";
      this.buttonConfig2.UseVisualStyleBackColor = true;
      this.buttonConfig2.Click += new System.EventHandler(this.buttonConfig2_Click);
      // 
      // buttonConfig1
      // 
      this.buttonConfig1.Enabled = false;
      this.buttonConfig1.Location = new System.Drawing.Point(193, 44);
      this.buttonConfig1.Name = "buttonConfig1";
      this.buttonConfig1.Size = new System.Drawing.Size(75, 23);
      this.buttonConfig1.TabIndex = 7;
      this.buttonConfig1.Text = "Config";
      this.buttonConfig1.UseVisualStyleBackColor = true;
      this.buttonConfig1.Click += new System.EventHandler(this.buttonConfig1_Click);
      // 
      // buttonConfig0
      // 
      this.buttonConfig0.Enabled = false;
      this.buttonConfig0.Location = new System.Drawing.Point(193, 17);
      this.buttonConfig0.Name = "buttonConfig0";
      this.buttonConfig0.Size = new System.Drawing.Size(75, 23);
      this.buttonConfig0.TabIndex = 6;
      this.buttonConfig0.Text = "Config";
      this.buttonConfig0.UseVisualStyleBackColor = true;
      this.buttonConfig0.Click += new System.EventHandler(this.buttonConfig0_Click);
      // 
      // selectPlugin2
      // 
      this.selectPlugin2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.selectPlugin2.FormattingEnabled = true;
      this.selectPlugin2.Location = new System.Drawing.Point(67, 73);
      this.selectPlugin2.Name = "selectPlugin2";
      this.selectPlugin2.Size = new System.Drawing.Size(121, 21);
      this.selectPlugin2.TabIndex = 5;
      this.selectPlugin2.SelectedIndexChanged += new System.EventHandler(this.selectPlugin2_SelectedIndexChanged);
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(6, 76);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(37, 13);
      this.label11.TabIndex = 4;
      this.label11.Text = "Key 2:";
      // 
      // selectPlugin1
      // 
      this.selectPlugin1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.selectPlugin1.FormattingEnabled = true;
      this.selectPlugin1.Location = new System.Drawing.Point(67, 46);
      this.selectPlugin1.Name = "selectPlugin1";
      this.selectPlugin1.Size = new System.Drawing.Size(121, 21);
      this.selectPlugin1.TabIndex = 3;
      this.selectPlugin1.SelectedIndexChanged += new System.EventHandler(this.selectPlugin1_SelectedIndexChanged);
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(6, 49);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(37, 13);
      this.label10.TabIndex = 2;
      this.label10.Text = "Key 1:";
      // 
      // selectPlugin0
      // 
      this.selectPlugin0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.selectPlugin0.FormattingEnabled = true;
      this.selectPlugin0.Location = new System.Drawing.Point(67, 19);
      this.selectPlugin0.Name = "selectPlugin0";
      this.selectPlugin0.Size = new System.Drawing.Size(121, 21);
      this.selectPlugin0.TabIndex = 1;
      this.selectPlugin0.SelectedIndexChanged += new System.EventHandler(this.selectPlugin0_SelectedIndexChanged);
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(6, 22);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(37, 13);
      this.label8.TabIndex = 0;
      this.label8.Text = "Key 0:";
      // 
      // taskbarIcon
      // 
      this.taskbarIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("taskbarIcon.Icon")));
      this.taskbarIcon.Text = "Click to restore";
      this.taskbarIcon.Click += new System.EventHandler(this.taskbarIcon_Click);
      this.taskbarIcon.DoubleClick += new System.EventHandler(this.taskbarIcon_Click);
      // 
      // selectPluginToAdd
      // 
      this.selectPluginToAdd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.selectPluginToAdd.FormattingEnabled = true;
      this.selectPluginToAdd.Location = new System.Drawing.Point(67, 122);
      this.selectPluginToAdd.Name = "selectPluginToAdd";
      this.selectPluginToAdd.Size = new System.Drawing.Size(121, 21);
      this.selectPluginToAdd.TabIndex = 9;
      // 
      // buttonAddPlugin
      // 
      this.buttonAddPlugin.Location = new System.Drawing.Point(193, 120);
      this.buttonAddPlugin.Name = "buttonAddPlugin";
      this.buttonAddPlugin.Size = new System.Drawing.Size(75, 23);
      this.buttonAddPlugin.TabIndex = 10;
      this.buttonAddPlugin.Text = "Add";
      this.buttonAddPlugin.UseVisualStyleBackColor = true;
      this.buttonAddPlugin.Click += new System.EventHandler(this.buttonAddPlugin_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(760, 373);
      this.Controls.Add(this.groupPlugins);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupSettings);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.Name = "Form1";
      this.Text = "Optimus mini library tester v0.2.0.1";
      this.Resize += new System.EventHandler(this.Form1_Resize);
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
      this.groupSettings.ResumeLayout(false);
      this.panel4.ResumeLayout(false);
      this.panel4.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.trackbarIdle)).EndInit();
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.trackbarGamma)).EndInit();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupPlugins.ResumeLayout(false);
      this.groupPlugins.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button buttonConnect;
    private System.Windows.Forms.GroupBox groupSettings;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.RadioButton fieldLayoutDown;
    private System.Windows.Forms.RadioButton fieldLayoutUp;
    private System.Windows.Forms.RadioButton fieldLayoutLeft;
    private System.Windows.Forms.RadioButton fieldLayoutRight;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.RadioButton fieldBrightnessHigh;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.RadioButton fieldBrightnessNormal;
    private System.Windows.Forms.RadioButton fieldBrightnessLow;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label labelConnectionState;
    private System.Windows.Forms.Label labelKey0;
    private System.Windows.Forms.Label labelKey2;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label labelKey1;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.GroupBox groupPlugins;
    private System.Windows.Forms.TrackBar trackbarGamma;
    private System.Windows.Forms.Panel panel4;
    private System.Windows.Forms.TrackBar trackbarIdle;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label labelIdleValue;
    private System.Windows.Forms.Label labelGammaValue;
    private System.Windows.Forms.NotifyIcon taskbarIcon;
    private System.Windows.Forms.ComboBox selectPlugin2;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.ComboBox selectPlugin1;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.ComboBox selectPlugin0;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Button buttonConfig2;
    private System.Windows.Forms.Button buttonConfig1;
    private System.Windows.Forms.Button buttonConfig0;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button buttonSuspend;
    private System.Windows.Forms.Button buttonResume;
    private System.Windows.Forms.Button buttonAddPlugin;
    private System.Windows.Forms.ComboBox selectPluginToAdd;
  }
}


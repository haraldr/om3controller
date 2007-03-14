namespace WeatherPlugin
{
  partial class Config
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
      this.buttonOK = new System.Windows.Forms.Button();
      this.buttonCancel = new System.Windows.Forms.Button();
      this.groupSettings = new System.Windows.Forms.GroupBox();
      this.labelUnits = new System.Windows.Forms.Label();
      this.radioEnglishUnit = new System.Windows.Forms.RadioButton();
      this.radioMetricUnit = new System.Windows.Forms.RadioButton();
      this.labelDisplay = new System.Windows.Forms.Label();
      this.checkTomorrow = new System.Windows.Forms.CheckBox();
      this.checkToday = new System.Windows.Forms.CheckBox();
      this.checkDayAfterTomorrow = new System.Windows.Forms.CheckBox();
      this.checkWeekend = new System.Windows.Forms.CheckBox();
      this.labelWait = new System.Windows.Forms.Label();
      this.textWait = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.groupLocation = new System.Windows.Forms.GroupBox();
      this.label1 = new System.Windows.Forms.Label();
      this.labelCurrentLocation = new System.Windows.Forms.Label();
      this.labelSearch = new System.Windows.Forms.Label();
      this.textSearchCriteria = new System.Windows.Forms.TextBox();
      this.buttonSearch = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.selectLocations = new System.Windows.Forms.ComboBox();
      this.buttonSelect = new System.Windows.Forms.Button();
      this.groupSettings.SuspendLayout();
      this.groupLocation.SuspendLayout();
      this.SuspendLayout();
      // 
      // buttonOK
      // 
      this.buttonOK.Location = new System.Drawing.Point(225, 295);
      this.buttonOK.Name = "buttonOK";
      this.buttonOK.Size = new System.Drawing.Size(75, 23);
      this.buttonOK.TabIndex = 0;
      this.buttonOK.Text = "Ok";
      this.buttonOK.UseVisualStyleBackColor = true;
      this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
      // 
      // buttonCancel
      // 
      this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.buttonCancel.Location = new System.Drawing.Point(306, 295);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new System.Drawing.Size(75, 23);
      this.buttonCancel.TabIndex = 1;
      this.buttonCancel.Text = "Cancel";
      this.buttonCancel.UseVisualStyleBackColor = true;
      // 
      // groupSettings
      // 
      this.groupSettings.Controls.Add(this.label2);
      this.groupSettings.Controls.Add(this.textWait);
      this.groupSettings.Controls.Add(this.labelWait);
      this.groupSettings.Controls.Add(this.checkWeekend);
      this.groupSettings.Controls.Add(this.checkDayAfterTomorrow);
      this.groupSettings.Controls.Add(this.checkTomorrow);
      this.groupSettings.Controls.Add(this.checkToday);
      this.groupSettings.Controls.Add(this.labelDisplay);
      this.groupSettings.Controls.Add(this.labelUnits);
      this.groupSettings.Controls.Add(this.radioEnglishUnit);
      this.groupSettings.Controls.Add(this.radioMetricUnit);
      this.groupSettings.Location = new System.Drawing.Point(12, 130);
      this.groupSettings.Name = "groupSettings";
      this.groupSettings.Size = new System.Drawing.Size(369, 159);
      this.groupSettings.TabIndex = 8;
      this.groupSettings.TabStop = false;
      this.groupSettings.Text = "Settings";
      // 
      // labelUnits
      // 
      this.labelUnits.AutoSize = true;
      this.labelUnits.Location = new System.Drawing.Point(6, 25);
      this.labelUnits.Name = "labelUnits";
      this.labelUnits.Size = new System.Drawing.Size(34, 13);
      this.labelUnits.TabIndex = 11;
      this.labelUnits.Text = "Units:";
      // 
      // radioEnglishUnit
      // 
      this.radioEnglishUnit.AutoSize = true;
      this.radioEnglishUnit.Checked = true;
      this.radioEnglishUnit.Location = new System.Drawing.Point(52, 23);
      this.radioEnglishUnit.Name = "radioEnglishUnit";
      this.radioEnglishUnit.Size = new System.Drawing.Size(84, 17);
      this.radioEnglishUnit.TabIndex = 10;
      this.radioEnglishUnit.TabStop = true;
      this.radioEnglishUnit.Text = "English units";
      this.radioEnglishUnit.UseVisualStyleBackColor = true;
      // 
      // radioMetricUnit
      // 
      this.radioMetricUnit.AutoSize = true;
      this.radioMetricUnit.Location = new System.Drawing.Point(52, 46);
      this.radioMetricUnit.Name = "radioMetricUnit";
      this.radioMetricUnit.Size = new System.Drawing.Size(79, 17);
      this.radioMetricUnit.TabIndex = 9;
      this.radioMetricUnit.Text = "Metric units";
      this.radioMetricUnit.UseVisualStyleBackColor = true;
      // 
      // labelDisplay
      // 
      this.labelDisplay.AutoSize = true;
      this.labelDisplay.Location = new System.Drawing.Point(158, 25);
      this.labelDisplay.Name = "labelDisplay";
      this.labelDisplay.Size = new System.Drawing.Size(83, 13);
      this.labelDisplay.TabIndex = 12;
      this.labelDisplay.Text = "Display data for:";
      // 
      // checkTomorrow
      // 
      this.checkTomorrow.AutoSize = true;
      this.checkTomorrow.Checked = true;
      this.checkTomorrow.CheckState = System.Windows.Forms.CheckState.Checked;
      this.checkTomorrow.Location = new System.Drawing.Point(247, 47);
      this.checkTomorrow.Name = "checkTomorrow";
      this.checkTomorrow.Size = new System.Drawing.Size(73, 17);
      this.checkTomorrow.TabIndex = 14;
      this.checkTomorrow.Text = "Tomorrow";
      this.checkTomorrow.UseVisualStyleBackColor = true;
      // 
      // checkToday
      // 
      this.checkToday.AutoSize = true;
      this.checkToday.Checked = true;
      this.checkToday.CheckState = System.Windows.Forms.CheckState.Checked;
      this.checkToday.Location = new System.Drawing.Point(247, 24);
      this.checkToday.Name = "checkToday";
      this.checkToday.Size = new System.Drawing.Size(56, 17);
      this.checkToday.TabIndex = 13;
      this.checkToday.Text = "Today";
      this.checkToday.UseVisualStyleBackColor = true;
      // 
      // checkDayAfterTomorrow
      // 
      this.checkDayAfterTomorrow.AutoSize = true;
      this.checkDayAfterTomorrow.Checked = true;
      this.checkDayAfterTomorrow.CheckState = System.Windows.Forms.CheckState.Checked;
      this.checkDayAfterTomorrow.Location = new System.Drawing.Point(247, 70);
      this.checkDayAfterTomorrow.Name = "checkDayAfterTomorrow";
      this.checkDayAfterTomorrow.Size = new System.Drawing.Size(115, 17);
      this.checkDayAfterTomorrow.TabIndex = 15;
      this.checkDayAfterTomorrow.Text = "Day after tomorrow";
      this.checkDayAfterTomorrow.UseVisualStyleBackColor = true;
      // 
      // checkWeekend
      // 
      this.checkWeekend.AutoSize = true;
      this.checkWeekend.Checked = true;
      this.checkWeekend.CheckState = System.Windows.Forms.CheckState.Checked;
      this.checkWeekend.Location = new System.Drawing.Point(247, 93);
      this.checkWeekend.Name = "checkWeekend";
      this.checkWeekend.Size = new System.Drawing.Size(73, 17);
      this.checkWeekend.TabIndex = 16;
      this.checkWeekend.Text = "Weekend";
      this.checkWeekend.UseVisualStyleBackColor = true;
      // 
      // labelWait
      // 
      this.labelWait.AutoSize = true;
      this.labelWait.Location = new System.Drawing.Point(6, 129);
      this.labelWait.Name = "labelWait";
      this.labelWait.Size = new System.Drawing.Size(40, 13);
      this.labelWait.TabIndex = 17;
      this.labelWait.Text = "Pause:";
      // 
      // textWait
      // 
      this.textWait.Location = new System.Drawing.Point(52, 126);
      this.textWait.Name = "textWait";
      this.textWait.Size = new System.Drawing.Size(34, 20);
      this.textWait.TabIndex = 18;
      this.textWait.Text = "30";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(92, 129);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(47, 13);
      this.label2.TabIndex = 19;
      this.label2.Text = "seconds";
      // 
      // groupLocation
      // 
      this.groupLocation.Controls.Add(this.buttonSelect);
      this.groupLocation.Controls.Add(this.selectLocations);
      this.groupLocation.Controls.Add(this.label3);
      this.groupLocation.Controls.Add(this.buttonSearch);
      this.groupLocation.Controls.Add(this.textSearchCriteria);
      this.groupLocation.Controls.Add(this.labelSearch);
      this.groupLocation.Controls.Add(this.labelCurrentLocation);
      this.groupLocation.Controls.Add(this.label1);
      this.groupLocation.Location = new System.Drawing.Point(12, 12);
      this.groupLocation.Name = "groupLocation";
      this.groupLocation.Size = new System.Drawing.Size(369, 112);
      this.groupLocation.TabIndex = 9;
      this.groupLocation.TabStop = false;
      this.groupLocation.Text = "Location";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(6, 25);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(84, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Current location:";
      // 
      // labelCurrentLocation
      // 
      this.labelCurrentLocation.AutoSize = true;
      this.labelCurrentLocation.Location = new System.Drawing.Point(96, 25);
      this.labelCurrentLocation.Name = "labelCurrentLocation";
      this.labelCurrentLocation.Size = new System.Drawing.Size(39, 13);
      this.labelCurrentLocation.TabIndex = 1;
      this.labelCurrentLocation.Text = "not set";
      // 
      // labelSearch
      // 
      this.labelSearch.AutoSize = true;
      this.labelSearch.Location = new System.Drawing.Point(6, 57);
      this.labelSearch.Name = "labelSearch";
      this.labelSearch.Size = new System.Drawing.Size(44, 13);
      this.labelSearch.TabIndex = 2;
      this.labelSearch.Text = "Search:";
      // 
      // textSearchCriteria
      // 
      this.textSearchCriteria.Location = new System.Drawing.Point(99, 54);
      this.textSearchCriteria.Name = "textSearchCriteria";
      this.textSearchCriteria.Size = new System.Drawing.Size(180, 20);
      this.textSearchCriteria.TabIndex = 3;
      this.textSearchCriteria.TextChanged += new System.EventHandler(this.textSearchCriteria_TextChanged);
      // 
      // buttonSearch
      // 
      this.buttonSearch.Enabled = false;
      this.buttonSearch.Location = new System.Drawing.Point(285, 52);
      this.buttonSearch.Name = "buttonSearch";
      this.buttonSearch.Size = new System.Drawing.Size(75, 23);
      this.buttonSearch.TabIndex = 4;
      this.buttonSearch.Text = "Search";
      this.buttonSearch.UseVisualStyleBackColor = true;
      this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(6, 83);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(80, 13);
      this.label3.TabIndex = 5;
      this.label3.Text = "Select location:";
      // 
      // selectLocations
      // 
      this.selectLocations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.selectLocations.Enabled = false;
      this.selectLocations.FormattingEnabled = true;
      this.selectLocations.Location = new System.Drawing.Point(99, 80);
      this.selectLocations.Name = "selectLocations";
      this.selectLocations.Size = new System.Drawing.Size(180, 21);
      this.selectLocations.TabIndex = 6;
      // 
      // buttonSelect
      // 
      this.buttonSelect.Enabled = false;
      this.buttonSelect.Location = new System.Drawing.Point(285, 78);
      this.buttonSelect.Name = "buttonSelect";
      this.buttonSelect.Size = new System.Drawing.Size(75, 23);
      this.buttonSelect.TabIndex = 7;
      this.buttonSelect.Text = "Select";
      this.buttonSelect.UseVisualStyleBackColor = true;
      this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
      // 
      // Config
      // 
      this.AcceptButton = this.buttonOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.buttonCancel;
      this.ClientSize = new System.Drawing.Size(391, 328);
      this.Controls.Add(this.groupLocation);
      this.Controls.Add(this.groupSettings);
      this.Controls.Add(this.buttonCancel);
      this.Controls.Add(this.buttonOK);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Config";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.Text = "Weather configuration";
      this.groupSettings.ResumeLayout(false);
      this.groupSettings.PerformLayout();
      this.groupLocation.ResumeLayout(false);
      this.groupLocation.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button buttonOK;
    private System.Windows.Forms.Button buttonCancel;
    private System.Windows.Forms.GroupBox groupSettings;
    private System.Windows.Forms.CheckBox checkWeekend;
    private System.Windows.Forms.CheckBox checkDayAfterTomorrow;
    private System.Windows.Forms.CheckBox checkTomorrow;
    private System.Windows.Forms.CheckBox checkToday;
    private System.Windows.Forms.Label labelDisplay;
    private System.Windows.Forms.Label labelUnits;
    private System.Windows.Forms.RadioButton radioEnglishUnit;
    private System.Windows.Forms.RadioButton radioMetricUnit;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox textWait;
    private System.Windows.Forms.Label labelWait;
    private System.Windows.Forms.GroupBox groupLocation;
    private System.Windows.Forms.Label labelCurrentLocation;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button buttonSearch;
    private System.Windows.Forms.TextBox textSearchCriteria;
    private System.Windows.Forms.Label labelSearch;
    private System.Windows.Forms.ComboBox selectLocations;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button buttonSelect;
  }
}
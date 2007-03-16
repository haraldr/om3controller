namespace Worldtime
{
  partial class WorldTimeConfig
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
      this.listTimezones = new System.Windows.Forms.ListView();
      this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
      this.buttonAdd = new System.Windows.Forms.Button();
      this.buttonDelete = new System.Windows.Forms.Button();
      this.buttonUp = new System.Windows.Forms.Button();
      this.buttonDown = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.selectTimezone = new System.Windows.Forms.ComboBox();
      this.fieldLabel = new System.Windows.Forms.TextBox();
      this.labelMaxReached = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // buttonOK
      // 
      this.buttonOK.Location = new System.Drawing.Point(300, 230);
      this.buttonOK.Name = "buttonOK";
      this.buttonOK.Size = new System.Drawing.Size(75, 23);
      this.buttonOK.TabIndex = 7;
      this.buttonOK.Text = "OK";
      this.buttonOK.UseVisualStyleBackColor = true;
      this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
      // 
      // buttonCancel
      // 
      this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.buttonCancel.Location = new System.Drawing.Point(381, 230);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new System.Drawing.Size(75, 23);
      this.buttonCancel.TabIndex = 8;
      this.buttonCancel.Text = "Cancel";
      this.buttonCancel.UseVisualStyleBackColor = true;
      // 
      // listTimezones
      // 
      this.listTimezones.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
      this.listTimezones.FullRowSelect = true;
      this.listTimezones.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
      this.listTimezones.HideSelection = false;
      this.listTimezones.Location = new System.Drawing.Point(12, 107);
      this.listTimezones.MultiSelect = false;
      this.listTimezones.Name = "listTimezones";
      this.listTimezones.Size = new System.Drawing.Size(356, 105);
      this.listTimezones.TabIndex = 3;
      this.listTimezones.UseCompatibleStateImageBehavior = false;
      this.listTimezones.View = System.Windows.Forms.View.Details;
      this.listTimezones.SelectedIndexChanged += new System.EventHandler(this.listTimezones_SelectedIndexChanged);
      // 
      // columnHeader1
      // 
      this.columnHeader1.Text = "Label: Timezone";
      this.columnHeader1.Width = 350;
      // 
      // buttonAdd
      // 
      this.buttonAdd.Enabled = false;
      this.buttonAdd.Location = new System.Drawing.Point(380, 65);
      this.buttonAdd.Name = "buttonAdd";
      this.buttonAdd.Size = new System.Drawing.Size(75, 23);
      this.buttonAdd.TabIndex = 2;
      this.buttonAdd.Text = "Add";
      this.buttonAdd.UseVisualStyleBackColor = true;
      this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
      // 
      // buttonDelete
      // 
      this.buttonDelete.Enabled = false;
      this.buttonDelete.Location = new System.Drawing.Point(381, 107);
      this.buttonDelete.Name = "buttonDelete";
      this.buttonDelete.Size = new System.Drawing.Size(75, 23);
      this.buttonDelete.TabIndex = 4;
      this.buttonDelete.Text = "Delete";
      this.buttonDelete.UseVisualStyleBackColor = true;
      this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
      // 
      // buttonUp
      // 
      this.buttonUp.Enabled = false;
      this.buttonUp.Location = new System.Drawing.Point(381, 136);
      this.buttonUp.Name = "buttonUp";
      this.buttonUp.Size = new System.Drawing.Size(75, 23);
      this.buttonUp.TabIndex = 5;
      this.buttonUp.Text = "Up";
      this.buttonUp.UseVisualStyleBackColor = true;
      this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
      // 
      // buttonDown
      // 
      this.buttonDown.Enabled = false;
      this.buttonDown.Location = new System.Drawing.Point(380, 165);
      this.buttonDown.Name = "buttonDown";
      this.buttonDown.Size = new System.Drawing.Size(75, 23);
      this.buttonDown.TabIndex = 6;
      this.buttonDown.Text = "Down";
      this.buttonDown.UseVisualStyleBackColor = true;
      this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(9, 42);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(36, 13);
      this.label1.TabIndex = 11;
      this.label1.Text = "Label:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(9, 15);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(56, 13);
      this.label2.TabIndex = 12;
      this.label2.Text = "Timezone:";
      // 
      // selectTimezone
      // 
      this.selectTimezone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.selectTimezone.FormattingEnabled = true;
      this.selectTimezone.Location = new System.Drawing.Point(71, 12);
      this.selectTimezone.Name = "selectTimezone";
      this.selectTimezone.Size = new System.Drawing.Size(385, 21);
      this.selectTimezone.TabIndex = 0;
      // 
      // fieldLabel
      // 
      this.fieldLabel.Location = new System.Drawing.Point(71, 39);
      this.fieldLabel.Name = "fieldLabel";
      this.fieldLabel.Size = new System.Drawing.Size(385, 20);
      this.fieldLabel.TabIndex = 1;
      // 
      // labelMaxReached
      // 
      this.labelMaxReached.AutoSize = true;
      this.labelMaxReached.Location = new System.Drawing.Point(149, 70);
      this.labelMaxReached.Name = "labelMaxReached";
      this.labelMaxReached.Size = new System.Drawing.Size(219, 13);
      this.labelMaxReached.TabIndex = 15;
      this.labelMaxReached.Text = "Maximum reached, you can only add up to 5.";
      this.labelMaxReached.Visible = false;
      // 
      // WorldTimeConfig
      // 
      this.AcceptButton = this.buttonOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.buttonCancel;
      this.ClientSize = new System.Drawing.Size(468, 265);
      this.Controls.Add(this.labelMaxReached);
      this.Controls.Add(this.fieldLabel);
      this.Controls.Add(this.selectTimezone);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.buttonDown);
      this.Controls.Add(this.buttonUp);
      this.Controls.Add(this.buttonDelete);
      this.Controls.Add(this.buttonAdd);
      this.Controls.Add(this.listTimezones);
      this.Controls.Add(this.buttonOK);
      this.Controls.Add(this.buttonCancel);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "WorldTimeConfig";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "WorldTimeConfig";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button buttonOK;
    private System.Windows.Forms.Button buttonCancel;
    private System.Windows.Forms.ListView listTimezones;
    private System.Windows.Forms.Button buttonAdd;
    private System.Windows.Forms.Button buttonDelete;
    private System.Windows.Forms.Button buttonUp;
    private System.Windows.Forms.Button buttonDown;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ComboBox selectTimezone;
    private System.Windows.Forms.TextBox fieldLabel;
    private System.Windows.Forms.Label labelMaxReached;
    private System.Windows.Forms.ColumnHeader columnHeader1;
  }
}
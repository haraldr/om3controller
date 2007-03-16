namespace EmailNotifierPlugin
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
      this.buttonOk = new System.Windows.Forms.Button();
      this.buttonCancel = new System.Windows.Forms.Button();
      this.labelType = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.checkSecure = new System.Windows.Forms.CheckBox();
      this.selectType = new System.Windows.Forms.ComboBox();
      this.textServer = new System.Windows.Forms.TextBox();
      this.textUsername = new System.Windows.Forms.TextBox();
      this.textPassword = new System.Windows.Forms.TextBox();
      this.textExecute = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.buttonAdd = new System.Windows.Forms.Button();
      this.listAccounts = new System.Windows.Forms.ListView();
      this.buttonDelete = new System.Windows.Forms.Button();
      this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.textCheckInterval = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.textMessageInterval = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // buttonOk
      // 
      this.buttonOk.Location = new System.Drawing.Point(276, 353);
      this.buttonOk.Name = "buttonOk";
      this.buttonOk.Size = new System.Drawing.Size(75, 23);
      this.buttonOk.TabIndex = 0;
      this.buttonOk.Text = "OK";
      this.buttonOk.UseVisualStyleBackColor = true;
      this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
      // 
      // buttonCancel
      // 
      this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.buttonCancel.Location = new System.Drawing.Point(357, 353);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new System.Drawing.Size(75, 23);
      this.buttonCancel.TabIndex = 1;
      this.buttonCancel.Text = "Cancel";
      this.buttonCancel.UseVisualStyleBackColor = true;
      // 
      // labelType
      // 
      this.labelType.AutoSize = true;
      this.labelType.Location = new System.Drawing.Point(12, 9);
      this.labelType.Name = "labelType";
      this.labelType.Size = new System.Drawing.Size(34, 13);
      this.labelType.TabIndex = 2;
      this.labelType.Text = "Type:";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 36);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(41, 13);
      this.label1.TabIndex = 3;
      this.label1.Text = "Server:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 62);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(58, 13);
      this.label2.TabIndex = 4;
      this.label2.Text = "Username:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(225, 62);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(56, 13);
      this.label3.TabIndex = 5;
      this.label3.Text = "Password:";
      // 
      // checkSecure
      // 
      this.checkSecure.AutoSize = true;
      this.checkSecure.Location = new System.Drawing.Point(225, 35);
      this.checkSecure.Name = "checkSecure";
      this.checkSecure.Size = new System.Drawing.Size(136, 17);
      this.checkSecure.TabIndex = 6;
      this.checkSecure.Text = "Use secure connection";
      this.checkSecure.UseVisualStyleBackColor = true;
      // 
      // selectType
      // 
      this.selectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.selectType.Enabled = false;
      this.selectType.FormattingEnabled = true;
      this.selectType.Items.AddRange(new object[] {
            "POP"});
      this.selectType.Location = new System.Drawing.Point(112, 6);
      this.selectType.Name = "selectType";
      this.selectType.Size = new System.Drawing.Size(107, 21);
      this.selectType.TabIndex = 7;
      // 
      // textServer
      // 
      this.textServer.Location = new System.Drawing.Point(112, 33);
      this.textServer.Name = "textServer";
      this.textServer.Size = new System.Drawing.Size(107, 20);
      this.textServer.TabIndex = 8;
      // 
      // textUsername
      // 
      this.textUsername.Location = new System.Drawing.Point(112, 59);
      this.textUsername.Name = "textUsername";
      this.textUsername.Size = new System.Drawing.Size(107, 20);
      this.textUsername.TabIndex = 9;
      // 
      // textPassword
      // 
      this.textPassword.Location = new System.Drawing.Point(289, 59);
      this.textPassword.Name = "textPassword";
      this.textPassword.Size = new System.Drawing.Size(107, 20);
      this.textPassword.TabIndex = 10;
      this.textPassword.UseSystemPasswordChar = true;
      // 
      // textExecute
      // 
      this.textExecute.Location = new System.Drawing.Point(112, 85);
      this.textExecute.Name = "textExecute";
      this.textExecute.Size = new System.Drawing.Size(320, 20);
      this.textExecute.TabIndex = 11;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(12, 88);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(96, 13);
      this.label4.TabIndex = 12;
      this.label4.Text = "Open file/web site:";
      // 
      // buttonAdd
      // 
      this.buttonAdd.Location = new System.Drawing.Point(357, 111);
      this.buttonAdd.Name = "buttonAdd";
      this.buttonAdd.Size = new System.Drawing.Size(75, 23);
      this.buttonAdd.TabIndex = 13;
      this.buttonAdd.Text = "Add";
      this.buttonAdd.UseVisualStyleBackColor = true;
      this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
      // 
      // listAccounts
      // 
      this.listAccounts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
      this.listAccounts.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
      this.listAccounts.HideSelection = false;
      this.listAccounts.Location = new System.Drawing.Point(12, 160);
      this.listAccounts.MultiSelect = false;
      this.listAccounts.Name = "listAccounts";
      this.listAccounts.Size = new System.Drawing.Size(339, 104);
      this.listAccounts.TabIndex = 14;
      this.listAccounts.UseCompatibleStateImageBehavior = false;
      this.listAccounts.View = System.Windows.Forms.View.Details;
      this.listAccounts.SelectedIndexChanged += new System.EventHandler(this.listAccounts_SelectedIndexChanged);
      // 
      // buttonDelete
      // 
      this.buttonDelete.Location = new System.Drawing.Point(357, 160);
      this.buttonDelete.Name = "buttonDelete";
      this.buttonDelete.Size = new System.Drawing.Size(75, 23);
      this.buttonDelete.TabIndex = 15;
      this.buttonDelete.Text = "Delete";
      this.buttonDelete.UseVisualStyleBackColor = true;
      this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
      // 
      // columnHeader1
      // 
      this.columnHeader1.Width = 308;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(12, 295);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(140, 13);
      this.label5.TabIndex = 16;
      this.label5.Text = "Check for new emails every:";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(12, 321);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(120, 13);
      this.label6.TabIndex = 17;
      this.label6.Text = "Show new message for:";
      // 
      // textCheckInterval
      // 
      this.textCheckInterval.Location = new System.Drawing.Point(158, 292);
      this.textCheckInterval.Name = "textCheckInterval";
      this.textCheckInterval.Size = new System.Drawing.Size(40, 20);
      this.textCheckInterval.TabIndex = 18;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(204, 295);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(47, 13);
      this.label7.TabIndex = 19;
      this.label7.Text = "seconds";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(204, 321);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(47, 13);
      this.label8.TabIndex = 21;
      this.label8.Text = "seconds";
      // 
      // textMessageInterval
      // 
      this.textMessageInterval.Location = new System.Drawing.Point(158, 318);
      this.textMessageInterval.Name = "textMessageInterval";
      this.textMessageInterval.Size = new System.Drawing.Size(40, 20);
      this.textMessageInterval.TabIndex = 20;
      // 
      // Config
      // 
      this.AcceptButton = this.buttonOk;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.buttonCancel;
      this.ClientSize = new System.Drawing.Size(449, 392);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.textMessageInterval);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.textCheckInterval);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.buttonDelete);
      this.Controls.Add(this.listAccounts);
      this.Controls.Add(this.buttonAdd);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.textExecute);
      this.Controls.Add(this.textPassword);
      this.Controls.Add(this.textUsername);
      this.Controls.Add(this.textServer);
      this.Controls.Add(this.selectType);
      this.Controls.Add(this.checkSecure);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.labelType);
      this.Controls.Add(this.buttonCancel);
      this.Controls.Add(this.buttonOk);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Config";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Email notifier configuration";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button buttonOk;
    private System.Windows.Forms.Button buttonCancel;
    private System.Windows.Forms.Label labelType;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.CheckBox checkSecure;
    private System.Windows.Forms.ComboBox selectType;
    private System.Windows.Forms.TextBox textServer;
    private System.Windows.Forms.TextBox textUsername;
    private System.Windows.Forms.TextBox textPassword;
    private System.Windows.Forms.TextBox textExecute;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button buttonAdd;
    private System.Windows.Forms.ListView listAccounts;
    private System.Windows.Forms.ColumnHeader columnHeader1;
    private System.Windows.Forms.Button buttonDelete;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox textCheckInterval;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.TextBox textMessageInterval;
  }
}
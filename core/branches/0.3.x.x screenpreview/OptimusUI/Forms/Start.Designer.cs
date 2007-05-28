namespace OptimusUI.Forms
{
  partial class Start
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Start));
      this.panel1 = new System.Windows.Forms.Panel();
      this.labelStatus = new System.Windows.Forms.Label();
      this.labelTitle = new System.Windows.Forms.Label();
      this.progressBar = new System.Windows.Forms.ProgressBar();
      this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
      this.menuNotifyIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.panel1.SuspendLayout();
      this.menuNotifyIcon.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel1.Controls.Add(this.labelStatus);
      this.panel1.Controls.Add(this.labelTitle);
      this.panel1.Controls.Add(this.progressBar);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(250, 74);
      this.panel1.TabIndex = 1;
      // 
      // labelStatus
      // 
      this.labelStatus.Location = new System.Drawing.Point(-4, 51);
      this.labelStatus.Name = "labelStatus";
      this.labelStatus.Size = new System.Drawing.Size(253, 20);
      this.labelStatus.TabIndex = 3;
      this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // labelTitle
      // 
      this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelTitle.Location = new System.Drawing.Point(-5, -1);
      this.labelTitle.Name = "labelTitle";
      this.labelTitle.Size = new System.Drawing.Size(250, 30);
      this.labelTitle.TabIndex = 2;
      this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // progressBar
      // 
      this.progressBar.Location = new System.Drawing.Point(24, 32);
      this.progressBar.Name = "progressBar";
      this.progressBar.Size = new System.Drawing.Size(200, 16);
      this.progressBar.Step = 1;
      this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
      this.progressBar.TabIndex = 1;
      // 
      // notifyIcon
      // 
      this.notifyIcon.ContextMenuStrip = this.menuNotifyIcon;
      this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
      this.notifyIcon.Text = "Double click to open";
      this.notifyIcon.Visible = true;
      this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
      // 
      // menuNotifyIcon
      // 
      this.menuNotifyIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.exitToolStripMenuItem});
      this.menuNotifyIcon.Name = "menuNotifyIcon";
      this.menuNotifyIcon.Size = new System.Drawing.Size(153, 70);
      // 
      // showToolStripMenuItem
      // 
      this.showToolStripMenuItem.Image = global::OptimusUI.Properties.Resources.application;
      this.showToolStripMenuItem.Name = "showToolStripMenuItem";
      this.showToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.showToolStripMenuItem.Text = "&Show";
      this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Image = global::OptimusUI.Properties.Resources.door_open;
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.exitToolStripMenuItem.Text = "E&xit";
      this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
      // 
      // Start
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(250, 74);
      this.Controls.Add(this.panel1);
      this.DoubleBuffered = true;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "Start";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "om3 controller";
      this.panel1.ResumeLayout(false);
      this.menuNotifyIcon.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.ProgressBar progressBar;
    private System.Windows.Forms.Label labelTitle;
    private System.Windows.Forms.Label labelStatus;
    public System.Windows.Forms.NotifyIcon notifyIcon;
    private System.Windows.Forms.ContextMenuStrip menuNotifyIcon;
    private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;

  }
}
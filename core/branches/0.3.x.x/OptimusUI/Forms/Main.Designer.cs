namespace OptimusUI.Forms
{
  partial class Main
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
      this.imagesCommon = new System.Windows.Forms.ImageList(this.components);
      this.statusMain = new System.Windows.Forms.StatusStrip();
      this.menuMain = new System.Windows.Forms.MenuStrip();
      this.menuMainFile = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMainFileExit = new System.Windows.Forms.ToolStripMenuItem();
      this.mainMenuTools = new System.Windows.Forms.ToolStripMenuItem();
      this.mainMenuToolsEventLog = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMainToolsSettings = new System.Windows.Forms.ToolStripMenuItem();
      this.mainMenuHelp = new System.Windows.Forms.ToolStripMenuItem();
      this.mainMenuHelpWebsite = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMainHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
      this.statusMainConnection = new System.Windows.Forms.ToolStripDropDownButton();
      this.statusMainConnectionDisconnect = new System.Windows.Forms.ToolStripMenuItem();
      this.statusMainConnectionConnect = new System.Windows.Forms.ToolStripMenuItem();
      this.controlPluginManager = new OptimusUI.Forms.PluginManagerControl();
      this.statusMain.SuspendLayout();
      this.menuMain.SuspendLayout();
      this.SuspendLayout();
      // 
      // imagesCommon
      // 
      this.imagesCommon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagesCommon.ImageStream")));
      this.imagesCommon.TransparentColor = System.Drawing.Color.Transparent;
      this.imagesCommon.Images.SetKeyName(0, "plugin.png");
      this.imagesCommon.Images.SetKeyName(1, "layout.png");
      this.imagesCommon.Images.SetKeyName(2, "arrow_up.png");
      this.imagesCommon.Images.SetKeyName(3, "arrow_down.png");
      this.imagesCommon.Images.SetKeyName(4, "plugin_edit.png");
      this.imagesCommon.Images.SetKeyName(5, "plugin_add.png");
      this.imagesCommon.Images.SetKeyName(6, "plugin_delete.png");
      this.imagesCommon.Images.SetKeyName(7, "plugin_link.png");
      this.imagesCommon.Images.SetKeyName(8, "plugin_go.png");
      // 
      // statusMain
      // 
      this.statusMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusMainConnection});
      this.statusMain.Location = new System.Drawing.Point(0, 458);
      this.statusMain.Name = "statusMain";
      this.statusMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
      this.statusMain.Size = new System.Drawing.Size(582, 22);
      this.statusMain.SizingGrip = false;
      this.statusMain.TabIndex = 14;
      this.statusMain.Text = "statusStrip1";
      // 
      // menuMain
      // 
      this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMainFile,
            this.mainMenuTools,
            this.mainMenuHelp});
      this.menuMain.Location = new System.Drawing.Point(0, 0);
      this.menuMain.Name = "menuMain";
      this.menuMain.Size = new System.Drawing.Size(582, 24);
      this.menuMain.TabIndex = 13;
      this.menuMain.Text = "menuStrip1";
      // 
      // menuMainFile
      // 
      this.menuMainFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMainFileExit});
      this.menuMainFile.Name = "menuMainFile";
      this.menuMainFile.Size = new System.Drawing.Size(35, 20);
      this.menuMainFile.Text = "&File";
      // 
      // menuMainFileExit
      // 
      this.menuMainFileExit.Image = global::OptimusUI.Properties.Resources.door_open;
      this.menuMainFileExit.Name = "menuMainFileExit";
      this.menuMainFileExit.Size = new System.Drawing.Size(152, 22);
      this.menuMainFileExit.Text = "E&xit";
      this.menuMainFileExit.Click += new System.EventHandler(this.menuMainFileExit_Click);
      // 
      // mainMenuTools
      // 
      this.mainMenuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainMenuToolsEventLog,
            this.menuMainToolsSettings});
      this.mainMenuTools.Name = "mainMenuTools";
      this.mainMenuTools.Size = new System.Drawing.Size(44, 20);
      this.mainMenuTools.Text = "&Tools";
      // 
      // mainMenuToolsEventLog
      // 
      this.mainMenuToolsEventLog.Image = global::OptimusUI.Properties.Resources.eventlog;
      this.mainMenuToolsEventLog.Name = "mainMenuToolsEventLog";
      this.mainMenuToolsEventLog.Size = new System.Drawing.Size(130, 22);
      this.mainMenuToolsEventLog.Text = "&Event log";
      // 
      // menuMainToolsSettings
      // 
      this.menuMainToolsSettings.Image = global::OptimusUI.Properties.Resources.config;
      this.menuMainToolsSettings.Name = "menuMainToolsSettings";
      this.menuMainToolsSettings.Size = new System.Drawing.Size(130, 22);
      this.menuMainToolsSettings.Text = "&Settings";
      // 
      // mainMenuHelp
      // 
      this.mainMenuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainMenuHelpWebsite,
            this.menuMainHelpAbout});
      this.mainMenuHelp.Name = "mainMenuHelp";
      this.mainMenuHelp.Size = new System.Drawing.Size(40, 20);
      this.mainMenuHelp.Text = "&Help";
      // 
      // mainMenuHelpWebsite
      // 
      this.mainMenuHelpWebsite.Image = global::OptimusUI.Properties.Resources.page_white_world;
      this.mainMenuHelpWebsite.Name = "mainMenuHelpWebsite";
      this.mainMenuHelpWebsite.Size = new System.Drawing.Size(144, 22);
      this.mainMenuHelpWebsite.Text = "&Visit website";
      // 
      // menuMainHelpAbout
      // 
      this.menuMainHelpAbout.Image = global::OptimusUI.Properties.Resources.help;
      this.menuMainHelpAbout.Name = "menuMainHelpAbout";
      this.menuMainHelpAbout.Size = new System.Drawing.Size(144, 22);
      this.menuMainHelpAbout.Text = "&About";
      // 
      // statusMainConnection
      // 
      this.statusMainConnection.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusMainConnectionConnect,
            this.statusMainConnectionDisconnect});
      this.statusMainConnection.Image = global::OptimusUI.Properties.Resources.connect;
      this.statusMainConnection.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.statusMainConnection.Name = "statusMainConnection";
      this.statusMainConnection.Size = new System.Drawing.Size(88, 20);
      this.statusMainConnection.Text = "Connected";
      // 
      // statusMainConnectionDisconnect
      // 
      this.statusMainConnectionDisconnect.Image = global::OptimusUI.Properties.Resources.disconnect;
      this.statusMainConnectionDisconnect.Name = "statusMainConnectionDisconnect";
      this.statusMainConnectionDisconnect.Size = new System.Drawing.Size(152, 22);
      this.statusMainConnectionDisconnect.Text = "Disconnect";
      // 
      // statusMainConnectionConnect
      // 
      this.statusMainConnectionConnect.Image = global::OptimusUI.Properties.Resources.connect;
      this.statusMainConnectionConnect.Name = "statusMainConnectionConnect";
      this.statusMainConnectionConnect.Size = new System.Drawing.Size(152, 22);
      this.statusMainConnectionConnect.Text = "Connect";
      // 
      // controlPluginManager
      // 
      this.controlPluginManager.Location = new System.Drawing.Point(12, 39);
      this.controlPluginManager.Name = "controlPluginManager";
      this.controlPluginManager.Size = new System.Drawing.Size(558, 402);
      this.controlPluginManager.TabIndex = 17;
      // 
      // Main
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(582, 480);
      this.Controls.Add(this.controlPluginManager);
      this.Controls.Add(this.statusMain);
      this.Controls.Add(this.menuMain);
      this.DoubleBuffered = true;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.menuMain;
      this.MaximizeBox = false;
      this.Name = "Main";
      this.Text = "om3 controller";
      this.Resize += new System.EventHandler(this.Main_Resize);
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
      this.statusMain.ResumeLayout(false);
      this.statusMain.PerformLayout();
      this.menuMain.ResumeLayout(false);
      this.menuMain.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ImageList imagesCommon;
    private System.Windows.Forms.StatusStrip statusMain;
    private PluginManagerControl controlPluginManager;
    private System.Windows.Forms.MenuStrip menuMain;
    private System.Windows.Forms.ToolStripMenuItem menuMainFile;
    private System.Windows.Forms.ToolStripMenuItem menuMainFileExit;
    private System.Windows.Forms.ToolStripMenuItem mainMenuTools;
    private System.Windows.Forms.ToolStripMenuItem mainMenuToolsEventLog;
    private System.Windows.Forms.ToolStripMenuItem menuMainToolsSettings;
    private System.Windows.Forms.ToolStripMenuItem mainMenuHelp;
    private System.Windows.Forms.ToolStripMenuItem mainMenuHelpWebsite;
    private System.Windows.Forms.ToolStripMenuItem menuMainHelpAbout;
    private System.Windows.Forms.ToolStripDropDownButton statusMainConnection;
    private System.Windows.Forms.ToolStripMenuItem statusMainConnectionConnect;
    private System.Windows.Forms.ToolStripMenuItem statusMainConnectionDisconnect;
  }
}
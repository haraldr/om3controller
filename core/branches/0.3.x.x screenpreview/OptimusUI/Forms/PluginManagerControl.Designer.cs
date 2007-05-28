namespace OptimusUI.Forms
{
  partial class PluginManagerControl
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PluginManagerControl));
      System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
      System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Default");
      this.imagesCommon = new System.Windows.Forms.ImageList(this.components);
      this.labelPluginAuthorValue = new System.Windows.Forms.Label();
      this.labelPluginAuthor = new System.Windows.Forms.Label();
      this.labelPluginDescriptionValue = new System.Windows.Forms.Label();
      this.labelPluginNameValue = new System.Windows.Forms.Label();
      this.labelPluginName = new System.Windows.Forms.Label();
      this.listAvailablePlugins = new System.Windows.Forms.ListView();
      this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
      this.menuListAvailablePlugins = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this.listLayouts = new System.Windows.Forms.ListView();
      this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
      this.listAssignedPlugins = new System.Windows.Forms.ListView();
      this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
      this.menuListAssignedPlugins = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.buttonPluginUnassign = new System.Windows.Forms.Button();
      this.picturePluginLogo = new System.Windows.Forms.PictureBox();
      this.buttonAssignedPluginConfig = new System.Windows.Forms.Button();
      this.menuListAvailablePluginsAssign = new System.Windows.Forms.ToolStripMenuItem();
      this.menuListAvailablePluginsConfigure = new System.Windows.Forms.ToolStripMenuItem();
      this.menuListAvailablePluginsCreateInstance = new System.Windows.Forms.ToolStripMenuItem();
      this.menuListAvailablePluginsDeleteInstance = new System.Windows.Forms.ToolStripMenuItem();
      this.buttonPluginAssign = new System.Windows.Forms.Button();
      this.buttonPluginInstanceDelete = new System.Windows.Forms.Button();
      this.buttonPluginInstanceAdd = new System.Windows.Forms.Button();
      this.buttonPluginConfig = new System.Windows.Forms.Button();
      this.buttonPluginDown = new System.Windows.Forms.Button();
      this.buttonPluginUp = new System.Windows.Forms.Button();
      this.buttonManageLayouts = new System.Windows.Forms.Button();
      this.menuListAssignedPluginsMoveUp = new System.Windows.Forms.ToolStripMenuItem();
      this.menuListAssignedPluginsMoveDown = new System.Windows.Forms.ToolStripMenuItem();
      this.menuListAssignedPluginsConfigure = new System.Windows.Forms.ToolStripMenuItem();
      this.menuListAssignedPluginsUnassign = new System.Windows.Forms.ToolStripMenuItem();
      this.menuListAvailablePlugins.SuspendLayout();
      this.menuListAssignedPlugins.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.picturePluginLogo)).BeginInit();
      this.SuspendLayout();
      // 
      // imagesCommon
      // 
      this.imagesCommon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagesCommon.ImageStream")));
      this.imagesCommon.TransparentColor = System.Drawing.Color.Transparent;
      this.imagesCommon.Images.SetKeyName(0, "arrow_down.png");
      this.imagesCommon.Images.SetKeyName(1, "arrow_up.png");
      this.imagesCommon.Images.SetKeyName(2, "layout.png");
      this.imagesCommon.Images.SetKeyName(3, "plugin_add.png");
      this.imagesCommon.Images.SetKeyName(4, "plugin_delete.png");
      this.imagesCommon.Images.SetKeyName(5, "plugin_edit.png");
      this.imagesCommon.Images.SetKeyName(6, "plugin_link.png");
      this.imagesCommon.Images.SetKeyName(7, "plugin_link_break.png");
      // 
      // labelPluginAuthorValue
      // 
      this.labelPluginAuthorValue.Location = new System.Drawing.Point(298, 57);
      this.labelPluginAuthorValue.Name = "labelPluginAuthorValue";
      this.labelPluginAuthorValue.Size = new System.Drawing.Size(260, 13);
      this.labelPluginAuthorValue.TabIndex = 42;
      this.labelPluginAuthorValue.Text = "Author\'s name";
      // 
      // labelPluginAuthor
      // 
      this.labelPluginAuthor.AutoSize = true;
      this.labelPluginAuthor.Location = new System.Drawing.Point(254, 57);
      this.labelPluginAuthor.Name = "labelPluginAuthor";
      this.labelPluginAuthor.Size = new System.Drawing.Size(41, 13);
      this.labelPluginAuthor.TabIndex = 41;
      this.labelPluginAuthor.Text = "Author:";
      // 
      // labelPluginDescriptionValue
      // 
      this.labelPluginDescriptionValue.Location = new System.Drawing.Point(213, 76);
      this.labelPluginDescriptionValue.Name = "labelPluginDescriptionValue";
      this.labelPluginDescriptionValue.Size = new System.Drawing.Size(345, 80);
      this.labelPluginDescriptionValue.TabIndex = 38;
      this.labelPluginDescriptionValue.Text = "Description of plugin ...";
      // 
      // labelPluginNameValue
      // 
      this.labelPluginNameValue.Location = new System.Drawing.Point(298, 38);
      this.labelPluginNameValue.Name = "labelPluginNameValue";
      this.labelPluginNameValue.Size = new System.Drawing.Size(260, 13);
      this.labelPluginNameValue.TabIndex = 37;
      this.labelPluginNameValue.Text = "Plugin name vX.X";
      // 
      // labelPluginName
      // 
      this.labelPluginName.AutoSize = true;
      this.labelPluginName.Location = new System.Drawing.Point(254, 38);
      this.labelPluginName.Name = "labelPluginName";
      this.labelPluginName.Size = new System.Drawing.Size(38, 13);
      this.labelPluginName.TabIndex = 36;
      this.labelPluginName.Text = "Name:";
      // 
      // listAvailablePlugins
      // 
      this.listAvailablePlugins.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
      this.listAvailablePlugins.ContextMenuStrip = this.menuListAvailablePlugins;
      this.listAvailablePlugins.FullRowSelect = true;
      this.listAvailablePlugins.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
      this.listAvailablePlugins.HideSelection = false;
      this.listAvailablePlugins.Location = new System.Drawing.Point(0, 38);
      this.listAvailablePlugins.MultiSelect = false;
      this.listAvailablePlugins.Name = "listAvailablePlugins";
      this.listAvailablePlugins.Size = new System.Drawing.Size(200, 115);
      this.listAvailablePlugins.TabIndex = 35;
      this.listAvailablePlugins.UseCompatibleStateImageBehavior = false;
      this.listAvailablePlugins.View = System.Windows.Forms.View.Details;
      this.listAvailablePlugins.DoubleClick += new System.EventHandler(this.listAvailablePlugins_DoubleClick);
      this.listAvailablePlugins.SelectedIndexChanged += new System.EventHandler(this.listAvailablePlugins_SelectedIndexChanged);
      // 
      // columnHeader3
      // 
      this.columnHeader3.Text = "Plugin";
      this.columnHeader3.Width = 159;
      // 
      // menuListAvailablePlugins
      // 
      this.menuListAvailablePlugins.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuListAvailablePluginsAssign,
            this.menuListAvailablePluginsConfigure,
            this.toolStripMenuItem1,
            this.menuListAvailablePluginsCreateInstance,
            this.menuListAvailablePluginsDeleteInstance});
      this.menuListAvailablePlugins.Name = "menuListAvailablePlugins";
      this.menuListAvailablePlugins.Size = new System.Drawing.Size(162, 98);
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(158, 6);
      // 
      // listLayouts
      // 
      this.listLayouts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
      this.listLayouts.Enabled = false;
      this.listLayouts.FullRowSelect = true;
      listViewGroup2.Header = "ListViewGroup";
      listViewGroup2.Name = "Games";
      this.listLayouts.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup2});
      this.listLayouts.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
      this.listLayouts.HideSelection = false;
      listViewItem2.StateImageIndex = 0;
      this.listLayouts.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
      this.listLayouts.Location = new System.Drawing.Point(0, 233);
      this.listLayouts.Name = "listLayouts";
      this.listLayouts.ShowGroups = false;
      this.listLayouts.Size = new System.Drawing.Size(200, 134);
      this.listLayouts.TabIndex = 27;
      this.listLayouts.UseCompatibleStateImageBehavior = false;
      this.listLayouts.View = System.Windows.Forms.View.Details;
      // 
      // columnHeader1
      // 
      this.columnHeader1.Text = "Layout";
      this.columnHeader1.Width = 155;
      // 
      // listAssignedPlugins
      // 
      this.listAssignedPlugins.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
      this.listAssignedPlugins.ContextMenuStrip = this.menuListAssignedPlugins;
      this.listAssignedPlugins.FullRowSelect = true;
      this.listAssignedPlugins.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
      this.listAssignedPlugins.HideSelection = false;
      this.listAssignedPlugins.Location = new System.Drawing.Point(216, 233);
      this.listAssignedPlugins.MultiSelect = false;
      this.listAssignedPlugins.Name = "listAssignedPlugins";
      this.listAssignedPlugins.Size = new System.Drawing.Size(291, 169);
      this.listAssignedPlugins.TabIndex = 26;
      this.listAssignedPlugins.UseCompatibleStateImageBehavior = false;
      this.listAssignedPlugins.View = System.Windows.Forms.View.Details;
      this.listAssignedPlugins.DoubleClick += new System.EventHandler(this.listAssignedPlugins_DoubleClick);
      this.listAssignedPlugins.SelectedIndexChanged += new System.EventHandler(this.listAssignedPlugins_SelectedIndexChanged);
      // 
      // columnHeader2
      // 
      this.columnHeader2.Text = "Plugin";
      this.columnHeader2.Width = 149;
      // 
      // menuListAssignedPlugins
      // 
      this.menuListAssignedPlugins.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuListAssignedPluginsMoveUp,
            this.menuListAssignedPluginsMoveDown,
            this.menuListAssignedPluginsConfigure,
            this.menuListAssignedPluginsUnassign});
      this.menuListAssignedPlugins.Name = "menuListAssignedPlugins";
      this.menuListAssignedPlugins.Size = new System.Drawing.Size(153, 114);
      // 
      // label4
      // 
      this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.label4.BackColor = System.Drawing.SystemColors.ButtonShadow;
      this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
      this.label4.Location = new System.Drawing.Point(-4, 195);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(561, 31);
      this.label4.TabIndex = 44;
      this.label4.Text = " Assigned plugins";
      this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label5
      // 
      this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.label5.BackColor = System.Drawing.SystemColors.ButtonShadow;
      this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
      this.label5.Location = new System.Drawing.Point(-4, 0);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(561, 31);
      this.label5.TabIndex = 45;
      this.label5.Text = " Available plugins";
      this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // buttonPluginUnassign
      // 
      this.buttonPluginUnassign.Enabled = false;
      this.buttonPluginUnassign.ImageKey = "plugin_link_break.png";
      this.buttonPluginUnassign.ImageList = this.imagesCommon;
      this.buttonPluginUnassign.Location = new System.Drawing.Point(513, 338);
      this.buttonPluginUnassign.Name = "buttonPluginUnassign";
      this.buttonPluginUnassign.Size = new System.Drawing.Size(45, 29);
      this.buttonPluginUnassign.TabIndex = 43;
      this.buttonPluginUnassign.UseVisualStyleBackColor = true;
      this.buttonPluginUnassign.Click += new System.EventHandler(this.buttonPluginUnassign_Click);
      // 
      // picturePluginLogo
      // 
      this.picturePluginLogo.Location = new System.Drawing.Point(216, 38);
      this.picturePluginLogo.Name = "picturePluginLogo";
      this.picturePluginLogo.Size = new System.Drawing.Size(32, 32);
      this.picturePluginLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
      this.picturePluginLogo.TabIndex = 40;
      this.picturePluginLogo.TabStop = false;
      // 
      // buttonAssignedPluginConfig
      // 
      this.buttonAssignedPluginConfig.Enabled = false;
      this.buttonAssignedPluginConfig.ImageKey = "plugin_edit.png";
      this.buttonAssignedPluginConfig.ImageList = this.imagesCommon;
      this.buttonAssignedPluginConfig.Location = new System.Drawing.Point(513, 303);
      this.buttonAssignedPluginConfig.Name = "buttonAssignedPluginConfig";
      this.buttonAssignedPluginConfig.Size = new System.Drawing.Size(45, 29);
      this.buttonAssignedPluginConfig.TabIndex = 39;
      this.buttonAssignedPluginConfig.UseVisualStyleBackColor = true;
      this.buttonAssignedPluginConfig.Click += new System.EventHandler(this.buttonAssignedPluginConfig_Click);
      // 
      // menuListAvailablePluginsAssign
      // 
      this.menuListAvailablePluginsAssign.Enabled = false;
      this.menuListAvailablePluginsAssign.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
      this.menuListAvailablePluginsAssign.Image = global::OptimusUI.Properties.Resources.plugin_link;
      this.menuListAvailablePluginsAssign.Name = "menuListAvailablePluginsAssign";
      this.menuListAvailablePluginsAssign.Size = new System.Drawing.Size(161, 22);
      this.menuListAvailablePluginsAssign.Text = "&Assign";
      this.menuListAvailablePluginsAssign.Click += new System.EventHandler(this.menuListAvailablePluginsAssign_Click);
      // 
      // menuListAvailablePluginsConfigure
      // 
      this.menuListAvailablePluginsConfigure.Enabled = false;
      this.menuListAvailablePluginsConfigure.Image = global::OptimusUI.Properties.Resources.plugin_edit;
      this.menuListAvailablePluginsConfigure.Name = "menuListAvailablePluginsConfigure";
      this.menuListAvailablePluginsConfigure.Size = new System.Drawing.Size(161, 22);
      this.menuListAvailablePluginsConfigure.Text = "&Configure";
      this.menuListAvailablePluginsConfigure.Click += new System.EventHandler(this.menuListAvailablePluginsConfigure_Click);
      // 
      // menuListAvailablePluginsCreateInstance
      // 
      this.menuListAvailablePluginsCreateInstance.Enabled = false;
      this.menuListAvailablePluginsCreateInstance.Image = global::OptimusUI.Properties.Resources.plugin_add;
      this.menuListAvailablePluginsCreateInstance.Name = "menuListAvailablePluginsCreateInstance";
      this.menuListAvailablePluginsCreateInstance.Size = new System.Drawing.Size(161, 22);
      this.menuListAvailablePluginsCreateInstance.Text = "Create &instance";
      // 
      // menuListAvailablePluginsDeleteInstance
      // 
      this.menuListAvailablePluginsDeleteInstance.Enabled = false;
      this.menuListAvailablePluginsDeleteInstance.Image = global::OptimusUI.Properties.Resources.plugin_delete;
      this.menuListAvailablePluginsDeleteInstance.Name = "menuListAvailablePluginsDeleteInstance";
      this.menuListAvailablePluginsDeleteInstance.Size = new System.Drawing.Size(161, 22);
      this.menuListAvailablePluginsDeleteInstance.Text = "&Delete instance";
      // 
      // buttonPluginAssign
      // 
      this.buttonPluginAssign.Enabled = false;
      this.buttonPluginAssign.ImageKey = "plugin_link.png";
      this.buttonPluginAssign.ImageList = this.imagesCommon;
      this.buttonPluginAssign.Location = new System.Drawing.Point(0, 159);
      this.buttonPluginAssign.Name = "buttonPluginAssign";
      this.buttonPluginAssign.Size = new System.Drawing.Size(200, 29);
      this.buttonPluginAssign.TabIndex = 34;
      this.buttonPluginAssign.Text = "Assign plugin to layout";
      this.buttonPluginAssign.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.buttonPluginAssign.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.buttonPluginAssign.UseVisualStyleBackColor = true;
      this.buttonPluginAssign.Click += new System.EventHandler(this.buttonPluginAssign_Click);
      // 
      // buttonPluginInstanceDelete
      // 
      this.buttonPluginInstanceDelete.Enabled = false;
      this.buttonPluginInstanceDelete.ImageKey = "plugin_delete.png";
      this.buttonPluginInstanceDelete.ImageList = this.imagesCommon;
      this.buttonPluginInstanceDelete.Location = new System.Drawing.Point(448, 159);
      this.buttonPluginInstanceDelete.Name = "buttonPluginInstanceDelete";
      this.buttonPluginInstanceDelete.Size = new System.Drawing.Size(110, 29);
      this.buttonPluginInstanceDelete.TabIndex = 33;
      this.buttonPluginInstanceDelete.Text = "Delete instance";
      this.buttonPluginInstanceDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.buttonPluginInstanceDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.buttonPluginInstanceDelete.UseVisualStyleBackColor = true;
      // 
      // buttonPluginInstanceAdd
      // 
      this.buttonPluginInstanceAdd.Enabled = false;
      this.buttonPluginInstanceAdd.ImageKey = "plugin_add.png";
      this.buttonPluginInstanceAdd.ImageList = this.imagesCommon;
      this.buttonPluginInstanceAdd.Location = new System.Drawing.Point(332, 159);
      this.buttonPluginInstanceAdd.Name = "buttonPluginInstanceAdd";
      this.buttonPluginInstanceAdd.Size = new System.Drawing.Size(110, 29);
      this.buttonPluginInstanceAdd.TabIndex = 32;
      this.buttonPluginInstanceAdd.Text = "Create instance";
      this.buttonPluginInstanceAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.buttonPluginInstanceAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.buttonPluginInstanceAdd.UseVisualStyleBackColor = true;
      // 
      // buttonPluginConfig
      // 
      this.buttonPluginConfig.Enabled = false;
      this.buttonPluginConfig.ImageKey = "plugin_edit.png";
      this.buttonPluginConfig.ImageList = this.imagesCommon;
      this.buttonPluginConfig.Location = new System.Drawing.Point(216, 159);
      this.buttonPluginConfig.Name = "buttonPluginConfig";
      this.buttonPluginConfig.Size = new System.Drawing.Size(110, 29);
      this.buttonPluginConfig.TabIndex = 31;
      this.buttonPluginConfig.Text = "Configure";
      this.buttonPluginConfig.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.buttonPluginConfig.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.buttonPluginConfig.UseVisualStyleBackColor = true;
      this.buttonPluginConfig.Click += new System.EventHandler(this.buttonPluginConfig_Click);
      // 
      // buttonPluginDown
      // 
      this.buttonPluginDown.Enabled = false;
      this.buttonPluginDown.ImageKey = "arrow_down.png";
      this.buttonPluginDown.ImageList = this.imagesCommon;
      this.buttonPluginDown.Location = new System.Drawing.Point(513, 268);
      this.buttonPluginDown.Name = "buttonPluginDown";
      this.buttonPluginDown.Size = new System.Drawing.Size(45, 29);
      this.buttonPluginDown.TabIndex = 30;
      this.buttonPluginDown.UseVisualStyleBackColor = true;
      this.buttonPluginDown.Click += new System.EventHandler(this.buttonPluginDown_Click);
      // 
      // buttonPluginUp
      // 
      this.buttonPluginUp.Enabled = false;
      this.buttonPluginUp.ImageKey = "arrow_up.png";
      this.buttonPluginUp.ImageList = this.imagesCommon;
      this.buttonPluginUp.Location = new System.Drawing.Point(513, 233);
      this.buttonPluginUp.Name = "buttonPluginUp";
      this.buttonPluginUp.Size = new System.Drawing.Size(45, 29);
      this.buttonPluginUp.TabIndex = 29;
      this.buttonPluginUp.UseVisualStyleBackColor = true;
      this.buttonPluginUp.Click += new System.EventHandler(this.buttonPluginUp_Click);
      // 
      // buttonManageLayouts
      // 
      this.buttonManageLayouts.Enabled = false;
      this.buttonManageLayouts.ImageKey = "layout.png";
      this.buttonManageLayouts.ImageList = this.imagesCommon;
      this.buttonManageLayouts.Location = new System.Drawing.Point(0, 373);
      this.buttonManageLayouts.Name = "buttonManageLayouts";
      this.buttonManageLayouts.Size = new System.Drawing.Size(200, 29);
      this.buttonManageLayouts.TabIndex = 28;
      this.buttonManageLayouts.Text = "Manage layouts";
      this.buttonManageLayouts.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.buttonManageLayouts.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.buttonManageLayouts.UseVisualStyleBackColor = true;
      // 
      // menuListAssignedPluginsMoveUp
      // 
      this.menuListAssignedPluginsMoveUp.Image = global::OptimusUI.Properties.Resources.arrow_up;
      this.menuListAssignedPluginsMoveUp.Name = "menuListAssignedPluginsMoveUp";
      this.menuListAssignedPluginsMoveUp.Size = new System.Drawing.Size(140, 22);
      this.menuListAssignedPluginsMoveUp.Text = "Move &up";
      this.menuListAssignedPluginsMoveUp.Click += new System.EventHandler(this.menuListAssignedPluginsMoveUp_Click);
      // 
      // menuListAssignedPluginsMoveDown
      // 
      this.menuListAssignedPluginsMoveDown.Image = global::OptimusUI.Properties.Resources.arrow_down;
      this.menuListAssignedPluginsMoveDown.Name = "menuListAssignedPluginsMoveDown";
      this.menuListAssignedPluginsMoveDown.Size = new System.Drawing.Size(140, 22);
      this.menuListAssignedPluginsMoveDown.Text = "Move &down";
      this.menuListAssignedPluginsMoveDown.Click += new System.EventHandler(this.menuListAssignedPluginsMoveDown_Click);
      // 
      // menuListAssignedPluginsConfigure
      // 
      this.menuListAssignedPluginsConfigure.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
      this.menuListAssignedPluginsConfigure.Image = global::OptimusUI.Properties.Resources.plugin_edit;
      this.menuListAssignedPluginsConfigure.Name = "menuListAssignedPluginsConfigure";
      this.menuListAssignedPluginsConfigure.Size = new System.Drawing.Size(140, 22);
      this.menuListAssignedPluginsConfigure.Text = "&Configure";
      this.menuListAssignedPluginsConfigure.Click += new System.EventHandler(this.menuListAssignedPluginsConfigure_Click);
      // 
      // menuListAssignedPluginsUnassign
      // 
      this.menuListAssignedPluginsUnassign.Image = global::OptimusUI.Properties.Resources.plugin_link_break;
      this.menuListAssignedPluginsUnassign.Name = "menuListAssignedPluginsUnassign";
      this.menuListAssignedPluginsUnassign.Size = new System.Drawing.Size(152, 22);
      this.menuListAssignedPluginsUnassign.Text = "&Remove";
      this.menuListAssignedPluginsUnassign.Click += new System.EventHandler(this.menuListAssignedPluginsUnassign_Click);
      // 
      // PluginManagerControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.buttonPluginUnassign);
      this.Controls.Add(this.labelPluginAuthorValue);
      this.Controls.Add(this.labelPluginAuthor);
      this.Controls.Add(this.picturePluginLogo);
      this.Controls.Add(this.buttonAssignedPluginConfig);
      this.Controls.Add(this.labelPluginDescriptionValue);
      this.Controls.Add(this.labelPluginNameValue);
      this.Controls.Add(this.labelPluginName);
      this.Controls.Add(this.listAvailablePlugins);
      this.Controls.Add(this.buttonPluginAssign);
      this.Controls.Add(this.buttonPluginInstanceDelete);
      this.Controls.Add(this.buttonPluginInstanceAdd);
      this.Controls.Add(this.buttonPluginConfig);
      this.Controls.Add(this.buttonPluginDown);
      this.Controls.Add(this.buttonPluginUp);
      this.Controls.Add(this.buttonManageLayouts);
      this.Controls.Add(this.listLayouts);
      this.Controls.Add(this.listAssignedPlugins);
      this.DoubleBuffered = true;
      this.Name = "PluginManagerControl";
      this.Size = new System.Drawing.Size(557, 401);
      this.menuListAvailablePlugins.ResumeLayout(false);
      this.menuListAssignedPlugins.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.picturePluginLogo)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button buttonPluginUnassign;
    private System.Windows.Forms.Label labelPluginAuthorValue;
    private System.Windows.Forms.Label labelPluginAuthor;
    private System.Windows.Forms.PictureBox picturePluginLogo;
    private System.Windows.Forms.Button buttonAssignedPluginConfig;
    private System.Windows.Forms.Label labelPluginDescriptionValue;
    private System.Windows.Forms.Label labelPluginNameValue;
    private System.Windows.Forms.Label labelPluginName;
    private System.Windows.Forms.ListView listAvailablePlugins;
    private System.Windows.Forms.ColumnHeader columnHeader3;
    private System.Windows.Forms.Button buttonPluginAssign;
    private System.Windows.Forms.Button buttonPluginInstanceDelete;
    private System.Windows.Forms.Button buttonPluginInstanceAdd;
    private System.Windows.Forms.Button buttonPluginConfig;
    private System.Windows.Forms.Button buttonPluginDown;
    private System.Windows.Forms.Button buttonPluginUp;
    private System.Windows.Forms.Button buttonManageLayouts;
    private System.Windows.Forms.ListView listLayouts;
    private System.Windows.Forms.ColumnHeader columnHeader1;
    private System.Windows.Forms.ListView listAssignedPlugins;
    private System.Windows.Forms.ColumnHeader columnHeader2;
    private System.Windows.Forms.ImageList imagesCommon;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.ContextMenuStrip menuListAvailablePlugins;
    private System.Windows.Forms.ToolStripMenuItem menuListAvailablePluginsAssign;
    private System.Windows.Forms.ToolStripMenuItem menuListAvailablePluginsConfigure;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem menuListAvailablePluginsCreateInstance;
    private System.Windows.Forms.ToolStripMenuItem menuListAvailablePluginsDeleteInstance;
    private System.Windows.Forms.ContextMenuStrip menuListAssignedPlugins;
    private System.Windows.Forms.ToolStripMenuItem menuListAssignedPluginsMoveUp;
    private System.Windows.Forms.ToolStripMenuItem menuListAssignedPluginsMoveDown;
    private System.Windows.Forms.ToolStripMenuItem menuListAssignedPluginsConfigure;
    private System.Windows.Forms.ToolStripMenuItem menuListAssignedPluginsUnassign;
  }
}

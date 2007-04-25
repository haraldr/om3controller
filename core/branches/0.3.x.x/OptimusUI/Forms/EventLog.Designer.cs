namespace OptimusUI.Forms
{
  partial class EventLog
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
      System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("19:12");
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventLog));
      this.listEvents = new System.Windows.Forms.ListView();
      this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
      this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
      this.imagesEventList = new System.Windows.Forms.ImageList(this.components);
      this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
      this.SuspendLayout();
      // 
      // listEvents
      // 
      this.listEvents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
      this.listEvents.FullRowSelect = true;
      this.listEvents.HideSelection = false;
      listViewItem2.StateImageIndex = 0;
      this.listEvents.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
      this.listEvents.Location = new System.Drawing.Point(12, 118);
      this.listEvents.Name = "listEvents";
      this.listEvents.Size = new System.Drawing.Size(493, 292);
      this.listEvents.StateImageList = this.imagesEventList;
      this.listEvents.TabIndex = 0;
      this.listEvents.UseCompatibleStateImageBehavior = false;
      this.listEvents.View = System.Windows.Forms.View.Details;
      // 
      // columnHeader1
      // 
      this.columnHeader1.Text = "Time";
      this.columnHeader1.Width = 89;
      // 
      // columnHeader2
      // 
      this.columnHeader2.Text = "Plugin";
      this.columnHeader2.Width = 109;
      // 
      // imagesEventList
      // 
      this.imagesEventList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagesEventList.ImageStream")));
      this.imagesEventList.TransparentColor = System.Drawing.Color.Transparent;
      this.imagesEventList.Images.SetKeyName(0, "information.png");
      this.imagesEventList.Images.SetKeyName(1, "warning.png");
      this.imagesEventList.Images.SetKeyName(2, "error.png");
      // 
      // columnHeader3
      // 
      this.columnHeader3.Text = "Description";
      this.columnHeader3.Width = 260;
      // 
      // EventLog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(601, 422);
      this.Controls.Add(this.listEvents);
      this.Name = "EventLog";
      this.Text = "EventLog";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ListView listEvents;
    private System.Windows.Forms.ColumnHeader columnHeader1;
    private System.Windows.Forms.ColumnHeader columnHeader2;
    private System.Windows.Forms.ImageList imagesEventList;
    private System.Windows.Forms.ColumnHeader columnHeader3;
  }
}
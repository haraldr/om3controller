using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Toolz.OptimusMini;


namespace OptimusUI.Forms
{
  public partial class Start : Form
  {

    public Start()
    {
      InitializeComponent();
    }


    private void ResetControls()
    {
      labelTitle.Text = "om3 controller is loading ...";
      labelStatus.Text = "";
      progressBar.Value = 0;
      progressBar.Maximum = 6;
    }


    public void Init()
    {
      ResetControls();
      this.Show();

      labelStatus.Text = "Loading configuration";
      this.Update();
      Program.Configuration = new OptimusMiniSettings();
      progressBar.Increment(1);

      labelStatus.Text = "Loading available plugins";
      this.Update();
      Program.PluginBrowser = new OptimusMiniPluginBrowser();
      progressBar.Increment(1);
      
      labelStatus.Text = "Initializing device";
      this.Update();
      Program.Device = new OptimusMiniController();
      progressBar.Increment(1);
      
      labelStatus.Text = "Initializing plugin manager";
      this.Update();
      Program.PluginManager = new Toolz.OptimusMini.Plugins.PluginManager(Program.Device);
      progressBar.Increment(1);
      
      labelStatus.Text = "Validating configuration";
      this.Update();
      // TODO
      Program.Device.SetPluginManager(Program.PluginManager);
      progressBar.Increment(1);

      labelStatus.Text = "Connecting to device";
      this.Update();
      Program.Device.Init();
      progressBar.Increment(1);

      this.Hide();
      this.notifyIcon.Visible = true;
    }


    private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      Program.ShowMain();
    }

    private void showToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Program.ShowMain();
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Program.Terminate();
    }

  }
}
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
  public partial class Main : Form
  {
    public Main()
    {
      InitializeComponent();
      controlPluginManager.Init(Program.PluginManager, Program.PluginBrowser, Program.Configuration);

      Program.Device.OnConnectionStateChanged += new Toolz.OptimusMini.OptimusMiniConnectionStateChangedEventHandler(OnConnectionStateChanged);
      UpdateActions();
    }

    void OnConnectionStateChanged(OptimusMiniController sender, bool connected)
    {
      UpdateActions();
    }


    private void UpdateActions()
    {
      if (Program.Device.IsConnected)
      {
        statusMainConnection.Image = Properties.Resources.connect;
        statusMainConnection.Text = "Connected";
        statusMainConnectionDisconnect.Visible = true;
        statusMainConnectionConnect.Visible = false;
      }
      else
      {
        statusMainConnection.Image = Properties.Resources.disconnect;
        statusMainConnection.Text = "Disconnected";
        statusMainConnectionDisconnect.Visible = false;
        statusMainConnectionConnect.Visible = true;        
      }
    }

    private void Main_FormClosing(object sender, FormClosingEventArgs e)
    {
      e.Cancel = true;
      Program.HideMain();
    }

    private void Main_Resize(object sender, EventArgs e)
    {
      if (WindowState == FormWindowState.Minimized)
      {
        Program.HideMain();
      }
    }

    private void menuMainFileExit_Click(object sender, EventArgs e)
    {
      Program.Terminate();
    }

  }
}
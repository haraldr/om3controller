using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

using Toolz.OptimusMini;
using Toolz.OptimusMini.Plugins;


namespace OptimusUI
{
  static class Program
  {

    private static OptimusMiniController _Device;
    private static OptimusMiniSettings _Configuration;
    private static OptimusMiniPluginBrowser _PluginBrowser;
    private static PluginManager _PluginManager;

    private static Forms.Start _StartForm;
    private static Forms.Main _MainForm;


    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      _StartForm = new OptimusUI.Forms.Start();

      Init();
      HideMain();

      Application.Run();
    }


    private static void Init()
    {
      _StartForm.Init();
      _Device.OnNotification += new OptimusMiniNotificationEventHandler(_Device_OnNotification);
    }

    static void _Device_OnNotification(OptimusMiniController sender, OptimusMiniEventLog notification)
    {
      ShowErrorNotification(notification.Summary);
    }


    internal static void Terminate()
    {
      _Device.Terminate();
      _Configuration.Save();
      Application.ExitThread();
    }


    public static void HideMain()
    {
      if (_MainForm != null)
      {
        _MainForm.Hide();
        _MainForm.ShowInTaskbar = false;
      }
    }


    public static void ShowMain()
    {
      if (_MainForm == null)
      {
        _MainForm = new OptimusUI.Forms.Main();
      }
      _MainForm.ShowInTaskbar = true;
      _MainForm.Show();
      _MainForm.WindowState = FormWindowState.Normal;
      _MainForm.Focus();
    }


    public static void ShowErrorNotification(string text)
    {
      _StartForm.notifyIcon.ShowBalloonTip(5000, "Error", text, ToolTipIcon.Error);
    }


    public static OptimusMiniController Device
    {
      get { return _Device; }
      set { _Device = value; }
    }


    public static OptimusMiniSettings Configuration
    {
      get { return _Configuration; }
      set { _Configuration = value; }
    }


    public static OptimusMiniPluginBrowser PluginBrowser
    {
      get { return _PluginBrowser; }
      set { _PluginBrowser = value; }
    }


    public static PluginManager PluginManager
    {
      get { return _PluginManager; }
      set { _PluginManager = value; }
    }

  }
}
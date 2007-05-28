using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading;


namespace Toolz.OptimusMini.Plugins
{

  public class PluginManager
  {
    private OptimusMiniController _Controller;
    public PluginLayout _DefaultLayout;
    private List<PluginLayout> _Layouts;
    private List<PluginInstance> _PluginInstances;


    private OptimusMiniPluginBrowser _Browser;
    private int _LastRotate;


    public PluginManager(OptimusMiniController controller)
    {
      _Controller = controller;
      _Layouts = new List<PluginLayout>();
      _DefaultLayout = new PluginLayout();
      _PluginInstances = new List<PluginInstance>();
      _Browser = new OptimusMiniPluginBrowser();
      _LastRotate = Environment.TickCount;
    }


    public void Init()
    {
      for (int i = 0; i <= _PluginInstances.Count; i++)
      {
        if (i > 2) { break; }
        if (_PluginInstances[i] != null)
        {
          _PluginInstances[i]._Worker.Repaint();
        }
      }
    }


    public int AssignPlugin(
      string pluginId,
      string layoutId,
      OptimusMiniSettingsList settings)
    {
      OptimusMiniPluginBase lPlugin = _Browser.GetPluginById(pluginId);
      
      PluginInstance lInstance = new PluginInstance();
      lInstance._Plugin = lPlugin;
      lInstance._Worker = lPlugin.CreateWorker();

      lock (_PluginInstances)
      {
        lock (_DefaultLayout)
        {
          _PluginInstances.Add(lInstance);
          _DefaultLayout._PluginInstances.Add(lInstance);
        }
      }

      lInstance._Worker.Initialize(settings);
      lInstance._Worker.Repaint();

      return 0;
    }


    public int UnassignPlugin(
      string pluginId,
      string layoutId,
      OptimusMiniSettingsList settings)
    {
      PluginInstance lInstance = null;
      bool lInstanceFound = false;

      lock (_PluginInstances)
      {
        lock (_DefaultLayout)
        {
          for (int i = 0; i < _PluginInstances.Count; i++)
          {
            lInstance = _PluginInstances[i];
            if (lInstance._Plugin.Id == pluginId)
            {
              _PluginInstances.RemoveAt(i);
              lInstanceFound = true;
              break;
            }
          }

          for (int i = 0; i < _DefaultLayout._PluginInstances.Count; i++)
          {
            if (_DefaultLayout._PluginInstances[i]._Id == pluginId)
            {
              _DefaultLayout._PluginInstances.RemoveAt(i);
              break;
            }
          }
        }
      }

      if (lInstanceFound)
      {
        //lInstance._Worker.Terminate();
      }

      return 0;
    }



    /// <summary>
    /// Assigns passed plugin to specified key.
    /// </summary>
    /// <param name="index">0-based index of key.</param>
    /// <param name="plugin">Plugin to assign.</param>
    /// <returns>0 if successful, otherwise an error code.</returns>
    public int AddPlugin(byte index, OptimusMiniPluginWorkerBase plugin, OptimusMiniSettingsList settings)
    {

      // ----- If there's already a plugin assigned remove it
      RemovePlugin(index);


      // ----- Add new plugin
      PluginInstance lInstance = new PluginInstance();
      lInstance._Worker = plugin;
      _PluginInstances[index] = lInstance;
      plugin.Initialize(settings);
      plugin.Repaint();


      // ----- Result
      return 0;
    }


    /// <summary>
    /// Removes all plugins.
    /// </summary>
    /// <returns>0 if successful, otherwise an error code.</returns>
    public int RemovePlugin()
    {
      for (byte i = 0; i <= 2; i++)
      {
        RemovePlugin(i);
      }
      return 0;
    }


    /// <summary>
    /// Removes plugin from specified key.
    /// </summary>
    /// <param name="index">0-based index of key.</param>
    /// <returns>0 if successful, otherwise an error code.</returns>
    public int RemovePlugin(byte index)
    {

      if (_PluginInstances[index] != null)
      {
        OptimusMiniPluginWorkerBase lCurrentPlugin = _PluginInstances[index]._Worker;
        _PluginInstances[index] = null;

        // Tell plugin to stop working

        // Terminate
        lCurrentPlugin.Terminate();
      }

      return 0;

    }


    internal void KeyDown(byte index)
    {
      if (_PluginInstances[index] != null)
      {
        ThreadPool.QueueUserWorkItem(new WaitCallback(_PluginInstances[index]._Worker.OnKeyDown));
      }
    }

    internal void KeyUp(byte index)
    {
      if (_PluginInstances[index] != null)
      {
        ThreadPool.QueueUserWorkItem(new WaitCallback(_PluginInstances[index]._Worker.OnKeyUp));
      }
    }

    internal void KeyHold(byte index)
    {
      if (_PluginInstances[index] != null)
      {
        ThreadPool.QueueUserWorkItem(new WaitCallback(_PluginInstances[index]._Worker.OnKeyHold));
      }
    }

    internal void KeyRelease(byte index)
    {
      if (_PluginInstances[index] != null)
      {
        ThreadPool.QueueUserWorkItem(new WaitCallback(_PluginInstances[index]._Worker.OnKeyRelease));
      }
    }

    internal void KeyPress(byte index)
    {
      if (_PluginInstances[index] != null)
      {
        ThreadPool.QueueUserWorkItem(new WaitCallback(_PluginInstances[index]._Worker.OnKeyPress));
      }
    }

    internal void KeyDoublePress(byte index)
    {
      if (_PluginInstances[index] != null)
      {
        ThreadPool.QueueUserWorkItem(new WaitCallback(_PluginInstances[index]._Worker.OnKeyDoublePress));
      }
    }


    internal void Update()
    {
      if (_PluginInstances.Count == 0) { return; }

      int lCurrentTicks = Environment.TickCount;

      lock (_PluginInstances)
      {
        // Time to rotate?
        bool lRotated = false;
        if (lCurrentTicks - _LastRotate >= 30000)
        {
          if (_PluginInstances.Count > 3)
          {
            PluginInstance lInstanceToMove = _PluginInstances[0];
            _PluginInstances.RemoveAt(0);
            _PluginInstances.Add(lInstanceToMove);
          }
          _LastRotate = lCurrentTicks;
          lRotated = true;
        }

        for (int i = 0; i < _PluginInstances.Count; i++)
        {
          PluginInstance lInstance = _PluginInstances[i];
          OptimusMiniPluginWorkerBase lWorker = lInstance._Worker;

          // Check for updated image
          if (i <= 2 && lWorker._Bitmap != null && (lRotated || (lWorker._BitmapUpdated > lWorker._BitmapPainted)))
          {
            lWorker._BitmapPainted = Environment.TickCount;
            Bitmap lBitmap = lWorker._Bitmap;
            _Controller.ShowImage((byte)i, lBitmap);
          }

          // Check for events
          List<OptimusMiniEventLog> lEvents = lWorker.GetEventLog();
          if (lEvents != null)
          {
            foreach (OptimusMiniEventLog lEvent in lEvents)
            {
              _Controller.RaiseNotification(lEvent);
            }
          }

          // Start update
          if (lWorker.IsNextUpdateDue())
          {
            ThreadPool.QueueUserWorkItem(new WaitCallback(lWorker.Update));
          }
        }

        //if (_PluginInstances.Count < 3)
        //{
        //  for (int i = _PluginInstances.Count - 1; i < 3; i++)
        //  {
        //    _Controller.ClearImage((byte)i);
        //  }
        //}

      }
    }

  }


  public class PluginLayoutCollection
  {

    private PluginManager _Owner;


    public PluginLayoutCollection(PluginManager owner)
    {
      _Owner = owner;
    }


    //public int Add(PluginLayout layout)
    //{
    //}


    //public int Remove(string layoutId)
    //{
    //}


    //public int RemoveAt(int index)
    //{
    //}


    //public int Count
    //{
    //  get { return _Layouts.Count; }
    //}

  }


  public enum PluginLayoutApplicationType
  {
    WindowTitle,
    ProcessName
  }


  public class PluginLayoutApplication
  {
    private string _Name;
    private string _Path;


  }


  public class PluginLayout
  {
    public const string DEFAULT_ID = "default";

    public string _Id;
    public string _Name;
    public List<PluginInstance> _PluginInstances;


    public PluginLayout()
    {
      _PluginInstances = new List<PluginInstance>();
    }

  }


  public class PluginInstance
  {
    public string _Id;
    public OptimusMiniPluginBase _Plugin;
    public OptimusMiniPluginWorkerBase _Worker;
  }


  public class PluginLayoutInstanceLink
  {

  }

}
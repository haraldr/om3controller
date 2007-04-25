/*
The contents of this file are subject to the Mozilla Public License
Version 1.1 (the "License"); you may not use this file except in
compliance with the License. You may obtain a copy of the License at
http://www.mozilla.org/MPL/

Software distributed under the License is distributed on an "AS IS"
basis, WITHOUT WARRANTY OF ANY KIND, either express or implied. See the
License for the specific language governing rights and limitations
under the License.

The Original Code is om3 controller library, UI and various plugins.

The Initial Developer of the Original Code is Harald Röxeisen.
Portions created by the initial developer are Copyright (C) 2007
the initial developer. All Rights Reserved.

Contributor(s): Harald Röxeisen.
*/


using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;


namespace Toolz.OptimusMini
{

  /// <summary>
  /// Provides access to available plugins.
  /// </summary>
  public class OptimusMiniPluginBrowser
  {

    private string _Path;
    private List<OptimusMiniPluginBase> _Plugins;


    /// <summary>
    /// Creates a new instance of the <see cref="OptimusMiniPluginBrowser" /> class and returns it.
    /// </summary>
    public OptimusMiniPluginBrowser()
    {
      _Path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins");
      _Plugins = LoadPlugins();
    }


    /// <summary>
    /// Creates a new instance of the <see cref="OptimusMiniPluginBrowser" /> class and returns it.
    /// </summary>
    /// <param name="path">The file path to look for plugins.</param>
    public OptimusMiniPluginBrowser(string path)
    {
      _Path = path;
      _Plugins = LoadPlugins();
    }


    /// <summary>
    /// Returns a list available plugins.
    /// </summary>
    private List<OptimusMiniPluginBase> LoadPlugins()
    {

      List<OptimusMiniPluginBase> lResult = new List<OptimusMiniPluginBase>();


      // ----- Open folder
      DirectoryInfo lFolder = new DirectoryInfo(_Path);
      if (!lFolder.Exists) { return lResult; }


      // ----- Get list of assemblies in this folder
      FileInfo[] lFiles = lFolder.GetFiles("*.dll");
      if (lFiles == null || lFiles.Length == 0) { return lResult; }


      // ----- Check each assembly if it contains one or more plugins
      foreach (FileInfo lFile in lFiles)
      {
        try
        {
          Assembly lAssembly = Assembly.Load(AssemblyName.GetAssemblyName(lFile.FullName));
          Type[] lTypes = lAssembly.GetTypes();

          // Check each type if it's a class inherited from plugin base
          foreach (Type lType in lTypes)
          {
            if (lType.IsSubclassOf(typeof(OptimusMiniPluginBase)))
            {
              // That's a plugin, add it to result
              OptimusMiniPluginBase lPlugin = Activator.CreateInstance(lType) as OptimusMiniPluginBase;
              lResult.Add(lPlugin);
            }
          }
        }
        catch (FileLoadException)
        {
        }
        catch (BadImageFormatException)
        {
        }
      }


      // ----- Result
      return lResult;

    }


    /// <summary>
    /// Returns plugin with the specified id.
    /// </summary>
    /// <param name="id">Id of plugin.</param>
    /// <returns>Plugin or null if not found.</returns>
    public OptimusMiniPluginBase GetPluginById(string id)
    {
      foreach (OptimusMiniPluginBase lPlugin in _Plugins)
      {
        if (lPlugin.Id == id) { return lPlugin; }
      }

      return null;
    }


    /// <summary>
    /// Returns 0-based index of plugin with specified id.
    /// </summary>
    /// <param name="id">Id of plugin.</param>
    /// <returns>0-based index of plugin or -1 if not found.</returns>
    public int GetIndexById(string id)
    {
      for (int i = 0; i < _Plugins.Count; i++)
      {
        if (_Plugins[i].Id == id) { return i; }
      }

      return -1;
    }


    /// <summary>
    /// Gets number of available plugins.
    /// </summary>
    public int Count
    {
      get { return _Plugins.Count; }
    }


    /// <summary>
    /// Gets plugin by index.
    /// </summary>
    /// <param name="index">0-based index of plugin.</param>
    /// <returns>Plugin at the specified index.</returns>
    public OptimusMiniPluginBase this[int index]
    {
      get { return _Plugins[index]; }
    }

  }

}
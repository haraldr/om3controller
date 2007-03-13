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
using System.Windows.Forms;


namespace Toolz.OptimusMini
{

  /// <summary>
  /// Base class to provide base information of a plugin.
  /// </summary>
  public abstract class OptimusMiniPluginBase
  {

    protected string _Id;
    protected string _Name;
    protected string _Description;
    protected string _Author;
    protected bool _IsConfigurable;


    /// <summary>
    /// Creates a new instance of the <see cref="OptimusMiniPlugin" /> class and returns it.
    /// </summary>
    protected OptimusMiniPluginBase()
    {
    }


    /// <summary>
    /// Gets unique id.
    /// </summary>
    public string Id
    {
      get { return _Id; }
    }


    /// <summary>
    /// Gets name.
    /// </summary>
    public string Name
    {
      get { return _Name; }
    }


    /// <summary>
    /// Gets description.
    /// </summary>
    public string Description
    {
      get { return _Description; }
    }


    /// <summary>
    /// Gets author.
    /// </summary>
    public string Author
    {
      get { return _Author; }
    }


    /// <summary>
    /// Gets flag if plugin can be configured.
    /// </summary>
    public bool IsConfigurable
    {
      get { return _IsConfigurable; }
    }


    /// <summary>
    /// Creates a new instance of a <see cref="OptimusMiniPluginWorkerBase" /> class and returns it.
    /// </summary>
    /// <returns></returns>
    public abstract OptimusMiniPluginWorkerBase CreateWorker();


    /// <summary>
    /// Creates a new instance of the configuration form and returns it.
    /// </summary>
    /// <param name="currentSettings">Current settings.</param>
    public virtual Form CreateConfiguration(OptimusMiniSettingsList currentSettings)
    {
      return null;
    }

  }

}
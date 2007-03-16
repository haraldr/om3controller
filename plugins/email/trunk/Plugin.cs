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
using System.Windows.Forms;
using Toolz.OptimusMini;


namespace EmailNotifierPlugin
{

  public class EmailPlugin : OptimusMiniPluginBase
  {

    public EmailPlugin()
      : base()
    {
      base._Id = "81A493D2-81A7-44ca-A302-3DA48EAF4D08";
      base._Name = "Email notifier";
      base._Description = "Notifies when you got new emails.";
      base._Author = "Harald Röxeisen";
      base._IsConfigurable = true;
    }


    public override OptimusMiniPluginWorkerBase CreateWorker()
    {
      return new EmailPluginWorker();
    }


    public override Form CreateConfiguration(OptimusMiniSettingsList currentSettings)
    {
      return new Config(currentSettings);
    }

  }

}
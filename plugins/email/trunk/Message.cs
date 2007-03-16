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

namespace EmailNotifierPlugin
{

  internal class Message
  {
    private string _Id;
    private DateTime _Recevied;
    private string _From;
    private string _Subject;
    private bool _Read;


    public string Id
    {
      get { return _Id; }
      set { _Id = value; }
    }


    public DateTime Recevied
    {
      get { return _Recevied; }
      set { _Recevied = value; }
    }


    public string From
    {
      get { return _From; }
      set { _From = value; }
    }


    public string Subject
    {
      get { return _Subject; }
      set { _Subject = value; }
    }


    public bool Read
    {
      get { return _Read; }
      set { _Read = value; }
    }
  }

}
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

  internal enum AccountType
  {
    Pop3
  }


  internal abstract class AccountBase
  {

    private string _Server;
    private string _User;
    private string _Password;
    private AccountType _Type;
    private string _Execute;
    private int _MessageCount;


    public string Server
    {
      get { return _Server; }
      set { _Server = value; }
    }


    public string User
    {
      get { return _User; }
      set { _User = value; }
    }


    public string Password
    {
      get { return _Password; }
      set { _Password = value; }
    }


    public AccountType Type
    {
      get { return _Type; }
      set { _Type = value; }
    }


    public string Execute
    {
      get { return _Execute; }
      set { _Execute = value; }
    }


    public int MessageCount
    {
      get { return _MessageCount; }
      set { _MessageCount = value; }
    }


    public abstract List<Message> GetNewMessages();

  }

}
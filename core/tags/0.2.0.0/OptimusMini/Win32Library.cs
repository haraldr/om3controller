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
using System.Runtime.InteropServices;


namespace Toolz.OptimusMini
{

  /// <summary>
  /// Contains imported win32 methods.
  /// </summary>
  internal class Win32Library
  {

    [DllImport("User32.dll")]
    private static extern bool GetLastInputInfo(ref LastInputInfo lastInputInfo);
    private struct LastInputInfo
    {
      public static readonly int SizeOf = Marshal.SizeOf(typeof(LastInputInfo));

      [MarshalAs(UnmanagedType.U4)]
      public int Size;
      [MarshalAs(UnmanagedType.U4)]
      public int Time;
    }


    /// <summary>
    /// Returns the user idle time in seconds.
    /// </summary>
    /// <returns>User idle time in seconds.</returns>
    public static int GetUserIdleTime()
    {

      LastInputInfo lInfo = new LastInputInfo();
      lInfo.Size = LastInputInfo.SizeOf;

      if (GetLastInputInfo(ref lInfo))
      {
        int lEnvTicks = Environment.TickCount;
        int lIdleTicks = lEnvTicks - lInfo.Time;
        return (lIdleTicks / 1000);
      }
      else
      {
        return 0;
      }

    }

  }

}
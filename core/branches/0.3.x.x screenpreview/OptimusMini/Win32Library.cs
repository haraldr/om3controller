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
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace Toolz.OptimusMini
{

      //  _hookID = SetHook(_proc);
      //Application.Run();
      //UnhookWindowsHookEx(_hookID);


  /// <summary>
  /// Contains imported win32 methods.
  /// </summary>
  internal class Win32Library
  {

    private const int WH_KEYBOARD_LL = 13;
    private const int WM_KEYDOWN = 0x0100;
    private const int WM_KEYUP = 0x101;
    private const int WM_SYSKEYDOWN = 0x0104;
    private const int WM_SYSKEYUP = 0x0105;

    private static LowLevelKeyboardProc _proc = HookCallback;
    private static IntPtr _hookID = IntPtr.Zero;

    private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

    private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
    {
      //if (nCode >= 0)
      //{
      //  int vkCode = Marshal.ReadInt32(lParam);
      //  Keys lKey = (Keys)vkCode;
      //  Console.WriteLine((Keys)vkCode);

      //  if (wParam == (IntPtr)WM_KEYDOWN || wParam == (IntPtr)WM_SYSKEYDOWN)
      //  {
      //    if (_Pressed.IndexOf(lKey) == -1)
      //    {
      //      _Pressed.Add(lKey);
      //    }
      //  }
      //  else if (wParam == (IntPtr)WM_KEYUP || wParam == (IntPtr)WM_SYSKEYUP)
      //  {
      //    int lIndex = _Pressed.IndexOf(lKey);
      //    if (lIndex != -1) { _Pressed.RemoveAt(lIndex); }
      //  }

      //  // Currently pressed
      //  //Console.Clear();
      //  //foreach (Keys key in _Pressed)
      //  //{
      //  //  Console.Write(key.ToString() + "+");
      //  //}
      //}

      return CallNextHookEx(_hookID, nCode, wParam, lParam);
    }

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

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool UnhookWindowsHookEx(IntPtr hhk);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr GetModuleHandle(string lpModuleName);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr GetForegroundWindow();

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern Int32 GetWindowThreadProcessId(IntPtr hWnd, out Int32 lpdwProcessId);


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


    /// <summary>
    /// Gets the process of the currently active window.
    /// </summary>
    /// <returns>Process of the currently active window.</returns>
    public static Process GetActiveProcess()
    {
      int lProcessId;
      GetWindowThreadProcessId(GetForegroundWindow(), out lProcessId);
      return Process.GetProcessById(lProcessId);
    }

  }

}
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


namespace Toolz.OptimusMini
{

  /// <summary>
  /// Holds data to handle key states.
  /// </summary>
  internal class OptimusMiniKeyState
  {

    private OptimusMiniController _Owner;
    private byte _KeyIndex;
    private int _LastKeyDownOn;
    private int _LastKeyUpOn;
    private int _DownOn;
    private bool _IsDown;
    private bool _IsHold;
    private bool _WaitForPress;
    private bool _WaitForDoublePress;


    public OptimusMiniKeyState(OptimusMiniController owner, byte keyIndex)
    {
      _Owner = owner;
      _KeyIndex = keyIndex;
      _LastKeyDownOn = 0;
      _LastKeyUpOn = 0;
      _DownOn = 0;
    }


    private byte KeyIndex
    {
      get { return _KeyIndex; }
    }


    private void ResetLastKeyDownAgo()
    {
      _LastKeyDownOn = Environment.TickCount;
    }


    private void ResetLastKeyUpAgo()
    {
      _LastKeyUpOn = Environment.TickCount;
    }


    private void ResetDownSince()
    {
      _DownOn = Environment.TickCount;
    }


    private long LastKeyDownAgo
    {
      get { return Environment.TickCount - _LastKeyDownOn; }
    }


    private long LastKeyUpAgo
    {
      get { return Environment.TickCount - _LastKeyUpOn; }
    }


    private long DownSince
    {
      get { return Environment.TickCount - _DownOn; }
    }


    private bool IsDown
    {
      get { return _IsDown; }
      set { _IsDown = value; }
    }


    private bool IsHold
    {
      get { return _IsHold; }
      set { _IsHold = value; }
    }


    private bool WaitForPress
    {
      get { return _WaitForPress; }
      set { _WaitForPress = value; }
    }


    private bool WaitForDoublePress
    {
      get { return _WaitForDoublePress; }
      set { _WaitForDoublePress = value; }
    }


    public void Update(bool pDown)
    {

      // ----- Reset time span of last down event
      if (pDown) { this.ResetLastKeyDownAgo(); }


      // ----- Was not down previously
      if (pDown && !IsDown)
      {
        IsDown = true;
        IsHold = false;
        WaitForPress = false;
        ResetDownSince();
        _Owner.RaiseKeyDown(KeyIndex);
      }


      // ----- Check if held (down since 500ms)
      if (IsDown && !IsHold && DownSince >= 500)
      {
        IsHold = true;
        WaitForPress = false;
        WaitForDoublePress = false;
        _Owner.RaiseKeyHold(KeyIndex);
      }


      // ----- Check if up (no down since 50ms)
      if (IsDown && LastKeyDownAgo >= 50)
      {
        _Owner.RaiseKeyUp(KeyIndex);

        if (!IsHold)
        {
          // Was not held down before
          if (!WaitForDoublePress)
          {
            // Down/up can become a press or double press
            WaitForPress = true;
            WaitForDoublePress = true;
          }
          else
          {
            // We were waiting for a second down/up within 250ms
            if (LastKeyUpAgo < 250)
            {
              _Owner.RaiseKeyDoublePress(KeyIndex);
            }
            WaitForPress = false;
            WaitForDoublePress = false;
          }
        }
        else
        {
          // Was held down before, raise release
          _Owner.RaiseKeyRelease(KeyIndex);
        }

        IsDown = false;
        IsHold = false;
        ResetLastKeyUpAgo();
      }


      // ----- Check if press (down/up occurred 250ms ago)
      if (WaitForPress)
      {
        if (LastKeyDownAgo >= 250 && LastKeyUpAgo >= 250)
        {
          WaitForPress = false;
          WaitForDoublePress = false;
          _Owner.RaiseKeyPress(KeyIndex);
        }
      }

    }

  }

}
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

The Initial Developer of the Original Code is Harald R�xeisen.
Portions created by the initial developer are Copyright (C) 2007
the initial developer. All Rights Reserved.

Contributor(s): Harald R�xeisen.
*/


using System;
using System.Collections.Generic;
using System.Text;


namespace Toolz.OptimusMini
{

  /// <summary>
  /// Specifies layout of the device.
  /// </summary>
  public enum OptimusMiniLayout
  {
    /// <summary>
    /// USB cable is at the left side.
    /// </summary>
    Left,

    /// <summary>
    /// USB cable is at the right side.
    /// </summary>
    Right,

    /// <summary>
    /// USB cable is at the top side.
    /// </summary>
    Up,

    /// <summary>
    /// USB cable is at the bottom side.
    /// </summary>
    Down
  }

}
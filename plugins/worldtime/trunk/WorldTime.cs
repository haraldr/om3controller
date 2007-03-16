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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;
using Toolz.OptimusMini;


namespace Worldtime
{

  public class TimezoneItem
  {
    public TimeZoneInformation Timezone;
    public string Label;

    public TimezoneItem(TimeZoneInformation timezone, string label)
    {
      Timezone = timezone;
      Label = label;
    }
  }

  public class WorldTimePlugin : OptimusMiniPluginBase
  {

    public WorldTimePlugin()
      : base()
    {
      _Id = "40D8A4FF-2B54-4cca-A243-2ECF2A8ABD37";
      _Name = "World time";
      _Description = "Displays the time in up to 5 different timezones.";
      _Author = "Harald Röxeisen";
      _IsConfigurable = true;
    }


    public override OptimusMiniPluginWorkerBase CreateWorker()
    {
      return new WorldTimePluginWorker();
    }


    public override Form CreateConfiguration(OptimusMiniSettingsList currentSettings)
    {
      return new WorldTimeConfig(currentSettings);
    }

  }

  public class WorldTimePluginWorker : OptimusMiniPluginWorkerBase
  {

    private Bitmap _Bitmap;
    private Graphics _Graphic;
    private TimezoneItem[] _Timezones;


    public WorldTimePluginWorker()
      : base()
    {
      _Bitmap = new Bitmap(96, 96, PixelFormat.Format16bppRgb565);
      _Graphic = Graphics.FromImage(_Bitmap);
    }


    public override void Initialize(OptimusMiniSettingsList currentSettings)
    {
      _Timezones = new TimezoneItem[5];

      for (int i = 0; i < 5; i++)
      {
        string lTimezone = currentSettings["Timezone" + i.ToString()];
        string lLabel = currentSettings["Label" + i.ToString()];

        if (lTimezone != "" && TimeZoneInformation.ContainsTimeZone(lTimezone))
        {
          TimezoneItem lItem = new TimezoneItem(TimeZoneInformation.GetTimeZone(lTimezone), lLabel);
          _Timezones[i] = lItem;
        }
        else
        {
          _Timezones[i] = null;
        }

      }

      RequestNextUpdate(new TimeSpan(0, 0, 0));
    }


    public override void Terminate()
    {
    }


    public override void Repaint()
    {
      DateTime lUtc = DateTime.UtcNow;

      lock (_Graphic)
      {
        _Graphic.FillRectangle(Brushes.Black, 0, 0, 96, 96);

        for (int i = 0; i < 5; i++)
        {
          TimezoneItem lItem = _Timezones[i];
          if (lItem == null) { continue; }

          string lTime = string.Format("{0} {1}", TimeZoneInformation.ToLocalTime(lUtc, lItem.Timezone.StandardName).ToShortTimeString(), lItem.Label);
          _Graphic.DrawString(lTime, SystemFonts.DefaultFont, Brushes.White, 0, i * 19);
        }

        _Graphic.Flush();
        UpdateImage(_Bitmap);
      }
    }


    private void Repaint_Timezone(TimeZoneInformation timezone,int y)
    {
    }


    public override void Update()
    {
      Repaint();
      RequestNextUpdate(new TimeSpan(0, 0, 60 - DateTime.Now.Second));
    }

  }


  /// <summary>
  /// Date: 12/4/2005
  /// Created By: William Stacey, MVP
  /// Used to convert to/from utc times and local times and respect DST.
  /// Can also covert between two local time zones.
  /// Information about a time zone containing methods to convert local times to and from UTC and
  /// between local time zones.
  /// </summary>
  public class TimeZoneInformation
  {
    #region Fields
    private TZI tzi; // Current time zone information.
    private string displayName; // Current time zone display name.
    private string standardName; // Current time zone standard name (non-DST).
    private string daylightName; // Current time zone daylight name (DST).
    private static readonly List<TimeZoneInformation> timeZones; // static list of all time zones on machine.
    #endregion

    #region Constructors
    private TimeZoneInformation()
    {
    }

    static TimeZoneInformation()
    {
      timeZones = new List<TimeZoneInformation>();

      using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Time Zones"))
      {
        string[] zoneNames = key.GetSubKeyNames();

        foreach (string zoneName in zoneNames)
        {
          using (RegistryKey subKey = key.OpenSubKey(zoneName))
          {
            TimeZoneInformation tzi = new TimeZoneInformation();
            tzi.displayName = (string)subKey.GetValue("Display");
            tzi.standardName = (string)subKey.GetValue("Std");
            tzi.daylightName = (string)subKey.GetValue("Dlt");
            tzi.InitTzi((byte[])subKey.GetValue("Tzi"));
            timeZones.Add(tzi);
          }
        }

        // Order list by offset
        timeZones.Sort(CompareByOffset);
      }
    }

    private static int CompareByOffset(TimeZoneInformation x, TimeZoneInformation y)
    {
      if (x.StandardOffset.TotalHours < y.StandardOffset.TotalHours)
      {
        return -1;
      }
      else if (x.StandardOffset.TotalHours > y.StandardOffset.TotalHours)
      {
        return 1;
      }
      else
      {
        return 0;
      }
    }

    #endregion

    #region Public Properties
    /// <summary>
    /// Gets list of all time zones defined on the current computer system.
    /// </summary>
    public static List<TimeZoneInformation> TimeZones
    {
      get
      {
        // Return a copy of the list.
        List<TimeZoneInformation> nList = new List<TimeZoneInformation>(timeZones);
        return nList;
      }
    }
    /// <summary>
    /// Gets an string array of standard time zone names supported on the current system.
    /// </summary>
    public static string[] TimeZoneNames
    {
      get
      {
        List<String> list = new List<String>();
        foreach (TimeZoneInformation tzi in timeZones)
        {
          list.Add(tzi.StandardName);
        }
        return list.ToArray();
      }
    }

    /// <summary>
    /// Gets the time zone information of the current computer system.
    /// </summary>
    public static TimeZoneInformation CurrentTimeZone
    {
      get
      {
        string tzn = TimeZone.CurrentTimeZone.StandardName;
        TimeZoneInformation tzi = TimeZoneInformation.GetTimeZone(tzn);
        return tzi;
      }
    }

    /// <summary>
    /// The time zone's name during 'standard' time (i.e. not daylight savings).
    /// </summary>
    public string StandardName
    {
      get
      {
        return standardName;
      }
    }

    /// <summary>
    /// The time zone's name during daylight savings time (DST).
    /// </summary>
    public string DaylightName
    {
      get
      {
        return daylightName;
      }
    }

    /// <summary>
    /// The time zone's display name (e.g. "(GMT-05:00) Eastern Time (US and Canada)").
    /// </summary>
    public string DisplayName
    {
      get
      {
        return displayName;
      }
    }

    /// <summary>
    /// Gets the standard offset from UTC as a TimeSpan.
    /// </summary>
    public TimeSpan StandardOffset
    {
      get
      {
        return TimeSpan.FromMinutes(StandardBias);
      }
    }

    /// <summary>
    /// Gets the daylight offset from UTC as a TimeSpan.
    /// </summary>
    public TimeSpan DaylightOffset
    {
      get
      {
        return TimeSpan.FromMinutes(DaylightBias);
      }
    }

    /// <summary>
    /// Gets the difference, in minutes, between UTC and local time.
    /// UTC = local time + bias.
    /// </summary>
    public int StandardBias
    {
      get
      {
        return -(tzi.bias + tzi.standardBias);
      }
    }

    /// <summary>
    /// Gets the difference, in minutes, between UTC and local time (in daylight savings time).
    /// UTC = local time + bias.
    /// </summary>
    public int DaylightBias
    {
      get
      {
        return -(tzi.bias + tzi.daylightBias);
      }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Returns standard name of this time zone instance.
    /// </summary>
    /// <returns>Time zone standard name.</returns>
    public override string ToString()
    {
      return this.standardName;
    }

    /// <summary>
    /// Returns a TimeZoneInformation instance for the time zone with supplied standard name.
    /// </summary>
    /// <param name="standardTimeZoneName">Standard name of the time zone.</param>
    /// <returns>TimeZoneInformation instance.</returns>
    /// <exception cref="ArgumentException">Thrown if name not found.</exception>
    public static TimeZoneInformation GetTimeZone(string standardTimeZoneName)
    {
      if (standardTimeZoneName == null)
        standardTimeZoneName = ".";
      if (standardTimeZoneName == ".")
        standardTimeZoneName = TimeZone.CurrentTimeZone.StandardName;

      foreach (TimeZoneInformation tzi in TimeZoneInformation.TimeZones)
      {
        if (tzi.StandardName.Equals(standardTimeZoneName, StringComparison.OrdinalIgnoreCase))
          return tzi;
      }
      throw new ArgumentException("standardTimeZoneName not found.");
    }


    /// <summary>
    /// Checks if the specified timezone exists.
    /// </summary>
    /// <param name="standardTimeZoneName">Standard name of the time zone.</param>
    /// <returns>Boolean indicating whether time zone exists or not.</returns>
    public static bool ContainsTimeZone(string standardTimeZoneName)
    {
      try
      {
        GetTimeZone(standardTimeZoneName);
        return true;
      }
      catch (ArgumentException)
      {
        return false;
      }
    }

    /// <summary>
    /// Converts the value of the utc time to a local time in this time zone.
    /// </summary>
    /// <param name="utc">The UTC time to convert.</param>
    /// <returns>The local time.</returns>
    public DateTime ToLocalTime(DateTime utc)
    {
      // Convert to SYSTEMTIME
      SYSTEMTIME stUTC = DateTimeToSystemTime(utc);

      // Set up the TIME_ZONE_INFORMATION
      TIME_ZONE_INFORMATION tziNative = TziNative();
      SYSTEMTIME stLocal;
      NativeMethods.SystemTimeToTzSpecificLocalTime(ref tziNative, ref stUTC, out stLocal);

      // Convert back to DateTime
      return SystemTimeToDateTime(ref stLocal);
    }

    /// <summary>
    /// Converts the value of the utc time to local time in supplied time zone.
    /// </summary>
    /// <param name="utc">The time to convert.</param>
    /// <param name="targetTimeZoneName">The standard name of the time zone.</param>
    /// <returns>The local time.</returns>
    /// <exception cref="ArgumentException">Thrown if time zone not found.</exception>
    public static DateTime ToLocalTime(DateTime utc, string targetTimeZoneName)
    {
      TimeZoneInformation tzi = TimeZoneInformation.GetTimeZone(targetTimeZoneName);
      return tzi.ToLocalTime(utc);
    }

    /// <summary>
    /// Converts a localTime from a source time zone to a target time zone, adjusting for DST as needed.
    /// The localTime must be a local time in the sourceTimeZoneName time zone.
    /// </summary>
    /// <param name="sourceTimeZoneName">Time zone name which represents localTime.</param>
    /// <param name="localTime">The source local time.</param>
    /// <param name="targetTimeZoneName">The time zone name which to convert the localTime.</param>
    /// <returns>The local time for targetTimeZoneName.</returns>
    public static DateTime ToLocalTime(string sourceTimeZoneName, DateTime localTime, string targetTimeZoneName)
    {
      DateTime utc = TimeZoneInformation.ToUniversalTime(sourceTimeZoneName, localTime);
      DateTime lt = TimeZoneInformation.ToLocalTime(utc, targetTimeZoneName);
      return lt;
    }

    /// <summary>
    /// Converts the value of the local time to UTC time.
    /// Note that there may be different possible interpretations at the daylight time boundaries.
    /// </summary>
    /// <param name="local">The local time to convert.</param>
    /// <returns>The UTC DateTime.</returns>
    /// <exception cref="NotSupportedException">Thrown if the method failed due to missing platform support.</exception>
    public DateTime ToUniversalTime(DateTime local)
    {
      SYSTEMTIME stLocal = DateTimeToSystemTime(local);
      TIME_ZONE_INFORMATION tziNative = TziNative();
      SYSTEMTIME stUTC;

      try
      {
        NativeMethods.TzSpecificLocalTimeToSystemTime(ref tziNative, ref stLocal, out stUTC);
        return SystemTimeToDateTime(ref stUTC);
      }
      catch (EntryPointNotFoundException e)
      {
        throw new NotSupportedException("This method is not supported on this operating system", e);
      }
    }

    /// <summary>
    /// Converts a local time in specified time zone to UTC time.
    /// </summary>
    /// <param name="standardTimeZoneName">The standard time zone name.</param>
    /// <param name="local">The local time to convert.</param>
    /// <returns>The UTC time.</returns>
    /// <exception cref="ArgumentException">Thrown if time zone name not found.</exception>
    /// <exception cref="NotSupportedException">Thrown if the method failed due to missing platform support.</exception>
    public static DateTime ToUniversalTime(string standardTimeZoneName, DateTime local)
    {
      TimeZoneInformation tzi = TimeZoneInformation.GetTimeZone(standardTimeZoneName);
      return tzi.ToUniversalTime(local);
    }
    #endregion

    #region Private Methods
    private static SYSTEMTIME DateTimeToSystemTime(DateTime dt)
    {
      SYSTEMTIME st;
      FILETIME ft = new FILETIME();
      ft.dwHighDateTime = (int)(dt.Ticks >> 32);
      ft.dwLowDateTime = (int)(dt.Ticks & 0xFFFFFFFFL);
      NativeMethods.FileTimeToSystemTime(ref ft, out st);
      return st;
    }

    private static DateTime SystemTimeToDateTime(ref SYSTEMTIME st)
    {
      FILETIME ft = new FILETIME();
      NativeMethods.SystemTimeToFileTime(ref st, out ft);
      DateTime dt = new DateTime((((long)ft.dwHighDateTime) << 32) | (uint)ft.dwLowDateTime);
      return dt;
    }

    private TIME_ZONE_INFORMATION TziNative()
    {
      TIME_ZONE_INFORMATION tziNative = new TIME_ZONE_INFORMATION();
      tziNative.Bias = tzi.bias;
      tziNative.StandardDate = tzi.standardDate;
      tziNative.StandardBias = tzi.standardBias;
      tziNative.DaylightDate = tzi.daylightDate;
      tziNative.DaylightBias = tzi.daylightBias;
      return tziNative;
    }

    /// <summary>
    /// The standard Windows SYSTEMTIME structure.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    private struct SYSTEMTIME
    {
      public UInt16 wYear;
      public UInt16 wMonth;
      public UInt16 wDayOfWeek;
      public UInt16 wDay;
      public UInt16 wHour;
      public UInt16 wMinute;
      public UInt16 wSecond;
      public UInt16 wMilliseconds;
    }

    // FILETIME is already declared in System.Runtime.InteropServices.

    /// <summary>
    /// The layout of the Tzi value in the registry.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    private struct TZI
    {
      public int bias;
      public int standardBias;
      public int daylightBias;
      public SYSTEMTIME standardDate;
      public SYSTEMTIME daylightDate;
    }

    /// <summary>
    /// The standard Win32 TIME_ZONE_INFORMATION structure.
    /// Thanks to www.pinvoke.net.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    private struct TIME_ZONE_INFORMATION
    {
      [MarshalAs(UnmanagedType.I4)]
      public Int32 Bias;
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
      public string StandardName;
      public SYSTEMTIME StandardDate;
      [MarshalAs(UnmanagedType.I4)]
      public Int32 StandardBias;
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
      public string DaylightName;
      public SYSTEMTIME DaylightDate;
      [MarshalAs(UnmanagedType.I4)]
      public Int32 DaylightBias;
    }

    /// <summary>
    /// A container for P/Invoke declarations.
    /// </summary>
    private struct NativeMethods
    {
      private const string KERNEL32 = "kernel32.dll";

      [DllImport(KERNEL32)]
      public static extern uint GetTimeZoneInformation(out TIME_ZONE_INFORMATION
      lpTimeZoneInformation);

      [DllImport(KERNEL32)]
      public static extern bool SystemTimeToTzSpecificLocalTime(
      [In] ref TIME_ZONE_INFORMATION lpTimeZone,
      [In] ref SYSTEMTIME lpUniversalTime,
out SYSTEMTIME lpLocalTime);

      [DllImport(KERNEL32)]
      public static extern bool SystemTimeToFileTime(
      [In] ref SYSTEMTIME lpSystemTime,
      out FILETIME lpFileTime);

      [DllImport(KERNEL32)]
      public static extern bool FileTimeToSystemTime(
      [In] ref FILETIME lpFileTime,
      out SYSTEMTIME lpSystemTime);

      /// <summary>
      /// Convert a local time to UTC, using the supplied time zone information.
      /// Windows XP and Server 2003 and later only.
      /// </summary>
      /// <param name="lpTimeZone">The time zone to use.</param>
      /// <param name="lpLocalTime">The local time to convert.</param>
      /// <param name="lpUniversalTime">The resultant time in UTC.</param>
      /// <returns>true if successful, false otherwise.</returns>
      [DllImport(KERNEL32)]
      public static extern bool TzSpecificLocalTimeToSystemTime(
      [In] ref TIME_ZONE_INFORMATION lpTimeZone,
      [In] ref SYSTEMTIME lpLocalTime,
out SYSTEMTIME lpUniversalTime);
    }

    /// <summary>
    /// Initialise the m_tzi member.
    /// </summary>
    /// <param name="info">The Tzi data from the registry.</param>
    private void InitTzi(byte[] info)
    {
      if (info.Length != Marshal.SizeOf(tzi))
        throw new ArgumentException("Information size is incorrect", "info");

      // Could have sworn there's a Marshal operation to pack bytes into
      // a structure, but I can't see it. Do it manually.
      GCHandle h = GCHandle.Alloc(info, GCHandleType.Pinned);
      try
      {
        tzi = (TZI)Marshal.PtrToStructure(h.AddrOfPinnedObject(), typeof(TZI));
      }
      finally
      {
        h.Free();
      }
    }
    #endregion
  }

}
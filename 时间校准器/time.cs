using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace 时间校准器
{
    class time
    {

        /*
         * 1. 修改时区的Windows API
         */
        // 针对于旧Windows系统，如Windows XP
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern void GetTimeZoneInformation(ref TimeZoneInformation lpTimeZoneInformation);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern bool SetTimeZoneInformation(ref TimeZoneInformation lpTimeZoneInformation);

        // 针对于新Windows系统，如Windows 7, Windows8, Windows10
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern void GetDynamicTimeZoneInformation(ref DynamicTimeZoneInformation lpDynamicTimeZoneInformation);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern bool SetDynamicTimeZoneInformation(ref DynamicTimeZoneInformation lpDynamicTimeZoneInformation);
        /*
         * 2. 相关结构struct类型
         */
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct TimeZoneInformation
        {
            [MarshalAs(UnmanagedType.I4)]
            internal int bias; // 以分钟为单位
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
            internal string standardName; // 标准时间的名称
            internal SystemTime standardDate;
            [MarshalAs(UnmanagedType.I4)]
            internal int standardBias; // 标准偏移
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
            internal string daylightName; // 夏令时的名称
            internal SystemTime daylightDate;
            [MarshalAs(UnmanagedType.I4)]
            internal int daylightBias; // 夏令时偏移
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct DynamicTimeZoneInformation
        {
            [MarshalAs(UnmanagedType.I4)]
            internal int bias; // 偏移，以分钟为单位
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
            internal string standardName; // 标准时间的名称
            internal SystemTime standardDate;
            [MarshalAs(UnmanagedType.I4)]
            internal int standardBias; // 标准偏移
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
            internal string daylightName; // 夏令时的名称
            internal SystemTime daylightDate;
            [MarshalAs(UnmanagedType.I4)]
            internal int daylightBias; // 夏令时偏移
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x80)]
            internal string timeZoneKeyName; // 时区名
            [MarshalAs(UnmanagedType.Bool)]
            internal bool dynamicDaylightTimeDisabled; // 是否自动调整时钟的夏令时
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SystemTime
        {
            [MarshalAs(UnmanagedType.U2)]
            internal ushort year; // 年
            [MarshalAs(UnmanagedType.U2)]
            internal ushort month; // 月
            [MarshalAs(UnmanagedType.U2)]
            internal ushort dayOfWeek; // 星期
            [MarshalAs(UnmanagedType.U2)]
            internal ushort day; // 日
            [MarshalAs(UnmanagedType.U2)]
            internal ushort hour; // 时
            [MarshalAs(UnmanagedType.U2)]
            internal ushort minute; // 分
            [MarshalAs(UnmanagedType.U2)]
            internal ushort second; // 秒
            [MarshalAs(UnmanagedType.U2)]
            internal ushort milliseconds; // 毫秒
        }
    }
}

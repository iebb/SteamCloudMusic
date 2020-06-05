using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SteamCloudMusic
{
    internal class ProcessRights
    {
        public const uint TERMINATE = 0x0001;
        public const uint CREATE_THREAD = 0x0002;
        public const uint SET_SESSIONID = 0x0004;
        public const uint VM_OPERATION = 0x0008;
        public const uint VM_READ = 0x0010;
        public const uint VM_WRITE = 0x0020;
        public const uint DUP_HANDLE = 0x0040;
        public const uint CREATE_PROCESS = 0x0080;
        public const uint SET_QUOTA = 0x0100;
        public const uint SET_INFORMATION = 0x0200;
        public const uint QUERY_INFORMATION = 0x0400;
        public const uint SUSPEND_RESUME = 0x0800;

        private const uint STANDARD_RIGHTS_REQUIRED = 0x000F0000;
        private const uint SYNCHRONIZE = 0x00100000;

        public const uint ALL_ACCESS = STANDARD_RIGHTS_REQUIRED | SYNCHRONIZE | 0xFFF;
    }
    internal class MemAllocationType
    {
        public const uint COMMIT = 0x1000;
        public const uint RESERVE = 0x2000;
        public const uint DECOMMIT = 0x4000;
        public const uint RELEASE = 0x8000;
        public const uint FREE = 0x10000;
        public const uint PRIVATE = 0x20000;
        public const uint MAPPED = 0x40000;
        public const uint RESET = 0x80000;
        public const uint TOP_DOWN = 0x100000;
        public const uint WRITE_WATCH = 0x200000;
        public const uint PHYSICAL = 0x400000;
        public const uint LARGE_PAGES = 0x20000000;
        public const uint FOURMB_PAGES = 0x80000000;
    }

    internal class MemoryProtection
    {
        public const uint PAGE_NOACCESS = 0x01;
        public const uint PAGE_READONLY = 0x02;
        public const uint PAGE_READWRITE = 0x04;
        public const uint PAGE_WRITECOPY = 0x08;
        public const uint PAGE_EXECUTE = 0x10;
        public const uint PAGE_EXECUTE_READ = 0x20;
        public const uint PAGE_EXECUTE_READWRITE = 0x40;
        public const uint PAGE_EXECUTE_WRITECOPY = 0x80;
        public const uint PAGE_GUARD = 0x100;
        public const uint PAGE_NOCACHE = 0x200;
        public const uint PAGE_WRITECOMBINE = 0x400;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TBBUTTON
    {
        public int iBitmap;
        public int idCommand;
        [StructLayout(LayoutKind.Explicit)]
        private struct TBBUTTON_U
        {
            [FieldOffset(0)] public byte fsState;
            [FieldOffset(1)] public byte fsStyle;
            [FieldOffset(0)] private IntPtr bReserved;
        }
        private TBBUTTON_U union;
        public byte fsState { get { return union.fsState; } set { union.fsState = value; } }
        public byte fsStyle { get { return union.fsStyle; } set { union.fsStyle = value; } }
        public UInt64 dwData;
        public IntPtr iString;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int Left;        // x position of upper-left corner
        public int Top;         // y position of upper-left corner
        public int Right;       // x position of lower-right corner
        public int Bottom;      // y position of lower-right corner


        public int Height { get { return Bottom - Top; } }
        public int Width { get { return Right - Left; } }
        public Size Size { get { return new Size(Width, Height); } }

        public RECT(int left, int top, int right, int bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }

    }
}
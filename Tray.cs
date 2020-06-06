using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Diagnostics;
using static SteamCloudMusic.User32;

namespace SteamCloudMusic
{

    class Tray
    {
        public delegate bool EnumWindowProc(IntPtr hwnd, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindowEx(IntPtr hWndParent, IntPtr hWndChildAfter, string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr i);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        static public bool EnumWindow(IntPtr hWnd, IntPtr lParam)
        {
            StringBuilder lpClassName = new StringBuilder();
            GetClassName(hWnd, lpClassName, 100);
            return true;
        }

        static public void GetIconFromTB(IntPtr _ToolbarWindowHandle, ref List<Tuple<string, string>> results)
        {
            UInt32 count = (uint)User32.SendMessage(_ToolbarWindowHandle, User32.TB.BUTTONCOUNT, 0, 0);
            for (int i = 0; i < count; i++)
            {
                TBBUTTON tbButton = new TBBUTTON();
                string text = String.Empty;
                IntPtr ipWindowHandle = IntPtr.Zero;
                Tray.GetTBButton(_ToolbarWindowHandle, i, ref tbButton, ref text, ref ipWindowHandle);
                string procName;
                try
                {
                    uint pid = 0;
                    GetWindowThreadProcessId(ipWindowHandle, out pid);
                    Process proc = Process.GetProcessById((int)pid);
                    procName = proc.ProcessName.ToString();
                }
                catch
                {
                    procName = "--";
                }

                results.Add(new Tuple<string, string>(procName, text));
            }
        }
        static public List<Tuple<string, string>> GetCollapsedTrayIcons()
        {

            List<Tuple<string, string>> r = new List<Tuple<string, string>>();
            IntPtr hWndTray = FindWindow("NotifyIconOverflowWindow", null);

            if (hWndTray != IntPtr.Zero)
            {
                hWndTray = FindWindowEx(hWndTray, IntPtr.Zero, "ToolbarWindow32", null);
                GetIconFromTB(hWndTray, ref r);
            }
            return r;
        }
        static public List<Tuple<string, string>> GetTaskbarIcons()
        {

            List<Tuple<string, string>> r = new List<Tuple<string, string>>();
            Process[] processlist = Process.GetProcesses();

            // Iterate over them
            foreach (Process process in processlist)
            {
                if (!String.IsNullOrEmpty(process.MainWindowTitle))
                {
                    r.Add(new Tuple<string, string>(process.ProcessName, process.MainWindowTitle));
                }
            }
            return r;
        }
        static public List<Tuple<string, string>> GetTrayIcons()
        {

            List<Tuple<string, string>> r = new List<Tuple<string, string>>();
            IntPtr hWndTray = FindWindow("Shell_TrayWnd", null);

            if (hWndTray != IntPtr.Zero)
            {
                hWndTray = FindWindowEx(hWndTray, IntPtr.Zero, "TrayNotifyWnd", null);
                if (hWndTray != IntPtr.Zero)
                {
                    hWndTray = FindWindowEx(hWndTray, IntPtr.Zero, "SysPager", null);
                    if (hWndTray != IntPtr.Zero)
                    {
                        hWndTray = FindWindowEx(hWndTray, IntPtr.Zero, "ToolbarWindow32", null);
                        GetIconFromTB(hWndTray, ref r);
                    }
                }
            }
            return r;
        }
        public static unsafe bool GetTBButton(IntPtr hToolbar, int i, ref TBBUTTON tbButton, ref string text, ref IntPtr ipWindowHandle)
        {
            // One page
            const int BUFFER_SIZE = 0x1000;

            byte[] localBuffer = new byte[BUFFER_SIZE];

            UInt32 processId = 0;
            UInt32 threadId = User32.GetWindowThreadProcessId(hToolbar, out processId);

            IntPtr hProcess = Kernel32.OpenProcess(ProcessRights.ALL_ACCESS, false, processId);
            if (hProcess == IntPtr.Zero) return false;

            IntPtr ipRemoteBuffer = Kernel32.VirtualAllocEx(
                hProcess,
                IntPtr.Zero,
                new UIntPtr(BUFFER_SIZE),
                MemAllocationType.COMMIT,
                MemoryProtection.PAGE_READWRITE);

            if (ipRemoteBuffer == IntPtr.Zero) return false;

            // TBButton
            fixed (TBBUTTON* pTBButton = &tbButton)
            {
                IntPtr ipTBButton = new IntPtr(pTBButton);

                int b = (int)User32.SendMessage(hToolbar, TB.GETBUTTON, (IntPtr)i, ipRemoteBuffer);
                if (b == 0) return false;

                // this is fixed
                Int32 dwBytesRead = 0;
                IntPtr ipBytesRead = new IntPtr(&dwBytesRead);

                bool b2 = Kernel32.ReadProcessMemory(
                    hProcess,
                    ipRemoteBuffer,
                    ipTBButton,
                    new UIntPtr((uint)sizeof(TBBUTTON)),
                    ipBytesRead);

                if (!b2) return false;
            }

            // button text
            fixed (byte* pLocalBuffer = localBuffer)
            {
                IntPtr ipLocalBuffer = new IntPtr(pLocalBuffer);

                int chars = (int)User32.SendMessage(hToolbar, TB.GETBUTTONTEXTW, (IntPtr)tbButton.idCommand, ipRemoteBuffer);
                if (chars == -1) { return false; }

                // this is fixed
                Int32 dwBytesRead = 0;
                IntPtr ipBytesRead = new IntPtr(&dwBytesRead);

                bool b4 = Kernel32.ReadProcessMemory(
                    hProcess,
                    ipRemoteBuffer,
                    ipLocalBuffer,
                    new UIntPtr(BUFFER_SIZE),
                    ipBytesRead);

                if (!b4) { return false; }

                text = Marshal.PtrToStringUni(ipLocalBuffer, chars);

                if (text == " ") text = String.Empty;
            }

            // window handle
            fixed (byte* pLocalBuffer = localBuffer)
            {
                var ipLocalBuffer = new IntPtr(pLocalBuffer);

                var dwBytesRead = 0;
                var ipBytesRead = new IntPtr(&dwBytesRead);

                var ipRemoteData = (IntPtr)tbButton.dwData;

                var b4 = Kernel32.ReadProcessMemory(
                    hProcess,
                    ipRemoteData,
                    ipLocalBuffer,
                    new UIntPtr(4),
                    ipBytesRead);

                if (!b4) {return false; }

                if (dwBytesRead != 4) { return false; }

                var iWindowHandle = BitConverter.ToInt32(localBuffer, 0);
                if (iWindowHandle == -1) { return false; }

                ipWindowHandle = new IntPtr(iWindowHandle);

            }

            Kernel32.VirtualFreeEx(
                hProcess,
                ipRemoteBuffer,
                UIntPtr.Zero,
                MemAllocationType.RELEASE);

            Kernel32.CloseHandle(hProcess);

            return true;
        }
    }
}

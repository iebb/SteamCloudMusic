
using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Drawing;

namespace SteamCloudMusic
{
	public static class User32
	{
		[DllImport("user32.dll")]
		public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 msg, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll")]
		public static extern UInt32 SendMessage(IntPtr hWnd, UInt32 msg, UInt32 wParam, UInt32 lParam);

		[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
		public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, int wParam, int lParam);

		[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
		public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, int wParam, IntPtr lParam);

		[DllImport("User32.dll")]
		public static extern bool PostMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

		[DllImport("User32.dll")]
		public static extern bool PostMessage(IntPtr hWnd, UInt32 Msg, UInt32 wParam, UInt32 lParam);

		[DllImport("user32.dll")]
		public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

		[DllImport("user32.dll")]
		public static extern int GetWindowText(int hWnd, StringBuilder title, int size);

		[DllImport("user32.dll")]
		public static extern int GetWindowModuleFileName(int hWnd, StringBuilder title, int size);

		[DllImport("user32.dll")]
		public static extern int EnumWindows(EnumWindowsProc ewp, int lParam);
		public delegate bool EnumWindowsProc(int hWnd, int lParam);

		[DllImport("user32.dll", SetLastError = true)]
		static extern System.IntPtr FindWindow(string lpClassName, string lpWindowName);

		[DllImport("user32.dll", SetLastError = true)]
		static extern System.IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

		[DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
		public static extern IntPtr GetParent(IntPtr hWnd);

		[DllImport("user32.dll")]
		public static extern bool IsWindowVisible(int hWnd);

		[DllImport("user32.dll")]
		public static extern IntPtr GetForegroundWindow();

		[DllImport("user32.dll")]
		public static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

		[DllImport("User32.dll")]
		public static extern bool ShowWindow(IntPtr handle, int nCmdShow);

		[DllImport("user32.dll")]
		public static extern bool SetForegroundWindow(IntPtr hWnd);

		[DllImport("user32.dll")]
		public static extern bool IsIconic(IntPtr hWnd);

		[DllImport("user32.dll")]
		public static extern bool IsZoomed(IntPtr hWnd);

		[DllImport("user32.dll")]
		static extern IntPtr GetShellWindow();

		[DllImport("user32.dll")]
		public static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);

		[DllImport("user32.dll")]
		public static extern IntPtr AttachThreadInput(IntPtr idAttach, IntPtr idAttachTo, int fAttach);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetWindowRect(HandleRef hWnd, out RECT lpRect);

		[DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, ExactSpelling = true, SetLastError = true)]
		public static extern void MoveWindow(IntPtr hwnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

		[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
		public static extern int MapWindowPoints(IntPtr hWndFrom, IntPtr hWndTo, ref RECT lpPoints, UInt32 cPoints);

		[DllImport("user32.dll")]
		public static extern IntPtr GetLastActivePopup(IntPtr hWnd);

		[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
		public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

		[DllImport("user32.dll", ExactSpelling = true)]
		public static extern IntPtr GetAncestor(IntPtr hwnd, GetAncestor_Flags gaFlags);
		public enum GetAncestor_Flags
		{
			GetParent = 1,
			GetRoot = 2,
			GetRootOwner = 3
		}


		public class WM
		{
			public const uint CLOSE = 0x0010;
			public const uint GETICON = 0x007F;
			public const uint KEYDOWN = 0x0100;
			public const uint COMMAND = 0x0111;
			public const uint USER = 0x0400; // 0x0400 - 0x7FFF
			public const uint APP = 0x8000; // 0x8000 - 0xBFFF
		}
		public class TB
		{
			public const uint GETBUTTON = WM.USER + 23;
			public const uint BUTTONCOUNT = WM.USER + 24;
			public const uint CUSTOMIZE = WM.USER + 27;
			public const uint GETBUTTONTEXTA = WM.USER + 45;
			public const uint GETBUTTONTEXTW = WM.USER + 75;
			public const uint WM_LBUTTONDBLCLK = 0x0203;
			public const uint PRESSBUTTON = (WM.USER + 3);
			public const uint HIDEBUTTON = (WM.USER + 4);
			public const uint GETITEMRECT = (WM.USER + 29);
			public const uint STATE_HIDDEN = 0x08;
		}
		public class NotificationAreaWindow
		{
			public RECT RECT { get; set; }
			public TBBUTTON TBBUTTON { get; set; }
			public IntPtr MainWindowHandle { get; set; }
			public IntPtr ToolBarIconHandle { get; set; }
			public string Text { get; set; }
		}
		private static IntPtr SystrayHwnd = User32.FindWindowEx(User32.FindWindow("Shell_TrayWnd", null), IntPtr.Zero, "TrayNotifyWnd", null);


		public static IntPtr GetNotificationToolbarWindowHandle()
		{
			var hShell = User32.FindWindowEx(IntPtr.Zero, IntPtr.Zero, "Shell_TrayWnd", null);
			var hTray = User32.FindWindowEx(hShell, IntPtr.Zero, "TrayNotifyWnd", null);
			var hPager = User32.FindWindowEx(hTray, IntPtr.Zero, "SysPager", null);
			var hToolbar = User32.FindWindowEx(hPager, IntPtr.Zero, "ToolbarWindow32", null);
			return hToolbar;

		}
		public static int GetButtonCount(IntPtr hwnd)
		{
			return (int)User32.SendMessage(hwnd, TB.BUTTONCOUNT, IntPtr.Zero, IntPtr.Zero);
		}

		public static IntPtr GetLastVisibleActivePopUpOfWindow(IntPtr window)
		{
			var lastPopUp = User32.GetLastActivePopup(window);
			if (User32.IsWindowVisible((int)lastPopUp))
				return lastPopUp;
			else if (lastPopUp == window)
				return IntPtr.Zero;
			else
				return GetLastVisibleActivePopUpOfWindow(lastPopUp);
		}


	}
}

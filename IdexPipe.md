### IdexPipe C#
Version: v1.1
```csharp

// ----------------------------------------------------
// COPYRIGHT (C) <TJG> ALL RIGHTS RESERVED. SEE THE LIC
// ENSE FILE FOR THE FULL LICENSE GOVERNING THIS CODE. 
// ----------------------------------------------------

using System;
using System.Linq;
using System.Security;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class IdexPipe : Form
{
	public const int Unicode = 0;
	public const int Ansi = 1;
	public static int Encoding { get; set; }
	private const string CID = "ClientId";
	private const string SID = "ServerId";
	private const string SID_VALUE = "IdexServer";
	private const int WM_COPYDATA = 0x004A;
	private static IdexPipe Instance;
	private string Response;
	private int State;

	private IdexPipe()
	{
		InitializeComponent();
		ShowInTaskbar = false;
		WindowState = FormWindowState.Minimized;
	}
	private void InitializeComponent()
	{
		ClientSize = new Size(300, 100);
		MaximizeBox = false;
		Text = "IdexPipe";
	}
	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
	}
	protected override void WndProc(ref Message m)
	{
		if (m.Msg == WM_COPYDATA)
		{
			try
			{
				var cds = (COPYDATASTRUCT)m.GetLParam(typeof(COPYDATASTRUCT));
				if (Encoding == 1)
				{
					Response = Marshal.PtrToStringAnsi(cds.lpData);
				}
				else
				{
					Response = Marshal.PtrToStringUni(cds.lpData);
				}
				State = 0;
			}
			catch
			{
				State = 1;
			}
		}
		base.WndProc(ref m);
	}

	public static string Send(string request)
	{
		if (Instance == null)
		{
			Instance = new IdexPipe();
			Instance.Show();
		}
		return Instance.SendInstance(request);
	}
	private string SendInstance(string request)
	{
		var lines = StringGetLines(request).ToList();
		var serverId = ListGetValue(lines, SID);
		var clientId = ListGetValue(lines, CID);
		var i = (lines.Count > 1) ? 1 : 0;
		if (serverId == "")
		{
			serverId = SID_VALUE;
			lines.Insert(i, SID + " = " + serverId);
		}
		if (clientId == "")
		{
			clientId = Text;
			lines.Insert(i, CID + " = " + clientId);
		}
		request = string.Join("\r\n", lines);
		State = 1;
		Response = "";
		int code = SendNative(serverId, request);
		switch(code)
		{
			case 1: return "<ServerId is missing or invalid>";
			case 2: return "<Server not found>";
			case 3: return "<Server is unresponsive>";
		}
		if (State != 0)
		{
			return "<Reqeust yields no result>";
		}
		return Response;
	}
	private int SendNative(string serverId, string request)
	{
		if (string.IsNullOrEmpty(serverId))
		{
			return 1;
		}
		var serverHandle = Native.FindWindow(null, serverId);
		if (serverHandle == IntPtr.Zero)
		{
			return 2;
		}
		var requestSize = (request.Length + 1) * 2;
		var requestPointer = IntPtr.Zero;
		try
		{
			if (Encoding == Ansi)
			{
				requestPointer = Marshal.StringToCoTaskMemAnsi(request);
			}
			else
			{
				requestPointer = Marshal.StringToCoTaskMemUni(request);
			}
			var cds = new COPYDATASTRUCT();
			cds.cbData = requestSize;
			cds.lpData = requestPointer;
			Native.SendMessage(serverHandle, WM_COPYDATA, IntPtr.Zero, ref cds);
		}
		catch
		{
			return 3;
		}
		finally
		{
			if (Encoding == Ansi)
			{
				Marshal.ZeroFreeCoTaskMemAnsi(requestPointer);
			}
			else
			{
				Marshal.ZeroFreeCoTaskMemUnicode(requestPointer);
			}
		}
		return 0;
	}

	private string ListGetValue(IEnumerable<string> list, string name)
	{
		var assoc = list.SingleOrDefault(x => StringSW(x.Trim(), name));
		return StringGetValue(assoc);
	}
	private static string[] StringGetLines(string input)
	{
		var parts = input.Split('\n').Where(x => !string.IsNullOrEmpty(x))
			.Select(x => x.Trim()).ToArray();
		return parts;
	}
	private static string StringGetValue(string input, string delim = "=")
	{
		if (!string.IsNullOrEmpty(input))
		{
			var i = input.IndexOf(delim);
			if (i > 0)
			{
				return input.Substring(i + 1).Trim();
			}
		}
		return "";
	}
	private static bool StringSW(string input, string prefix)
	{
		return input.StartsWith(prefix, StringComparison.InvariantCultureIgnoreCase);
	}

	[StructLayout(LayoutKind.Sequential)]
	private struct COPYDATASTRUCT
	{
		public IntPtr dwData;
		public int cbData;
		public IntPtr lpData;
	}

	[SuppressUnmanagedCodeSecurity]
	private class Native
	{
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr SendMessage(IntPtr hWnd, int Msg,
			IntPtr wParam, ref COPYDATASTRUCT lParam);

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
	}
}


```

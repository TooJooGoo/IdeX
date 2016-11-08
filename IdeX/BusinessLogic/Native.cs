// ----------------------------------------------------
// COPYRIGHT (C) <TJG> ALL RIGHTS RESERVED. SEE THE LIC
// ENSE FILE FOR THE FULL LICENSE GOVERNING THIS CODE. 
// ----------------------------------------------------

using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

[SuppressUnmanagedCodeSecurity]
public class Native
{
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr SendMessage(IntPtr hWnd, int Msg,
        IntPtr wParam, ref COPYDATASTRUCT lParam);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
}

[StructLayout(LayoutKind.Sequential)]
public struct COPYDATASTRUCT
{
    public IntPtr dwData;
    public int cbData;
    public IntPtr lpData;
}
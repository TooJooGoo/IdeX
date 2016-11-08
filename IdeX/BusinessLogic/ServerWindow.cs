// ----------------------------------------------------
// COPYRIGHT (C) <TJG> ALL RIGHTS RESERVED. SEE THE LIC
// ENSE FILE FOR THE FULL LICENSE GOVERNING THIS CODE. 
// ----------------------------------------------------

using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Text;

public partial class ServerWindow : Form
{
    public const int WM_COPYDATA = 0x004A;
    public readonly string Marker;
    public int RequestNumber;

    public ServerWindow()
    {
        InitializeComponent();
        Marker = Persistence.Marker;
        RequestNumber = 1;
    }
    protected override void WndProc(ref Message m)
    {
        if (m.Msg == WM_COPYDATA)
        {
            try
            {
                Handle_CopyData(ref m);
            }
            catch (Exception e)
            {
                XLog.Log($"HandleOnCopyData Exception: {e.Message} {e.StackTrace}");
            }
        }
        base.WndProc(ref m);
    }
    public void Handle_CopyData(ref Message m)
    {
        XLog.Log($"Begin Request: {RequestNumber}");
        RequestNumber++;
        var cdsRequest = (COPYDATASTRUCT)m.GetLParam(typeof(COPYDATASTRUCT));

        var request = "";
        var requestEncoding = Persistence.RequestEncoding;
        XLog.Log($"RequestEncoding: {requestEncoding}");
        if (requestEncoding == IdexEncoding.Ansi)
        {
            request = Marshal.PtrToStringAnsi(cdsRequest.lpData);
        }
        else
        {
            request = Marshal.PtrToStringUni(cdsRequest.lpData);
        }

        XLog.Log($"ClaimMarkerInRequest: {Persistence.ClaimMarkerInRequest}");
        if (Persistence.ClaimMarkerInRequest)
        {
            if (XString.StartsWith(request, Marker))
            {
                XLog.Log($"Eliminate Marker: {Marker}");
                request = request.Substring(Marker.Length).Trim();
            }
            else
            {
                XLog.Log($"Marker is expected but not present. Request is denied.");
                return;
            }
        }

        XLog.Log($"Parse Request");
        string requestServerId = "";
        string requestClientId = "";
        var requestLines = XString.SplitIntoLines(request);
        var actionLines = new List<string>();
        foreach(var requestLine in requestLines)
        {
            string left, right;
            XString.ParseAssoc(requestLine, out left, out right);
            if(XString.Eq(left,"ServerId") || XString.Eq(left, "sid"))
            {
                requestServerId = right;
            }
            else if (XString.Eq(left, "ClientId") || XString.Eq(left, "cid"))
            {
                requestClientId = right;
            }
            else if(XString.StartsWith(requestLine, "o ", "g ", "s "))
            {
                actionLines.Add(requestLine);
            }
        }

        XLog.Log($"Identify client");
        IntPtr clientHandle = IntPtr.Zero;
        if (requestClientId != "")
        {
            XLog.Log($"ClientId: {requestClientId}");
            clientHandle = Native.FindWindow(null, requestClientId);
        }
        if (clientHandle == IntPtr.Zero)
        {
            XLog.Log($"Cannot find client");
            return;
        }
        XLog.Log($"ClientHandle: {clientHandle}");

        var response = "";

        foreach (var actionLine in actionLines)
        {
            if(actionLine.Length > 2)
            {
                var actionPrefix = actionLine.Substring(0, 2).Trim();
                var actionBody = actionLine.Substring(2).Trim();
                if(XString.Eq(actionPrefix,"o"))
                {
                    XLog.Log($"Execute action: {actionPrefix} {actionBody}");
                    response += actionBody;
                }
                else if (XString.Eq(actionPrefix, "g"))
                {
                    if (Persistence.SupportGetOps)
                    {
                        XLog.Log($"Execute action: {actionPrefix} {actionBody}");
                        var result = Ide.TryGetOp(actionBody);
                        response += result;
                    }
                }
                else if (XString.Eq(actionPrefix, "s"))
                {
                    if (Persistence.SupportSetOps)
                    {
                        XLog.Log($"Execute action: {actionPrefix} {actionBody}");
                        string left, right;
                        XString.ParseAssoc(actionBody, out left, out right);
                        Ide.TrySetOp(left, right);
                    }
                }
            }
        }

        XLog.Log($"IncludeMarkerInResponse: {Persistence.IncludeMarkerInResponse}");
        if (Persistence.IncludeMarkerInResponse)
        {
            response += Marker + "\r\n";
        }

        var responseEncoding = Persistence.ResponseEncoding;
        XLog.Log($"ResponseEncoding: {responseEncoding}");
        var sizeInBytes = (response.Length + 1) * 2;
        var responsePointer = IntPtr.Zero;
        try
        {
            if(responseEncoding == IdexEncoding.Ansi)
            {
                 responsePointer = Marshal.StringToCoTaskMemAnsi(response);               
            }
            else
            {
                responsePointer = Marshal.StringToCoTaskMemUni(response);
            }
            
            var cds = new COPYDATASTRUCT();
            cds.cbData = sizeInBytes;
            cds.lpData = responsePointer;
            Native.SendMessage(clientHandle, WM_COPYDATA, IntPtr.Zero, ref cds);
            int errorCode = Marshal.GetLastWin32Error();
            if (errorCode != 0)
            {
                XLog.Log($"SendMessage Code: {errorCode}");
            }
        }
        finally
        {
            XLog.Log($"Free native objects");
            if (responseEncoding == IdexEncoding.Ansi)
            {
                Marshal.ZeroFreeCoTaskMemAnsi(responsePointer);
            }
            else
            {
                Marshal.ZeroFreeCoTaskMemUnicode(responsePointer);
            }
        }
        XLog.Log($"End Request");
    }
    public string GetWindowClassName()
    {
        var windowHandle = Handle;
        string windowClass = "";
        var windowClassSb = new StringBuilder(256);
        var result = Native.GetClassName(windowHandle, windowClassSb, windowClassSb.Capacity);
        if (result != 0)
        {
            windowClass = windowClassSb.ToString();
        }
        return windowClass;
    }
}



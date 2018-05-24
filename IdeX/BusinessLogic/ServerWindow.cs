// ----------------------------------------------------
// COPYRIGHT (C) <TooJooGoo> ALL RIGHTS RESERVED. SEE THE LIC
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

        if(requestLines.Length >= 3)
        {
            for(int i = 0; i < 3; i++)
            {
                string requestLine = requestLines[i];
                string left, right;
                XString.ParseAssoc(requestLine, out left, out right);
                if (XString.Eq(left, "ServerId") || XString.Eq(left, "sid"))
                {
                    requestServerId = right;
                }
                else if (XString.Eq(left, "ClientId") || XString.Eq(left, "cid"))
                {
                    requestClientId = right;
                }
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
        foreach (var actionLine in requestLines)
        {
            if (XString.StartsWith(actionLine, "o ", "g ", "s "))
            {
                var actionPrefix = actionLine.Substring(0, 2).Trim();
                var actionBody = actionLine.Substring(2).Trim();
                if (XString.Eq(actionPrefix, "o"))
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
            else if (XString.StartsWith(actionLine, "Document."))
            {
                string rest = actionLine.Substring(9);
                int openBracket = rest.IndexOf('(');
                string functionName = rest.Substring(0, openBracket);
                rest = rest.Substring(openBracket + 1);
                int closingBracket = rest.IndexOf(')');
                rest = rest.Substring(0, closingBracket);
                var args = rest.Split(',');
                if (XString.Eq(functionName
                , "SetSelectedRange"))
                {
                    int startIndex = int.Parse(args[0]);
                    int endIndex = int.Parse(args[1]);
                    Ide.Document_SetSelectedRange(startIndex, endIndex);
                }
                else if (XString.Eq(functionName
                , "GetSelectedRange"))
                {
                    int startIndex = 0;
                    int endIndex = 0;
                    Ide.Document_GetSelectedRange(out startIndex, out endIndex);
                    response += startIndex + "," + endIndex;
                }
                else if (XString.Eq(functionName
                , "GetSelectedText"))
                {
                    string text = Ide.Document_GetSelectedText();
                    response += text;
                }
                else if (XString.Eq(functionName
                , "ReplaceSelectedText"))
                {
                    Ide.Document_ReplaceSelectedText();
                }
                else if (XString.Eq(functionName
                , "DeleteSelectedText"))
                {
                    Ide.Document_DeleteSelectedText();
                }
                else if (XString.Eq(functionName
                , "GetLineIndexByChar"
                ))
                {
                    int charIndex = int.Parse(args[0]);
                    int lineIndex = Ide.Document_GetLineIndexByChar(charIndex);
                    response += lineIndex.ToString();
                }
                else if (XString.Eq(functionName
                , "GetLine"
                ))
                {
                    int lineIndex = int.Parse(args[0]);
                    string lineContent = Ide.Document_GetLine(lineIndex);
                    response += lineContent.ToString();
                }
                else if (XString.Eq(functionName
                , "SelectLine"
                ))
                {
                    int lineIndex = int.Parse(args[0]);
                    Ide.Document_SelectLine(lineIndex);
                }
                else if (XString.Eq(functionName
                , "GetLineLength"
                ))
                {
                    int charIndex = int.Parse(args[0]);
                    int charCount = Ide.Document_GetLineLength(charIndex);
                    response += charCount.ToString();
                }
                else if (XString.Eq(functionName
                , "GetCharIndexByLine"
                ))
                {
                    int lineIndex = int.Parse(args[0]);
                    int charIndex = Ide.Document_GetCharIndexByLine(lineIndex);
                    response += charIndex.ToString();
                }
                else if (XString.Eq(functionName
                , "GetTextLength"
                ))
                {
                    int charCount = Ide.Document_GetTextLength();
                    response += charCount.ToString();
                }
                else if (XString.Eq(functionName
                , "GetText"
                ))
                {
                    string chars = Ide.Document_GetText();
                    response += chars;
                }
                else if (XString.Eq(functionName
                , "ScrollToEnd"
                ))
                {
                    Ide.Document_ScrollToEnd();
                }
                else if (XString.Eq(functionName
                , "GetCaretLineIndex"
                ))
                {
                    response += Ide.Document_GetCaretLineIndex();
                }
                else if (XString.Eq(functionName
                , "GetCaretColumnIndex"
                ))
                {
                    response += Ide.Document_GetCaretColumnIndex();
                }
                else if (XString.Eq(functionName
                , "GetSelectedStartLineIndex"
                ))
                {
                    response += Ide.Document_GetSelectedStartLineIndex();
                }
                else if (XString.Eq(functionName
                , "GetSelectedEndLineIndex"
                ))
                {
                    response += Ide.Document_GetSelectedEndLineIndex();
                }
                else if (XString.Eq(functionName
                , "GetSelectedRangeCount"
                ))
                {
                    response += Ide.Document_GetSelectedRangeCount();
                }
                else if (XString.Eq(functionName
                , "GetSelectedStartCharIndex"
                ))
                {
                    response += Ide.Document_GetSelectedStartCharIndex();
                }
                else if (XString.Eq(functionName
                , "GetSelectedEndCharIndex"
                ))
                {
                    response += Ide.Document_GetSelectedEndCharIndex();
                }
                else if (XString.Eq(functionName
                , "GetOpenDocuments"
                ))
                {
                    response += Ide.Document_GetOpenDocuments();
                }
            }
            else if (XString.StartsWith(actionLine, "SolutionExplorer."))
            {
                string functionName = null;
                string[] args = null;
                ParseActionLine(actionLine, "SolutionExplorer.",
                    out functionName, out args);

                if (XString.Eq(functionName
                , "GetSelectedItems"
                ))
                {
                    response += Ide.SolutionExplorer_GetSelectedItems();
                }
                else if (XString.Eq(functionName
                , "GetSelectedItemCount"
                ))
                {
                    response += Ide.SolutionExplorer_GetSelectedItemCount();
                }
            }
            else if (XString.StartsWith(actionLine, "Base."))
            {
                string functionName = null;
                string[] args = null;
                ParseActionLine(actionLine, "Base.",
                    out functionName, out args);

                if (XString.Eq(functionName
                , "GetServerId"
                ))
                {
                    response += Ide.Base_GetServerId();
                }
                else if (XString.Eq(functionName
                , "SetServerId"
                ))
                {
                    string serverId = args[0];
                    Ide.Base_SetServerId(serverId);
                }
                else if (XString.Eq(functionName
                , "GetServerHandle"
                ))
                {
                    response += Ide.Base_GetServerHandle();
                }
            }
            else if (XString.StartsWith(actionLine, "Output."))
            {
                string functionName = null;
                string[] args = null;
                ParseActionLine(actionLine, "Output.",
                    out functionName, out args);

                if (XString.Eq(functionName
                , "WriteCR"
                ))
                {
                    response += Ide.Output_WriteCR();
                }
                else if (XString.Eq(functionName
                , "WriteLF"
                ))
                {
                    response += Ide.Output_WriteLF();
                }
                else if (XString.Eq(functionName
                , "WriteCRLF"
                ))
                {
                    response += Ide.Output_WriteCRLF();
                }
                else if (XString.Eq(functionName
                , "WriteHT"
                ))
                {
                    response += Ide.Output_WriteHT();
                }
                else if (XString.Eq(functionName
                , "WriteSP"
                ))
                {
                    response += Ide.Output_WriteSP();
                }
                else if (XString.Eq(functionName
                , "Write"
                ))
                {
                    string text = args[0].Trim('"');
                    response += Ide.Output_Write(text);
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

    void ParseActionLine(string line, string prefix, out string functionName, out string[] args)
    {
        string rest = line.Substring(prefix.Length);
        int openBracket = rest.IndexOf('(');
        functionName = rest.Substring(0, openBracket);
        rest = rest.Substring(openBracket + 1);
        int closingBracket = rest.IndexOf(')');
        rest = rest.Substring(0, closingBracket);
        args = rest.Split(',');
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



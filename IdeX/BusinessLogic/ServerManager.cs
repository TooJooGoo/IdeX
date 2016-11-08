// ----------------------------------------------------
// COPYRIGHT (C) <TJG> ALL RIGHTS RESERVED. SEE THE LIC
// ENSE FILE FOR THE FULL LICENSE GOVERNING THIS CODE. 
// ----------------------------------------------------

using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

public class ServerManager
{
    public static ServerWindow ServerWindow { get; set; }
    public static VsPackage Package;
    public static event EventHandler ServerEnabled;
    public static event EventHandler ServerDisabled;

    public static void Init(VsPackage package)
    {
        Package = package;
    }

    public static int ServerState
    {
        get
        {
            return Persistence.ServerState;
        }
    }
    public static bool CanEnable()
    {
        if(!ServerId_IsValid(Persistence.ServerId))
        {
            return false;
        }
        if(!Marker_IsValid(Persistence.Marker))
        {
            return false;
        }
        return true;
    }

    public static bool ServerId_IsValid(string serverId)
    {
        var matchId = Regex.Match(serverId, @"(?i)^[a-z0-9_]{2,20}$");
        return matchId.Success;
    }
    public static bool Marker_IsValid(string marker)
    {
        var matchMarker = Regex.Match(marker, @"(?i)^[a-z0-9_]{2,8}$");
        return matchMarker.Success;
    }

    public static string GetProfileText()
    {
        string text = "";
        var id = "";
        var marker = "";
        var handle = "";
        var classname = "";
        var integrity = "unconfirmed";
        try
        {
            if (ServerWindow != null)
            {
                id = ServerWindow.Text;
                marker = ServerWindow.Marker;
                handle = ServerWindow.Handle.ToString();
                classname = ServerWindow.GetWindowClassName();
            }
            integrity = "confirmed";
        }
        catch
        {
            integrity = "damaged";
        }
        text += "Integrity: " + integrity + "\r\n";
        text += "Id: " + id + "\r\n";
        text += "Marker: " + marker + "\r\n";
        text += "Handle: " + handle + "\r\n";
        text += "Class: " + classname + "\r\n";
        return text;
    }
    public static void EnableServer()
    {
        CreateWindow();
        Persistence.ServerState = 1;
        FireServerEnabled();
        XLog.Log("Enabled Server");
    }
    public static void DisableServer()
    {
        DestroyWindow();
        Persistence.ServerState = 0;
        FireServerDisabled();
        XLog.Log("Disabled Server");
    }
    public static void CreateWindow()
    {
        ServerWindow = new ServerWindow();
        ServerWindow.ShowInTaskbar = false;
        ServerWindow.WindowState = FormWindowState.Minimized;
        ServerWindow.Text = Persistence.ServerId;
        ServerWindow.Show();
        Ide.ServerWindow = ServerWindow;
    }
    public static void DestroyWindow()
    {
        if (ServerWindow != null)
        {
            ServerWindow.Close();
            ServerWindow.Dispose();
        }
        ServerWindow = null;
        Ide.ServerWindow = null;
    }
    public static void Update()
    {
        EnableIfNeeded();
        NotifyUi();
    }
    public static void EnableIfNeeded()
    {
        if (Persistence.ServerState == 1)
        {
            EnableServer();
        }
    }
    public static void NotifyUi()
    {
        var serverState = Persistence.ServerState;
        if (serverState == 1)
        {
            FireServerEnabled();
        }
        else if (serverState == 0)
        {
            FireServerDisabled();
        }
    }
    public static void FireServerEnabled()
    {
        var handler = ServerEnabled;
        if(handler != null)
        {
            handler.Invoke(typeof(ServerManager).Name, EventArgs.Empty);
        }
    }
    public static void FireServerDisabled()
    {
        var handler = ServerDisabled;
        if (handler != null)
        {
            handler.Invoke(typeof(ServerManager).Name, EventArgs.Empty);
        }
    }

}

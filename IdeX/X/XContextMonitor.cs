// ----------------------------------------------------
// COPYRIGHT (C) <TJG> ALL RIGHTS RESERVED. SEE THE LIC
// ENSE FILE FOR THE FULL LICENSE GOVERNING THIS CODE. 
// ----------------------------------------------------

using Microsoft.VisualStudio.Shell.Interop;
using System;

public class XContextMonitor
{
    public static VsPackage Package;
    public static void Init(VsPackage package)
    {
        Package = package;
    }
    private static IServiceProvider ServiceProvider
    {
        get
        {
            return Package;
        }
    }
    public static string GetContextString()
    {
        try
        {
            if (IsContextActive(UIContextGuids80.NoSolution) == 1)
            {
                return "NoSolution";
            }
            if (IsContextActive(UIContextGuids80.EmptySolution) == 1)
            {
                return "EmptySolution";
            }
            if (IsContextActive(UIContextGuids80.SolutionExists) == 1)
            {
                return "SolutionExists";
            }
            return "Unknown";
        }
        catch
        {
            return "";
        }
    }
    public static int IsContextActive(string context)
    {
        uint cookie;
        int active = 0;
        var monitorSelection = (IVsMonitorSelection)(ServiceProvider.GetService(typeof(IVsMonitorSelection)));
        monitorSelection.GetCmdUIContextCookie(new Guid(context), out cookie);
        monitorSelection.IsCmdUIContextActive(cookie, out active);
        return active;
    }
}

// ----------------------------------------------------
// COPYRIGHT (C) <TJG> ALL RIGHTS RESERVED. SEE THE LIC
// ENSE FILE FOR THE FULL LICENSE GOVERNING THIS CODE. 
// ----------------------------------------------------

using Microsoft.VisualStudio.Settings;
using Microsoft.VisualStudio.Shell.Settings;
using System;

/// <summary>
/// General settings are stored in "HKEY_CURRENT_USER\Software\Microsoft\VisualStudio\14.0" 
/// respective "HKEY_CURRENT_USER\Software\Microsoft\VisualStudio\14.0Exp".
/// Expert settings are stored in "%USERPROFILE%\Documents\Visual Studio 2015\Settings\CurrentSettings.vssettings" 
/// respective "%USERPROFILE%\Documents\Visual Studio 2015\Settings\Exp\CurrentSettings.vssettings".
/// </summary>
public class Persistence
{
    public static VsPackage Package;
    public static readonly string CollectionPath = Vsix.Name;
    public static readonly string CollectionVersion = Vsix.Version;
    public static event EventHandler LoggingEnabled;
    public static event EventHandler LoggingDisabled;

    public static void Init(VsPackage package)
    {
        Package = package;
    }

    public static string Edition
    {
        get { return String_Get("Edition"); }
        set { String_Set("Edition", value); }
    }
    public static string Version
    {
        get { return String_Get("Version"); }
        set { String_Set("Version", value); }
    }
    public static int ServerState
    {
        get { return Int_Get("ServerState"); }
        set { Int_Set("ServerState", value); }
    }
    public static string ServerId
    {
        get { return String_Get("ServerId"); }
        set { String_Set("ServerId", value); }
    }
    public static string Marker
    {
        get { return String_Get("Marker"); }
        set { String_Set("Marker", value); }
    }
    public static int LogEnabled
    {
        get { return Int_Get("LogEnabled"); }
        set {

            Int_Set("LogEnabled", value);
            if(value == 1)
            {
                FireLogEnabled();
            }
            else
            {
                FireLogDisabled();
            }
        }
    }
    public static int AutoUpdateLogfileControls
    {
        get { return Int_Get("AutoUpdateLogfileControls"); }
        set { Int_Set("AutoUpdateLogfileControls", value); }
    }

    public static WritableSettingsStore GetSettingsStore()
    {
        var settingsManager = new ShellSettingsManager(Package);
        // User settings are in "HKEY_CURRENT_USER\Software\Microsoft\VisualStudio\14.0"
        // or "HKEY_CURRENT_USER\Software\Microsoft\VisualStudio\14.0Exp"
        var store = settingsManager.GetWritableSettingsStore(SettingsScope.UserSettings);

        if (!store.CollectionExists(CollectionPath))
        {
            store.CreateCollection(CollectionPath);
            Version = CollectionVersion;
            Edition = "Base Edition";
            ServerState = 0;
            ServerId = "IdexServer";
            Marker = "IDEX";
            LogEnabled = 0;
            AutoUpdateLogfileControls = 0;
        }
        return store;
    }
    public static int Int_Get(string name)
    {
        var store = GetSettingsStore();
        if(store.PropertyExists(CollectionPath, name))
        {
            return store.GetInt32(CollectionPath, name);
        }
        return 0;
    }
    public static void Int_Set(string name, int value)
    {
        var store = GetSettingsStore();
        store.SetInt32(CollectionPath, name, value);
    }
    public static string String_Get(string name)
    {
        var store = GetSettingsStore();
        if(store.PropertyExists(CollectionPath, name))
        {
            return store.GetString(CollectionPath, name);
        }
        return "";
    }
    public static void String_Set(string name, string value)
    {
        var store = GetSettingsStore();
        store.SetString(CollectionPath, name, value);
    }

    public static ExpertPage GetExpertPage()
    {
        var page = (ExpertPage)Package.GetDialogPage(typeof(ExpertPage));
        return page;
    }
    public static bool SupportGetOps
    {
        get
        {
            return GetExpertPage().SupportGetOps;
        }
    }
    public static bool SupportSetOps
    {
        get
        {
            return GetExpertPage().SupportSetOps;
        }
    }
    public static bool ClaimMarkerInRequest
    {
        get
        {
            return GetExpertPage().ClaimMarkerInRequest;
        }
    }
    public static bool IncludeMarkerInResponse
    {
        get
        {
            return GetExpertPage().IncludeMarkerInResponse;
        }
    }
    public static IdexEncoding RequestEncoding
    {
        get
        {
            return GetExpertPage().RequestEncoding;
        }
    }
    public static IdexEncoding ResponseEncoding
    {
        get
        {
            return GetExpertPage().ResponseEncoding;
        }
    }

    public static void FireLogEnabled()
    {
        var handler = LoggingEnabled;
        if(handler != null)
        {
            handler.Invoke(typeof(Persistence),EventArgs.Empty);
        }
    }
    public static void FireLogDisabled()
    {
        var handler = LoggingDisabled;
        if (handler != null)
        {
            handler.Invoke(typeof(Persistence), EventArgs.Empty);
        }
    }
}


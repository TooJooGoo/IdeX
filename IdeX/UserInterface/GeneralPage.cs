// ----------------------------------------------------
// COPYRIGHT (C) <TJG> ALL RIGHTS RESERVED. SEE THE LIC
// ENSE FILE FOR THE FULL LICENSE GOVERNING THIS CODE. 
// ----------------------------------------------------

using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Settings;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.Shell.Settings;
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;

/// <summary>
/// https://msdn.microsoft.com/en-us/library/bb166195.aspx
/// </summary>
[Guid("BADA5A51-A811-4AF9-B818-CA07681A69B1")]
public class GeneralPage : DialogPage
{
    public GeneralUserControl UserControlInstance;

    /// <summary>
    /// Called when the dialog page is opened the first time.
    /// </summary>
    protected override IWin32Window Window
    {
        get
        {
            UserControlInstance = new GeneralUserControl();
            UserControlInstance.GeneralPageInstance = this;
            UserControlInstance.Initialize();
            return UserControlInstance;
        }
    }

    /// <summary>
    /// Is called when:
    /// - button "Cancel" is pressed
    /// - button "X" is pressed
    /// - button "Apply" is pressed
    /// - key "Alt+F4" is pressed
    /// </summary>
    public override void LoadSettingsFromStorage()
    {
        //XMB.Info("LoadSettingsFromStorage");
        if(UserControlInstance != null)
        {
            UserControlInstance.LoadSettings();
        }
    }
    /// <summary>
    /// Is called when:
    /// - button "Apply" is pressed
    /// - key "Enter" is pressed
    /// </summary>
    public override void SaveSettingsToStorage()
    {
        //XMB.Info("SaveSettingsToStorage");
        if(UserControlInstance != null)
        {
            UserControlInstance.SaveSettings();
        }
    }

    //protected override void OnApply(PageApplyEventArgs e)
    //{
    //    XMB.Info("OnActivate, e.ApplyBehavior = " + e.ApplyBehavior.ToString());
    //    base.OnApply(e);
    //}
    /// <summary>
    /// Is called each time when the dialog page is opened.
    /// </summary>
    //protected override void OnActivate(CancelEventArgs e)
    //{
    //    XMB.Info("OnActivate, e.Cancel = " + e.Cancel.ToString());
    //    base.OnActivate(e);
    //}
    //protected override void SaveSetting(PropertyDescriptor property)
    //{
    //    //XMB.Info("SaveSetting");
    //    base.SaveSetting(property);
    //}
    //protected override void OnClosed(EventArgs e)
    //{
    //    XMB.Info("OnClosed");
    //    base.OnClosed(e);
    //}
    //protected override void OnDeactivate(CancelEventArgs e)
    //{
    //    XMB.Info("OnDeactivate, e.Cancel = " + e.Cancel.ToString());
    //    base.OnDeactivate(e);
    //}
}

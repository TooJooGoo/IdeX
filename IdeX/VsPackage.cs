// ----------------------------------------------------
// COPYRIGHT (C) <TJG> ALL RIGHTS RESERVED. SEE THE LIC
// ENSE FILE FOR THE FULL LICENSE GOVERNING THIS CODE. 
// ----------------------------------------------------

using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Runtime.InteropServices;

[PackageRegistration(UseManagedResourcesOnly = true)]
// Integrate into "Help/About".
[InstalledProductRegistration("#110", "#112", Vsix.Version, IconResourceID = 400)]
[ProvideMenuResource("Menus.ctmenu", 1)]
[Guid(IdeX.PackageGuids.IdexPackageGuidString)]
// Integrate into "Tools/Options".
[ProvideOptionPage(typeof(GeneralPage), "IdeX", "General", 0, 0, true)]
[ProvideOptionPage(typeof(ExpertPage), "IdeX", "Expert", 0, 0, true)]
// Integrate a custom settings point into the "Import and Export settings" wizard.
// The custom settings point data is stored in the vssettings file under TJG_IdeX.
// See https://msdn.microsoft.com/en-us/library/bb166176.aspx
[ProvideProfile(typeof(ExpertPage)
    , "TJG"
    , "IdeX"
    , 106
    , 107 // Is shown in "Import and Export settings" as node name.
    , isToolsOptionPage: true
    , DescriptionResourceID = 108 // Is shown in "Import and Export settings" as node description.
    )]
[ProvideAutoLoad(UIContextGuids80.NoSolution, PackageAutoLoadFlags.None)]
[ProvideAutoLoad(UIContextGuids80.EmptySolution, PackageAutoLoadFlags.None)]
[ProvideAutoLoad(UIContextGuids80.SolutionExists, PackageAutoLoadFlags.None)]
public sealed class VsPackage : Package
{
    /// <summary>
    /// Is called by Visual Studio on demand.
    /// </summary>
    protected override void Initialize()
    {
        XLog.Init();
        XContextMonitor.Init(this);
        Ide.Init(this);
        Persistence.Init(this);
        ServerManager.Init(this);
        MenuCommands.Initialize(this);
        ServerManager.Update();
        base.Initialize();
    }
}

// ----------------------------------------------------
// COPYRIGHT (C) <TooJooGoo> ALL RIGHTS RESERVED. SEE THE LIC
// ENSE FILE FOR THE FULL LICENSE GOVERNING THIS CODE. 
// ----------------------------------------------------

using System;
using System.ComponentModel.Design;
using Microsoft.VisualStudio.Shell;
using System.Threading;
using System.IO;
using System.Diagnostics;

internal sealed class MenuCommands
{
    public static readonly Guid CommandSet = IdeX.PackageGuids.IdexMenuGroupGuid;
    public static readonly CommandID EnableButtonCid = new CommandID(CommandSet, IdeX.PackageIds.EnableButton);
    public static readonly CommandID DisableButtonCid = new CommandID(CommandSet, IdeX.PackageIds.DisableButton);
    public static readonly CommandID OptionsButtonCid = new CommandID(CommandSet, IdeX.PackageIds.OptionsButton);
    public static readonly CommandID ExpertButtonCid = new CommandID(CommandSet, IdeX.PackageIds.ExpertButton);
    public static readonly CommandID LabButtonCid = new CommandID(CommandSet, IdeX.PackageIds.LabButton);
    private readonly Package package;

    private MenuCommands(Package package)
    {
        if (package == null)
        {
            throw new ArgumentNullException("package");
        }
        this.package = package;
        var commandService = this.ServiceProvider.GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
        if (commandService != null)
        {
            var enableButton = new OleMenuCommand(EnableButton_Click, EnableButtonCid);
            commandService.AddCommand(enableButton);

            var disableButton = new OleMenuCommand(DisableButton_Click, DisableButtonCid);
            commandService.AddCommand(disableButton);

            var labButton = new MenuCommand(LabButton_Click, LabButtonCid);
            commandService.AddCommand(labButton);

            var optionsButton = new MenuCommand(OptionsButton_Click, OptionsButtonCid);
            commandService.AddCommand(optionsButton);

            var expertButton = new MenuCommand(ExpertButton_Click, ExpertButtonCid);
            commandService.AddCommand(expertButton);
            
            ServerManager.ServerDisabled += ServerManager_ServerDisabled;
            ServerManager.ServerEnabled += ServerManager_ServerEnabled;
        }
    }
    public static void Initialize(Package package)
    {
        Instance = new MenuCommands(package);
    }

    private void EnableButton_Click(object sender, EventArgs e)
    {
        Ide.StatusBar_Set("Enable starts...");
        if (ServerManager.CanEnable())
        {
            Thread.Sleep(250);
            XLog.DeleteLogfile();
            Thread.Sleep(1250);
            ServerManager.EnableServer();
            Ide.StatusBar_Set("Enable succeeded");
        }
        else
        {
            Ide.StatusBar_Set("Enable failed, because the settings are invalid.");
        }
    }
    private void DisableButton_Click(object sender, EventArgs e)
    {
        Ide.StatusBar_Set("Disable starts...");
        ServerManager.DisableServer();
        Ide.StatusBar_Set("Disable succeeded");

    }
    private void LabButton_Click(object sender, EventArgs e)
    {
        var temp = Path.GetTempPath();
        if (!temp.EndsWith("\\"))
        {
            temp += "\\";
        }
        temp += "IdeX";
        if (!Directory.Exists(temp))
        {
            Directory.CreateDirectory(temp);
        }
        var labExe = temp + "\\IdexLab_64.exe";
        if (!File.Exists(labExe))
        {
            byte[] exeBytes = IdeX.MainResource.IdexLab_64;
            using (var stream = new FileStream(labExe, FileMode.CreateNew, FileAccess.Write))
            {
                byte[] bytes = exeBytes;
                stream.Write(bytes, 0, bytes.Length);
                stream.Close();
                stream.Dispose();
            }
        }
        if(File.Exists(labExe))
        {
            var process = new Process();
            process.StartInfo.FileName = labExe;
            process.StartInfo.Arguments = "";
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();
        }
        else
        {
            XMB.Info("The IdeX Lab is not available.");
        }
    }
    private void OptionsButton_Click(object sender, EventArgs e)
    {
        try
        {
            package.ShowOptionPage(typeof(GeneralPage));
        }
        catch
        {
        }
    }
    private void ExpertButton_Click(object sender, EventArgs e)
    {
        try
        {
            package.ShowOptionPage(typeof(ExpertPage));
        }
        catch
        {
        }
    }
    private void ServerManager_ServerEnabled(object sender, EventArgs e)
    {
        var enableButton = GetCommandService().FindCommand(EnableButtonCid);
        enableButton.Enabled = false;

        var disableButton = GetCommandService().FindCommand(DisableButtonCid);
        disableButton.Enabled = true;
    }
    private void ServerManager_ServerDisabled(object sender, EventArgs e)
    {
        var enableButton = GetOleCommand(EnableButtonCid) as OleMenuCommand;
        if(ServerManager.ServerState == 0)
        {
            if(ServerManager.CanEnable())
            {
                enableButton.Enabled = true;
            }
        }
        var disableButton = GetOleCommand(DisableButtonCid) as OleMenuCommand;
        if (ServerManager.ServerState == 0)
        {
            disableButton.Enabled = false;
        }
    }

    public static MenuCommands Instance
    {
        get;
        private set;
    }
    private IServiceProvider ServiceProvider
    {
        get
        {
            return this.package;
        }
    }
    private OleMenuCommandService GetCommandService()
    {
        var commandService = ServiceProvider.GetService(typeof(IMenuCommandService))
            as OleMenuCommandService;
        return commandService;
    }
    private OleMenuCommand GetOleCommand(CommandID cid)
    {
        return GetCommandService().FindCommand(cid) as OleMenuCommand;
    }
}

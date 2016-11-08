// ----------------------------------------------------
// COPYRIGHT (C) <TJG> ALL RIGHTS RESERVED. SEE THE LIC
// ENSE FILE FOR THE FULL LICENSE GOVERNING THIS CODE. 
// ----------------------------------------------------

using System;
using System.Windows.Forms;
using System.Diagnostics;

public partial class GeneralUserControl : UserControl
{
    public GeneralPage GeneralPageInstance;
    public XTimer Timer;

    public GeneralUserControl()
    {
        InitializeComponent();
    }
    public void Initialize()
    {
        LoadSettings();


        ProductLabel.Text = $"{Vsix.Author} {Vsix.Name} {Persistence.Edition} {Vsix.Version}";

        if (Persistence.ServerState == 1)
        {
            StateLabel.Text = "Enabled";
            EnableButton.Enabled = false;
            DisableButton.Enabled = true;
            ServerIdText.Enabled = false;
            MarkerText.Enabled = false;
            ProfileText.Text = ServerManager.GetProfileText();
            LogoPicture.Image = IdeX.MainResource.idex_128;
        }
        else
        {
            StateLabel.Text = "Disabled";
            EnableButton.Enabled = true;
            DisableButton.Enabled = false;
            ServerIdText.Enabled = true;
            MarkerText.Enabled = true;
            ProfileText.Text = "";
            LogoPicture.Image = IdeX.MainResource.idex_gray_128;
        }
        UpdateLogfileButtons();
        UpdateServerIdPicture();
        UpdateMarkerPicture();

        AutoUpdateCheckbox.Checked = (Persistence.AutoUpdateLogfileControls == 1) ? true : false;
        Timer = XTimer.CreateStoppedTimer(Timer_IntervalElapsed);
        Timer.StartMultiEvent(1000, 5000);

        ServerManager.ServerDisabled += ServerManager_ServerDisabled;
        ServerManager.ServerEnabled += ServerManager_ServerEnabled;
        
        ManualTT.SetToolTip(ServerIdLabel, XString.WrapWords(IdeX.MainResource.ServerIdLabelInfo));
        ManualTT.SetToolTip(MarkerLabel, XString.WrapWords(IdeX.MainResource.MarkerLabelInfo));
        ManualTT.SetToolTip(ProductCopyLink, XString.WrapWords(IdeX.MainResource.ProductCopyLinkInfo));
        ManualTT.SetToolTip(ProfileLabel, XString.WrapWords(IdeX.MainResource.ProfileLabelInfo));
        ManualTT.SetToolTip(ProfileCopyLink, XString.WrapWords(IdeX.MainResource.ProfileCopyLinkInfo));
        ManualTT.SetToolTip(LogfileCopyLink, XString.WrapWords(IdeX.MainResource.LogfileCopyLinkInfo));
        ManualTT.SetToolTip(LogCheckbox, XString.WrapWords(IdeX.MainResource.LogCheckboxInfo));
        ManualTT.SetToolTip(AutoUpdateCheckbox, XString.WrapWords(IdeX.MainResource.AutoUpdateCheckboxInfo));

        XLog.DeleteLogfileIfTooLarge();
    }

    public void LoadSettings()
    {
        ServerIdText.Text = Persistence.ServerId;
        MarkerText.Text = Persistence.Marker;
        LogCheckbox.Checked = (Persistence.LogEnabled == 1);
    }
    public void SaveSettings()
    {
        Persistence.ServerId = ServerIdText.Text;
        Persistence.Marker = MarkerText.Text;
        Persistence.LogEnabled = LogCheckbox.Checked ? 1 : 0;
    }

    private void ServerManager_ServerEnabled(object sender, EventArgs e)
    {
        StateLabel.Text = "Enabled";
        EnableButton.Enabled = false;
        DisableButton.Enabled = true;
        ServerIdText.Enabled = false;
        MarkerText.Enabled = false;
        ProfileText.Text = ServerManager.GetProfileText();
        LogoPicture.Image = IdeX.MainResource.idex_128;
    }
    private void ServerManager_ServerDisabled(object sender, EventArgs e)
    {
        StateLabel.Text = "Disabled";
        EnableButton.Enabled = true;
        DisableButton.Enabled = false;
        ServerIdText.Enabled = true;
        MarkerText.Enabled = true;
        ProfileText.Text = "";
        LogoPicture.Image = IdeX.MainResource.idex_gray_128;
    }

    private void EnableButton_Click(object sender, EventArgs e)
    {
        ServerIdText.Text = ServerIdText.Text.Trim();

        if (!ServerId_CheckSyntax())
        {
            XMB.Info("The given Id is not valid.");
            ServerIdText.Focus();
            return;
        }

        if (!Marker_CheckSyntax())
        {
            XMB.Info("The given Marker is not valid.");
            MarkerText.Focus();
            return;
        }

        GeneralPageInstance.SaveSettingsToStorage();
        ServerManager.EnableServer();
    }
    private void DisableButton_Click(object sender, EventArgs e)
    {
        ServerManager.DisableServer();
        GeneralPageInstance.SaveSettingsToStorage();
    }

    private void LogfileCheckbox_CheckedChanged(object sender, EventArgs e)
    {
        Persistence.LogEnabled = LogCheckbox.Checked ? 1 : 0;
    }
    private void OpenLogfileButton_Click(object sender, EventArgs e)
    {
        if (XLog.Exists)
        {
            XLog.DeleteLogfileIfTooLarge();

            var process = new Process();
            process.StartInfo.FileName = "notepad";
            process.StartInfo.Arguments = "\"" + XLog.LogFile + "\"";
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();
        }
        else
        {
            XMB.Info("No logs are available.");
        }
    }
    private void ClearLogfileButton_Click(object sender, EventArgs e)
    {
        if(XLog.Exists)
        {
            XLog.DeleteLogfile();
            XMB.Info("The Logfile has been deleted.");
        }
        else
        {
            XMB.Info("The Logfile has already been deleted.");
        }
    }
    private void UpdateLogfileButtons()
    {
        LogfileText.Text = XLog.LogFile;
        OpenLogfileButton.Enabled = true;
        ClearLogfileButton.Enabled = true;
    }

    private bool ServerId_CheckSyntax()
    {
        return ServerManager.ServerId_IsValid(ServerIdText.Text);
    }
    private void ServerIdText_TextChanged(object sender, EventArgs e)
    {
        UpdateServerIdPicture();
    }
    private void UpdateServerIdPicture()
    {
        if(ServerId_CheckSyntax())
        {
            ServerIdPicture.Image = IdeX.MainResource.i_blue_smooth_64;
            RedTT.SetToolTip(ServerIdPicture, null);
            BlueTT.SetToolTip(ServerIdPicture, "Input is OK.");
        }
        else
        {
            ServerIdPicture.Image = IdeX.MainResource.i_red_smooth_64;
            RedTT.SetToolTip(ServerIdPicture
                , "Input needs 2-20 alphanumeric chars.");
            BlueTT.SetToolTip(ServerIdPicture, null);
        }
    }

    private bool Marker_CheckSyntax()
    {
        return ServerManager.Marker_IsValid(MarkerText.Text);
    }
    private void MarkerText_TextChanged(object sender, EventArgs e)
    {
        UpdateMarkerPicture();
    }
    private void UpdateMarkerPicture()
    {
        if (Marker_CheckSyntax())
        {
            MarkerPicture.Image = IdeX.MainResource.i_blue_smooth_64;
            RedTT.SetToolTip(MarkerPicture, null);
            BlueTT.SetToolTip(MarkerPicture, "Input is OK.");
        }
        else
        {
            MarkerPicture.Image = IdeX.MainResource.i_red_smooth_64;
            RedTT.SetToolTip(MarkerPicture
            , "Input needs 2-8 alphanumeric chars.");
            BlueTT.SetToolTip(MarkerPicture, null);
        }
    }

    private void LogoPicture_Click(object sender, EventArgs e)
    {
        var str = "Hello picture";
        BlueTT.ShowAlways = true;
        BlueTT.AutomaticDelay = 0;
        BlueTT.AutoPopDelay = 2000;
        BlueTT.InitialDelay = 0;
        BlueTT.ReshowDelay = 100;
        BlueTT.ToolTipIcon = ToolTipIcon.None;
        BlueTT.ToolTipTitle = "";
        BlueTT.UseFading = false;
        BlueTT.Show(str, LogoPicture);
    }
    private void CopyLink_MouseDown(object sender, MouseEventArgs e)
    {
        XCache.SetTextSafe(ProductLabel.Text);
        CopyTT_Show(ProductLabel);
    }
    private void ProfileCopyLink_MouseDown(object sender, MouseEventArgs e)
    {
        XCache.SetTextSafe(ProfileText.Text);
        CopyTT_Show(ProfileText);
    }
    private void LogfileCopyLink_MouseDown(object sender, MouseEventArgs e)
    {
        XCache.SetTextSafe(LogfileText.Text);
        CopyTT_Show(LogfileText);
    }
    private void CopyTT_Show(Control control, string content = "Copy succeeded")
    {
        CopyTT.Show(content
        , control
        , control.Width / 2 - 30
        , control.Height / 2 - 5
        , 900);
    }

    private void AutoUpdateCheckbox_CheckedChanged(object sender, EventArgs e)
    {
        var autoUpdate = AutoUpdateCheckbox.Checked;
        Persistence.AutoUpdateLogfileControls = (autoUpdate == true) ? 1 : 0;

        if(Timer != null)
        {
            Timer.Discard();
            Timer = null;
        }

        if(autoUpdate)
        {
            Timer = XTimer.CreateStoppedTimer(Timer_IntervalElapsed);
            Timer.StartMultiEvent(1000, 5000);
        }
        else
        {
            OpenLogfileButton.Enabled = true;
            ClearLogfileButton.Enabled = true;
        }     
    }
    private void Timer_IntervalElapsed(object state)
    {
        if (AutoUpdateCheckbox.Checked)
        {
            if (XLog.Exists)
            {
                OpenLogfileButton.InvokeAction(() => { OpenLogfileButton.Enabled = true; });
                ClearLogfileButton.InvokeAction(() => { ClearLogfileButton.Enabled = true; });
            }
            else
            {
                OpenLogfileButton.InvokeAction(() => { OpenLogfileButton.Enabled = false; });
                ClearLogfileButton.InvokeAction(() => { ClearLogfileButton.Enabled = false; });
            }
        }
    }
}




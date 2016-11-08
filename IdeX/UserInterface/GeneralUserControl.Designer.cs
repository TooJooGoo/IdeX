
partial class GeneralUserControl
{
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            this.MarkerText = new System.Windows.Forms.TextBox();
            this.ProductLabel = new System.Windows.Forms.Label();
            this.EnableButton = new System.Windows.Forms.Button();
            this.DisableButton = new System.Windows.Forms.Button();
            this.StateLabel = new System.Windows.Forms.Label();
            this.CurrentStateLabel = new System.Windows.Forms.Label();
            this.OpenLogfileButton = new System.Windows.Forms.Button();
            this.ClearLogfileButton = new System.Windows.Forms.Button();
            this.LogfileText = new System.Windows.Forms.TextBox();
            this.MarkerLabel = new System.Windows.Forms.Label();
            this.ServerIdLabel = new System.Windows.Forms.Label();
            this.ServerIdText = new System.Windows.Forms.TextBox();
            this.ProfileText = new System.Windows.Forms.TextBox();
            this.ProfileLabel = new System.Windows.Forms.Label();
            this.LogCheckbox = new System.Windows.Forms.CheckBox();
            this.RedTT = new System.Windows.Forms.ToolTip(this.components);
            this.ServerIdPicture = new System.Windows.Forms.PictureBox();
            this.LogoPicture = new System.Windows.Forms.PictureBox();
            this.MarkerPicture = new System.Windows.Forms.PictureBox();
            this.BlueTT = new System.Windows.Forms.ToolTip(this.components);
            this.ProductCopyLink = new System.Windows.Forms.LinkLabel();
            this.CopyTT = new System.Windows.Forms.ToolTip(this.components);
            this.ProfileCopyLink = new System.Windows.Forms.LinkLabel();
            this.LogfileCopyLink = new System.Windows.Forms.LinkLabel();
            this.AutoUpdateCheckbox = new System.Windows.Forms.CheckBox();
            this.ManualTT = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ServerIdPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MarkerPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // MarkerText
            // 
            this.MarkerText.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MarkerText.Location = new System.Drawing.Point(57, 120);
            this.MarkerText.MaxLength = 16;
            this.MarkerText.Name = "MarkerText";
            this.MarkerText.Size = new System.Drawing.Size(217, 20);
            this.MarkerText.TabIndex = 0;
            this.MarkerText.Text = "IDEX";
            this.MarkerText.TextChanged += new System.EventHandler(this.MarkerText_TextChanged);
            // 
            // ProductLabel
            // 
            this.ProductLabel.BackColor = System.Drawing.Color.DarkGray;
            this.ProductLabel.Location = new System.Drawing.Point(82, 12);
            this.ProductLabel.Name = "ProductLabel";
            this.ProductLabel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 4);
            this.ProductLabel.Size = new System.Drawing.Size(186, 20);
            this.ProductLabel.TabIndex = 0;
            this.ProductLabel.Text = "IdeX Test Edition";
            // 
            // EnableButton
            // 
            this.EnableButton.Location = new System.Drawing.Point(82, 52);
            this.EnableButton.Name = "EnableButton";
            this.EnableButton.Size = new System.Drawing.Size(90, 23);
            this.EnableButton.TabIndex = 0;
            this.EnableButton.Text = "Enable";
            this.EnableButton.UseVisualStyleBackColor = true;
            this.EnableButton.Click += new System.EventHandler(this.EnableButton_Click);
            // 
            // DisableButton
            // 
            this.DisableButton.Location = new System.Drawing.Point(178, 52);
            this.DisableButton.Name = "DisableButton";
            this.DisableButton.Size = new System.Drawing.Size(90, 23);
            this.DisableButton.TabIndex = 0;
            this.DisableButton.TabStop = false;
            this.DisableButton.Text = "Disable";
            this.DisableButton.UseVisualStyleBackColor = true;
            this.DisableButton.Click += new System.EventHandler(this.DisableButton_Click);
            // 
            // StateLabel
            // 
            this.StateLabel.AutoSize = true;
            this.StateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StateLabel.Location = new System.Drawing.Point(155, 32);
            this.StateLabel.Name = "StateLabel";
            this.StateLabel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 4);
            this.StateLabel.Size = new System.Drawing.Size(60, 20);
            this.StateLabel.TabIndex = 0;
            this.StateLabel.Text = "Unknown";
            // 
            // CurrentStateLabel
            // 
            this.CurrentStateLabel.AutoSize = true;
            this.CurrentStateLabel.Location = new System.Drawing.Point(82, 32);
            this.CurrentStateLabel.Name = "CurrentStateLabel";
            this.CurrentStateLabel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 4);
            this.CurrentStateLabel.Size = new System.Drawing.Size(72, 20);
            this.CurrentStateLabel.TabIndex = 0;
            this.CurrentStateLabel.Text = "Current State:";
            // 
            // OpenLogfileButton
            // 
            this.OpenLogfileButton.Location = new System.Drawing.Point(12, 372);
            this.OpenLogfileButton.Name = "OpenLogfileButton";
            this.OpenLogfileButton.Size = new System.Drawing.Size(90, 23);
            this.OpenLogfileButton.TabIndex = 0;
            this.OpenLogfileButton.Text = "Show Logfile";
            this.OpenLogfileButton.UseVisualStyleBackColor = true;
            this.OpenLogfileButton.Click += new System.EventHandler(this.OpenLogfileButton_Click);
            // 
            // ClearLogfileButton
            // 
            this.ClearLogfileButton.Location = new System.Drawing.Point(108, 372);
            this.ClearLogfileButton.Name = "ClearLogfileButton";
            this.ClearLogfileButton.Size = new System.Drawing.Size(90, 23);
            this.ClearLogfileButton.TabIndex = 0;
            this.ClearLogfileButton.Text = "Delete Logfile";
            this.ClearLogfileButton.UseVisualStyleBackColor = true;
            this.ClearLogfileButton.Click += new System.EventHandler(this.ClearLogfileButton_Click);
            // 
            // LogfileText
            // 
            this.LogfileText.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogfileText.Location = new System.Drawing.Point(12, 300);
            this.LogfileText.Multiline = true;
            this.LogfileText.Name = "LogfileText";
            this.LogfileText.ReadOnly = true;
            this.LogfileText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogfileText.Size = new System.Drawing.Size(360, 60);
            this.LogfileText.TabIndex = 0;
            // 
            // MarkerLabel
            // 
            this.MarkerLabel.AutoSize = true;
            this.MarkerLabel.Location = new System.Drawing.Point(12, 120);
            this.MarkerLabel.Name = "MarkerLabel";
            this.MarkerLabel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 4);
            this.MarkerLabel.Size = new System.Drawing.Size(40, 20);
            this.MarkerLabel.TabIndex = 0;
            this.MarkerLabel.Text = "Marker";
            // 
            // ServerIdLabel
            // 
            this.ServerIdLabel.AutoSize = true;
            this.ServerIdLabel.Location = new System.Drawing.Point(12, 88);
            this.ServerIdLabel.Name = "ServerIdLabel";
            this.ServerIdLabel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 4);
            this.ServerIdLabel.Size = new System.Drawing.Size(16, 20);
            this.ServerIdLabel.TabIndex = 0;
            this.ServerIdLabel.Text = "Id";
            // 
            // ServerIdText
            // 
            this.ServerIdText.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServerIdText.Location = new System.Drawing.Point(34, 88);
            this.ServerIdText.MaxLength = 32;
            this.ServerIdText.Name = "ServerIdText";
            this.ServerIdText.Size = new System.Drawing.Size(240, 20);
            this.ServerIdText.TabIndex = 0;
            this.ServerIdText.Text = "IdexServer";
            this.ServerIdText.TextChanged += new System.EventHandler(this.ServerIdText_TextChanged);
            // 
            // ProfileText
            // 
            this.ProfileText.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProfileText.Location = new System.Drawing.Point(12, 175);
            this.ProfileText.Multiline = true;
            this.ProfileText.Name = "ProfileText";
            this.ProfileText.ReadOnly = true;
            this.ProfileText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ProfileText.Size = new System.Drawing.Size(360, 90);
            this.ProfileText.TabIndex = 0;
            this.ProfileText.Text = "Title: IdexServer\r\nHandle: 202020\r\nClass: WindowClass.Can.Be.A.Very.Long.Text.In." +
    "Some.Situations\r\n";
            this.ProfileText.WordWrap = false;
            // 
            // ProfileLabel
            // 
            this.ProfileLabel.AutoSize = true;
            this.ProfileLabel.Location = new System.Drawing.Point(12, 152);
            this.ProfileLabel.Name = "ProfileLabel";
            this.ProfileLabel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 4);
            this.ProfileLabel.Size = new System.Drawing.Size(36, 20);
            this.ProfileLabel.TabIndex = 0;
            this.ProfileLabel.Text = "Profile";
            // 
            // LogCheckbox
            // 
            this.LogCheckbox.AutoSize = true;
            this.LogCheckbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LogCheckbox.Location = new System.Drawing.Point(12, 277);
            this.LogCheckbox.Name = "LogCheckbox";
            this.LogCheckbox.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.LogCheckbox.Size = new System.Drawing.Size(44, 20);
            this.LogCheckbox.TabIndex = 0;
            this.LogCheckbox.Text = "Log";
            this.LogCheckbox.UseVisualStyleBackColor = true;
            this.LogCheckbox.CheckedChanged += new System.EventHandler(this.LogfileCheckbox_CheckedChanged);
            // 
            // RedTT
            // 
            this.RedTT.AutomaticDelay = 0;
            this.RedTT.AutoPopDelay = 3000;
            this.RedTT.InitialDelay = 0;
            this.RedTT.ReshowDelay = 0;
            this.RedTT.ShowAlways = true;
            this.RedTT.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Error;
            this.RedTT.ToolTipTitle = "Error";
            this.RedTT.UseAnimation = false;
            this.RedTT.UseFading = false;
            // 
            // ServerIdPicture
            // 
            this.ServerIdPicture.Image = global::IdeX.MainResource.i_blue_smooth_64;
            this.ServerIdPicture.Location = new System.Drawing.Point(254, 90);
            this.ServerIdPicture.Name = "ServerIdPicture";
            this.ServerIdPicture.Size = new System.Drawing.Size(16, 16);
            this.ServerIdPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ServerIdPicture.TabIndex = 0;
            this.ServerIdPicture.TabStop = false;
            // 
            // LogoPicture
            // 
            this.LogoPicture.BackColor = System.Drawing.Color.DarkGray;
            this.LogoPicture.Image = global::IdeX.MainResource.idex_128;
            this.LogoPicture.Location = new System.Drawing.Point(12, 12);
            this.LogoPicture.Name = "LogoPicture";
            this.LogoPicture.Size = new System.Drawing.Size(64, 64);
            this.LogoPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LogoPicture.TabIndex = 0;
            this.LogoPicture.TabStop = false;
            this.LogoPicture.Click += new System.EventHandler(this.LogoPicture_Click);
            // 
            // MarkerPicture
            // 
            this.MarkerPicture.Image = global::IdeX.MainResource.i_blue_smooth_64;
            this.MarkerPicture.Location = new System.Drawing.Point(254, 122);
            this.MarkerPicture.Name = "MarkerPicture";
            this.MarkerPicture.Size = new System.Drawing.Size(16, 16);
            this.MarkerPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MarkerPicture.TabIndex = 0;
            this.MarkerPicture.TabStop = false;
            // 
            // BlueTT
            // 
            this.BlueTT.AutomaticDelay = 0;
            this.BlueTT.AutoPopDelay = 3000;
            this.BlueTT.InitialDelay = 0;
            this.BlueTT.ReshowDelay = 0;
            this.BlueTT.ShowAlways = true;
            this.BlueTT.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.BlueTT.ToolTipTitle = "Info";
            this.BlueTT.UseAnimation = false;
            this.BlueTT.UseFading = false;
            // 
            // ProductCopyLink
            // 
            this.ProductCopyLink.ActiveLinkColor = System.Drawing.SystemColors.Control;
            this.ProductCopyLink.AutoSize = true;
            this.ProductCopyLink.Location = new System.Drawing.Point(274, 10);
            this.ProductCopyLink.Name = "ProductCopyLink";
            this.ProductCopyLink.Padding = new System.Windows.Forms.Padding(0, 3, 0, 4);
            this.ProductCopyLink.Size = new System.Drawing.Size(98, 20);
            this.ProductCopyLink.TabIndex = 0;
            this.ProductCopyLink.TabStop = true;
            this.ProductCopyLink.Text = "copy product name";
            this.ProductCopyLink.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CopyLink_MouseDown);
            // 
            // CopyTT
            // 
            this.CopyTT.AutomaticDelay = 0;
            this.CopyTT.ShowAlways = true;
            this.CopyTT.UseAnimation = false;
            this.CopyTT.UseFading = false;
            // 
            // ProfileCopyLink
            // 
            this.ProfileCopyLink.ActiveLinkColor = System.Drawing.SystemColors.Control;
            this.ProfileCopyLink.AutoSize = true;
            this.ProfileCopyLink.BackColor = System.Drawing.SystemColors.Control;
            this.ProfileCopyLink.Location = new System.Drawing.Point(311, 151);
            this.ProfileCopyLink.Margin = new System.Windows.Forms.Padding(0);
            this.ProfileCopyLink.Name = "ProfileCopyLink";
            this.ProfileCopyLink.Padding = new System.Windows.Forms.Padding(0, 3, 0, 4);
            this.ProfileCopyLink.Size = new System.Drawing.Size(61, 20);
            this.ProfileCopyLink.TabIndex = 0;
            this.ProfileCopyLink.TabStop = true;
            this.ProfileCopyLink.Text = "copy profile";
            this.ProfileCopyLink.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ProfileCopyLink_MouseDown);
            // 
            // LogfileCopyLink
            // 
            this.LogfileCopyLink.ActiveLinkColor = System.Drawing.SystemColors.Control;
            this.LogfileCopyLink.AutoSize = true;
            this.LogfileCopyLink.BackColor = System.Drawing.SystemColors.Control;
            this.LogfileCopyLink.Location = new System.Drawing.Point(318, 277);
            this.LogfileCopyLink.Margin = new System.Windows.Forms.Padding(0);
            this.LogfileCopyLink.Name = "LogfileCopyLink";
            this.LogfileCopyLink.Padding = new System.Windows.Forms.Padding(0, 3, 0, 4);
            this.LogfileCopyLink.Size = new System.Drawing.Size(54, 20);
            this.LogfileCopyLink.TabIndex = 0;
            this.LogfileCopyLink.TabStop = true;
            this.LogfileCopyLink.Text = "copy path";
            this.LogfileCopyLink.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LogfileCopyLink_MouseDown);
            // 
            // AutoUpdateCheckbox
            // 
            this.AutoUpdateCheckbox.AutoSize = true;
            this.AutoUpdateCheckbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AutoUpdateCheckbox.Location = new System.Drawing.Point(72, 280);
            this.AutoUpdateCheckbox.Name = "AutoUpdateCheckbox";
            this.AutoUpdateCheckbox.Size = new System.Drawing.Size(100, 17);
            this.AutoUpdateCheckbox.TabIndex = 0;
            this.AutoUpdateCheckbox.Text = "Update Buttons";
            this.AutoUpdateCheckbox.UseVisualStyleBackColor = true;
            this.AutoUpdateCheckbox.CheckedChanged += new System.EventHandler(this.AutoUpdateCheckbox_CheckedChanged);
            // 
            // ManualTT
            // 
            this.ManualTT.AutomaticDelay = 0;
            this.ManualTT.AutoPopDelay = 10000;
            this.ManualTT.InitialDelay = 0;
            this.ManualTT.ReshowDelay = 0;
            this.ManualTT.ShowAlways = true;
            this.ManualTT.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ManualTT.ToolTipTitle = "Info";
            this.ManualTT.UseAnimation = false;
            this.ManualTT.UseFading = false;
            // 
            // GeneralUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MarkerPicture);
            this.Controls.Add(this.ServerIdPicture);
            this.Controls.Add(this.ProfileLabel);
            this.Controls.Add(this.ServerIdLabel);
            this.Controls.Add(this.MarkerLabel);
            this.Controls.Add(this.CurrentStateLabel);
            this.Controls.Add(this.StateLabel);
            this.Controls.Add(this.ProductLabel);
            this.Controls.Add(this.LogoPicture);
            this.Controls.Add(this.EnableButton);
            this.Controls.Add(this.DisableButton);
            this.Controls.Add(this.ServerIdText);
            this.Controls.Add(this.MarkerText);
            this.Controls.Add(this.ProfileText);
            this.Controls.Add(this.LogCheckbox);
            this.Controls.Add(this.AutoUpdateCheckbox);
            this.Controls.Add(this.LogfileText);
            this.Controls.Add(this.OpenLogfileButton);
            this.Controls.Add(this.ClearLogfileButton);
            this.Controls.Add(this.ProductCopyLink);
            this.Controls.Add(this.ProfileCopyLink);
            this.Controls.Add(this.LogfileCopyLink);
            this.Name = "GeneralUserControl";
            this.Size = new System.Drawing.Size(420, 480);
            ((System.ComponentModel.ISupportInitialize)(this.ServerIdPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MarkerPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox MarkerText;
    private System.Windows.Forms.PictureBox LogoPicture;
    private System.Windows.Forms.Label ProductLabel;
    private System.Windows.Forms.Button EnableButton;
    private System.Windows.Forms.Button DisableButton;
    private System.Windows.Forms.Label StateLabel;
    private System.Windows.Forms.Label CurrentStateLabel;
    private System.Windows.Forms.Button OpenLogfileButton;
    private System.Windows.Forms.Button ClearLogfileButton;
    private System.Windows.Forms.TextBox LogfileText;
    private System.Windows.Forms.Label MarkerLabel;
    private System.Windows.Forms.Label ServerIdLabel;
    private System.Windows.Forms.TextBox ServerIdText;
    private System.Windows.Forms.TextBox ProfileText;
    private System.Windows.Forms.Label ProfileLabel;
    private System.Windows.Forms.PictureBox ServerIdPicture;
    private System.Windows.Forms.CheckBox LogCheckbox;
    private System.Windows.Forms.ToolTip RedTT;
    private System.Windows.Forms.PictureBox MarkerPicture;
    private System.Windows.Forms.ToolTip BlueTT;
    private System.Windows.Forms.LinkLabel ProductCopyLink;
    private System.Windows.Forms.ToolTip CopyTT;
    private System.Windows.Forms.LinkLabel ProfileCopyLink;
    private System.Windows.Forms.LinkLabel LogfileCopyLink;
    private System.Windows.Forms.CheckBox AutoUpdateCheckbox;
    private System.Windows.Forms.ToolTip ManualTT;
}

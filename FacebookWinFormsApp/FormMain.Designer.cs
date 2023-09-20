namespace FacebookAppForDesktopInterface
{
    partial class FormMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.buttonLogin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBoxProfile = new System.Windows.Forms.PictureBox();
            this.comboBoxAppId = new System.Windows.Forms.ComboBox();
            this.applyAppIdButton = new System.Windows.Forms.Button();
            this.keepUserLoggedIn = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(569, 272);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(268, 32);
            this.buttonLogin.TabIndex = 36;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(559, 36);
            this.label1.TabIndex = 53;
            this.label1.Text = "This is the AppID of \"Design Patterns App 2.4\". The grader will use it to test yo" +
    "ur app.\r\nType here your own AppID to test it:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(927, 438);
            this.tabControl1.TabIndex = 54;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pictureBoxProfile);
            this.tabPage1.Controls.Add(this.comboBoxAppId);
            this.tabPage1.Controls.Add(this.applyAppIdButton);
            this.tabPage1.Controls.Add(this.keepUserLoggedIn);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.buttonLogout);
            this.tabPage1.Controls.Add(this.buttonLogin);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(919, 407);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pictureBoxProfile
            // 
            this.pictureBoxProfile.Image = global::BasicFacebookFeatures.Properties.Resources.deafult_profile;
            this.pictureBoxProfile.InitialImage = global::BasicFacebookFeatures.Properties.Resources.deafult_profile;
            this.pictureBoxProfile.Location = new System.Drawing.Point(569, 131);
            this.pictureBoxProfile.Name = "pictureBoxProfile";
            this.pictureBoxProfile.Size = new System.Drawing.Size(130, 100);
            this.pictureBoxProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxProfile.TabIndex = 60;
            this.pictureBoxProfile.TabStop = false;
            // 
            // comboBoxAppId
            // 
            this.comboBoxAppId.FormattingEnabled = true;
            this.comboBoxAppId.Items.AddRange(new object[] {
            "1008417083525437",
            "1450160541956417"});
            this.comboBoxAppId.Location = new System.Drawing.Point(26, 96);
            this.comboBoxAppId.Name = "comboBoxAppId";
            this.comboBoxAppId.Size = new System.Drawing.Size(237, 26);
            this.comboBoxAppId.TabIndex = 59;
            // 
            // applyAppIdButton
            // 
            this.applyAppIdButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applyAppIdButton.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.applyAppIdButton.Location = new System.Drawing.Point(269, 96);
            this.applyAppIdButton.Name = "applyAppIdButton";
            this.applyAppIdButton.Size = new System.Drawing.Size(75, 28);
            this.applyAppIdButton.TabIndex = 58;
            this.applyAppIdButton.Text = "Apply";
            this.applyAppIdButton.UseVisualStyleBackColor = true;
            this.applyAppIdButton.Click += new System.EventHandler(this.applyAppIdButton_Click);
            // 
            // keepUserLoggedIn
            // 
            this.keepUserLoggedIn.AutoSize = true;
            this.keepUserLoggedIn.Location = new System.Drawing.Point(569, 237);
            this.keepUserLoggedIn.Name = "keepUserLoggedIn";
            this.keepUserLoggedIn.Size = new System.Drawing.Size(147, 22);
            this.keepUserLoggedIn.TabIndex = 57;
            this.keepUserLoggedIn.Text = "keep me logged in";
            this.keepUserLoggedIn.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(75, 276);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(439, 78);
            this.label3.TabIndex = 0;
            this.label3.Text = "Connect with friends and the world around you on Facebook.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft PhagsPa", 45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(67, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(295, 79);
            this.label2.TabIndex = 56;
            this.label2.Text = "facebook";
            // 
            // buttonLogout
            // 
            this.buttonLogout.Enabled = false;
            this.buttonLogout.Location = new System.Drawing.Point(569, 312);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(268, 32);
            this.buttonLogout.TabIndex = 52;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(919, 407);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 438);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facebook For Desktop";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).EndInit();
            this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.Button buttonLogin;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox keepUserLoggedIn;
        private System.Windows.Forms.Button applyAppIdButton;
        private System.Windows.Forms.ComboBox comboBoxAppId;
        private System.Windows.Forms.PictureBox pictureBoxProfile;
    }
}


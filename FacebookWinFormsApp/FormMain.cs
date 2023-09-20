namespace FacebookAppForDesktopInterface
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using FacebookAppForDesktopLogic;
    using FacebookWrapper;

    internal partial class FormMain : Form
    {
        internal FacebookDesktopAppLogic m_FacebookAppDesktopLogical;

        internal FormMain()
        {
            InitializeComponent();
            FacebookService.s_CollectionLimit = int.MaxValue;
            m_FacebookAppDesktopLogical = new FacebookDesktopAppLogic();
            this.StartPosition = FormStartPosition.Manual;
            getValuesFromAppSettings();
        }

        private void getValuesFromAppSettings()
        {
            this.Size = m_FacebookAppDesktopLogical.m_AppSettings.LastWindowSize;
            this.Location = m_FacebookAppDesktopLogical.m_AppSettings.LastWindowLocation;
            comboBoxAppId.SelectedItem = m_FacebookAppDesktopLogical.m_AppSettings.AppID;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (m_FacebookAppDesktopLogical.IsThereAccessTokenToConnectTo())
            {
                try
                {
                    m_FacebookAppDesktopLogical.ConnectToFacebook();
                    setButtonsForLoginState();
                    keepUserLoggedIn.Checked = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            m_FacebookAppDesktopLogical.UpdateUserPreferencesAndSaveToAppSettingsFile(this.Location, this.Size);
            base.OnClosed(e);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            loginAndShowFacebookForm();
        }

        private void loginAndShowFacebookForm()
        {
            login();
            showFacebookForm();
        }

        private void showFacebookForm()
        {
            if (m_FacebookAppDesktopLogical.IsLoginSucceed())
            {
                FormFacebookApp fbAppForm = (FormFacebookApp)FormFactory.CreateForm(FormFactory.eFormTypes.FormFacebookApp, m_FacebookAppDesktopLogical);
                fbAppForm.ShowDialog();
            }
            else
            {
                MessageBox.Show(string.IsNullOrEmpty(m_FacebookAppDesktopLogical.m_LoginResult.ErrorMessage) ? "No login has occurred." : m_FacebookAppDesktopLogical.m_LoginResult.ErrorMessage, "Login Failed");
            }
        }

        private void login()
        {
            if (m_FacebookAppDesktopLogical.IsUserNotLoggedinOrNotConnectedAlready())
            {
                try
                {
                    m_FacebookAppDesktopLogical.LoginToFacebook();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                if (m_FacebookAppDesktopLogical.IsAccessTokenNotNullOrEmpty())
                {
                    if (keepUserLoggedIn.Checked)
                    {
                        m_FacebookAppDesktopLogical.UpdateAppSettingsToRememberUserForNextTime();
                    }

                    setButtonsForLoginState();
                }
            }
        }

        private void setButtonsForLoginState()
        {
            buttonLogin.Text = $"Logged in as {m_FacebookAppDesktopLogical.m_LoginResult.LoggedInUser.Name}";
            buttonLogin.BackColor = Color.LightGreen;
            pictureBoxProfile.ImageLocation = m_FacebookAppDesktopLogical.m_LoginResult.LoggedInUser.PictureNormalURL;
            keepUserLoggedIn.Enabled = false;
            buttonLogout.Enabled = true;
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            if (m_FacebookAppDesktopLogical.IsAccessTokenNotNullOrEmpty())
            {
                try
                {
                    m_FacebookAppDesktopLogical.LogOutFromFacebook();
                    prepareToLogOut();
                    MessageBox.Show("You successfully logged out");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Login is required before logging out.");
            }
        }

        private void prepareToLogOut()
        {
            buttonLogin.Text = "Login";
            buttonLogin.BackColor = buttonLogout.BackColor;
            keepUserLoggedIn.Enabled = true;
            m_FacebookAppDesktopLogical.m_LoginResult = null;
            m_FacebookAppDesktopLogical.m_AppSettings.RememberUser = false;
            m_FacebookAppDesktopLogical.m_AppSettings.LastAccessToken = null;
            buttonLogout.Enabled = false;
        }

        private void applyAppIdButton_Click(object sender, EventArgs e)
        {
            int notSelected = -1;

            if (comboBoxAppId.SelectedIndex == notSelected)
            {
                MessageBox.Show("No app Id has been selected.");
            }
            else
            {
                m_FacebookAppDesktopLogical.m_AppSettings.AppID = comboBoxAppId.SelectedItem.ToString();
                MessageBox.Show($"The current App Id is {m_FacebookAppDesktopLogical.m_AppSettings.AppID}.");
            }
        }
    }
}

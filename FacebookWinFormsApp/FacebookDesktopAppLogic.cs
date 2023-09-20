namespace FacebookAppForDesktopLogic
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using FacebookWrapper;
    using FacebookWrapper.ObjectModel;

    public class FacebookDesktopAppLogic
    {
        public User m_LoggedInUser;
        public AppSettings m_AppSettings;
        public LoginResult m_LoginResult;

        public FacebookDesktopAppLogic()
        {
            m_AppSettings = AppSettings.LoadFromFile();
        }

        public void UpdateUserPreferencesAndSaveToAppSettingsFile(Point i_WindowLocation, Size i_WindowSize)
        {
            if (m_AppSettings != null)
            {
                m_AppSettings.LastWindowLocation = i_WindowLocation;
                m_AppSettings.LastWindowSize = i_WindowSize;
            }

            m_AppSettings.SaveToFile();
        }

        public bool IsThereAccessTokenToConnectTo()
        {
            return m_AppSettings.RememberUser && !string.IsNullOrEmpty(m_AppSettings.LastAccessToken);
        }

        public bool IsLoginSucceed()
        {
            return string.IsNullOrEmpty(m_LoginResult.ErrorMessage) && IsAccessTokenNotNullOrEmpty();
        }

        public bool IsUserNotLoggedinOrNotConnectedAlready()
        {
            return m_LoginResult == null || string.IsNullOrEmpty(m_LoginResult.AccessToken);
        }

        public bool IsAccessTokenNotNullOrEmpty()
        {
            return !string.IsNullOrEmpty(m_LoginResult.AccessToken);
        }

        public void ConnectToFacebook()
        {
            m_LoginResult = FacebookWrapper.FacebookService.Connect(m_AppSettings.LastAccessToken);
            if (m_LoginResult == null)
            {
                throw new Exception("Connect to facebook has failed");
            }
            else
            {
                m_LoggedInUser = m_LoginResult.LoggedInUser;
            }
        }

        public void LoginToFacebook()
        {
            m_LoginResult = FacebookService.Login(m_AppSettings.AppID, m_AppSettings.Permissions);
            if (m_LoginResult == null)
            {
                throw new Exception("Login to facebook has failed");
            }
            else
            {
                m_LoggedInUser = m_LoginResult.LoggedInUser;
            }
        }

        public void UpdateAppSettingsToRememberUserForNextTime()
        {
            m_AppSettings.RememberUser = true;
            m_AppSettings.LastAccessToken = m_LoginResult.AccessToken;
        }

        public void LogOutFromFacebook()
        {
            try
            {
                FacebookService.LogoutWithUI();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<User> FetchFriendsWithSameMonthBirthList()
        {
            string monthOfUserBday = m_LoggedInUser.Birthday.Substring(0, 2);
            List<User> friendsWithSameMonthBirth = new List<User>();

            friendsWithSameMonthBirth = m_LoggedInUser.Friends
                .Where(friend => friend.Birthday.Substring(0, 2) == monthOfUserBday)
                .ToList();

            return friendsWithSameMonthBirth;
        }

        public List<Post> FetchNotEmptyOrNullPostsFromUserFeed()
        {
            List<Post> notNullOrEmptyFeedPosts = new List<Post>();

            notNullOrEmptyFeedPosts = m_LoggedInUser.NewsFeed
                .Where(feedPost => !string.IsNullOrEmpty(feedPost.Message))
                .ToList();

            return notNullOrEmptyFeedPosts;
        }
    }
}

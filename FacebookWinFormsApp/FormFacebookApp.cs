namespace FacebookAppForDesktopInterface
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Windows.Forms;
    using FacebookAppForDesktopLogic;
    using FacebookWrapper.ObjectModel;

    internal partial class FormFacebookApp : Form
    {
        private const int k_NumOfAlbumsBoxes = 4;
        internal FacebookDesktopAppLogic m_FacebookAppDesktopLogical;
        private int m_NumberOfUsingLoadAlbumsButton;
        private List<PictureBox> m_AlbumPictureBoxes;
        private List<Label> m_AlbumPictureLabels;

        internal FormFacebookApp(FacebookDesktopAppLogic i_FacebookAppDesktopLogical)
        {
            m_FacebookAppDesktopLogical = i_FacebookAppDesktopLogical;
            InitializeComponent();
            setAlbumPicturesBoxesAndLablesLists();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            new Thread(fetchUserInfo).Start();
        }

        private void fetchUserInfo()
        {
            userProfilePictureBox.LoadAsync(m_FacebookAppDesktopLogical.m_LoggedInUser.PictureNormalURL);
            userFullNameLabel.Invoke(new Action(() => userFullNameLabel.Text = m_FacebookAppDesktopLogical.m_LoggedInUser.Name));
            fetchAllUserBasicFacebookFeaturesData();
        }

        private void fetchAllUserBasicFacebookFeaturesData()
        {
            new Thread(fetchUserLikedPages).Start();
            new Thread(fetchUserFriendsList).Start();
            new Thread(fetchUserGroups).Start();
            new Thread(fetchSomeAlbums).Start();
            new Thread(fetchUserEventsList).Start();
            new Thread(fetchUserFeed).Start();
        }

        private void fetchUserLikedPages()
        {
            try
            {
                pageBindingSource.DataSource = m_FacebookAppDesktopLogical.m_LoggedInUser.LikedPages;
            }
            catch (Exception ex)
            {
                outputTextBox.AppendText(ex.Message);
            }

            if (userLikedPagesList.Items.Count == 0)
            {
                outputTextBox.AppendText("No liked pages to retrieve :(");
            }
        }

        private void fetchUserGroups()
        {
            try
            {
                groupBindingSource.DataSource = m_FacebookAppDesktopLogical.m_LoggedInUser.Groups;
            }
            catch (Exception ex)
            {
                outputTextBox.AppendText(ex.Message);
            }

            if (userGroupsList.Items.Count == 0)
            {
                outputTextBox.AppendText("No groups to retrieve :(");
            }
        }

        private void fetchUserFriendsList()
        {
            try
            {
                userBindingSource.DataSource = m_FacebookAppDesktopLogical.m_LoggedInUser.Friends;
            }
            catch (Exception ex)
            {
                outputTextBox.AppendText(ex.Message);
            }

            if (userFriendsListBox.Items.Count == 0)
            {
                outputTextBox.AppendText("No friends to retrieve :(");
            }
        }

        private void fetchUserEventsList()
        {
            try
            {
                eventBindingSource.DataSource = m_FacebookAppDesktopLogical.m_LoggedInUser.Events;
            }
            catch (Exception ex)
            {
                outputTextBox.AppendText(ex.Message);
            }

            if (userEventsBox.Items.Count == 0)
            {
                outputTextBox.AppendText("No events to retrieve :(");
            }
        }

        private void fetchUserFeed()
        {
            try
            {
                postBindingSource.DataSource = m_FacebookAppDesktopLogical.FetchNotEmptyOrNullPostsFromUserFeed();
            }
            catch (Exception ex)
            {
                outputTextBox.AppendText(ex.Message);
            }

            if (feedBox.Items.Count == 0)
            {
                outputTextBox.AppendText("No posts to retrieve :(");
            }
        }

        private void setAlbumPicturesBoxesAndLablesLists()
        {
            m_AlbumPictureBoxes = new List<PictureBox>
            {
                AlbumCoverPhoto1,
                AlbumCoverPhoto2,
                AlbumCoverPhoto3,
                AlbumCoverPhoto4,
            };
            m_AlbumPictureLabels = new List<Label>
            {
                albumName1,
                albumName2,
                albumName3,
                albumName4,
            };
        }

        private void fetchSomeAlbums()
        {
            int iteratorForList = 0 + (m_NumberOfUsingLoadAlbumsButton * k_NumOfAlbumsBoxes);
            int numOfUserAlbums = m_FacebookAppDesktopLogical.m_LoggedInUser.Albums.Count;

            iteratorForList = (0 + (m_NumberOfUsingLoadAlbumsButton * k_NumOfAlbumsBoxes)) % numOfUserAlbums;
            for (int i = 0; i < m_AlbumPictureBoxes.Count; i++)
            {
                PictureBox albumPictureBox = m_AlbumPictureBoxes[i];
                Label albumLabel = m_AlbumPictureLabels[i];
                Album album = m_FacebookAppDesktopLogical.m_LoggedInUser.Albums[iteratorForList];
                albumPictureBox.LoadAsync(album.PictureAlbumURL);
                albumLabel.Invoke(new Action(() => albumLabel.Text = album.Name));
                iteratorForList = (iteratorForList + 1) % numOfUserAlbums;
            }

            m_NumberOfUsingLoadAlbumsButton++;
        }

        private void showFriendsWithSameMonthBirthAsUser()
        {
            List<User> userFriendsWithSameBirthMonth;

            userFriendsWithSameBirthMonth = m_FacebookAppDesktopLogical.FetchFriendsWithSameMonthBirthList();
            foreach (User friend in userFriendsWithSameBirthMonth)
            {
                friendsWhoShareBirthMonthWithUser.Items.Add(friend);
            }

            if(userFriendsWithSameBirthMonth.Count == 0)
            {
                outputTextBox.AppendText("No friends with same birth month to display");
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fetchLabel_Click(object sender, EventArgs e)
        {
            new Thread(fetchPostsOlderThanDate).Start();
        }

        private void fetchPostsOlderThanDate()
        {
            List<Post> olderPosts = new List<Post>();

            PostscheckedListBox.Items.Clear();
            PostscheckedListBox.DisplayMember = "Message"; 
            try
            {
                olderPosts = new FilterPostList(new FilterOlderPost(), dateTimePicker.Value).GetFilteredPostList(m_FacebookAppDesktopLogical.m_LoggedInUser.Posts.ToList());

                foreach (Post post in olderPosts)
                {
                    PostscheckedListBox.Invoke(new Action(() => PostscheckedListBox.Items.Add(post)));
                }
            }
            catch (Exception ex)
            {
                outputTextBox.AppendText(ex.Message);
            }
        }

        private void fetchPostsNewerThanDate()
        {
            List<Post> newerPosts = new List<Post>();

            PostscheckedListBox.Items.Clear();
            PostscheckedListBox.DisplayMember = "Message";
            try
            {
                newerPosts = new FilterPostList(new FilterNewerPost(), dateTimePicker.Value).GetFilteredPostList(m_FacebookAppDesktopLogical.m_LoggedInUser.Posts.ToList());

                foreach (Post post in newerPosts)
                {
                    PostscheckedListBox.Invoke(new Action(() => PostscheckedListBox.Items.Add(post)));
                }
            }
            catch (Exception ex)
            {
                outputTextBox.AppendText(ex.Message);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Post post in PostscheckedListBox.CheckedItems)
                {
                    post.Delete();
                }
            }
            catch
            {
                outputTextBox.AppendText("Action not supported yet");
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            PostscheckedListBox.Items.Clear();
        }

        private void decelectAllPostsButton_Click(object sender, EventArgs e)
        {
            selectOrDeselectAllItems(PostscheckedListBox, false);
        }

        private void selectOrDeselectAllItems(CheckedListBox i_CheckedListBox, bool i_ToSelect)
        {
            for (int i = 0; i < i_CheckedListBox.Items.Count; i++)
            {
                i_CheckedListBox.SetItemChecked(i, i_ToSelect);
            }
        }

        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            selectOrDeselectAllItems(PostscheckedListBox, true);
        }

        private void loadMoreAlbums_Click(object sender, EventArgs e)
        {
            fetchSomeAlbums();
        }

        private void createEventButton_Click(object sender, EventArgs e)
        {
            List<User> friendsToInviteToEvent = friendsWhoShareBirthMonthWithUser.CheckedItems.Cast<User>().ToList();

            if (friendsWhoShareBirthMonthWithUser.Items.Count == 0)
            {
                outputTextBox.AppendText("No friends to celebrate shared B-day together :(");
            }
            else if (friendsToInviteToEvent.Count == 0)
            {
                outputTextBox.AppendText("Please choose friends to celebrate together");
            }
            else
            {
                FormCreateEvent eventForm = (FormCreateEvent)FormFactory.CreateForm(FormFactory.eFormTypes.FormCreateEvent, friendsToInviteToEvent);
                eventForm.ShowDialog();
            }
        }

        private void selectAllFriendsWithSameBirthMonth_Click(object sender, EventArgs e)
        {
            selectOrDeselectAllItems(friendsWhoShareBirthMonthWithUser, true);
        }

        private void deselectFriendsWithSameBirthMonth_Click(object sender, EventArgs e)
        {
            selectOrDeselectAllItems(friendsWhoShareBirthMonthWithUser, false);
        }

        private void fetchFriendsWithSameBirthMonthButton_Click(object sender, EventArgs e)
        {
            new Thread(showFriendsWithSameMonthBirthAsUser).Start();
        }

        private void LoadPictureURLFromSelectedItem<TItem>(ListBox listBox, PictureBox pictureBox, string urlPictureProperyName)
            where TItem : class
        {
            if (listBox.SelectedItem is TItem item && item.GetType().GetProperty(urlPictureProperyName) is PropertyInfo property)
            {
                if (string.IsNullOrEmpty(property.GetValue(item) as string))
                {
                    pictureBox.Image = null;
                }
                else
                {
                    pictureBox.LoadAsync(property.GetValue(item) as string);
                }
            }
        }

        private void userGroupsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPictureURLFromSelectedItem<Group>(userGroupsList, pictureBoxGroups, "IconUrl");
        }

        private void userEventsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPictureURLFromSelectedItem<Event>(userEventsBox, pictureBoxEvents, "PictureNormalUrl");
        }

        private void addPostToFacebook(string i_PostToAdd)
        {
            m_FacebookAppDesktopLogical.m_LoggedInUser.PostStatus(postTextBox.Text);
        }

        private void postButton_Click(object sender, EventArgs e)
        {
            string pleaseTypeMsg = "Please type something";

            try
            {
                if (string.IsNullOrEmpty(postTextBox.Text))
                {
                    throw new Exception(pleaseTypeMsg);
                }
                else
                {
                    m_FacebookAppDesktopLogical.m_LoggedInUser.PostStatus(postTextBox.Text);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == pleaseTypeMsg)
                {
                    outputTextBox.AppendText(pleaseTypeMsg);
                }
                else
                {
                    outputTextBox.AppendText("Action not supported yet");
                }
            }
        }

        private void fetchNewerButton_Click(object sender, EventArgs e)
        {
            new Thread(fetchPostsNewerThanDate).Start();
        }
    }
}
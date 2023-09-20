namespace FacebookAppForDesktopInterface
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using FacebookWrapper.ObjectModel;

    internal partial class FormCreateEvent : Form
    {
        private const int k_eventDurationInHours = 2;
        private readonly List<User> r_FriendsToInviteToEvent;

        internal FormCreateEvent(List<User> i_FriendsToInviteToEvent)
        {
            InitializeComponent();
            dateTimePickerDateEvent.MinDate = DateTime.Now;
            r_FriendsToInviteToEvent = i_FriendsToInviteToEvent;
        }

        private void createEvent()
        {
            string enterCityMsg = "Please enter a city";
            string eventName = "Birthday Shared Celebration";
            string eventDescription = "Lets celebrate all together!";

            try
            {
                Event newEvent = new Event();
                DateTime eventDateTime = dateTimePickerDateEvent.Value;
                if (string.IsNullOrEmpty(textBoxCityOfEvent.Text))
                {
                    throw new Exception(enterCityMsg);
                }

                newEvent.InviteUsers(r_FriendsToInviteToEvent);
                newEvent.Owner.CreateEvent_DeprecatedSinceV2(eventName, eventDateTime, eventDateTime.AddHours(k_eventDurationInHours), eventDescription, textBoxCityOfEvent.Text);
            }
            catch (Exception ex)
            {
                if (ex.Message == enterCityMsg)
                {
                    MessageBox.Show(enterCityMsg);
                }
                else
                {
                    MessageBox.Show("Action not supported yet", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            createEvent();
        }
    }
}

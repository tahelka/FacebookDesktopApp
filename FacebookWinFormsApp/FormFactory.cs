namespace FacebookAppForDesktopLogic
{
    using System.Collections.Generic;
    using System.Windows.Forms;
    using FacebookAppForDesktopInterface;
    using FacebookWrapper.ObjectModel;

    public static class FormFactory
    {
        public enum eFormTypes
        {
            FormMain,
            FormFacebookApp,
            FormCreateEvent,
        }

        public static Form CreateForm(eFormTypes i_FormType, object i_AdditionalParameter = null)
        {
            Form form;

            switch (i_FormType)
            {
                case eFormTypes.FormMain:
                    form = new FormMain();
                    break;
                case eFormTypes.FormFacebookApp:
                    FacebookDesktopAppLogic facebookDesktopAppLogic = (FacebookDesktopAppLogic)i_AdditionalParameter;
                    form = new FormFacebookApp(facebookDesktopAppLogic);
                    break;
                case eFormTypes.FormCreateEvent:
                    List<User> friendsToInviteToEvent = (List<User>)i_AdditionalParameter;
                    form = new FormCreateEvent(friendsToInviteToEvent);
                    break;
                default:
                    form = new Form();
                    break;
            }

            return form;
        }
    }
}
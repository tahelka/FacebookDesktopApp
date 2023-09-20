﻿namespace FacebookAppForDesktopInterface
{
    using System;
    using System.Windows.Forms;
    using FacebookAppForDesktopLogic;
    using FacebookWrapper;

    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Clipboard.SetText("design.patterns20cc");
            FacebookService.s_UseForamttedToStrings = true;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(FormFactory.CreateForm(FormFactory.eFormTypes.FormMain));
        }
    }
}

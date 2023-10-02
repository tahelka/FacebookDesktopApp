using System;
using System.Drawing;
using System.Windows.Forms;
using BasicFacebookFeatures;

namespace FacebookAppForDesktopInterface
{
    public class OutputTextBox : TextBox, IShakeable
    {
        private static readonly object lockObject = new object();
        private static OutputTextBox instance = null;
        private Shaker shaker = new Shaker();

        public bool IsShaking { get; set; } = false;

        private OutputTextBox()
        {
            Multiline = true;
            ScrollBars = ScrollBars.Vertical;
            ReadOnly = true;
        }

        public static OutputTextBox Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new OutputTextBox();
                        }
                    }
                }

                return instance;
            }
        }

        public new void AppendText(string text)
        {
            DateTime now = DateTime.Now;
            string message = $"{now} - {text} {System.Environment.NewLine}";

            Invoke(new Action(() => base.AppendText(message)));
            Shake();
        }

        public new void Clear()
        {
            base.Clear();
        }

        public void Shake()
        {
            shaker.Shake(this);
        }
    }
}

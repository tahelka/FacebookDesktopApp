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
        private bool isShaking = false;
        private int shakeDurationInMilliseconds = 200;
        private int shakeMagnitudeInPixels = 5;
        private Shaker shaker = new Shaker();

        public bool IsShaking
        {
            get { return isShaking; } set { isShaking = value; }
        }

        public int ShakeDurationInMilliseconds
        {
            get { return shakeDurationInMilliseconds; } set { shakeDurationInMilliseconds = value; }
        }

        public int ShakeMagnitudeInPixels
        {
            get { return shakeMagnitudeInPixels; } set { shakeMagnitudeInPixels = value; }
        }

        public OutputTextBox()
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

namespace FacebookAppForDesktopInterface
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class OutputTextBox : TextBox
    {
        private static readonly object lockObject = new object();
        private static OutputTextBox instance = null;
        private bool isShaking = false;
        private int shakeDurationInMilliseconds = 200;
        private int shakeMagnitudeInPixels = 5;

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
            shake();
        }

        private void shake()
        {
            if (!isShaking)
            {
                isShaking = true;
                Point originalLocation = Location;
                Random random = new Random();
                DateTime startTime = DateTime.Now;
                while ((DateTime.Now - startTime).TotalMilliseconds < shakeDurationInMilliseconds)
                {
                    int offsetX = random.Next(-shakeMagnitudeInPixels, shakeMagnitudeInPixels);
                    int offsetY = random.Next(-shakeMagnitudeInPixels, shakeMagnitudeInPixels);
                    Invoke(new Action(() => Location = new Point(originalLocation.X + offsetX, originalLocation.Y + offsetY)));
                    Application.DoEvents();
                }

                Invoke(new Action(() => Location = originalLocation));
                Invoke(new Action(() => isShaking = false));
            }
        }

        public new void Clear()
        {
            base.Clear();
        }
    }
}

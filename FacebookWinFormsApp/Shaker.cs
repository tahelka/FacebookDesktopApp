using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    internal class Shaker
    {
        public void Shake(IShakeable i_shakeable)
        {
            if (!i_shakeable.IsShaking)
            {
                i_shakeable.IsShaking = true;
                Point originalLocation = i_shakeable.Location;
                Random random = new Random();
                DateTime startTime = DateTime.Now;
                while ((DateTime.Now - startTime).TotalMilliseconds < i_shakeable.ShakeDurationInMilliseconds)
                {
                    int offsetX = random.Next(-i_shakeable.ShakeMagnitudeInPixels, i_shakeable.ShakeMagnitudeInPixels);
                    int offsetY = random.Next(-i_shakeable.ShakeMagnitudeInPixels, i_shakeable.ShakeMagnitudeInPixels);
                    i_shakeable.Invoke(new Action(() => i_shakeable.Location = new Point(originalLocation.X + offsetX, originalLocation.Y + offsetY)));
                    Application.DoEvents();
                }

                i_shakeable.Invoke(new Action(() => i_shakeable.Location = originalLocation));
                i_shakeable.Invoke(new Action(() => i_shakeable.IsShaking = false));
            }
        }
    }
}

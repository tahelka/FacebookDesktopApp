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
        public int ShakeDurationInMilliseconds { get; set; } = 200;

        public int ShakeMagnitudeInPixels { get; set; } = 5;

        public void Shake(IShakeable i_ToShake)
        {
            if (!i_ToShake.IsShaking)
            {
                i_ToShake.IsShaking = true;
                Point originalLocation = i_ToShake.Location;
                Random random = new Random();
                DateTime startTime = DateTime.Now;
                while ((DateTime.Now - startTime).TotalMilliseconds < ShakeDurationInMilliseconds)
                {
                    int offsetX = random.Next(-ShakeMagnitudeInPixels, ShakeMagnitudeInPixels);
                    int offsetY = random.Next(-ShakeMagnitudeInPixels, ShakeMagnitudeInPixels);
                    i_ToShake.Invoke(new Action(() => i_ToShake.Location = new Point(originalLocation.X + offsetX, originalLocation.Y + offsetY)));
                    Application.DoEvents();
                }

                i_ToShake.Invoke(new Action(() => i_ToShake.Location = originalLocation));
                i_ToShake.Invoke(new Action(() => i_ToShake.IsShaking = false));
            }
        }
    }
}

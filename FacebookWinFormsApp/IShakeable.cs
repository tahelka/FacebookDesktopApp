using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFacebookFeatures
{
    internal interface IShakeable
    {
        bool IsShaking { get; set; }

        Point Location { get; set; }

        void Shake();

        object Invoke(Delegate method);
    }
}

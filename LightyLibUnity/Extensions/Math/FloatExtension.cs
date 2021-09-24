using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightyLibUnity.Extensions.Math
{
    /// <summary>
    /// Extension class for float
    /// </summary>
    public static class FloatExtension
    {
        /// <summary>
        /// Round the float down when below 0.5 or up when above or equal to 0.5
        /// </summary>
        public static int Round(this float value)
        {
            if (value == 0) return 0;
            var integer = (int)value;
            var frac = value - integer;
            if(value > 0)
            {
                if (frac >= 0.5f) return integer + 1;
                else return integer;
            }
            else
            {
                frac += 1.0f;
                if (frac >= 0.5f) return integer;
                else return integer - 1;
            }
        }
    }
}

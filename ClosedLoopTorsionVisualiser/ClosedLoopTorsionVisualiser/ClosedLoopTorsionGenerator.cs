using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ClosedLoopTorsionVisualiser
{
    /// <summary>
    /// Determine the torsion of a closed loop.
    /// </summary>
    public class ClosedLoopTorsionGenerator
    {
        /// <summary>
        /// Convert HSV coordinates into <see cref="Color"/>.
        /// </summary>
        /// <param name="hue">The hue.</param>
        /// <param name="saturation">The saturation.</param>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="Color"/>.</returns>
        public static Color ColorFromHSV(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return Color.FromArgb(255, v, t, p);
            else if (hi == 1)
                return Color.FromArgb(255, q, v, p);
            else if (hi == 2)
                return Color.FromArgb(255, p, v, t);
            else if (hi == 3)
                return Color.FromArgb(255, p, q, v);
            else if (hi == 4)
                return Color.FromArgb(255, t, p, v);
            else
                return Color.FromArgb(255, v, p, q);
        }

        /// <summary>
        /// The number of twists of the closed loop.
        /// </summary>
        public double Twists = 0;

        /// <summary>
        /// Gets the torsion at the <paramref name="theta"/> along the closed loop.
        /// </summary>
        /// <param name="theta">The parameter value describing a point on the closed loop.</param>
        /// <returns>The torsion at <paramref name="theta"/>.</returns>
        public double GetTorsion(double theta)
        {
            return Twists * Math.Abs(Math.PI - theta);
        }

        /// <summary>
        /// Gets the torsion colour at the <paramref name="theta"/> along the closed loop.
        /// </summary>
        /// <param name="theta">The parameter value describing a point on the closed loop.</param>
        /// <returns>The torsion colour at <paramref name="theta"/>.</returns>
        public Color GetTorsionColour(double theta)
        {
            var hue = 2 * GetTorsion(theta) * 180 / Math.PI;
            return ColorFromHSV(hue, 1, 1);
        }
    }
}

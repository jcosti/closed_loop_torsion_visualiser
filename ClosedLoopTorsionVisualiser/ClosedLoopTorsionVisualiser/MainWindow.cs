using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClosedLoopTorsionVisualiser
{
    public partial class MainWindow : Form
    {
        public const float pi = (float)Math.PI;
        public const float rad2deg = 180 / pi;

        private ClosedLoopTorsionGenerator ClosedLoopTorsionGenerator = new ClosedLoopTorsionGenerator();

        public MainWindow()
        {
            InitializeComponent();

            this.Paint += MainWindow_Paint;
            this.twistTrackBar.KeyDown += TwistTrackBar_KeyDown;
            this.DoubleBuffered = true;

            ClosedLoopTorsionGenerator.Twists = 0;
        }

        private void TwistTrackBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                if (!this.sliderTimer.Enabled)
                    this.sliderTimer.Start();
                else
                    this.sliderTimer.Stop();
            }
        }

        private void MainWindow_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            graphics.Clear(Color.White);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            float delta = 0.02F;
            var segments = (int)Math.Ceiling(2 * Math.PI / delta);

            var centreX = this.ClientRectangle.Width / 2;
            var centreY = this.ClientRectangle.Height / 2;

            var radius = 100;

            var rect = new Rectangle(centreX - radius, centreY - radius, radius * 2, radius * 2);

            for (int i = 0; i < segments; i++)
            {
                var theta = i * delta;
                graphics.DrawArc(new Pen(this.ClosedLoopTorsionGenerator.GetTorsionColour(theta), 5), rect, rad2deg * theta, rad2deg * delta);
            }
        }

        private void twistTrackBar_ValueChanged(object sender, EventArgs e)
        {
            var twists = (double)this.twistTrackBar.Value / 10;
            this.ClosedLoopTorsionGenerator.Twists = twists;

            this.twistsLabel.Text = string.Format("Twists: {0}", twists);
            this.Invalidate();
        }

        public bool SliderVelocityForward = true;

        private void sliderTimer_Tick(object sender, EventArgs e)
        {
            this.twistTrackBar.Value = Math.Max(Math.Min(this.twistTrackBar.Value + 5 * (SliderVelocityForward ? 1 : -1), this.twistTrackBar.Maximum), this.twistTrackBar.Minimum);
            if (this.twistTrackBar.Value == this.twistTrackBar.Maximum || this.twistTrackBar.Value == this.twistTrackBar.Minimum)
            {
                SliderVelocityForward = !SliderVelocityForward;
            }
        }
    }
}


namespace ClosedLoopTorsionVisualiser
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.twistTrackBar = new System.Windows.Forms.TrackBar();
            this.twistsLabel = new System.Windows.Forms.Label();
            this.sliderTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.twistTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // twistTrackBar
            // 
            this.twistTrackBar.LargeChange = 10;
            this.twistTrackBar.Location = new System.Drawing.Point(12, 12);
            this.twistTrackBar.Maximum = 400;
            this.twistTrackBar.Name = "twistTrackBar";
            this.twistTrackBar.Size = new System.Drawing.Size(776, 69);
            this.twistTrackBar.TabIndex = 0;
            this.twistTrackBar.ValueChanged += new System.EventHandler(this.twistTrackBar_ValueChanged);
            // 
            // twistsLabel
            // 
            this.twistsLabel.AutoSize = true;
            this.twistsLabel.Location = new System.Drawing.Point(12, 56);
            this.twistsLabel.Name = "twistsLabel";
            this.twistsLabel.Size = new System.Drawing.Size(78, 25);
            this.twistsLabel.TabIndex = 1;
            this.twistsLabel.Text = "Twists: 0";
            // 
            // sliderTimer
            // 
            this.sliderTimer.Tick += new System.EventHandler(this.sliderTimer_Tick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.twistsLabel);
            this.Controls.Add(this.twistTrackBar);
            this.Name = "MainWindow";
            this.Text = "Closed Loop Torsion Visualiser";
            ((System.ComponentModel.ISupportInitialize)(this.twistTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar twistTrackBar;
        private System.Windows.Forms.Label twistsLabel;
        private System.Windows.Forms.Timer sliderTimer;
    }
}


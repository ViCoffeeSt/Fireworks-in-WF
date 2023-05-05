
using System.Drawing;
using System.Windows.Forms;

namespace Fireworks_in_WF
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AnimationTimer = new System.Windows.Forms.Timer(this.components);
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // AnimationTimer
            // 
            this.AnimationTimer.Enabled = true;
            this.AnimationTimer.Interval = 20;
            this.AnimationTimer.Tick += new System.EventHandler(this.AnimationTimeEvent);
            // 
            // trackBar1
            // 
            this.trackBar1.BackColor = System.Drawing.Color.LightGray;
            this.trackBar1.BackgroundImage = this.BackgroundImage;
            this.trackBar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.trackBar1.LargeChange = 10;
            this.trackBar1.Location = new System.Drawing.Point(12, 393);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 45);
            this.trackBar1.SmallChange = 5;
            this.trackBar1.TabIndex = 0;
            this.trackBar1.Value = 50;
            this.trackBar1.Scroll += new System.EventHandler(this.TrackBar1_Scroll);
            this.trackBar1.ValueChanged += new System.EventHandler(this.VolumeTrackBarChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(586, 407);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fireworks";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Fireworks";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormPaintEvent);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer AnimationTimer;
        private System.Windows.Forms.TrackBar trackBar1;
        private Label label1;
    }
}


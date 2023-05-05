using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using NAudio.Wave;
using NAudio.CoreAudioApi;
using System.Linq;
using System.Threading;

namespace Fireworks_in_WF
{
    public partial class Form1 : Form
    {
        List<string> image_location = new List<string>();
        List<Firework> fireworks_list = new List<Firework>();

        int backgroundNumber;
        int currentFirework = 0;

        private TrackBar volumeTrackBar;

        public Form1()
        {
            InitializeComponent();
            SetUp();
            MusicThread();
            VolumeBar();
        }

        private void SetUp()
        {
            image_location = Directory.GetFiles("background", "*.jpg").ToList();
            this.BackgroundImage = Image.FromFile(image_location[0]);
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.KeyPreview = true;
            this.KeyUp += new KeyEventHandler(this.KeyIsUp);
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (backgroundNumber < image_location.Count - 1)
            {
                backgroundNumber++;
            }
            else
            {
                backgroundNumber = 0;
            }

            this.BackgroundImage = Image.FromFile(image_location[backgroundNumber]);
        }

        private void FormMouseDown(object sender, MouseEventArgs e)
        {
            Point mousePosition = new Point
            {
                X = e.X,
                Y = e.Y
            };

            Firework newFirework = new Firework();
            newFirework.position.X = mousePosition.X - (newFirework.widht/2);
            newFirework.position.Y = mousePosition.Y - (newFirework.height/2);
            fireworks_list.Add(newFirework);

            currentFirework++;
            label1.Text = $"Fireworks: {currentFirework}";
        }

        private void FormPaintEvent(object sender, PaintEventArgs e)
        {
            foreach (Firework newFirework in fireworks_list.ToList())
            {
                if (newFirework.animationComplete == false)
                {
                    e.Graphics.DrawImage(newFirework.firework, newFirework.position.X, newFirework.position.Y,
                        newFirework.widht, newFirework.height);
                }
            }
        }

        private void AnimationTimeEvent(object sender, EventArgs e)
        {
            if (fireworks_list != null)
            {
                foreach (Firework firework in fireworks_list.ToList())
                {
                    if (firework.animationComplete == false)
                    {
                        firework.AnimateFirework();
                    }
                    else
                    {
                        fireworks_list.Remove(firework);
                    }
                }
            }

            this.Invalidate();
        }

        private void MusicThread()
        {
            Thread musicThread = new Thread(PlayMusic)
            {
                IsBackground = true
            };
            musicThread.Start();
        }

        private void PlayMusic()
        {
            string[] fileEntries = Directory.GetFiles("music", "*.mp3");
            foreach (string fileName in fileEntries)
            {
                using (var audioFile = new AudioFileReader(fileName))
                using (var outputDevice = new WaveOutEvent())
                {
                    outputDevice.Volume = volumeTrackBar.Value/100f;
                    outputDevice.Init(audioFile);
                    outputDevice.Play();
                    while (outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        Thread.Sleep(100);
                    }
                }
            }
        }

        private void VolumeBar()
        {
            volumeTrackBar = new TrackBar
            {
                Width = 100,
                Minimum = 0,
                Maximum = 100,
                TickFrequency = 10,
                Value = 50
            };

            volumeTrackBar.ValueChanged += TrackBar1_Scroll;
        }

        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            VolumeTrackBarChanged(sender, e);
        }

        private void VolumeTrackBarChanged(object sender, EventArgs e)
        {
            float volumeValue = (float)(sender as TrackBar).Value / volumeTrackBar.Maximum;
            foreach (var outputDevice in new MMDeviceEnumerator().EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active))
            {
                outputDevice.AudioEndpointVolume.MasterVolumeLevelScalar = volumeValue;
            }
        }
    }
}

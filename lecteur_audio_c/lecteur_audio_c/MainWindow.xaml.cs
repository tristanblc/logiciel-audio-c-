using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace lecteur_audio_c
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Update;
            timer.Start();
        }


        public MediaPlayer player = new MediaPlayer();

        private void OpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "MP3 files (*.mp3)|*.mp3| All files (*.*)|*.*";
            if (fileDialog.ShowDialog() == true)
            {
                player.Open(new System.Uri(fileDialog.FileName));
                player.Play();
                Path.Text = fileDialog.FileName;
            }

        }

        private void JouerFile_Click(object sender, EventArgs e)
        {
            player.Play();
        }

        private void  PauseFile_Click(object sender, EventArgs e)
        {
            player.Pause();
           
        }
        private void StopFile_Click(object sender, EventArgs e)
        {
            player.Stop();
            progress.Minimum = 0;
        }
        private void vol_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            player.Volume = vol.Value / 100;
        }

        private void Update(object sender,EventArgs e)
        {
             if (player.Source != null)
            {
                progress.Minimum = 0;
                progress.Minimum = player.NaturalDuration.TimeSpan.TotalSeconds;
                progress.Minimum = player.NaturalDuration.TimeSpan.TotalSeconds;
                progress.Value = player.Position.TotalSeconds;

            }

        }
    }
}

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
using System.Windows.Shapes;

namespace testtest
{
    /// <summary>
    /// Interaction logic for Radio.xaml
    /// </summary>
    public partial class Radio : Window
    {
        float Volume = 0;
        

        public Radio()
        {
            InitializeComponent();
            this.Title = "Radio App";


            mPlayer.LoadedBehavior = MediaState.Manual;
            mPlayer.Source = new Uri("Sympathique.mp3", UriKind.Relative);
            mPlayer.Play();

            System.Windows.Threading.DispatcherTimer mTimer = new System.Windows.Threading.DispatcherTimer();
            mTimer.Tick += new EventHandler(mTimer_Tick);
            mTimer.Interval = new TimeSpan(1);
            mTimer.Start();


        }

        private void mTimer_Tick(object sender, EventArgs e)
        {
            Volume = (int)mSlider.Value;

            // Players volume is 0:mute, 1:max

            mPlayer.Volume = Volume / 100;
        }

       
    }
}

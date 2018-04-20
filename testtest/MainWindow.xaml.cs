using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace testtest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        

        public MainWindow()
        {
            InitializeComponent();
            this.Title = "Fridget Spinner";

            // Timer for Time.
            // Date is fused into TimeLabel for aesthetic purposes.
            // See Change -- ChangeDateTimer_Tick --

            System.Windows.Threading.DispatcherTimer ChangeDateTimer = new System.Windows.Threading.DispatcherTimer();
            ChangeDateTimer.Tick += new EventHandler(ChangeDateTimer_Tick);
            ChangeDateTimer.Interval = new TimeSpan(50);
            ChangeDateTimer.Start();

            // Json Fetching
            // Realtime Weather Forecast, using OpenWeather API.
            // OpenWeatherMap, maps json data so i can decode them and display whatever i want.

            /*  WeatherInfo mWtrInfo = new WeatherInfo();
            string jsonData = mWtrInfo.urlBuilder();
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(jsonData);
                var obj = JsonConvert.DeserializeObject<OpenWeatherMap.Root>(json);
                DegreesLabel.Content = mWtrInfo.getTemperature(obj) + " °C";
                // debuglabel.Text = mWtrInfo.getPictureUrl(obj);
                // use Source for images, content for Text.
                ConditionImage.Source = new BitmapImage(new Uri(mWtrInfo.getPictureUrl(obj), UriKind.Absolute));
                WeatherConditionLabel.Content = mWtrInfo.getWeatherCondition(obj).ToUpper();
            }   */

            Fridge_Variables.Content = "Fridge Info:\tTemp: -2°C\tHum: 75%";


        }

        // Tick every second and updates current time.
      
        private void ChangeDateTimer_Tick(object sender, EventArgs e)
        {
            TimeLabel.Content = DateTime.Now.ToString("HH:mm:ss");
            TimeLabel.Content += "\n" + DateTime.Now.DayOfWeek + ",\n" + getCustomMonthName(DateTime.Now.Month) + ". " + DateTime.Now.Day;

        }

        // Shortening Month names for dispalying purposes.

        public string getCustomMonthName(int x)
        {
            string y="";

            if (x == 1)  y = "Jan";
            if (x == 2) y = "Feb";
            if (x == 3) y = "Mar";
            if (x == 4) y = "Apr";
            if (x == 5) y = "May";
            if (x == 6) y = "Jun";
            if (x == 7) y = "Jul";
            if (x == 8) y = "Aug";
            if (x == 9) y = "Sep";
            if (x == 10) y = "Oct";
            if (x == 11) y = "Nov";
            if (x == 12) y = "Dec";
            return y;
        }

        // Each button creates a new form and displays it.

        private void cameraButton_click(object sender, RoutedEventArgs e)
        {
            var mCameraForm = new Camera_View();
            mCameraForm.Show();
        }

        private void WhatsInsideButton_click(object sender, RoutedEventArgs e)
        {
            var mWhatsInside = new WhatsInside();
            mWhatsInside.Show();
        }

        private void RadioButton_click(object sender, RoutedEventArgs e)
        {
            var mRadioForm = new Radio();
            mRadioForm.Show();
        }

        private void barcodeButton_click(object sender, RoutedEventArgs e)
        {
            var mBarcodeForm = new Barcode_Scanner();
            mBarcodeForm.Show();
        }

        private void Calendar_Button_Click(object sender, RoutedEventArgs e)
        {
            var mCalendar = new Google_Calendar();
            mCalendar.Show();
        }

        private void PhotoView_Button_Click(object sender, RoutedEventArgs e)
        {
            var mPhotoView = new PhotoView();
            mPhotoView.Show();
        }

        private void Recipes_Button_Click(object sender, RoutedEventArgs e)
        {
            var mRecipes = new Recipes_form();
            mRecipes.Show();
        }
    }
}

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
using System.Windows.Threading;
using System.Diagnostics;
using WpfAnimatedGif;

namespace testtest
{
    /// <summary>
    /// Interaction logic for Home_Manipulator_v1.xaml
    /// </summary>
    public partial class Home_Manipulator_v1 : Window
    {
        // Channel selected when tv is launced.

        int ChannelSelected;

        //  Booleans for adjusting label's colors. Need to be white when selected.
        //  true:no selection, false:something's selected.

        Boolean lockFridge = true;
        Boolean lockManual = true;
        Boolean lockWardrobe = true;
        Boolean lockLights = true;
        Boolean lockBedroom = true;
        Boolean lockLivingroom = true;
        Boolean lockYard = true;
        Boolean lockCoffeepot = true;
        Boolean lockTv = true;

        //  Creating UI's main Colors.

        SolidColorBrush LabelsDefaultColor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF52A3F5"));
        SolidColorBrush LabelsHoverColor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFB3FFF8"));
        SolidColorBrush LabelsWhiteColor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFFFF"));


        // creating paths for images

        BitmapImage CloseWindowDefault = new BitmapImage(new Uri(@"closewindow2gray.png", UriKind.Relative));
        BitmapImage CloseWindowHover = new BitmapImage(new Uri(@"closewindow2white.png", UriKind.Relative));

        // Side Menu Images

        BitmapImage MenuImage = new BitmapImage(new Uri(@"menuwhite.png", UriKind.Relative));
        BitmapImage TvIcon = new BitmapImage(new Uri(@"tv.png", UriKind.Relative));
        BitmapImage TeapotIcon = new BitmapImage(new Uri(@"electric-teapot.png", UriKind.Relative));
        BitmapImage CoffeeIcon = new BitmapImage(new Uri(@"coffee-pot.png", UriKind.Relative));
        BitmapImage TempIcon = new BitmapImage(new Uri(@"temperature-sensitive.png", UriKind.Relative));

        //  Menu -> Wardrobe Images

        BitmapImage SportOutfitImage = new BitmapImage(new Uri(@"SportOutfit.jpg", UriKind.Relative));
        BitmapImage FormalOutfitImage = new BitmapImage(new Uri(@"FormalOutfit.jpg", UriKind.Relative));
        BitmapImage CasualOutfitImage = new BitmapImage(new Uri(@"CasualOutfit.jpg", UriKind.Relative));

        //  Side Menu -> Coffeepot Images

        BitmapImage CoffeeEmpty = new BitmapImage(new Uri(@"coffee_default.png", UriKind.Relative));
        BitmapImage CoffeeFilled = new BitmapImage(new Uri(@"coffee_filled.png", UriKind.Relative));
        BitmapImage CoffeeMaking = new BitmapImage(new Uri(@"coffeemaking.gif", UriKind.Relative));

        //  Side Menu -> Tv Images

        BitmapImage TvOffImage = new BitmapImage(new Uri(@"tv_off.jpg", UriKind.Relative));
        BitmapImage TvOnImage1 = new BitmapImage(new Uri(@"tv_on.gif", UriKind.Relative));
        BitmapImage TvOnImage2 = new BitmapImage(new Uri(@"tv_open2.gif", UriKind.Relative));
        BitmapImage TvOnImage3 = new BitmapImage(new Uri(@"tv_open3.gif", UriKind.Relative));

        //  Side Menu -> Temp Adjust Images

        BitmapImage ColdIcon = new BitmapImage(new Uri(@"cold-icon.png", UriKind.Relative));
        BitmapImage HotIcon = new BitmapImage(new Uri(@"hot-icon.png", UriKind.Relative));

        //  House Lights Off Image

        BitmapImage LightsOffImage = new BitmapImage(new Uri(@"ligthsOff.jpg", UriKind.Relative));

        //  House Lights -> Bedroom Image

        BitmapImage BedroomOn = new BitmapImage(new Uri(@"BedroomOn.jpg", UriKind.Relative));

        //  House Lights -> Livingroom Image

        BitmapImage LivingroomLightsOnImage = new BitmapImage(new Uri(@"LivingroomOn.jpg", UriKind.Relative));

        //  House Lights -> Yard Image

        BitmapImage YardLightsOnImage = new BitmapImage(new Uri(@"YardOn.jpg", UriKind.Relative));

        //  Toggle Images

        BitmapImage ToggleOn = new BitmapImage(new Uri(@"toggle-on.png", UriKind.Relative));
        BitmapImage ToggleOff = new BitmapImage(new Uri(@"toggle-off.png", UriKind.Relative));

        //  Main Logo Image

        BitmapImage LogoImage = new BitmapImage(new Uri(@"appIconwhite.png", UriKind.Relative));

        // Creating Timers, for displaying purposes.
        // Use them to display how much time are the lights running.
        // StopWatch1: BedroomLights, StopWatch2: LivingroomLights, StopWatch3: YardLights.
        //
        // Grinder Timer, is used to keep track of slinder in Wardrobe menu.
        //
        // tempSliderTimer, is used to keep track of slinder in Temperature menu.

        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        DispatcherTimer grinderTimer = new DispatcherTimer();
        DispatcherTimer tempSliderTimer = new DispatcherTimer();

        Stopwatch stopWatch1 = new Stopwatch();
        Stopwatch stopWatch2 = new Stopwatch();
        Stopwatch stopWatch3 = new Stopwatch();
        string currentTime1 = string.Empty;
        string currentTime2 = string.Empty;
        string currentTime3 = string.Empty;


        int SliderValue;
        int tempSliderValue;


        public Home_Manipulator_v1()
        {
            InitializeComponent();

            //  Asigning Pictures to proper Pictureboxes.

            closeWindow_image.Source = CloseWindowDefault;

            logo_image.Source = LogoImage;
            menu_image.Source = MenuImage;

            tv_icon.Source = TvIcon;
            temp_icon.Source = TempIcon;
            coffeepot_icon.Source = CoffeeIcon;

            BedroomLights_toggle.Source = ToggleOff;
            LivingroomLights_toggle.Source = ToggleOff;
            YardLights_toggle.Source = ToggleOff;
            Coffeepot_toggle.Source = ToggleOff;
            Tv_toggle.Source = ToggleOff;

            Bedroom_image.Source = LightsOffImage;
            Livingroom_image.Source = LightsOffImage;
            Yard_image.Source = LightsOffImage;


            Coffeepot_Device_image.Source = CoffeeEmpty;
            Tv_Device_image.Source = TvOffImage;
            


            //  Hiding all Grids, that are called using Navigation or Menu links.

            HouseLights_Grid.Visibility = Visibility.Hidden;
            Menu_Grid.Visibility = Visibility.Hidden;
            Wardrobe_Grid.Visibility = Visibility.Hidden;
            Coffeepot_Interact_Grid.Visibility = Visibility.Hidden;
            Tv_Interact_Grid.Visibility = Visibility.Hidden;
            Temp_Interact_Grid.Visibility = Visibility.Hidden;
            Help_Grid.Visibility = Visibility.Hidden;
            

            dispatcherTimer.Tick += new EventHandler(dt_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            dispatcherTimer.Start();

            grinderTimer.Tick += new EventHandler(grinder_Tick);
            grinderTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            grinderTimer.Start();

            tempSliderTimer.Tick += new EventHandler(tempSliderTimer_Tick);
            tempSliderTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            tempSliderTimer.Start();

        }

        //  Stopwatches for display "on time" of lights while in Home Lights.
        //

        void dt_Tick(object sender, EventArgs e)
        {
            if (stopWatch1.IsRunning)
            {
                TimeSpan ts1 = stopWatch1.Elapsed;
                currentTime1 = String.Format("{0:00}:{1:00}:{2:00}",
                ts1.Minutes, ts1.Seconds, ts1.Milliseconds / 10);
                BedroomRuntime_label.Content = currentTime1;
            }
            if (stopWatch2.IsRunning)
            {
                TimeSpan ts2 = stopWatch2.Elapsed;
                currentTime2 = String.Format("{0:00}:{1:00}:{2:00}",
                ts2.Minutes, ts2.Seconds, ts2.Milliseconds / 10);
                LivingroomRuntime_label.Content = currentTime2;
            }
            if (stopWatch3.IsRunning)
            {
                TimeSpan ts3 = stopWatch3.Elapsed;
                currentTime3 = String.Format("{0:00}:{1:00}:{2:00}",
                ts3.Minutes, ts3.Seconds, ts3.Milliseconds / 10);
                YardRuntime_label.Content = currentTime3;
            }
        }

        


        // Code used for making window moveable.

        private bool clicked = false;
        private Point lmAbs = new Point();

        // PnMouseDown, PnMouseUp, PnMouseMove is used for making custom header movable
        
        void PnMouseDown(object sender, MouseEventArgs e)
        {
            clicked = true;
            this.lmAbs = e.GetPosition(this);
            this.lmAbs.Y = Convert.ToInt16(this.Top) + this.lmAbs.Y;
            this.lmAbs.X = Convert.ToInt16(this.Left) + this.lmAbs.X;
        }

        void PnMouseUp(object sender, MouseEventArgs e)
        {
            clicked = false;
        }

        void PnMouseMove(object sender, MouseEventArgs e)
        {
            if (clicked)
            {
                Point MousePosition = e.GetPosition(this);
                Point MousePositionAbs = new Point();
                MousePositionAbs.X = Convert.ToInt16(this.Left) + MousePosition.X;
                MousePositionAbs.Y = Convert.ToInt16(this.Top) + MousePosition.Y;
                this.Left = this.Left + (MousePositionAbs.X - this.lmAbs.X);
                this.Top = this.Top + (MousePositionAbs.Y - this.lmAbs.Y);
                this.lmAbs = MousePositionAbs;
            }
        }

        void grinder_Tick(object sender, EventArgs e)
        {
            SliderValue = (int)slider.Value;

            if (SliderValue == 1) Suggestion_image.Source = SportOutfitImage;
            if (SliderValue == 2) Suggestion_image.Source = CasualOutfitImage;
            if (SliderValue == 3) Suggestion_image.Source = FormalOutfitImage;

        }

        //  Closes application when X is clicked.

        private void closeWindow_image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();

        }

        //  Displays Helpscribe once clicked.

        private void OnlineHelp_button_Click(object sender, RoutedEventArgs e)
        {
            //  Place Home_Manipulator.chm -> testtest\testtest\bin\Debug\

            Process.Start("Home_Manipulator.chm");
        }

        //  Displays User Manual once clicked.

        private void UsersManual_button_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("UsersManual.pdf");
        }


        //  ~~~~~~~~~~~~~~ EVERY FUNCTION BELOW THIS POINT ~~~~~~~~~~~~~~~~~~~~~~
        //
        //              Hides/Shows Grids, depending on user's pick.
        //              Restores colors to labels while hovering over them.
        //              Makes label's color white once selected.
        //              Changes images when switching states of a toggle.
        //  
        //  ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        void tempSliderTimer_Tick(object sender, EventArgs e)
        {
            tempSliderValue = (int)Temp_slider.Value;

            Temp_slider_info.Content = "Current Temp:\t" + tempSliderValue + " ℃";

            // Show cold image for Temp < 20, otherwise show hot image.

            if (tempSliderValue < 20)
            {
                Temp_Device_image.Source = ColdIcon;
            }
            else
            {
                Temp_Device_image.Source = HotIcon;
            }

        }

        private void HouseLights_label_MouseEnter(object sender, MouseEventArgs e)
        {
            if (lockLights) HouseLights_label.Foreground = LabelsHoverColor;
            Menu_Grid.Visibility = Visibility.Hidden;
        }

        private void HouseLights_label_MouseLeave(object sender, MouseEventArgs e)
        {
            if (lockLights) HouseLights_label.Foreground = LabelsDefaultColor;
        }

        private void Wardrobe_label_MouseEnter(object sender, MouseEventArgs e)
        {
            if (lockWardrobe) Wardrobe_label.Foreground = LabelsHoverColor;
            Menu_Grid.Visibility = Visibility.Hidden;
        }

        private void Wardrobe_label_MouseLeave(object sender, MouseEventArgs e)
        {
            if (lockWardrobe) Wardrobe_label.Foreground = LabelsDefaultColor;
        }

        private void FridgetSpinner_label_MouseEnter(object sender, MouseEventArgs e)
        {
            if (lockFridge) FridgetSpinner_label.Foreground = LabelsHoverColor;
            Menu_Grid.Visibility = Visibility.Hidden;
        }

        private void Manual_MouseEnter(object sender, MouseEventArgs e)
        {
            if (lockManual) Help_label.Foreground = LabelsHoverColor;
            Menu_Grid.Visibility = Visibility.Hidden;
        }

        private void Manual_MouseLeave(object sender, MouseEventArgs e)
        {
            if (lockManual) Help_label.Foreground = LabelsDefaultColor;
        }

        private void FridgetSpinner_label_MouseLeave(object sender, MouseEventArgs e)
        {
            if (lockFridge) FridgetSpinner_label.Foreground = LabelsDefaultColor;
        }        

        private void closeWindow_image_MouseEnter(object sender, MouseEventArgs e)
        {
            closeWindow_image.Source = CloseWindowHover;
        }

        private void closeWindow_image_MouseLeave(object sender, MouseEventArgs e)
        {
            closeWindow_image.Source = CloseWindowDefault;
        }        

        private void FridgetSpinner_label_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            lockFridge = false;
            lockLights = true;
            lockWardrobe = true;
            lockManual = true;

            FridgetSpinner_label.Foreground = LabelsWhiteColor;

            Help_label.Foreground = LabelsDefaultColor;
            HouseLights_label.Foreground = LabelsDefaultColor;
            Wardrobe_label.Foreground = LabelsDefaultColor;

            HouseLights_Grid.Visibility = Visibility.Hidden;
            Wardrobe_Grid.Visibility = Visibility.Hidden;
            Coffeepot_Interact_Grid.Visibility = Visibility.Hidden;
            Tv_Interact_Grid.Visibility = Visibility.Hidden;
            Temp_Interact_Grid.Visibility = Visibility.Hidden;
            Help_Grid.Visibility = Visibility.Hidden;

            var mFridge = new MainWindow();
            mFridge.Show();

        }

        private void Wardrobe_label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            lockFridge = true;
            lockLights = true;
            lockManual = true;
            lockWardrobe = false;

            Wardrobe_label.Foreground = LabelsWhiteColor;

            Help_label.Foreground = LabelsDefaultColor;
            FridgetSpinner_label.Foreground = LabelsDefaultColor;
            HouseLights_label.Foreground = LabelsDefaultColor;

            HouseLights_Grid.Visibility = Visibility.Hidden;
            Coffeepot_Interact_Grid.Visibility = Visibility.Hidden;
            Tv_Interact_Grid.Visibility = Visibility.Hidden;
            Temp_Interact_Grid.Visibility = Visibility.Hidden;
            Help_Grid.Visibility = Visibility.Hidden;

            Wardrobe_Grid.Visibility = Visibility.Visible;
        }

        private void HouseLights_label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            lockFridge = true;
            lockManual = true;
            lockLights = false;
            lockWardrobe = true;

            HouseLights_label.Foreground = LabelsWhiteColor;

            Help_label.Foreground = LabelsDefaultColor;
            Wardrobe_label.Foreground = LabelsDefaultColor;
            FridgetSpinner_label.Foreground = LabelsDefaultColor;

            Wardrobe_Grid.Visibility = Visibility.Hidden;
            Coffeepot_Interact_Grid.Visibility = Visibility.Hidden;
            Tv_Interact_Grid.Visibility = Visibility.Hidden;
            Temp_Interact_Grid.Visibility = Visibility.Hidden;
            Help_Grid.Visibility = Visibility.Hidden;

            HouseLights_Grid.Visibility = Visibility.Visible;
        }

        private void menu_image_MouseEnter(object sender, MouseEventArgs e)
        {
            Menu_Grid.Visibility = Visibility.Visible;
        }

        private void Menu_Grid_MouseEnter(object sender, MouseEventArgs e)
        {
           Menu_Grid.Visibility = Visibility.Visible;
        }

        private void Menu_Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            
        }

        private void menu_image_MouseLeave(object sender, MouseEventArgs e)
        {
            
        }

        private void Tv_Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            Tv_Grid.Background = LabelsDefaultColor;
            Coffeepot_Grid.Background = Brushes.Transparent;
            Temp_Grid.Background = Brushes.Transparent;
        }        

        private void Coffeepot_Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            Tv_Grid.Background = Brushes.Transparent;
            Coffeepot_Grid.Background = LabelsDefaultColor;
            Temp_Grid.Background = Brushes.Transparent;
        }       

        private void Temp_Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            Tv_Grid.Background = Brushes.Transparent;
            Coffeepot_Grid.Background = Brushes.Transparent;
            Temp_Grid.Background = LabelsDefaultColor;
        }

        private void Addnew_Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            Tv_Grid.Background = Brushes.Transparent;
            Coffeepot_Grid.Background = Brushes.Transparent;
            Temp_Grid.Background = Brushes.Transparent;
        }

        private void BedroomLights_toggle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //  change boolean value once clicked.

            lockBedroom = !lockBedroom;

            if (lockBedroom)
            {
                BedroomLights_toggle.Source = ToggleOff;
                Bedroom_image.Source = LightsOffImage;
                if (stopWatch1.IsRunning)
                {
                    stopWatch1.Stop();
                }
                stopWatch1.Reset();
            }
            else
            {
                BedroomLights_toggle.Source = ToggleOn;
                Bedroom_image.Source = BedroomOn;
                stopWatch1.Start();
            }
        }

        private void LivingroomLights_toggle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //  change boolean value once clicked.

            lockLivingroom = !lockLivingroom;

            if (lockLivingroom)
            {
                LivingroomLights_toggle.Source = ToggleOff;
                Livingroom_image.Source = LightsOffImage;
                if (stopWatch2.IsRunning)
                {
                    stopWatch2.Stop();
                }
                stopWatch2.Reset();
            }
            else
            {
                LivingroomLights_toggle.Source = ToggleOn;
                Livingroom_image.Source = LivingroomLightsOnImage;
                stopWatch2.Start();
            }
        }

        private void YardLights_toggle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //  change boolean value once clicked.

            lockYard = !lockYard;

            if (lockYard)
            {
                YardLights_toggle.Source = ToggleOff;
                Yard_image.Source = LightsOffImage;
                if (stopWatch3.IsRunning)
                {
                    stopWatch3.Stop();
                }
                stopWatch3.Reset();
            }
            else
            {
                YardLights_toggle.Source = ToggleOn;
                Yard_image.Source = YardLightsOnImage;
                stopWatch3.Start();
            }
        }

        private void Coffeepot_toggle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            lockCoffeepot = !lockCoffeepot;

            if (lockCoffeepot)
            {
                Coffeepot_toggle.Source = ToggleOff;
                Coffeepot_Device_image.Source = CoffeeEmpty;
                ImageBehavior.SetAnimatedSource(Coffeepot_Device_image, CoffeeEmpty);
                Coffeepot_Device_Info.Content = "Use Switch below to start making Coffee";

            }
            else
            {
                Coffeepot_toggle.Source = ToggleOn;
                Coffeepot_Device_image.Source = CoffeeMaking;
                ImageBehavior.SetAnimatedSource(Coffeepot_Device_image, CoffeeMaking);
                Coffeepot_Device_Info.Content = "Your Coffee is being Prepared.. Thank you for your patience";
            }
        }

        private void coffeepot_label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            HouseLights_Grid.Visibility = Visibility.Hidden;
            Wardrobe_Grid.Visibility = Visibility.Hidden;
            Menu_Grid.Visibility = Visibility.Hidden;
            Tv_Interact_Grid.Visibility = Visibility.Hidden;
            Temp_Interact_Grid.Visibility = Visibility.Hidden;
            Help_Grid.Visibility = Visibility.Hidden;

            Wardrobe_label.Foreground = LabelsDefaultColor;
            FridgetSpinner_label.Foreground = LabelsDefaultColor;
            HouseLights_label.Foreground = LabelsDefaultColor;

            Coffeepot_Interact_Grid.Visibility = Visibility.Visible;
            
        }

        private void Tv_toggle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            lockTv = !lockTv;

            if (lockTv)
            {
                Tv_toggle.Source = ToggleOff;
                Tv_Device_image.Source = TvOffImage;
                ImageBehavior.SetAnimatedSource(Tv_Device_image, TvOffImage);
                Tv_Device_Info.Content = "Tv Switched Off!";
                Select_Channel_label.Visibility = Visibility.Hidden;

            }
            else
            {
                Tv_toggle.Source = ToggleOn;
                Select_Channel_label.Visibility = Visibility.Visible;
                Tv_Device_Info.Content = "Tv Switched On!";
            }
        }


        //  using with lockTv == false, cause toggle must be enabled in order for this to work.
        //       
        //  For every channel below, when it is selected, change gif image of Tv.
        //

        private void Channel_1_Selected(object sender, RoutedEventArgs e)
        {
            if (lockTv == false)
            {
                Tv_Device_image.Source = TvOnImage1;
                ImageBehavior.SetAnimatedSource(Tv_Device_image, TvOnImage1);
            }
        }

        private void Channel_2_Selected(object sender, RoutedEventArgs e)
        {
            if (lockTv == false)
            {
                Tv_Device_image.Source = TvOnImage2;
                ImageBehavior.SetAnimatedSource(Tv_Device_image, TvOnImage2);
            }
        }

        private void Channel_3_Selected(object sender, RoutedEventArgs e)
        {
            if (lockTv == false)
            {
                Tv_Device_image.Source = TvOnImage3;
                ImageBehavior.SetAnimatedSource(Tv_Device_image, TvOnImage3);
            }
        }

        private void tv_label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            HouseLights_Grid.Visibility = Visibility.Hidden;
            Wardrobe_Grid.Visibility = Visibility.Hidden;
            Menu_Grid.Visibility = Visibility.Hidden;
            Coffeepot_Interact_Grid.Visibility = Visibility.Hidden;
            Tv_Interact_Grid.Visibility = Visibility.Hidden;
            Temp_Interact_Grid.Visibility = Visibility.Hidden;
            Help_Grid.Visibility = Visibility.Hidden;

            Wardrobe_label.Foreground = LabelsDefaultColor;
            FridgetSpinner_label.Foreground = LabelsDefaultColor;
            HouseLights_label.Foreground = LabelsDefaultColor;

            Tv_Interact_Grid.Visibility = Visibility.Visible;
        }

        private void Manual_MouseDown(object sender, MouseButtonEventArgs e)
        {
            lockFridge = true;
            lockLights = true;
            lockWardrobe = true;
            lockManual = false;

            Help_label.Foreground = LabelsWhiteColor;
            FridgetSpinner_label.Foreground = LabelsDefaultColor;
            HouseLights_label.Foreground = LabelsDefaultColor;
            Wardrobe_label.Foreground = LabelsDefaultColor;


            Temp_Interact_Grid.Visibility = Visibility.Hidden;
            HouseLights_Grid.Visibility = Visibility.Hidden;
            Wardrobe_Grid.Visibility = Visibility.Hidden;
            Tv_Interact_Grid.Visibility = Visibility.Hidden;
            Coffeepot_Interact_Grid.Visibility = Visibility.Hidden;


            Help_Grid.Visibility = Visibility.Visible;
        }

        private void Temp_Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            HouseLights_Grid.Visibility = Visibility.Hidden;
            Wardrobe_Grid.Visibility = Visibility.Hidden;
            Menu_Grid.Visibility = Visibility.Hidden;
            Coffeepot_Interact_Grid.Visibility = Visibility.Hidden;
            Tv_Interact_Grid.Visibility = Visibility.Hidden;
            Help_Grid.Visibility = Visibility.Hidden;


            Wardrobe_label.Foreground = LabelsDefaultColor;
            FridgetSpinner_label.Foreground = LabelsDefaultColor;
            HouseLights_label.Foreground = LabelsDefaultColor;

            Temp_Interact_Grid.Visibility = Visibility.Visible;
        }

        private void Menu_Grid_MouseLeave_1(object sender, MouseEventArgs e)
        {
            Menu_Grid.Visibility = Visibility.Hidden;
        }

       
    }
}

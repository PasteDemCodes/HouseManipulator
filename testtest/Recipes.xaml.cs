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
    /// Interaction logic for Recipes_form.xaml
    /// </summary>
    public partial class Recipes_form : Window
    {
        int index;
        public Recipes_form()
        {
            InitializeComponent();
            this.Title = "Recipes";
            System.Windows.Threading.DispatcherTimer updateBoxTimer = new System.Windows.Threading.DispatcherTimer();
            updateBoxTimer.Tick += new EventHandler(updateBoxTimer_Tick);
            updateBoxTimer.Interval = new TimeSpan(50);
            updateBoxTimer.Start();
        }

        private void updateBoxTimer_Tick(object sender, EventArgs e)
        {
            index = Recipes_Box.SelectedIndex;
            setFoodRequirements(index);
        }

        public void setFoodRequirements(int a)
        {
            Igridient_label.Content = "";
            amount_label.Content = "";
            availability_label.Content = "";

            if (a == 0)
            {
                Igridient_label.Content = "Ingred.\n\n" + "Spaghetti" + "\n" + "Cream" + "\n" + "Butter" + "\n" + "Cheese" + "\n" + "Meat";
                amount_label.Content = "Quant.\n\n" + "500g" + "\n" + "400g" + "\n" + "200g" + "\n" + "150g" + "\n" + "500g";
                availability_label.Content = "Stock.\n\n"+"0/1" + "\n" + "1/1" + "\n" + "0/2" + "\n" + "1/1" + "\n" + "1/1";
                Food_Image.Source = new BitmapImage(new Uri(@"pastitsio.jpg", UriKind.Relative));
            }
            if (a == 1)
            {
                Igridient_label.Content = "Ingred.\n\n" + "Spaghetti" + "\n" + "Cream" + "\n" + "Butter" + "\n" + "Cheese" + "\n" + "Eggs";
                amount_label.Content = "Quant.\n\n" + "500g" + "\n" + "400g" + "\n" + "200g" + "\n" + "150g" + "\n" + "";
                availability_label.Content = "Stock.\n\n" + "0/1" + "\n" + "1/1" + "\n" + "0/2" + "\n" + "1/1" + "\n" + "6/10";
                Food_Image.Source = new BitmapImage(new Uri(@"souffle.jpg", UriKind.Relative));
            }
            if (a == 2)
            {
                Igridient_label.Content = "Ingred.\n\n" + "Quaker" + "\n" + "Honey" + "\n" + "Eggs" + "\n" + "Peanut But." + "\n" + "Cinnamon";
                amount_label.Content = "Quant.\n\n" + "100g" + "\n" + "60g" + "\n" + "" + "\n" + "50g" + "\n" + "5g";
                availability_label.Content = "Stock.\n\n" + "1/1" + "\n" + "1/1" + "\n" + "6/6" + "\n" + "1/1" + "\n" + "1/1";
                Food_Image.Source = new BitmapImage(new Uri(@"steelcutoats.jpg", UriKind.Relative));

            }

        }

        private void textBox_GotFocus(object sender, RoutedEventArgs e)
        {
            textBox.Text = "";
        }

        private void textBox_LostFocus(object sender, RoutedEventArgs e)
        {
            textBox.Text = "Search Recipes Online";
        }
    }
}

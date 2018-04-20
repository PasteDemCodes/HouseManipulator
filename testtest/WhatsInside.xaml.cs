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
    /// Interaction logic for WhatsInside.xaml
    /// </summary>
    public partial class WhatsInside : Window
    {
        public WhatsInside()
        {
            InitializeComponent();
            this.Title = "What's Inside";
            SetLabelValues();
        }

        private void label_MouseEnter(object sender, MouseEventArgs e)
        {
            label.Foreground = new SolidColorBrush(Colors.Red);
        }

        private void label_MouseLeave(object sender, MouseEventArgs e)
        {
            label.Foreground = new SolidColorBrush(Colors.White);
        }


        public void SetLabelValues()
        {
            Ingred.Content ="Ingred.\n\n"   +   "Milk\nHoney\nYoghurt\nEgg(s)\nCheese\nCream\nButter";
            Quant.Content = "Quant.\n\n"    +   "1lt\n500g\n330ml\n\n200g\n500g\n250g";
            Stock.Content = "Stock.\n\n"    +   "1/4\n1/3\n5/5\n6/20\n2/2\n2/3\n2/5";

            sale.Content = "There's a running Sale on:";
            sale.Content += "\n\tButter:\tSave:\t30%.";
            sale.Content += "\n\tMilk:\tSave:\t17%.";
            sale.Content += "\n\tEgg(s):\tSave:\t50%.";
        }
    }
}

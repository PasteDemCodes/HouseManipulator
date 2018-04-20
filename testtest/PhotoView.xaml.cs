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
    /// Interaction logic for PhotoView.xaml
    /// </summary>
    public partial class PhotoView : Window
    {

        int imageCounter = 0;
        public PhotoView()
        {
            InitializeComponent();
            this.Title = "Photo View";


        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            imageCounter++;
            if (imageCounter == 0)  ShownImage.Source = new BitmapImage(new Uri(@"0.jpg", UriKind.Relative)); 
            if (imageCounter == 1)  ShownImage.Source = new BitmapImage(new Uri(@"1.jpg", UriKind.Relative)); 
            if (imageCounter == 2)  ShownImage.Source = new BitmapImage(new Uri(@"2.jpg", UriKind.Relative)); 
            if (imageCounter == 3)  ShownImage.Source = new BitmapImage(new Uri(@"3.jpg", UriKind.Relative)); 
            if (imageCounter == 4) ShownImage.Source = new BitmapImage(new Uri(@"4.jpg", UriKind.Relative));
            if (imageCounter > 4) imageCounter = 4;
        }

        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            imageCounter--;
            if (imageCounter == 0)  ShownImage.Source = new BitmapImage(new Uri(@"0.jpg", UriKind.Relative));
            if (imageCounter == 1) ShownImage.Source = new BitmapImage(new Uri(@"1.jpg", UriKind.Relative)); 
            if (imageCounter == 2)  ShownImage.Source = new BitmapImage(new Uri(@"2.jpg", UriKind.Relative));
            if (imageCounter == 3)  ShownImage.Source = new BitmapImage(new Uri(@"3.jpg", UriKind.Relative));
            if (imageCounter == 4) ShownImage.Source = new BitmapImage(new Uri(@"4.jpg", UriKind.Relative));
            if (imageCounter < 0) imageCounter = 0;
        }
    }
}

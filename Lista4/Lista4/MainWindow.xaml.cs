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

namespace Lista4
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private byte r = 0;
        private byte g = 255;
        private byte b = 0;

        public MainWindow()
        {
            InitializeComponent();
            Kolo.Visibility = Visibility.Hidden;
            UpdateColor();
            
        }

       

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            double x = e.GetPosition(MainGrid).X;
            double y = e.GetPosition(MainGrid).Y;
            r = (byte)x;
            b = (byte)y;

            e.Handled = true;
        }

         private void TrybButton_Click(object sender, RoutedEventArgs e)
        {
          
             
           
        }
        private void KwadraturaButton_Click(object sender, RoutedEventArgs e)
        {
            if(Kwadrat.IsVisible)
            {
                Kwadrat.Visibility = Visibility.Hidden;
                Kolo.Visibility = Visibility.Visible;
            } else
            {             
                Kwadrat.Visibility = Visibility.Visible;
                Kolo.Visibility = Visibility.Hidden;
            }
        }

    

        private void UpdateColor()
        {
            Kwadrat.Fill = new SolidColorBrush(Color.FromRgb(r, g, b));
            Kolo.Fill = new SolidColorBrush(Color.FromRgb(r, g, b));

        }

       
    }
}

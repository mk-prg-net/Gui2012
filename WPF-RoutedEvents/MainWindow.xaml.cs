using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Diagnostics;

namespace WPF_RoutedEvents
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        Color myColor = System.Windows.Media.Colors.Blue;
        bool toggle = true;




        private void imgBtnOuter_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("Routed Events: imgBtnOuter_MouseDown (Bubbeling)");
            e.Handled = false;
        }

        private void btnOuter_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("Routed Events: btnOuter_MouseDown (Bubbeling)");
        }

        private void imgBtnOuter_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("Routed Events: imgBtnOuter_PreviewMouseDown (Tunneling)");
            if (toggle)
                imgBtnOuter.Source = new BitmapImage(new Uri("pack://application:,,,/WPF-RoutedEvents;component/smiley2.png"));
            else
                imgBtnOuter.Source = new BitmapImage(new Uri("pack://application:,,,/WPF-RoutedEvents;component/smiley.png"));

            toggle = !toggle;

        }

        private void btnOuter_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("Routed Events: btnOuter_PreviewMouseDown (Tunneling)");
            myColor = myColor == Colors.Blue ? Colors.Red : Colors.Green;
            btnOuter.Background = new SolidColorBrush(myColor);

            // Handled wird auf false gesetzt. Damit wird das Tunneling (Event wird weiter
            // an das Kindelement gereicht) fortgesetzt.
            e.Handled = false;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("----------------------------------");
        }
    }
}

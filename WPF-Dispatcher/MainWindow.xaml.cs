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

namespace WPF_Dispatcher
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Timers.Timer clock = new System.Timers.Timer(1000.0);
        
        public MainWindow()
        {
            InitializeComponent();

            clock.AutoReset = true;
            clock.Elapsed += new System.Timers.ElapsedEventHandler(clock_Elapsed);
            clock.Elapsed += new System.Timers.ElapsedEventHandler(clock_Elapsed2);
            clock.Enabled = true;

            
        }

        int sekunde = 0;

        void clock_Elapsed2(object sender, System.Timers.ElapsedEventArgs e)
        {
            Debug.WriteLine(e.SignalTime.ToString());
        }

        void clock_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            // Das Setzen der Label- Eigenschaft wird an den UI Thread delegiert.
            // Dieses Vorgehen wird durch das STA erzwungen
            //Dispatcher.Invoke(
            //    new Action<string>(time => lblStatusTime.Content = time),
            //    new object[] { DateTime.Now.ToLongTimeString() });

            //// Weiterschalten des ProgressBar
            sekunde++;
            sekunde %= 60;

            Dispatcher.Invoke(
                //new Action<int>(sec => { progress.Value = (double)sec; Zeiger.X2 = Zx(sec); Zeiger.Y2 = Zy(sec); }),
                new Action<int>(MoveZeiger),
                new object[] { sekunde });

            // Direkter Zugriff aus dem Timer- Thread auf die Elemente der Oberfläche 
            // ist verboten !!
            //Zeiger.X2 = Zx(sekunde); 
            //Zeiger.Y2 = Zy(sekunde);
        }

        void MoveZeiger(int sec) 
        { 
            progress.Value = (double)sec; 
            Zeiger.X2 = Zx(sec); 
            Zeiger.Y2 = Zy(sec); 
        }

        double Zx(int sec)
        {
            return 125.0* Math.Cos((Math.PI * 6.0 * (double)sec)/180.0);
        }

        double Zy(int sec)
        {
            return 125.0 * Math.Sin((Math.PI * 6.0 * (double)sec) / 180.0);
        }

        private void mnuBeenden_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        
    }

    
}

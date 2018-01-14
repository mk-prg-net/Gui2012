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

namespace WPFWindowsLib
{
    /// <summary>
    /// Interaktionslogik für Window1.xaml
    /// </summary>
    public partial class Window1 : Grid
    {
        public Window1()
        {
            InitializeComponent();
            Debug.WriteLine("Initialisiere WPF Window");
        }

        private void btnWpf_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("WPF tut was");
            MessageBox.Show("Du hast mich geklickt!");
        }
    }
}

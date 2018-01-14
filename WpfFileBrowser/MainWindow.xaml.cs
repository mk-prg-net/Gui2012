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

using WF = System.Windows.Forms;

namespace WpfFileBrowser
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

        private void mnuShootdown_Click(object sender, RoutedEventArgs e)
        {
            // Anwendung wird beendet
            Application.Current.Shutdown();
        }

        private void mnuSetHomeDir_Click(object sender, RoutedEventArgs e)
        {
            var fldDlg = new WF.FolderBrowserDialog();
            if (fldDlg.ShowDialog() == WF.DialogResult.OK)
            {
                tbxCurrentHomeDir.Text = fldDlg.SelectedPath;
            }
        }
    }
}

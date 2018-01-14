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

namespace WPF_Steuerelemente
{
    /// <summary>
    /// Interaktionslogik für Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        System.Timers.Timer clock = new System.Timers.Timer(1000.0);

        Logserver logServer;

        public Window1()
        {
            InitializeComponent();
            logServer = new Logserver(lbxLog);
            
            logServer.log(new Logserver.StatusMsg("Client gestartet"));

        }

        private void mnuExit_Click(object sender, RoutedEventArgs e)
        {
            // Anwendung beenden
            Application.Current.Shutdown();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (frameXmp != null)
            {
                ComboBox cbx = sender as ComboBox;
                Debug.Assert(cbx != null);
                ComboBoxItem item = (ComboBoxItem)cbx.SelectedItem;
                LabledUri lbUri = item.Content as LabledUri;
                Debug.Assert(lbUri != null);
                Uri uri = new Uri(lbUri.Uri);
                frameXmp.Navigate(uri);
                logServer.log(new Logserver.LogMsg("Seite " + lbUri.Uri + " geladen"));
            }
        }

        private void ListBox_Loaded(object sender, RoutedEventArgs e)
        {
            //ListBox lbx = sender as ListBox;
            //Debug.Assert(lbx != null);

            //boArtikel bo = new boArtikel();
            //lbx.DataContext = bo.selectLieferanten();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox lbx = sender as ListBox;
            Debug.Assert(lbx != null, "ListBox_SelectionChanged wurde von keiner Listbox gefeuert");


            Debug.WriteLine(e.Source.ToString());
            Debug.WriteLine(lbx.SelectedItem.ToString());

            if (((ListBoxItem)lbx.SelectedItem).Content is StackPanel)
            {
                // as gibt null zurück, wenn es nicht funkt
                StackPanel sp = ((ListBoxItem)lbx.SelectedItem).Content as StackPanel;
                Label lbl = sp.Children[1] as Label;

                MessageBox.Show(lbl.Content.ToString());
            }

            
        }
    }
}

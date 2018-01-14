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

namespace WpfStandardApp
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            TreeViewItem all = trvAll.Items[0] as TreeViewItem;

            foreach(string dir in System.IO.Directory.GetDirectories(@"C:\"))
            {
                var it = new TreeViewItem()
                {                    
                    Header = new StackPanel()
                    {
                        Orientation = Orientation.Horizontal,
                        Children = {
                            new Rectangle(){
                                Width=20,
                                Height=20,
                                Fill = (Brush)FindResource("brBook")
                            },
                            new Label() {
                                Content = System.IO.Path.GetFileName(dir)
                            }
                        }
                    },
                    Tag = dir 
                };

                it.Selected += new RoutedEventHandler(it_Selected);

                all.Items.Add(it);
            }
        }

        void it_Selected(object sender, RoutedEventArgs e)
        {
            TreeViewItem ti = sender as TreeViewItem;
            //var sp = ti.Header as StackPanel;
            //var lbl = sp.Children[1] as Label;
            //tbxPath.Text = lbl.Content as string;
            tbxPath.Text = ti.Tag as string;
                
        }

        void Dir_Selected(object sender, RoutedEventArgs e)
        {
            TreeViewItem ti = sender as TreeViewItem;
            tbxPath.Text = ti.Tag as string;

        }

        void File_Selected(object sender, RoutedEventArgs e)
        {
            TreeViewItem ti = sender as TreeViewItem;
            string filename = ti.Tag as string;

            string ext = System.IO.Path.GetExtension(filename).ToLower();
            if (ext == ".jpg" || ext == ".gif" || ext == ".png")
            {
                BitmapImage bi3 = new BitmapImage();
                bi3.BeginInit();
                bi3.UriSource = new Uri(filename, UriKind.RelativeOrAbsolute);
                bi3.EndInit();

                imgViewer.Source = bi3;
            }


        }


        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (System.IO.Directory.Exists(tbxPath.Text))
            {
                var tg = new TreeViewGenerator();
                tg.RootNode = trvAll.Items[0] as TreeViewItem;
                tg.MainWindow = this;
                tg.DirSelectedHandler += new RoutedEventHandler(Dir_Selected);
                tg.FileSelectedHandler += new RoutedEventHandler(File_Selected);

                tg.scanDir(tbxPath.Text);
                MessageBox.Show("TreeView aufgebaut");
            }
            else
            {
                MessageBox.Show("Das Verzeichnis " + tbxPath.Text + " existiert nicht");
            }
        }

    }
}

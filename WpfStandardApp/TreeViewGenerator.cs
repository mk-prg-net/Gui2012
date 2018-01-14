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
    class TreeViewGenerator : DMS.DirTree
    {
        /// <summary>
        /// Wurzelknoten der Treview
        /// </summary>
        public TreeViewItem RootNode;
        TreeViewItem ParentNode;

        public FrameworkElement MainWindow;

        Stack<TreeViewItem> NodeStack = new Stack<TreeViewItem>();

        public event System.Windows.RoutedEventHandler DirSelectedHandler;
        public event System.Windows.RoutedEventHandler FileSelectedHandler;


        protected override bool BeginScanDir(string path)
        {
            // Löschen aller alten Einträge
            RootNode.Items.Clear();
            
            NodeStack.Clear();
            NodeStack.Push(RootNode);
            
            return true;
        }

        protected override bool EnterDir(string path)
        {
            ParentNode = NodeStack.Peek();

            string dir = System.IO.Path.GetFileName(path);
            var node = new TreeViewItem()
            {
                Header = new StackPanel()
                {
                    Orientation = Orientation.Horizontal,
                    Children = {
                            new Rectangle(){
                                Width=20,
                                Height=20,
                                Fill = (Brush)MainWindow.FindResource("brBook")
                            },
                            new Label() {
                                Content = dir
                            }
                        }
                },
                Tag = path
            };

            if(DirSelectedHandler != null)
                node.Selected += new RoutedEventHandler(DirSelectedHandler);

            NodeStack.Push(node);

            ParentNode.Items.Add(node);            

            return true;
        }

        protected override bool TouchFile(string path)
        {
            string dir = System.IO.Path.GetFileName(path);
            var node = new TreeViewItem()
            {
                Header = new StackPanel()
                {
                    Orientation = Orientation.Horizontal,
                    Children = {
                            new Rectangle(){
                                Width=20,
                                Height=20,
                                Fill = (Brush)MainWindow.FindResource("brVideo")
                            },
                            new Label() {
                                Content = dir
                            }
                        }
                },
                Tag = path
            };

            if(FileSelectedHandler != null)
                node.Selected += new RoutedEventHandler(FileSelectedHandler);
            ParentNode.Items.Add(node);   

            return true;
        }

        protected override bool ExitDir(string path)
        {
            NodeStack.Pop();
            return true;
        }

    }
}

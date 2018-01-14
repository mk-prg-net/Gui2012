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

using IO = System.IO;
using markup = System.Windows.Markup;

namespace Wpf2DGrafik
{
    /// <summary>
    /// Interaktionslogik für UserControl1.xaml
    /// </summary>
    public partial class Viewer2D : UserControl
    {
        // zentrale Meldungshub
        mko.Log.LogServer log = new mko.Log.LogServer();

        // Zeichnung als Liste aus Shape- Elementen
        Zeichnung zb = new Zeichnung();

        // Referenz auf eine Generator für eine Ellipse/Linie/Knick (= Shape)
        // Der Generator erzeugt die Figur über Stützpunkte, die mit der Maus eingegeben werden
        ShapeFactory factory = new LinienFactory();

        public Viewer2D()
        {
            InitializeComponent();

            // Fehlerprotokollierung definieren
            log.EventLog += (user, info) =>
            {
                statusBarText.Content = string.Format("{0:t} {1:g} {2}", info.LogDate, info.LogType, info.Message);
            };

        }

        public void LoadXaml2D(IO.Stream stream)
        {

        }

        private void mainCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (factory == null)
            {
                zb.auswählen(e.GetPosition(mainCanvas));
                zb.zeichne(mainCanvas);
            }
            else if (factory.CollectBaseAndCreateShape(e.GetPosition(mainCanvas), zb))
            {
                zb.zeichne(mainCanvas);
                //lbxDrawingElements.Items.Add(New ListBoxItem() With {.Content = factory.GetType().Name})
            }
            e.Handled = true;
        }

        private void btnDrawEllipse_Click(object sender, RoutedEventArgs e)
        {
            factory = new EllipsenFactory();
            log.Log(mko.Log.RC.CreateStatus("Ellipse erzeugen"));
        }

        private void btnDrawLine_Click(object sender, RoutedEventArgs e)
        {
            factory = new LinienFactory();
            log.Log(mko.Log.RC.CreateStatus("Linie erzeugen"));
        }

        private void btnDrawKnick_Click(object sender, RoutedEventArgs e)
        {
            factory = new KnickFactory();
            log.Log(mko.Log.RC.CreateStatus("Knick erzeugen"));
        }

        
        private void mnuClearZeichnung_Click(object sender, RoutedEventArgs e)
        {
            zb.Elemente.Clear();
            mainCanvas.Children.Clear();
        }

        private void mnuSaveXaml_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dlg = new System.Windows.Forms.SaveFileDialog();
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    IO.Stream fstream = dlg.OpenFile();

                    markup.XamlWriter.Save(mainCanvas, fstream);
                }
            }
            catch (Exception ex)
            {
                log.Log(mko.Log.RC.CreateError(ex.Message));
            }
        }

        private void mnuOpenXaml_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dlg = new System.Windows.Forms.OpenFileDialog();
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    IO.Stream fstream = dlg.OpenFile();

                    var cv = (Canvas)markup.XamlReader.Load(fstream);
                    cv.Name = ShapeFactory.MakeCtrlId();
                    mainCanvas.Children.Add(cv);
                    
                    
                }
            }
            catch (Exception ex)
            {
                log.Log(mko.Log.RC.CreateError(ex.Message));
            }

        }        
    }
}

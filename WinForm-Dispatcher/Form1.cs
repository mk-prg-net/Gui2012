using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace WinForm_Dispatcher
{
    public partial class Form1 : Form
    {
        System.Timers.Timer clock = new System.Timers.Timer(1000.0);

        public Form1()
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

            if (statusStrip1.InvokeRequired)
            {
                // Änderung des Steuerelementinhaltes an den HAuptthread deligieren
                statusStrip1.Invoke(
                    //new Action<int>(sec => { progress.Value = (double)sec; Zeiger.X2 = Zx(sec); Zeiger.Y2 = Zy(sec); }),
                //new Action<int>(MoveZeiger),
                new Action<int>(sec =>
                {
                    lblTime.Text = sec.ToString();
                    MyProgressBar.Value = sec;
                }),
                new object[] { sekunde });
            }
            else
            {

                // Direkter Zugriff aus dem Timer- Thread auf die Elemente der Oberfläche 
                // ist verboten !!
                lblTime.Text = sekunde.ToString();
                MyProgressBar.Value = sekunde;
            }

        }

        void MoveZeiger(int sec)
        {
            lblTime.Text = sec.ToString();
            MyProgressBar.Value = sec;
            
        }

        double Zx(int sec)
        {
            return 125.0 * Math.Cos((Math.PI * 6.0 * (double)sec) / 180.0);
        }

        double Zy(int sec)
        {
            return 125.0 * Math.Sin((Math.PI * 6.0 * (double)sec) / 180.0);
        }


        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

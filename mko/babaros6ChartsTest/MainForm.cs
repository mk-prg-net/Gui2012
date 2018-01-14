using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace babaros6ChartsTest
{
    public partial class MainForm : Form
    {
        const int SamplesCount = 100;

        babaros6Charts.MultiChart<double, double> linearChart = new babaros6Charts.MultiChart<double,double>();
        babaros6Charts.MultiChart<double, double> logChart = new babaros6Charts.MultiChart<double,double>();

        mko.Log.LogServer logServer = new mko.Log.LogServer();
        

        public MainForm()
        {
            InitializeComponent();
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnTestLinearPlotReset_Click(object sender, EventArgs e)
        {
            try{
                linearChart.Clear();

                linearChart.Title = "Lineare Achsen";
                linearChart.TitleFont = new Font("Arial", 22f);

                double[] xAchse = { 0, 0.125, 0.25, 0.5, 1.0, 2.0, 4.0, 8.0, 16, 32 };
                string[] xLabels = { "0", "0.125", "0.25", "0.5", "1.0", "2.0", "4.0", "8.0", "16", "32" };
                linearChart.CreateXLabelAxis(xAchse, xLabels, babaros6Charts.MultiChart<double, double>.XAxisPosition.Top);

                
            }
            catch(Exception ex) {
                logServer.Log(mko.Log.RC.CreateError("Reset Test linear Plot" + ex.Message));
            }
        }

        private void btnTestLinearPlotGenerateSinus_Click(object sender, EventArgs e)
        {
            DrawSinusLinear();
        }

        private void DrawSinusLinear()
        {
            if (linearChart != null)
            {
                // Sinus- Testsignal erzeugen zwischen -2 Pi und 2 Pi
                List<double> XAxis = new List<double>(SamplesCount);
                List<double> YAxis = new List<double>(SamplesCount);

                double dx = 4 * Math.PI / SamplesCount;

                for (int i = 0; i < SamplesCount; i++)
                {
                    double x = i * dx;// -2 * Math.PI;
                    XAxis.Add(x);
                    YAxis.Add(Math.Sin(x));
                }

                linearChart.AddLinePlot(
                    XAxis,
                    babaros6Charts.MultiChart<double, double>.XAxisPosition.Bottom,
                    YAxis,
                    babaros6Charts.MultiChart<double, double>.YAxisPosition.Left,
                    System.Drawing.Color.Blue, "Sinus", true);

                linearChart.PanelSize = pbxTestLinearPlot.Size;
                linearChart.Autozoom = true;
                pbxTestLinearPlot.Image = linearChart.drawChart();
            }
        }

        private void btnTestLinearPlotGenerateLog_Click(object sender, EventArgs e)
        {
            DrawLogLinear();
        }

        private void DrawLogLinear()
        {
            if (linearChart != null)
            {
                GenerateLog(linearChart);

                linearChart.PanelSize = pbxTestLinearPlot.Size;
                linearChart.Autozoom = true;
                pbxTestLinearPlot.Image = linearChart.drawChart();
            }
        }

        private void GenerateLog(babaros6Charts.MultiChart<double, double> chart)
        {
            // logarithmus- Testsignal zwischen -2Pi und 2Pi zeichen
            List<double> XAxis = new List<double>(SamplesCount);
            List<double> YAxis = new List<double>(SamplesCount);

            double dx = 4 * Math.PI / SamplesCount;

            for (int i = 0; i < SamplesCount; i++)
            {
                double x = i * dx + dx;
                XAxis.Add(x);
                YAxis.Add(Math.Log(x));
            }

            chart.AddLinePlot(
                XAxis,
                babaros6Charts.MultiChart<double, double>.XAxisPosition.Bottom,
                YAxis,
                babaros6Charts.MultiChart<double, double>.YAxisPosition.Left,
                System.Drawing.Color.Red, "log", true);
        }

        private void btnTestLogarithmicPlotReset_Click(object sender, EventArgs e)
        {
            if (logChart != null)
            {
                logChart.Title = "Logarithmische Achsen";
                logChart.Clear();
                logChart.CreateXLog10Axis(babaros6Charts.MultiChart<double, double>.XAxisPosition.Bottom);

                double[] xAchse = {0, -3, -2, -1, 0, 1, 2, 3, 4, 5};
                string[] xLabels = {"0", "0.125", "0.25", "0.5", "1.0", "2.0", "4.0", "8.0", "16", "32"};
                logChart.CreateXLabelAxis(xAchse, xLabels, babaros6Charts.MultiChart<double, double>.XAxisPosition.Top);
            }
        }

        void DrawLogLog() {
            if (logChart != null)
            {
                GenerateLog(logChart);

                logChart.PanelSize = pbxLogarithmicPlot.Size;
                logChart.Autozoom = true;                
                pbxLogarithmicPlot.Image = logChart.drawChart();
            }
        }

        private void btnTestLogarithmicPlotLog_Click(object sender, EventArgs e)
        {
            DrawLogLog();
        }


        private void btnLabel_Click(object sender, EventArgs e)
        {
            double[] xAchse = {0, 0.125, 0.25, 0.5, 1.0, 2.0, 4.0, 8.0, 16, 32};
            double ln2 = Math.Log(2);
            double[] funktion = {
                                    0, 
                                    Math.Log(0.125)/ln2, 
                                    Math.Log(0.25)/ln2, 
                                    Math.Log(0.5)/ln2, 
                                    Math.Log(1.0)/ln2,
                                    Math.Log(2.0)/ln2,
                                    Math.Log(4.0)/ln2,
                                    Math.Log(8.0)/ln2,
                                    Math.Log(16)/ln2,
                                    Math.Log(32)/ln2};


            linearChart.AddLinePlot(
                xAchse,
                babaros6Charts.MultiChart<double, double>.XAxisPosition.Top,
                funktion,
                babaros6Charts.MultiChart<double, double>.YAxisPosition.Right,
                System.Drawing.Color.Green, "Label", true);

            linearChart.AddPointPlot(
                xAchse,
                babaros6Charts.MultiChart<double, double>.XAxisPosition.Top,
                funktion,
                babaros6Charts.MultiChart<double, double>.YAxisPosition.Right,
                babaros6Charts.MultiChart<double, double>.MarkerType.Diamond, 10, System.Drawing.Color.Black, true, false);

            linearChart.XAxis2Label = "X-Achse";
            linearChart.YAxis1Label = "Y-Achse";
            linearChart.PanelSize = pbxTestLinearPlot.Size;
            linearChart.Autozoom = true;
            pbxTestLinearPlot.Image = linearChart.drawChart();

        }

        private void btnLabelLog_Click(object sender, EventArgs e)
        {
            double[] xAchse = { 0, -3, -2, -1, 0, 1, 2, 3, 4, 5 };
            double ln2 = Math.Log(2);
            double[] funktion = {
                                    0, 
                                    Math.Log(0.125)/ln2, 
                                    Math.Log(0.25)/ln2, 
                                    Math.Log(0.5)/ln2, 
                                    Math.Log(1.0)/ln2,
                                    Math.Log(2.0)/ln2,
                                    Math.Log(4.0)/ln2,
                                    Math.Log(8.0)/ln2,
                                    Math.Log(16)/ln2,
                                    Math.Log(32)/ln2};


            logChart.AddLinePlot(
                xAchse,
                babaros6Charts.MultiChart<double, double>.XAxisPosition.Top,
                funktion,
                babaros6Charts.MultiChart<double, double>.YAxisPosition.Right,
                System.Drawing.Color.Green, "Label", true);

            logChart.PanelSize = pbxLogarithmicPlot.Size;
            logChart.Autozoom = true;
            pbxLogarithmicPlot.Image = logChart.drawChart();


        }



    }
}

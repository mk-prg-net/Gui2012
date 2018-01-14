using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;

namespace babaros6Charts
{
    public class LineChart
    {
        // Zeichenfläche des Graphen
        public Size PanelSize = new Size();
        public Color PanelBackgroundColor;

        // Beschriftung des Diagrammes
        public string Title;

        // Beschriftung der Achsen
        public string XLabel;
        public string YLabel;

        // Automatisches zoomen in Y- Richtung, an/aus
        public bool Autozoom;
        public double YMin;
        public double YMax;


        public LineChart()
        {
            PanelSize.Width = 500;
            PanelSize.Height = 400;

            PanelBackgroundColor = Color.White;
        }


        public Image drawChart(List<long> xTime, List<double> yVel)
        {
            Bitmap bm = new Bitmap(PanelSize.Width, PanelSize.Height);
            using (Graphics g = Graphics.FromImage(bm)) {
                NPlot.Bitmap.PlotSurface2D plotSurface = new NPlot.Bitmap.PlotSurface2D(bm);
                plotSurface.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                NPlot.LinePlot linePlot = new NPlot.LinePlot(yVel, xTime);
                linePlot.Color = Color.Red;                

                plotSurface.Add(linePlot);

                plotSurface.YAxis1.AutoScaleTicks = Autozoom;
                if (!Autozoom)
                {
                    plotSurface.YAxis1.WorldMax = YMax;
                    plotSurface.YAxis1.WorldMin = YMin;
                }

                plotSurface.Title = Title;
                plotSurface.XAxis1.Label = XLabel;
                plotSurface.YAxis1.Label = YLabel;

                NPlot.Legend legende = new NPlot.Legend();
                
                NPlot.Grid grid = new NPlot.Grid();

                grid.HorizontalGridType = NPlot.Grid.GridType.Fine;
                grid.VerticalGridType = NPlot.Grid.GridType.Fine;
                plotSurface.Add(grid);
                

                Rectangle rectBounds = new Rectangle(0, 0, PanelSize.Width, PanelSize.Height);
                plotSurface.Draw(g, rectBounds);
            }

            return bm;


        }
    }
}

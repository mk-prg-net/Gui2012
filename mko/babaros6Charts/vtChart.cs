using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;

namespace babaros6Charts
{
    public class vtChart
    {
        // Zeichenfläche des Graphen
        public Size PanelSize = new Size();
        public Color PanelBackgroundColor;

        public vtChart()
        {
            PanelSize.Width = 500;
            PanelSize.Height = 400;

            PanelBackgroundColor = Color.White;
        }


        public Image drawChart(List<int> xTime, List<double> yVel)
        {
            Bitmap bm = new Bitmap(PanelSize.Width, PanelSize.Height);
            using (Graphics g = Graphics.FromImage(bm)) {
                NPlot.Bitmap.PlotSurface2D plotSurface = new NPlot.Bitmap.PlotSurface2D(bm);

                NPlot.LinePlot linePlot = new NPlot.LinePlot(yVel, xTime);
                linePlot.Color = Color.Green;

                plotSurface.Add(linePlot);

                NPlot.Legend legende = new NPlot.Legend();

                NPlot.Grid grid = new NPlot.Grid();

                grid.HorizontalGridType = NPlot.Grid.GridType.Coarse;
                grid.VerticalGridType = NPlot.Grid.GridType.Fine;
                plotSurface.Add(grid);
                

                Rectangle rectBounds = new Rectangle(0, 0, PanelSize.Width, PanelSize.Height);
                plotSurface.Draw(g, rectBounds);
            }

            return bm;


        }
    }
}

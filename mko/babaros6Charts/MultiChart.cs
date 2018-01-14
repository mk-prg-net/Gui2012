using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;


namespace babaros6Charts
{
    public class MultiChart<TX, TY>
    {
        // Zeichenfläche des Graphen
        public Size PanelSize = new Size();
        public Color PanelBackgroundColor;

        // Beschriftung des Diagrammes
        public string Title = "";
        public System.Drawing.Font TitleFont = new Font(FontFamily.GenericSansSerif, 12.0f);

        public MultiChart()
        {
            PanelSize.Width = 500;
            PanelSize.Height = 400;

            PanelBackgroundColor = Color.White;
        }

        // Liste der zu plottenden Graphen
        struct MyPlot
        {
            public NPlot.IDrawable plot;
            public NPlot.PlotSurface2D.XAxisPosition XAxisPosition;
            public NPlot.PlotSurface2D.YAxisPosition YAxisPosition;
        }

        List<MyPlot> plots = new List<MyPlot>();

        public bool IsEmpty
        {
            get
            {
                return plots.Count > 0 ? false : true;
            }
        }

        // Typen von Marken in Punkt- Diagrammen
        public enum MarkerType
        {
            Plus,
            Cross,
            Circle,
            FilledCircle,
            Square,
            FilledSquare,
            Triangle,
            FilledTriangle,
            TriangleDown,
            Diamond,
            Flag,
            FlagDown,
            None            
        }

        NPlot.Marker.MarkerType ToNPlotMarkerType(MarkerType mt)
        {
            switch (mt)
            {
                case MarkerType.Circle:
                    return NPlot.Marker.MarkerType.Circle;
                case MarkerType.Cross:
                    return NPlot.Marker.MarkerType.Cross1;
                case MarkerType.Plus:
                    return NPlot.Marker.MarkerType.Cross2;
                case MarkerType.Diamond:
                    return NPlot.Marker.MarkerType.Diamond;
                case MarkerType.FilledCircle:
                    return NPlot.Marker.MarkerType.FilledCircle;
                case MarkerType.FilledSquare:
                    return NPlot.Marker.MarkerType.FilledSquare;
                case MarkerType.FilledTriangle:
                    return NPlot.Marker.MarkerType.FilledTriangle;
                case MarkerType.Flag:
                    return NPlot.Marker.MarkerType.Flag;
                case MarkerType.FlagDown:
                    return NPlot.Marker.MarkerType.FlagDown;
                case MarkerType.None:
                    return NPlot.Marker.MarkerType.None;
                case MarkerType.Square:
                    return NPlot.Marker.MarkerType.Square;
                case MarkerType.Triangle:
                    return NPlot.Marker.MarkerType.Triangle;
                case MarkerType.TriangleDown:
                    return NPlot.Marker.MarkerType.TriangleDown;
                default: return NPlot.Marker.MarkerType.None;
                
            }
        }

        // Löscht alle Einträg in der Liste der zu plottenden Graphen
        public void Clear()
        {
            plots.Clear();
        }

        // X- und Y Achsen definieren
        // NPlot kann bis zu 4 Achsen dartstellen:
        // X unten, Y links, X oben, Y rechts

        public Font LabelFont = new Font(FontFamily.GenericSansSerif, 12);
        public Font TickTextFont = new Font(FontFamily.GenericSansSerif, 12);

        public enum XAxisPosition
        {
            Bottom,
            Top
        }

        public enum YAxisPosition
        {
            Left,
            Right
        }

        // Achsentyp
        public enum AxisType
        {
            undef,
            linear,
            log10,
            label
        }

        // Beschriftung der Achsen
        public string XAxis1Label = "";
        public string YAxis1Label = "";
        public string XAxis2Label = "";
        public string YAxis2Label = "";
        
        // Implementierung der Achsdefinitionen
        AxisType _XAxisBottomType = AxisType.undef;
        IEnumerable<double> _XAxisBottomSeries;
        IEnumerable<string> _XAxisBottomLabels;

        AxisType _XAxisTopType = AxisType.undef;
        IEnumerable<double> _XAxisTopSeries;
        IEnumerable<string> _XAxisTopLabels;

        AxisType _YAxisLeftType = AxisType.undef;
        IEnumerable<double> _YAxisLeftSeries;
        IEnumerable<string> _YAxisLeftLabels;

        AxisType _YAxisRightType = AxisType.undef;
        IEnumerable<double> _YAxisRightSeries;
        IEnumerable<string> _YAxisRightLabels;

        // Automatisches zoomen in Y- Richtung, an/aus
        public bool Autozoom = false;
        public double YMin = 0;
        public double YMax = 0;

        // X- Achsen

        public void CreateXLinearAxis(XAxisPosition xpos)
        {
            if (xpos == XAxisPosition.Bottom)
                _XAxisBottomType = AxisType.linear;
            else
                _XAxisTopType = AxisType.linear;
        }

        public void CreateXLog10Axis(XAxisPosition xpos)
        {
            if (xpos == XAxisPosition.Bottom)
                _XAxisBottomType = AxisType.log10;
            else
                _XAxisTopType = AxisType.log10;
        }

        public void CreateXLabelAxis(
            IEnumerable<double> xSeries,
            IEnumerable<string> xSeriesLabels,
            XAxisPosition xpos
            )
        {
            if (xpos == XAxisPosition.Bottom)
            {
                _XAxisBottomType = AxisType.label;
                _XAxisBottomSeries = xSeries;
                _XAxisBottomLabels = xSeriesLabels;
            }
            else
            {
                _XAxisTopType = AxisType.label;
                _XAxisTopSeries = xSeries;
                _XAxisTopLabels = xSeriesLabels;
            }
        }

        // Y- Achsen

        public void CreateYLinearAxis(YAxisPosition ypos)
        {
            if (ypos == YAxisPosition.Left)
                _YAxisLeftType = AxisType.linear;
            else
                _YAxisRightType = AxisType.linear;
        }

        public void CreateYLog10Axis(YAxisPosition ypos)
        {
            if (ypos == YAxisPosition.Left)
                _YAxisLeftType = AxisType.log10;
            else
                _YAxisRightType = AxisType.log10;
        }

        public void CreateYLabelAxis(
            IEnumerable<double> ySeries,
            IEnumerable<string> ySeriesLabels,
            YAxisPosition ypos
            )
        {
            if (ypos == YAxisPosition.Left)
            {
                _YAxisLeftType = AxisType.label;
                _YAxisLeftSeries = ySeries;
                _YAxisLeftLabels = ySeriesLabels;
            }
            else
            {
                _YAxisRightType = AxisType.label;
                _YAxisRightSeries = ySeries;
                _YAxisRightLabels = ySeriesLabels;
            }
        }

        // Zu plotende Funktionen definieren

        public void AddLinePlot(
            IEnumerable<TX> xSeries,
            XAxisPosition xpos,
            IEnumerable<TY> ySeries,
            YAxisPosition ypos,
            Color _color,
            string Label,
            bool ShowLabelInLegend)
        {
            NPlot.LinePlot plot = new NPlot.LinePlot(ySeries, xSeries);

            plot.ShowInLegend = ShowLabelInLegend;
            plot.Label = Label;
            plot.Color = _color;

            MyPlot my = new MyPlot();
            my.plot = plot;
            my.XAxisPosition = xpos == XAxisPosition.Bottom ? NPlot.PlotSurface2D.XAxisPosition.Bottom : NPlot.PlotSurface2D.XAxisPosition.Top;
            my.YAxisPosition = ypos == YAxisPosition.Left ? NPlot.PlotSurface2D.YAxisPosition.Left : NPlot.PlotSurface2D.YAxisPosition.Right;

            plots.Add(my);
        }

        public void AddPointPlot(
            IEnumerable<TX> xSeries,
            XAxisPosition xpos,
            IEnumerable<TY> ySeries,
            YAxisPosition ypos,            
            MarkerType _markerType,
            int MarkerSize,
            Color MarkerColor,
            bool MarkerFilled,
            bool ShowLabelInLegend)
        {
            NPlot.PointPlot plot = new NPlot.PointPlot();
            plot.AbscissaData = xSeries;
            plot.OrdinateData = ySeries;

            plot.Marker = new NPlot.Marker(ToNPlotMarkerType(_markerType), MarkerSize, MarkerColor);

            plot.ShowInLegend = ShowLabelInLegend;         
            

            MyPlot my = new MyPlot();
            my.plot = plot;
            my.XAxisPosition = xpos == XAxisPosition.Bottom ? NPlot.PlotSurface2D.XAxisPosition.Bottom : NPlot.PlotSurface2D.XAxisPosition.Top;
            my.YAxisPosition = ypos == YAxisPosition.Left ? NPlot.PlotSurface2D.YAxisPosition.Left : NPlot.PlotSurface2D.YAxisPosition.Right;

            plots.Add(my);
        }





        // Erzeugt in einem Bitmap den zu plotenden Graphen

        public Image drawChart()
        {
            Bitmap bm = new Bitmap(PanelSize.Width, PanelSize.Height);
            using (Graphics g = Graphics.FromImage(bm))
            {

                //Rectangle allRect = new Rectangle(0, 0, PanelSize.Width, PanelSize.Height);
                //g.FillRectangle(Brushes.White, allRect);

                NPlot.Bitmap.PlotSurface2D plotSurface = new NPlot.Bitmap.PlotSurface2D(bm);
                plotSurface.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                // Achsen definieren

                if(_XAxisBottomType == AxisType.linear)
                    plotSurface.XAxis1 = new NPlot.LinearAxis();
                if (_XAxisBottomType == AxisType.log10)
                    plotSurface.XAxis1 = new NPlot.LogAxis();
                else if (_XAxisBottomType == AxisType.label)
                {                    
                    NPlot.LabelAxis lA = new NPlot.LabelAxis();
                    IEnumerator<string> elabels = _XAxisBottomLabels.GetEnumerator();
                    elabels.Reset();
                    IEnumerator<double> evalues = _XAxisBottomSeries.GetEnumerator();
                    evalues.Reset();
                    double minValue = double.MaxValue;
                    double maxValue = double.MinValue;
                    while (elabels.MoveNext() && evalues.MoveNext()) {
                        lA.AddLabel(elabels.Current, evalues.Current);
                        minValue = Math.Min(minValue, evalues.Current);
                        maxValue = Math.Max(maxValue, evalues.Current);
                    }
                    double puffer = (maxValue - minValue)*0.05;
                    lA.WorldMin = minValue - puffer;
                    lA.WorldMax = maxValue + puffer;
                    plotSurface.XAxis1 = lA;
                }

                if (_XAxisBottomType != AxisType.undef)
                {
                    plotSurface.XAxis1.Label = XAxis1Label;
                    plotSurface.XAxis1.TickTextFont = TickTextFont;
                    plotSurface.XAxis1.LabelFont = LabelFont;
                }

                if (_XAxisTopType == AxisType.linear)
                    plotSurface.XAxis2 = new NPlot.LinearAxis();
                else if (_XAxisTopType == AxisType.log10)
                    plotSurface.XAxis2 = new NPlot.LogAxis();
                else if (_XAxisTopType == AxisType.label)
                {
                    NPlot.LabelAxis lA = new NPlot.LabelAxis();
                    IEnumerator<string> elabels = _XAxisTopLabels.GetEnumerator();
                    elabels.Reset();
                    IEnumerator<double> evalues = _XAxisTopSeries.GetEnumerator();
                    evalues.Reset();
                    while (elabels.MoveNext() && evalues.MoveNext())
                        lA.AddLabel(elabels.Current, evalues.Current);
                    plotSurface.XAxis2 = lA;
                }

                if (_XAxisTopType != AxisType.undef)
                {
                    plotSurface.XAxis2.Label = XAxis2Label;
                    plotSurface.XAxis2.TickTextFont = TickTextFont;
                    plotSurface.XAxis2.LabelFont = LabelFont;
                }

                if(_YAxisLeftType == AxisType.linear)
                    plotSurface.YAxis1 = new NPlot.LinearAxis();
                else if (_YAxisLeftType == AxisType.log10)
                    plotSurface.YAxis1 = new NPlot.LogAxis();
                else if (_YAxisLeftType == AxisType.label)
                {
                    NPlot.LabelAxis lA = new NPlot.LabelAxis();
                    IEnumerator<string> elabels = _YAxisLeftLabels.GetEnumerator();
                    elabels.Reset();
                    IEnumerator<double> evalues = _YAxisLeftSeries.GetEnumerator();
                    evalues.Reset();
                    while (elabels.MoveNext() && evalues.MoveNext())
                        lA.AddLabel(elabels.Current, evalues.Current);
                    plotSurface.YAxis1 = lA;
                }

                if (plotSurface.YAxis1 != null)
                {
                    plotSurface.YAxis1.AutoScaleTicks = Autozoom;
                    plotSurface.YAxis1.Label = YAxis1Label;
                    plotSurface.YAxis1.LabelFont = LabelFont;
                    plotSurface.YAxis1.TickTextFont = TickTextFont;
                    if (!Autozoom)
                    {
                        plotSurface.YAxis1.WorldMax = YMax;
                        plotSurface.YAxis1.WorldMin = YMin;
                    }
                }

                if (_YAxisRightType == AxisType.linear)
                    plotSurface.YAxis2 = new NPlot.LinearAxis();
                else if (_YAxisRightType == AxisType.log10)
                    plotSurface.YAxis2 = new NPlot.LogAxis();
                else if (_YAxisRightType == AxisType.label)
                {
                    NPlot.LabelAxis lA = new NPlot.LabelAxis();
                    IEnumerator<string> elabels = _YAxisRightLabels.GetEnumerator();
                    elabels.Reset();
                    IEnumerator<double> evalues = _YAxisRightSeries.GetEnumerator();
                    evalues.Reset();
                    while (elabels.MoveNext() && evalues.MoveNext())
                        lA.AddLabel(elabels.Current, evalues.Current);
                    plotSurface.YAxis2 = lA;
                }

                if (plotSurface.YAxis2 != null)
                {
                    plotSurface.YAxis2.AutoScaleTicks = Autozoom;
                    plotSurface.YAxis2.Label = YAxis2Label;
                    plotSurface.YAxis2.LabelFont = LabelFont;
                    plotSurface.YAxis2.TickTextFont = TickTextFont;
                    if (!Autozoom)
                    {
                        plotSurface.YAxis2.WorldMax = YMax;
                        plotSurface.YAxis2.WorldMin = YMin;
                    }
                }

                // Graphen hinzufügen                              

                foreach (MyPlot my in plots)
                {
                    plotSurface.Add(my.plot, my.XAxisPosition, my.YAxisPosition);
                }                

                // Titel und Achsbeschrigtungen hinzufügen                
                plotSurface.Title = Title;
                plotSurface.TitleFont = TitleFont;

                // Legende hinzufügen
                NPlot.Legend legende = new NPlot.Legend();
                plotSurface.Legend = legende;

                // Gitternetzlinien hinzufügen
                NPlot.Grid grid = new NPlot.Grid();

                grid.HorizontalGridType = NPlot.Grid.GridType.Fine;
                grid.VerticalGridType = NPlot.Grid.GridType.Coarse;
                plotSurface.Add(grid);


                Rectangle rectBounds = new Rectangle(0, 0, PanelSize.Width, PanelSize.Height);
                 plotSurface.Draw(g, rectBounds);
            }

            return bm;


        }
    }
}

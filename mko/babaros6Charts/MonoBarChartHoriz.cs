using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;

namespace babaros6Charts
{
    public class MonoBarChartHoriz
    {
        //-----------------------------------------------------------------------------
        // Eigenschaften des Graphen

        // Zeichenfläche des Graphen
        public Size PanelSize = new Size();
        public Size PanelSizeCaption = new Size();
        public Color PanelBackgroundColor;
        public Color PanelCaptionBackgroundColor;

        // Definition des Zoomfensters für den Balken
        public double XAxisVisibleRangeMin; 
        public double XAxisVisibleRangeMax; 

        // Definition von Sollwerten und Sollwertgrenzen
        public double ValueOffset;
        public string OffsetTag;
        public double ValueLowerBound;
        public string LowerBoundTag;
        public double ValueUpperBound;
        public string UpperBoundTag;

        // Definition einer 2. Sollwertgrenze
        public bool SecondBound;
        public double ValueLowerBound2;
        public string LowerBoundTag2;
        public double ValueUpperBound2;
        public string UpperBoundTag2;

        // Erscheinungsbild des Graphen
        public Color BarColor;
        public Color BarLimitExeedColor;
        public Color BarLimitExeedColor2;

        public int BarPadding;
        public int BarHeight;        

        // X- Achse
        public Color XAxisColor;        
        public int XAxisTickMarkWidth;
        public double XAxisIncrement;

        // Beschriftungen
        public Color FontColor;
        public int ValuePadding;

        // Impelmentierungsdetails
        private Size BarPanel = new Size();

        public MonoBarChartHoriz()
        {
            PanelSize.Width = 500;
            PanelSize.Height = 20;

            PanelSizeCaption.Width = 500;
            PanelSizeCaption.Height = 35;


            PanelBackgroundColor = Color.DarkBlue;
            PanelCaptionBackgroundColor = Color.DarkBlue;

            XAxisVisibleRangeMin = 0;
            XAxisVisibleRangeMax = 1000;

            OffsetTag = "S";

            ValueLowerBound = XAxisVisibleRangeMin;
            LowerBoundTag = "min";
            ValueUpperBound = XAxisVisibleRangeMax;
            UpperBoundTag = "max";

            ValueLowerBound2 = XAxisVisibleRangeMin;
            LowerBoundTag2 = "uL";
            ValueUpperBound2 = XAxisVisibleRangeMax;
            UpperBoundTag2 = "oL";

            ValueOffset = 500;

            BarColor = Color.Green;
            BarLimitExeedColor = Color.Orange;
            BarLimitExeedColor2 = Color.Red;
            BarHeight = 100;
            BarPadding = 25;

            XAxisColor = Color.White;
            XAxisTickMarkWidth = 10;
            XAxisIncrement = 100;

            FontColor = Color.Yellow;
            ValuePadding = 25;
        }

        private int ConvertPtXToPixel(Graphics g, float sizeInPt)
        {
            return (int)((g.DpiX * sizeInPt) / 72);
        }

        private int ConvertPtYToPixel(Graphics g, float sizeInPt)
        {
            return (int)((g.DpiY * sizeInPt) / 72);
        }

        // Legende erzeugen
        public Image drawCaption()
        {
            Bitmap bm = new Bitmap(PanelSize.Width, PanelSizeCaption.Height);
            using (Graphics g = Graphics.FromImage(bm))
            {
                // Hintergrund Zeichnen
                Rectangle Background = new Rectangle(new Point(0, 0), PanelSizeCaption);
                Brush BgBrush = new SolidBrush(PanelCaptionBackgroundColor);
                Pen BgPen = new Pen(BgBrush);

                g.FillRectangle(BgBrush, Background);

                // Breite des Zoomfensters für den Balken darstellen            
                //double XAxisVisibleRange = Math.Abs(XAxisVisibleRangeMax - XAxisVisibleRangeMin);
                double XAxisVisibleRange = Math.Abs(XAxisVisibleRangeMax - XAxisVisibleRangeMin);

                if (XAxisVisibleRange != 0)
                {
                    // Umrechnen in die Koordinaten der Zeichenfläche
                    int offset = (int)(((ValueOffset - XAxisVisibleRangeMin) * PanelSizeCaption.Width) / XAxisVisibleRange);
                    int LB = (int)(((ValueLowerBound - XAxisVisibleRangeMin) * PanelSizeCaption.Width) / XAxisVisibleRange);
                    int UB = (int)(((ValueUpperBound - XAxisVisibleRangeMin) * PanelSizeCaption.Width) / XAxisVisibleRange);


                    // Font für Beschriftungen wählen
                    Brush XAxisFontBrush = new SolidBrush(Color.Yellow);
                    Font XAxisFont = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);                    
                    StringFormat sf = new StringFormat();
                    sf.Alignment = StringAlignment.Center;

                    // Zeichnen der Offset Linie
                    Brush XAxisBrush = new SolidBrush(XAxisColor);
                    Pen XAxisPen = new Pen(XAxisBrush);

                    Size OffsetLineSize = new Size();
                    OffsetLineSize.Width = XAxisTickMarkWidth;
                    OffsetLineSize.Height = ValuePadding;

                    Point OffsetLineOrigin = new Point();
                    OffsetLineOrigin.X = offset - (int)Math.Max(XAxisTickMarkWidth / 2, 1);
                    OffsetLineOrigin.Y = PanelSizeCaption.Height - ValuePadding;

                    Rectangle OffsetLine = new Rectangle(OffsetLineOrigin, OffsetLineSize);
                    g.FillRectangle(XAxisBrush, OffsetLine);

                    // Offset- Linie beschriften
                    PointF OffsetDescriptionOrigin = new PointF();
                    OffsetDescriptionOrigin.Y = OffsetLineOrigin.Y - ValuePadding - ConvertPtYToPixel(g, XAxisFont.SizeInPoints);
                    OffsetDescriptionOrigin.X = OffsetLineOrigin.X - ConvertPtXToPixel(g, XAxisFont.SizeInPoints) / 2;

                    g.DrawString(OffsetTag, XAxisFont, XAxisFontBrush, OffsetDescriptionOrigin);

                    // Zeichnen der Lower Bound- Linie
                    Point LowerBoundOrigin = new Point();
                    LowerBoundOrigin.X = LB - (int)Math.Max(XAxisTickMarkWidth / 2, 1);
                    LowerBoundOrigin.Y = OffsetLineOrigin.Y;

                    Rectangle LowerBoundLine = new Rectangle(LowerBoundOrigin, OffsetLineSize);
                    g.FillRectangle(XAxisBrush, LowerBoundLine);

                    // LowerBound- Linie beschriften
                    PointF LowerBoundDescriptionOrigin = new PointF();
                    LowerBoundDescriptionOrigin.Y = LowerBoundOrigin.Y - ValuePadding - ConvertPtYToPixel(g, XAxisFont.SizeInPoints);
                    LowerBoundDescriptionOrigin.X = LowerBoundOrigin.X - ConvertPtXToPixel(g, XAxisFont.SizeInPoints) / 2;

                    g.DrawString(LowerBoundTag, XAxisFont, XAxisFontBrush, LowerBoundDescriptionOrigin);


                    // Zeichnen der Upper Bound- Linie
                    Point UpperBoundOrigin = new Point();
                    UpperBoundOrigin.X = UB - (int)Math.Max(XAxisTickMarkWidth / 2, 1);
                    UpperBoundOrigin.Y = OffsetLineOrigin.Y;

                    Rectangle UpperBoundLine = new Rectangle(UpperBoundOrigin, OffsetLineSize);
                    g.FillRectangle(XAxisBrush, UpperBoundLine);

                    // UpperBound- Linie beschriften
                    PointF UpperBoundDescriptionOrigin = new PointF();
                    UpperBoundDescriptionOrigin.Y = UpperBoundOrigin.Y - ValuePadding - ConvertPtYToPixel(g, XAxisFont.SizeInPoints);
                    UpperBoundDescriptionOrigin.X = UpperBoundOrigin.X - ConvertPtXToPixel(g, XAxisFont.SizeInPoints) / 2;

                    g.DrawString(UpperBoundTag, XAxisFont, XAxisFontBrush, UpperBoundDescriptionOrigin);

                    if (SecondBound)
                    {
                        int LB2 = (int)(((ValueLowerBound2 - XAxisVisibleRangeMin) * PanelSizeCaption.Width) / XAxisVisibleRange);
                        int UB2 = (int)(((ValueUpperBound2 - XAxisVisibleRangeMin) * PanelSizeCaption.Width) / XAxisVisibleRange);

                        // Zeichnen der Lower Bound- Linie
                        LowerBoundOrigin = new Point();
                        LowerBoundOrigin.X = LB2 - (int)Math.Max(XAxisTickMarkWidth / 2, 1);
                        LowerBoundOrigin.Y = OffsetLineOrigin.Y;

                        LowerBoundLine = new Rectangle(LowerBoundOrigin, OffsetLineSize);
                        g.FillRectangle(XAxisBrush, LowerBoundLine);

                        // LowerBound- Linie beschriften
                        LowerBoundDescriptionOrigin = new PointF();
                        LowerBoundDescriptionOrigin.Y = LowerBoundOrigin.Y - ValuePadding - ConvertPtYToPixel(g, XAxisFont.SizeInPoints);
                        LowerBoundDescriptionOrigin.X = LowerBoundOrigin.X - ConvertPtXToPixel(g, XAxisFont.SizeInPoints) / 2;

                        g.DrawString(LowerBoundTag2, XAxisFont, XAxisFontBrush, LowerBoundDescriptionOrigin);


                        // Zeichnen der Upper Bound- Linie
                        UpperBoundOrigin = new Point();
                        UpperBoundOrigin.X = UB2 - (int)Math.Max(XAxisTickMarkWidth / 2, 1);
                        UpperBoundOrigin.Y = OffsetLineOrigin.Y;

                        UpperBoundLine = new Rectangle(UpperBoundOrigin, OffsetLineSize);
                        g.FillRectangle(XAxisBrush, UpperBoundLine);

                        // UpperBound- Linie beschriften
                        UpperBoundDescriptionOrigin = new PointF();
                        UpperBoundDescriptionOrigin.Y = UpperBoundOrigin.Y - ValuePadding - ConvertPtYToPixel(g, XAxisFont.SizeInPoints);
                        UpperBoundDescriptionOrigin.X = UpperBoundOrigin.X - ConvertPtXToPixel(g, XAxisFont.SizeInPoints) / 2;

                        g.DrawString(UpperBoundTag2, XAxisFont, XAxisFontBrush, UpperBoundDescriptionOrigin);
                    }
                }
            }

            return bm;
        }

        // Messwert als Abweichung durch Balken visualisieren
        public Image drawChart(double curValue)
        {
            Bitmap bm = new Bitmap(PanelSize.Width, PanelSize.Height);
            using (Graphics g = Graphics.FromImage(bm))
            {
                // Hintergrund Zeichnen
                Rectangle Background = new Rectangle(new Point(0, 0), PanelSize);
                Brush BgBrush = new SolidBrush(PanelBackgroundColor);
                Pen BgPen = new Pen(BgBrush);

                g.FillRectangle(BgBrush, Background);

                // Breite des Zoomfensters für den Balken darstellen            
                //double XAxisVisibleRange = Math.Abs(XAxisVisibleRangeMax - XAxisVisibleRangeMin);
                double XAxisVisibleRange = Math.Abs(XAxisVisibleRangeMax - XAxisVisibleRangeMin);

                if (XAxisVisibleRange != 0)
                {
                    // Umrechnen in die Koordinaten der Zeichenfläche
                    int offset = (int)(((ValueOffset - XAxisVisibleRangeMin) * PanelSize.Width)/ XAxisVisibleRange);
                    int LB = (int)(((ValueLowerBound - XAxisVisibleRangeMin) * PanelSize.Width) / XAxisVisibleRange);
                    int UB = (int)(((ValueUpperBound - XAxisVisibleRangeMin) * PanelSize.Width) / XAxisVisibleRange);


                    // Font für Beschriftungen wählen
                    Brush XAxisFontBrush = new SolidBrush(Color.Yellow);                    
                    Font XAxisFont = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);                    
                    StringFormat sf = new StringFormat();
                    sf.Alignment = StringAlignment.Center;                    

                    // Zeichnen der Offset Linie
                    Brush XAxisBrush = new SolidBrush(XAxisColor);
                    Pen XAxisPen = new Pen(XAxisBrush);

                    Size OffsetLineSize = new Size();
                    OffsetLineSize.Width = XAxisTickMarkWidth;
                    OffsetLineSize.Height = PanelSize.Height;

                    Point OffsetLineOrigin = new Point();
                    OffsetLineOrigin.X = offset - (int)Math.Max(XAxisTickMarkWidth / 2, 1);
                    OffsetLineOrigin.Y = 0;

                    Rectangle OffsetLine = new Rectangle(OffsetLineOrigin, OffsetLineSize);
                    g.FillRectangle(XAxisBrush, OffsetLine);

                    // Offset- Linie beschriften
                    PointF OffsetDescriptionOrigin = new PointF();
                    OffsetDescriptionOrigin.Y = OffsetLineOrigin.Y - ValuePadding - ConvertPtYToPixel(g, XAxisFont.SizeInPoints);
                    OffsetDescriptionOrigin.X = OffsetLineOrigin.X - ConvertPtXToPixel(g, XAxisFont.SizeInPoints) / 2;

                    //g.DrawString(OffsetTag, XAxisFont,  XAxisFontBrush, OffsetDescriptionOrigin);

                    // Zeichnen der Lower Bound- Linie
                    Point LowerBoundOrigin = new Point();
                    LowerBoundOrigin.X = LB - (int)Math.Max(XAxisTickMarkWidth / 2, 1);
                    LowerBoundOrigin.Y = OffsetLineOrigin.Y;

                    Rectangle LowerBoundLine = new Rectangle(LowerBoundOrigin, OffsetLineSize);
                    g.FillRectangle(XAxisBrush, LowerBoundLine);

                    // LowerBound- Linie beschriften
                    PointF LowerBoundDescriptionOrigin = new PointF();
                    LowerBoundDescriptionOrigin.Y = LowerBoundOrigin.Y - ValuePadding - ConvertPtYToPixel(g, XAxisFont.SizeInPoints);
                    LowerBoundDescriptionOrigin.X = LowerBoundOrigin.X - ConvertPtXToPixel(g, XAxisFont.SizeInPoints) / 2;

                    //g.DrawString(LowerBoundTag, XAxisFont, XAxisFontBrush, LowerBoundDescriptionOrigin);


                    // Zeichnen der Upper Bound- Linie
                    Point UpperBoundOrigin = new Point();
                    UpperBoundOrigin.X = UB - (int)Math.Max(XAxisTickMarkWidth / 2, 1);
                    UpperBoundOrigin.Y = OffsetLineOrigin.Y;

                    Rectangle UpperBoundLine = new Rectangle(UpperBoundOrigin, OffsetLineSize);
                    g.FillRectangle(XAxisBrush, UpperBoundLine);

                    // UpperBound- Linie beschriften
                    PointF UpperBoundDescriptionOrigin = new PointF();
                    UpperBoundDescriptionOrigin.Y = UpperBoundOrigin.Y - ValuePadding - ConvertPtYToPixel(g, XAxisFont.SizeInPoints);
                    UpperBoundDescriptionOrigin.X = UpperBoundOrigin.X - ConvertPtXToPixel(g, XAxisFont.SizeInPoints) / 2;

                    //g.DrawString(UpperBoundTag, XAxisFont, XAxisFontBrush, UpperBoundDescriptionOrigin);

                    if (SecondBound)
                    {
                        int LB2 = (int)(((ValueLowerBound2 - XAxisVisibleRangeMin) * PanelSize.Width) / XAxisVisibleRange);
                        int UB2 = (int)(((ValueUpperBound2 - XAxisVisibleRangeMin) * PanelSize.Width) / XAxisVisibleRange);

                        // Zeichnen der Lower Bound- Linie
                        LowerBoundOrigin = new Point();
                        LowerBoundOrigin.X = LB2 - (int)Math.Max(XAxisTickMarkWidth / 2, 1);
                        LowerBoundOrigin.Y = OffsetLineOrigin.Y;

                        LowerBoundLine = new Rectangle(LowerBoundOrigin, OffsetLineSize);
                        g.FillRectangle(XAxisBrush, LowerBoundLine);

                        // LowerBound- Linie beschriften
                        LowerBoundDescriptionOrigin = new PointF();
                        LowerBoundDescriptionOrigin.Y = LowerBoundOrigin.Y - ValuePadding - ConvertPtYToPixel(g, XAxisFont.SizeInPoints);
                        LowerBoundDescriptionOrigin.X = LowerBoundOrigin.X - ConvertPtXToPixel(g, XAxisFont.SizeInPoints) / 2;

                        //g.DrawString(LowerBoundTag2, XAxisFont, XAxisFontBrush, LowerBoundDescriptionOrigin);


                        // Zeichnen der Upper Bound- Linie
                        UpperBoundOrigin = new Point();
                        UpperBoundOrigin.X = UB2 - (int)Math.Max(XAxisTickMarkWidth / 2, 1);
                        UpperBoundOrigin.Y = OffsetLineOrigin.Y;

                        UpperBoundLine = new Rectangle(UpperBoundOrigin, OffsetLineSize);
                        g.FillRectangle(XAxisBrush, UpperBoundLine);

                        // UpperBound- Linie beschriften
                        UpperBoundDescriptionOrigin = new PointF();
                        UpperBoundDescriptionOrigin.Y = UpperBoundOrigin.Y - ValuePadding - ConvertPtYToPixel(g, XAxisFont.SizeInPoints);
                        UpperBoundDescriptionOrigin.X = UpperBoundOrigin.X - ConvertPtXToPixel(g, XAxisFont.SizeInPoints) / 2;

                        //g.DrawString(UpperBoundTag2, XAxisFont, XAxisFontBrush, UpperBoundDescriptionOrigin);
                    }

                    // Anfangsposition und Breite des Balken berechnen
                    Size BarSize = new Size((int)(((curValue - XAxisVisibleRangeMin) * PanelSize.Width) / XAxisVisibleRange), BarHeight);                   
                    Point BarOrigin = new Point();
                    BarOrigin.Y = PanelSize.Height - BarHeight - BarPadding;

                    if (offset < BarSize.Width)
                    {
                        BarSize.Width -= offset;
                        BarOrigin.X = offset;                        
                    }
                    else if (offset == BarSize.Width)
                    {
                        BarSize.Width = XAxisTickMarkWidth;
                        BarOrigin.X = OffsetLineOrigin.X;
                    }
                    else
                    {
                        BarOrigin.X = BarSize.Width;
                        BarSize.Width = offset - BarSize.Width;
                    }                    
                    
                    Rectangle Bar = new Rectangle(BarOrigin, BarSize);

                    // Farbe des Balkens definieren
                    Color aktBarColor = BarColor;
                    if (curValue < ValueLowerBound || curValue > ValueUpperBound)
                    {
                        if (SecondBound)
                        {
                            if (curValue < ValueLowerBound2 || curValue > ValueUpperBound2)
                                aktBarColor = BarLimitExeedColor2;
                            else
                                aktBarColor = BarLimitExeedColor;
                        } else
                            aktBarColor = BarLimitExeedColor;
                    }

                    // Balken zeichnen
                    Brush BarBrush = new SolidBrush(aktBarColor);
                    Pen BarPen = new Pen(BarBrush);

                    g.FillRectangle(BarBrush, Bar);
                    
                }
                else
                {
                    Size BarSize = new Size( XAxisTickMarkWidth, BarHeight);                    
                    
                    Point BarOrigin = new Point();
                    BarOrigin.X = (PanelSize.Width - XAxisTickMarkWidth) / 2;
                    BarOrigin.Y = PanelSize.Height - BarHeight - BarPadding ;

                    Rectangle Bar = new Rectangle(BarOrigin, BarSize);

                    // Balken zeichnen
                    Brush BarBrush = new SolidBrush(BarColor);
                    Pen BarPen = new Pen(BarBrush);

                    g.FillRectangle(BarBrush, Bar);
                }

            }

            return bm;
        }
    }
}

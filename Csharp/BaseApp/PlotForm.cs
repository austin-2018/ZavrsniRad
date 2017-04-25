using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BaseApp
{
    public partial class PlotForm : Form
    {
        private PointF[] pfTemp;
        private PointF[] pfHumid;
        private PointF[] pfLight;

        private LinkedList<byte[]> dataBytesList;
        
        private PointF plotOrigin;
        private Size plotSize;
        private Font plotFont;
        private float xScale;
        private float yScale;

        private string dataFilePathName;
        public string DataFile
        {
            get { return dataFilePathName; }
        }


        public PlotForm(string fileName)
        {
            InitializeComponent();
            plotFont = new Font(SystemFonts.CaptionFont, FontStyle.Bold);

            dataFilePathName = fileName;

            dataBytesList = Logger.Parse(DataFile);

            CalcDataPoints();
        }

        private void CalcDataPoints()
        {
            plotOrigin = new PointF(pbxPlot.Location.X + 50, pbxPlot.Location.Y + 50);
            plotSize = pbxPlot.Size - new Size(100, 100);

            yScale = (float)plotSize.Height / byte.MaxValue;
            if(dataBytesList.Count > 1)
            {
                xScale = (float)plotSize.Width / (dataBytesList.Count - 1);
            }
            else
            {
                xScale = plotSize.Width;
            }

            int count = dataBytesList.Count;
            int currentIndex = 0;

            pfTemp = new PointF[count];
            pfHumid = new PointF[count];
            pfLight = new PointF[count];

            for (LinkedListNode<byte[]> ba = dataBytesList.First; ba != null; ba = ba.Next)
            {
                float xCoord = currentIndex * xScale + 1 + plotOrigin.X;

                pfTemp[currentIndex] = new PointF(xCoord, (plotOrigin.Y + plotSize.Height) - (ba.Value[1] * yScale + 1));
                pfHumid[currentIndex] = new PointF(xCoord, (plotOrigin.Y + plotSize.Height) - (ba.Value[2] * yScale + 1));
                pfLight[currentIndex] = new PointF(xCoord, (plotOrigin.Y + plotSize.Height) - (ba.Value[3] * yScale + 1));

                ++currentIndex;
            }
        }

        private void DrawData(Graphics gr)
        {
            if (dataBytesList.Count == 1)
            {
                gr.DrawLine(Pens.Red, pfTemp[0], new PointF(pfTemp[0].X + xScale, pfTemp[0].Y));
                gr.DrawLine(Pens.Blue, pfHumid[0], new PointF(pfHumid[0].X + xScale, pfHumid[0].Y));
                gr.DrawLine(Pens.Green, pfLight[0], new PointF(pfLight[0].X + xScale, pfLight[0].Y));
            }
            else
            {
                gr.DrawLines(Pens.Red, pfTemp);
                gr.DrawLines(Pens.Blue, pfHumid);
                gr.DrawLines(Pens.Green, pfLight);
            }
        }

        private void DrawPlotAxes(Graphics g)
        {
            g.FillRectangle(Brushes.Black, pbxPlot.ClientRectangle);
            // Draw plot axes and labels and marks

            // Draw Y axis
            g.DrawLine(Pens.White, 
                new PointF(plotOrigin.X, plotOrigin.Y), 
                new PointF(plotOrigin.X, plotOrigin.Y + plotSize.Height));

            // Draw X axis
            g.DrawLine(Pens.White, 
                new PointF(plotOrigin.X, plotOrigin.Y + plotSize.Height), 
                new PointF(plotOrigin.X + plotSize.Width, plotOrigin.Y + plotSize.Height));

            // Draw 0 point
            g.DrawString("0", plotFont, Brushes.White, 
                new PointF(plotOrigin.X-plotFont.Size, plotOrigin.Y + plotSize.Height));

            int vertLinesNum = dataBytesList.Count;

            for (int i = 0; i < vertLinesNum; ++i)
            {
                g.DrawLine(Pens.DarkSlateGray, 
                    new PointF(i * xScale + 1 + plotOrigin.X, plotOrigin.Y + 1), 
                    new PointF(i * xScale + 1 + plotOrigin.X, plotSize.Height + plotOrigin.Y + 1));
            }
            for (int i = 0; i < byte.MaxValue; i += 10)
            {
                g.DrawLine(Pens.DarkSlateGray,
                    new PointF(1 + plotOrigin.X, i * yScale + plotOrigin.Y + 1), 
                    new PointF(plotSize.Width + 1 + plotOrigin.X, i * yScale + plotOrigin.Y + 1));
            }
        }

        private void PbxPlot_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            DrawPlotAxes(e.Graphics);
            DrawData(e.Graphics);
        }

        private void PlotForm_Resize(object sender, EventArgs e)
        {
            CalcDataPoints();
        }
    }
}

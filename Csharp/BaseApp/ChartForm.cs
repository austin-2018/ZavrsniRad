using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BaseApp
{
    public partial class ChartForm : Form
    {
        // Paths with filenames holding data bytes
        private string[] dataFiles;
        // Filenames linked with their data which is extracted to byte arrays in Linked List for each file.
        private Dictionary<string, LinkedList<byte[]>> FileDataMap;

        public ChartForm(string[] dataFilesParam)
        {
            InitializeComponent();
            dataFiles = dataFilesParam;
            ExtractData();
            ShowData();
        }

        /// <summary>
        /// Creates a dictionary of strings and Linked Lists of byte arrays for each file in DataFiles string array.
        /// </summary>
        private void ExtractData()
        {
            FileDataMap = new Dictionary<string, LinkedList<byte[]>>();
            foreach (string filename in dataFiles)
            {
                FileDataMap.Add(filename, Logger.Parse(filename));
            }
        }

        private void ShowData()
        {
            foreach (KeyValuePair<string, LinkedList<byte[]>> pair in FileDataMap)
            {
                string file = Path.GetFileName(pair.Key);
                LinkedList<byte[]> data = pair.Value;
                byte[] temperatures = new byte[data.Count];
                int[] xValues = new int[data.Count];
                // TODO: add humidity and light
                int index = 0;

                for (LinkedListNode<byte[]> node = data.First; node != null; node = node.Next)
                {
                    temperatures[index] = node.Value[1];
                    xValues[index] = index + 1;
                    index++;
                }

                Chart chart = new Chart()
                {
                    Dock = DockStyle.Fill
                };
                ChartArea chartArea = new ChartArea();
                chartArea.AxisX.MajorGrid.LineColor = Color.LightGreen;
                chartArea.AxisY.MajorGrid.LineColor = Color.LightGreen;
                chart.ChartAreas.Add(chartArea);

                Series tempSeries = new Series("Temperature")
                {
                    ChartType = SeriesChartType.Line,
                    XValueType = ChartValueType.Int32
                };
                chart.Series.Add(tempSeries);

                chart.Series["Temperature"].Points.DataBindXY(xValues, temperatures);
                chart.Invalidate();

                chart.SaveImage(Path.Combine(Path.GetDirectoryName(pair.Key), "ChartImage.png"), ChartImageFormat.Png);

                TabPage tabPage = new TabPage(Path.GetFileNameWithoutExtension(pair.Key));
                tabPage.Controls.Add(chart);

                TabContainer.Controls.Add(tabPage);
            }
        }

    }
}

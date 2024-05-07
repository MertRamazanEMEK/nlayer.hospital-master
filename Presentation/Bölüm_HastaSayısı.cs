using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace Presentation
{ 
    public partial class Bölüm_HastaSayısı : Form
    {
        private Business.HatalıkBölümleri_Zed_Graph zedgraphbr;
        public Bölüm_HastaSayısı()
        {
            zedgraphbr = new Business.HatalıkBölümleri_Zed_Graph();
            InitializeComponent();
        }

        private void Bölüm_HastaSayısı_Load(object sender, EventArgs e)
        {
            DisplayGraph();
        }
        public void DisplayGraph()
        {
            GraphPane myPane = zedGraphControl1.GraphPane;
            PointPairList list = zedgraphbr.LoadGraphData();
            BarItem myBar = myPane.AddBar("Hasta Sayısı", list, System.Drawing.Color.Black);
            myBar.Bar.Fill = new Fill(System.Drawing.Color.Blue);
            myBar.Label.IsVisible = true;
            myPane.XAxis.Type = AxisType.Text;
            myPane.XAxis.Scale.TextLabels = list.Select(p => p.Tag.ToString()).ToArray();

            myPane.XAxis.Title.Text = "Branşlar";
            myPane.YAxis.Title.Text = "Hasta Sayısı";

            zedGraphControl1.AxisChange();
        }
    }
}

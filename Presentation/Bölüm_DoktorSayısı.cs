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
    public partial class Bölüm_DoktorSayısı : Form
    {
        private Business.DoktorHastaSayısı_ZedGraph zedgraphj;
        public Bölüm_DoktorSayısı()
        {   
            zedgraphj = new Business.DoktorHastaSayısı_ZedGraph();
            InitializeComponent();
            
        }

        private void Bölüm_DoktorSayısı_Load(object sender, EventArgs e)
        {
            DisplayGraph();
        }
        public void DisplayGraph()
        {
            GraphPane myPane = zedGraphControl1.GraphPane;
            PointPairList list = zedgraphj.LoadGraphData();
            BarItem myBar = myPane.AddBar("Hasta Sayısı", list, System.Drawing.Color.Black);
            myBar.Bar.Fill = new Fill(System.Drawing.Color.Brown);
            myBar.Label.IsVisible = true;
            myPane.XAxis.Type = AxisType.Text;
            myPane.XAxis.Scale.TextLabels = list.Select(p => p.Tag.ToString()).ToArray();

            myPane.XAxis.Title.Text = "Doktorlar";
            myPane.YAxis.Title.Text = "Hasta Sayısı";

            zedGraphControl1.AxisChange();
        }
    }
}

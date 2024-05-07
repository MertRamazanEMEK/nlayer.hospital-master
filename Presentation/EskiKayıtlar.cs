using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    public partial class EskiKayıtlar : Form
    {
        private Business.DataGrid dataGrid = new Business.DataGrid();
        private string kimlikno;
        public EskiKayıtlar(string kimlik)
        {
            InitializeComponent();
            kimlikno = kimlik;
        }

        private void EskiKayıtlar_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dataGrid.filldatagridhastagecmis(kimlikno);
        }
    }
}

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
    public partial class SilmeGuncelleme : Form
    {
        private Business.DataGrid dataGrid = new Business.DataGrid();
        private Business.Sil sil = new Business.Sil();
        private Business.Guncelle guncel = new Business.Guncelle();
        int menuno = 0;
        string eskikimlik;
        public SilmeGuncelleme()
        {
            InitializeComponent();
        }

        private void SilmeGuncelleme_Load(object sender, EventArgs e)
        {
            button2.Visible= false;
            if (menuno == 0)
            {
                dataGridView1.DataSource = dataGrid.filldatagriddoktor();
            }
            else if (menuno == 1)
            {
                dataGridView1.DataSource = dataGrid.filldatagridhasta();
            }
            else if (menuno == 2)
            {
                dataGridView1.DataSource = dataGrid.filldatagridsekreter();
            }
        }

        private void doktorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dataGrid.filldatagriddoktor();
            menuno = 0;
        }

        private void hastaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dataGrid.filldatagridhasta();
            menuno = 1;

        }

        private void sekreterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dataGrid.filldatagridsekreter();
            menuno = 2;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (menuno == 0)
            {
                string kimlik = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                sil.DoktorSil(kimlik);
                MessageBox.Show("Başarıyla Silindi");
                SilmeGuncelleme_Load(sender, e);
            }
            else if (menuno ==1)
            {
                string kimlik = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                sil.HastaSil(kimlik);
                MessageBox.Show("Başarıyla Silindi");
                SilmeGuncelleme_Load(sender, e);

            }
            else if (menuno == 2)
            {
                string kimlik = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                sil.SekreterSil(kimlik);
                MessageBox.Show("Başarıyla Silindi");
                SilmeGuncelleme_Load(sender, e);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1_CellEndEdit(sender, (DataGridViewCellEventArgs)e);
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (menuno == 0)
            {
                string kimlikno = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string ad = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                string soyad = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                string cinsiyet = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                DateTime dogum_tarihi = DateTime.Parse(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
                string telefon = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                string brans = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                string sifre = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                guncel.DoktorGuncelle(eskikimlik,kimlikno,ad,soyad,cinsiyet,dogum_tarihi,telefon,brans,sifre);
                MessageBox.Show("Başarıyla Güncellendi");
            }
            else if (menuno == 1)
            {
                string kimlikno = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string ad = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                string soyad = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                string cinsiyet = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                DateTime dogum_tarihi = DateTime.Parse(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
                string mail = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                string telefon = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                guncel.HastaGuncelle(eskikimlik,kimlikno, ad, soyad, cinsiyet, dogum_tarihi, mail, telefon);
                MessageBox.Show("Başarıyla Güncellendi");


            }
            else if (menuno == 2)
            {
                string kimlikno = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string ad = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                string soyad = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                string cinsiyet = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                DateTime dogum_tarihi = DateTime.Parse(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());              
                string sifre = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                guncel.SekreterGuncelle(eskikimlik,kimlikno, ad, soyad, cinsiyet, dogum_tarihi, sifre);
                MessageBox.Show("Başarıyla Güncellendi");

            }
            button2.Visible = false;
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            eskikimlik = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            button2.Visible = true;
        }
    }
}

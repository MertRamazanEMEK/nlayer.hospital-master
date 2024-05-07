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
    public partial class Doktor : Form
    {
        Giris1 forkn = new Giris1();
        Business.Sırala sırala = new Business.Sırala();
        Business.Giris giris = new Business.Giris();
        Business.DataGrid datagrid = new Business.DataGrid();
        private Control[] eskiElemanlar; 


        public Doktor(string kimlikno)
        {            

            InitializeComponent();
            label6.Text = kimlikno;

        }

        private void Doktor_Load(object sender, EventArgs e)
        {
            label6.Visible = false;
            List<string> liste = new List<string>();
            sırala.DoktorBilgileriSırala(label6.Text, liste);
            label1.Text = liste[0];
            label2.Text = liste[1];
            label3.Text = liste[2];
            label4.Text = liste[3];
            
            eskiElemanlar = new Control[panel1.Controls.Count];
            panel1.Controls.CopyTo(eskiElemanlar, 0);

            button1.Visible = false;
            button2.Visible = true;
            label7.Text = DateTime.Today.ToLongDateString();
            dateTimePicker1.MinDate = DateTime.Today;
            dateTimePicker1.Value = DateTime.Today;
            dataGridView2.DataSource = datagrid.filldatagridhastarandevu(label6.Text,dateTimePicker1.Value);

        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string kimlik = dataGridView2.SelectedRows[0].Cells[0].Value.ToString() ;
            Gorusme1 form2 = new Gorusme1(label1.Text,label2.Text,label3.Text,kimlik);
            eskiElemanlar = new Control[panel1.Controls.Count];
            
            panel1.Controls.CopyTo(eskiElemanlar, 0);
            panel1.Controls.Clear();

            if (form2 != null)
            {
                button1.Visible = true;
                dateTimePicker1.Visible = false;
                form2 = new Gorusme1(label1.Text, label2.Text, label3.Text,kimlik);
                form2.TopLevel = false; 
                form2.FormBorderStyle = FormBorderStyle.None; 
                form2.Dock = DockStyle.Fill; 
                panel1.Controls.Add(form2); 
                form2.Show(); 
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();

            
            if (eskiElemanlar != null)
            {
                panel1.Controls.AddRange(eskiElemanlar);
            }
            button1.Visible = false;
            dateTimePicker1.Visible = true;

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dataGridView2.DataSource = datagrid.filldatagridhastarandevu(label6.Text, dateTimePicker1.Value);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Visible == true)
            {
                Giris1 giriş = new Giris1();
                giriş.Show();
            }
            this.Hide();


        }
    }
}

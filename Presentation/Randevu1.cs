using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;

namespace Presentation
{
    public partial class Randevu1 : Form
    {
        private Business.Sırala sırala = new Business.Sırala();
        private Business.Randevu randevu = new Business.Randevu();
        public Randevu1()
        {
            InitializeComponent();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> liste = new List<string>();
            string brans = comboBox4.Text;
            string kimlik = "kimlik";
            sırala.DoktorSırala(brans,ref kimlik, liste);
            comboBox2.DataSource = liste;
            label9.Text = comboBox4.Text;
            label10.Text = kimlik;
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;
            checkedListBox1.Enabled = true;
            dateTimePicker1.Enabled = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            label8.Text = comboBox2.Text;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            checklistsaat();
            checkedlistlistele();
            
        }
        private void checklistsaat()
        {
            checkedListBox1.Enabled = true;
            checkedListBox1.Items.Clear();
            string selectedText = comboBox3.Text;
            string editedText = selectedText.Substring(0, selectedText.Length - 2);
            //editedText.
            for (int i = 0; i < 6; i++)
            {
                checkedListBox1.Items.Add(editedText + i + "0");

            }
        }
        private void checkedlistlistele()
        {

            for (int j = 0; j < checkedListBox1.Items.Count; j++)
            {
                int dolu = 0;
                DateTime saat = DateTime.Parse(checkedListBox1.Items[j].ToString());
                randevu.RandevuAktifligi(label10.Text, dateTimePicker1.Value, saat, ref dolu);
                if (dolu == 1)
                {
                    checkedListBox1.Items.RemoveAt(j);
                }
            }
        }


        private void Randevu1_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MinDate = DateTime.Today;
            dateTimePicker1.Value = DateTime.Today;
            checkedListBox1.Enabled = false;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd.MM.yyyy";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime tarih = dateTimePicker1.Value.Date; 
                DateTime saat = DateTime.Parse(label7.Text);

                randevu.RandevuOlustur(textBox1.Text,label10.Text,saat, tarih);
                if (label11.Text== "")
                {
                    MessageBox.Show("Lütfen gerçek bir kişi giriniz");
                    return;
                }
                else
                {
                    MessageBox.Show("Eklendi");
                    checkedlistlistele();
                    label7.Text = "Randevu Saati";
                }


            }
            catch
            {
                MessageBox.Show("ab");
            }

        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {

                if (e.NewValue == CheckState.Checked)
                {
                    foreach (int index in checkedListBox1.CheckedIndices)
                    {
                        if (index != e.Index)
                        {
                            checkedListBox1.SetItemChecked(index, false);
                        }
                    }
                }            
            label7.Text = checkedListBox1.SelectedItem.ToString();
            KontrolEt();
            }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> liste = new List<string>();
                sırala.HastaSırala(textBox1.Text, liste);
                label11.Text = liste[0];
                KontrolEt();

            }
            catch
            {
                MessageBox.Show("Hasta Görüntülenemedi");
            }
        }
        private void KontrolEt()
        {

            if (label9.Text!="Branş" && label8.Text != "Doktor" && label7.Text != "Randevu Saati"&&label11.Text!="label11")
            {
                button10.Enabled = true;
            }
            else
            {
                button10.Enabled = false;
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}


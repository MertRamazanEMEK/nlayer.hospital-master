using Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    public partial class Sekreter1 : Form
    {
        private Business.Ekle ekle = new Business.Ekle();
        public Sekreter1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Doktor")
            {
                string ad = textBox1.Text;
                string soyad = textBox2.Text;
                string cinsiyet = comboBox2.Text;
                string kimlik = textBox3.Text;
                DateTime dogum = dateTimePicker1.Value;
                string brans = comboBox4.Text;
                string telefon = textBox4.Text;
                string sifre = textBox5.Text;
                try
                {
                    ekle.DoktorEkle(ad, soyad, cinsiyet, kimlik, dogum, brans, telefon, sifre);
                    MessageBox.Show("Üye Kaydedildi");

                }
                catch
                {
                    MessageBox.Show("Üye kaydedilemedi, tekrar deneyin");
                }

            }
            else if (comboBox1.Text == "Hasta")
            {
                string ad = textBox11.Text;
                string soyad = textBox12.Text;
                string cinsiyet = comboBox3.Text;
                string kimlik = textBox13.Text;
                DateTime dogum = dateTimePicker3.Value;
                string e_posta = textBox14.Text;
                string telefon = textBox15.Text;

                try
                {
                    ekle.HastaEkle(ad, soyad, cinsiyet, kimlik, dogum, e_posta, telefon);
                    MessageBox.Show("Üye Kaydedildi");

                }
                catch
                {
                    MessageBox.Show("Üye kaydedilemedi, tekrar deneyin");
                }

            }
            else if (comboBox1.Text == "Sekreter")
            {
                string ad = textBox6.Text;
                string soyad = textBox7.Text;
                string cinsiyet = comboBox5.Text;
                string kimlik = textBox8.Text;
                DateTime dogum = dateTimePicker2.Value;
                string sifre = textBox10.Text;

                try
                {
                    ekle.SekreterEkle(ad, soyad, cinsiyet, kimlik, dogum, sifre);
                    MessageBox.Show("Üye Kaydedildi");

                }
                catch
                {
                    MessageBox.Show("Üye kaydedilemedi, tekrar deneyin");
                }

            }
        }

        private void randevuOluşturmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Randevu1 randevu = new Randevu1();
            randevu.StartPosition = FormStartPosition.CenterScreen;
            randevu.Show();
        }

        private void silmeGüncellemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SilmeGuncelleme silme = new SilmeGuncelleme();
            silme.StartPosition = FormStartPosition.CenterScreen;
            silme.TopLevel = false;
            silme.FormBorderStyle = FormBorderStyle.None;
            silme.ControlBox = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(silme);
            silme.Show();
        }
        private void doktorHastaSayısıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bölüm_DoktorSayısı zed = new Bölüm_DoktorSayısı();
            zed.StartPosition = FormStartPosition.Manual;
            zed.TopLevel = false;
            zed.FormBorderStyle = FormBorderStyle.None;
            zed.ControlBox = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(zed);
            zed.Show();
        }
        private void Sekreter1_Load(object sender, EventArgs e)
        {
            comboBox1.Text = comboBox1.Items[0].ToString();
            Bölüm_HastaSayısı hasta = new Bölüm_HastaSayısı();
            hasta.StartPosition = FormStartPosition.Manual;
            hasta.TopLevel = false;
            hasta.FormBorderStyle = FormBorderStyle.None;
            hasta.ControlBox = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(hasta);
            hasta.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Doktor")
            {
                groupBox1.BringToFront();
                groupBox2.SendToBack();
                groupBox3.SendToBack();
                groupBox1.Visible = true;
                groupBox2.Visible = false;
                groupBox3.Visible = false;
            }
            else if (comboBox1.Text == "Hasta")
            {
                groupBox2.BringToFront();
                groupBox1.SendToBack();
                groupBox3.SendToBack();
                groupBox1.Visible = false;
                groupBox2.Visible = false;
                groupBox3.Visible = true;
            }
            else if (comboBox1.Text == "Sekreter")
            {
                groupBox3.BringToFront();
                groupBox2.SendToBack();
                groupBox1.SendToBack();
                groupBox1.Visible = false;
                groupBox2.Visible = true;
                groupBox3.Visible = false;
            }
        }

        private void bölümHastaSayısıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bölüm_HastaSayısı hasta = new Bölüm_HastaSayısı();
            hasta.StartPosition = FormStartPosition.Manual;
            hasta.TopLevel = false;
            hasta.FormBorderStyle = FormBorderStyle.None;
            hasta.ControlBox = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(hasta);
            hasta.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Giris1 giriş = new Giris1();
            giriş.Show();
            this.Hide();
        }
    }
}


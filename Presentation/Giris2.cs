using Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Presentation
{
    public partial class Giris2 : Form
    {
        private string ad = "ad";
        private string kimlikno = "kimlik";
        private Business.Giris giris = new Business.Giris();
        public Giris2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Kullanıcı adı ve şifre gereklidir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                int sayı = 0;

                giris.GirisYap(textBox1.Text, textBox2.Text, ref ad, ref kimlikno, ref sayı);

                if (sayı == 2)
                {
                    while (progressBar1.Value < 100)
                    {

                        progressBar1.Value = +progressBar1.Value + 100;

                    }
                    if (progressBar1.Value == 100)
                    {
                        progressBar1.Value = 0;
                    }
                    Sekreter1 sekreter = new Sekreter1();
                    sekreter.Show();
                }
                else if (sayı == 1)
                {
                    while (progressBar1.Value < 35)
                    {

                        progressBar1.Value = +progressBar1.Value + 35;

                    }
                    if (progressBar1.Value == 35)
                    {
                        MessageBox.Show("Yanlış Giriş Yaptınız Tekrar Deneyin");
                        progressBar1.Value = 0;
                    }

                    return;
                }
                else
                {
                    while (progressBar1.Value < 35)
                    {

                        progressBar1.Value = +progressBar1.Value + 35;

                    }
                    if (progressBar1.Value == 35)
                    {
                        MessageBox.Show("Hatalı Kimlik Numarası Girdiniz");
                        progressBar1.Value = 0;
                    }
                    textBox1.Clear();
                    textBox2.Clear();
                    return;
                }
            }
            this.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AnaGiriş anagiris = new AnaGiriş();
            anagiris.Show();
            this.Close();
        }
    }

    }


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Presentation
{
    public partial class Giris1 : Form
    {
        private string ad = "ad";
        private string kimlikno = "kimlik";
        private Business.Giris giris = new Business.Giris();

        public Giris1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Kullanıcı adı ve şifre gereklidir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                int sayı = 0;

                giris.GirisYap(textBox4.Text, textBox3.Text, ref ad, ref kimlikno, ref sayı);

                if (sayı == 1)
                {
                    for (int i = 20; i <= 100; i+=20)
                    {
                        
                        progressBar2.Value = i;
                        Thread.Sleep(350); 
                    }
                    if (progressBar2.Value == 100)
                    {
                     Doktor doktor = new Doktor(kimlikno);
                     doktor.Show();
                     progressBar2.Value = 0;
                     }
                }
                
                else if (sayı == 2)
                {
                    for (int i = 20; i <= 100; i += 20)
                    {

                        progressBar2.Value = i;
                        Thread.Sleep(350);
                    }
                    if (progressBar2.Value == 100)
                    {
                        Sekreter1 sekreter = new Sekreter1();
                        sekreter.Show();
                        progressBar2.Value = 0;
                    }
                }
                else
                {
                    for (int i = 20; i <= 40; i += 20)
                    {

                        progressBar2.Value = i;
                        Thread.Sleep(100);
                    }
                    if (progressBar2.Value == 40)
                    {
                        MessageBox.Show("Hatalı kimlik numarası veya şifre. Tekrar deneyin");
                        textBox1.Clear();
                        textBox2.Clear();
                        progressBar2.Value = 0;
                    }
                    return;
                }
                this.Hide();
            }
        }
        private void Giris1_Load(object sender, EventArgs e)
        {

        }
    }
}
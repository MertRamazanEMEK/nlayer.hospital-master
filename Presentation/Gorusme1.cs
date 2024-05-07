using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text;


namespace Presentation
{
    public partial class Gorusme1 : Form
    {
        private Business.Mail mail = new Business.Mail();
        private Business.Randevu randevu = new Business.Randevu();
        private Business.Sırala sırala = new Business.Sırala();
        public string _brans, _ad, _cinsiyet,_kimlik;

        public Gorusme1(string ad,  string brans,string cinsiyet,string kimlik)
        {
            InitializeComponent();
            _ad = ad;
            _cinsiyet = cinsiyet;
            _brans = brans;
            _kimlik = kimlik;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            EskiKayıtlar doktor = new EskiKayıtlar(label7.Text);
            doktor.StartPosition = FormStartPosition.CenterScreen;
            doktor.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<string> liste = new List<string>();
            try
            {
                string gorus = ("Tanı : \n" + richTextBox1.Text + "\n\nGörüş: \n" + richTextBox2.Text + "\n\nTahlil: \n" + richTextBox3.Text);
                mail.SendMail(liste, label7.Text, "X Devlet Hastanesi", gorus);
                MessageBox.Show("Mail Gönderildi");
            }
            catch
            {
                MessageBox.Show("Hata");

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            randevu.RandevuKaydet(label7.Text, richTextBox1.Text, richTextBox2.Text, richTextBox3.Text, _brans);
            MessageBox.Show("Görüşme Kaydedildi");

        }

        private void Gorusme1_Load(object sender, EventArgs e)
        {
            label7.Text = _kimlik;
            List<string> liste = new List<string>();

            sırala.HastaSırala(label7.Text, liste);
            label8.Text = liste[0];
            label9.Text = liste[1];
            label10.Text = liste[2];
            label14.Text = liste[3];
            label6.Text = liste[4];


        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "PDF Files|*.pdf";
                saveFileDialog1.Title = "Save PDF File";
                saveFileDialog1.ShowDialog();

                // Seçilen dosya yolu
                string pdfPath = saveFileDialog1.FileName;

                if (pdfPath != "")
                {
                    // PDF oluşturma işlemi
                    using (Document doc = new Document())
                    {
                        try
                        {
                            // PDF dosyasını oluştur
                            PdfWriter.GetInstance(doc, new FileStream(pdfPath, FileMode.Create));

                            // PDF dosyasını aç
                            doc.Open();

                            // Başlık
                            Paragraph title = new Paragraph("Görüşme Kaydı");
                            title.Alignment = Element.ALIGN_CENTER;
                            doc.Add(title);
                            doc.Add(new Chunk("\n\n"));

                            // Bilgileri ekle
                            doc.Add(new Paragraph("Doktor Bilgileri \nDoktor Adı: " + _ad));
                            doc.Add(new Paragraph("Doktor Cinsiyet: " + _cinsiyet));
                            doc.Add(new Paragraph("Doktor Branşı: " + _brans));

                            doc.Add(new Paragraph("\nHasta Bilgileri \nHasta Adı: " + label8.Text));
                            doc.Add(new Paragraph("Hasta Cinsiyet: " + label9.Text));
                            doc.Add(new Paragraph("Hasta Kimlik Numarası: " + label7.Text));
                            doc.Add(new Paragraph("Hasta Doğum Tarihi: " + label10.Text));
                            doc.Add(new Paragraph("Hasta Telefon Numarası: " + label6.Text));

                            doc.Add(new Paragraph("\nTanı: " + richTextBox1.Text));
                            doc.Add(new Paragraph("Görüş: " + richTextBox2.Text));
                            doc.Add(new Paragraph("Tahlil Sonuçları: " + richTextBox3.Text));


                            // Dosyayı kapat
                            doc.Close();

                            MessageBox.Show("PDF başarıyla oluşturuldu ve " + pdfPath + " konumuna kaydedildi.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("PDF oluşturma hatası: " + ex.Message);
                        }
                    }
                }
            }

            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }
    }
}
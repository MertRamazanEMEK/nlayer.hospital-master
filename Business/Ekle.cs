using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data.OleDb;

namespace Business
{   
    public class Ekle
    {
        private DataAccess.Baglanti baglanti = new Baglanti();

        public void DoktorEkle(string ad, string soyad, string cinsiyet, string kimlik, DateTime dogum,  string brans, string telefon, string sifre)
        {

            OleDbConnection connection = baglanti.BaglantiAc();
            try
            {
                OleDbCommand komut = new OleDbCommand("insert into Doktor" +
                "(ad,soyad,cinsiyet,kimlikno,dogum_tarihi,telefon,brans,sifre) values (@ad, @soyad, @cinsiyet, @kimlikno, @dogum_tarihi," +
                "@telefon,@brans,@sifre)", connection);

                komut.Parameters.AddWithValue("@ad", ad);
                komut.Parameters.AddWithValue("@soyad", soyad);
                komut.Parameters.AddWithValue("@cinsiyet", cinsiyet);
                komut.Parameters.AddWithValue("@kimlikno", kimlik);
                komut.Parameters.AddWithValue("@dogum_tarihi", dogum);
                komut.Parameters.AddWithValue("@telefon", telefon);
                komut.Parameters.AddWithValue("@brans", brans);
                komut.Parameters.AddWithValue("@sifre", sifre);
                komut.ExecuteNonQuery();

            }
            catch
            {
                throw;
            }
            connection.Close();
        }
        public void HastaEkle(string ad, string soyad, string cinsiyet, string kimlik, DateTime dogum, string e_posta, string telefon)
        {
            OleDbConnection connection = baglanti.BaglantiAc();
            try {
            OleDbCommand komut = new OleDbCommand("insert into Hasta" +
            "(ad,soyad,cinsiyet,kimlikno,dogum_tarihi,mail,telefon) values (@ad, @soyad, @cinsiyet, @kimlikno, @dogum_tarihi, @mail," +
            "@telefon)", connection);

            komut.Parameters.AddWithValue("@ad", ad);
            komut.Parameters.AddWithValue("@soyad", soyad);
            komut.Parameters.AddWithValue("@cinsiyet", cinsiyet);
            komut.Parameters.AddWithValue("@kimlikno", kimlik);
            komut.Parameters.AddWithValue("@dogum_tarihi", dogum);
            komut.Parameters.AddWithValue("@mail", e_posta);
            komut.Parameters.AddWithValue("@telefon", telefon);
            komut.ExecuteNonQuery();

        }
            catch
            {
                throw;
            }
            connection.Close();
        }
        public void SekreterEkle(string ad, string soyad, string cinsiyet, string kimlik, DateTime dogum, string sifre)
        {
            OleDbConnection connection = baglanti.BaglantiAc();
            try
            {
                OleDbCommand komut = new OleDbCommand("insert into Sekreter" +
                "(ad,soyad,cinsiyet,kimlikno,dogum_tarihi,sifre) values (@ad, @soyad, @cinsiyet, @kimlikno, " +
                "@dogum_tarihi,@sifre)", connection);

                komut.Parameters.AddWithValue("@ad", ad);
                komut.Parameters.AddWithValue("@soyad", soyad);
                komut.Parameters.AddWithValue("@cinsiyet", cinsiyet);
                komut.Parameters.AddWithValue("@kimlikno", kimlik);
                komut.Parameters.AddWithValue("@dogum_tarihi", dogum);
                komut.Parameters.AddWithValue("@sifre", sifre);
                komut.ExecuteNonQuery();

            }
            catch
            {
                throw;
            }
            connection.Close();
        }
    }
}

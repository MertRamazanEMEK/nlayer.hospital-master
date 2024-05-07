using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data.OleDb;

namespace Business
{
    public class Guncelle
    {
        private DataAccess.Baglanti baglanti = new Baglanti();

        public void DoktorGuncelle(string eskikimlik,string kimlikno, string ad, string soyad, string cinsiyet,DateTime dogum_tarihi, string telefon, string brans, string sifre)
        {

            OleDbConnection connection = baglanti.BaglantiAc();
            try
            {
                OleDbCommand komut = new OleDbCommand("UPDATE Doktor SET " +
                    "ad = @ad, soyad = @soyad, cinsiyet = @cinsiyet, kimlikno = @kimlikno, " +
                    "dogum_tarihi = @dogum_tarihi, telefon = @telefon, brans = @brans, sifre = @sifre " +
                    "WHERE kimlikno = @eskikimlik", connection);
               
                komut.Parameters.AddWithValue("@ad", ad);
                komut.Parameters.AddWithValue("@soyad", soyad);
                komut.Parameters.AddWithValue("@cinsiyet", cinsiyet);               
                komut.Parameters.AddWithValue("@kimlikno", kimlikno);
                komut.Parameters.AddWithValue("@dogum_tarihi", dogum_tarihi);
                komut.Parameters.AddWithValue("@telefon", telefon);
                komut.Parameters.AddWithValue("@brans", brans);
                komut.Parameters.AddWithValue("@sifre", sifre);
                komut.Parameters.AddWithValue("@eskikimlik", eskikimlik);

                komut.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                // Hata yönetimi: Hata mesajını loglama veya kullanıcıya gösterme
                Console.WriteLine("hata: " + ex.Message);
            }
            connection.Close();
        }
        public void HastaGuncelle(string eskikimlik,string kimlikno, string ad, string soyad, string cinsiyet, DateTime dogum_tarihi, string mail, string telefon)
        {

            OleDbConnection connection = baglanti.BaglantiAc();
            try
            {
                OleDbCommand komut = new OleDbCommand("UPDATE Hasta SET " +
                    "ad = @ad, soyad = @soyad, cinsiyet = @cinsiyet, kimlikno = @kimlikno, " +
                    "dogum_tarihi = @dogum_tarihi, mail = @mail, telefon = @telefon " +
                    "WHERE kimlikno = @eskikimlik", connection);



                komut.Parameters.AddWithValue("@ad", ad);
                komut.Parameters.AddWithValue("@soyad", soyad);
                komut.Parameters.AddWithValue("@cinsiyet", cinsiyet);
                komut.Parameters.AddWithValue("@kimlikno", kimlikno);
                komut.Parameters.AddWithValue("@dogum_tarihi", dogum_tarihi);
                komut.Parameters.AddWithValue("@mail", mail);
                komut.Parameters.AddWithValue("@telefon", telefon);
                komut.Parameters.AddWithValue("@eskikimlik", eskikimlik);
                komut.ExecuteNonQuery();

            }
            catch
            {
                throw;
            }
            connection.Close();
        }
        public void SekreterGuncelle(string eskikimlik, string ad, string soyad, string cins, string kn, DateTime dt,string sifre)
        {

            OleDbConnection connection = baglanti.BaglantiAc();
            try
            {
                OleDbCommand komut = new OleDbCommand("UPDATE Sekreter SET " +
                    "ad = @ad, soyad = @soyad, cinsiyet = @cinsiyet, kimlikno = @kimlikno, " +
                    "dogum_tarihi = @dogum_tarihi,sifre = @sifre WHERE kimlikno = @eskikimlik", connection);

                komut.Parameters.AddWithValue("@ad", ad);
                komut.Parameters.AddWithValue("@soyad", soyad);
                komut.Parameters.AddWithValue("@cinsiyet", cins);
                komut.Parameters.AddWithValue("@kimlikno", kn);
                komut.Parameters.AddWithValue("@dogum_tarihi", dt);
                komut.Parameters.AddWithValue("@sifre", sifre);
                komut.Parameters.AddWithValue("@eskikimlik", eskikimlik);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Randevu
    {
        private DataAccess.Baglanti baglanti = new DataAccess.Baglanti();
        public void RandevuOlustur(string hastakimlik,string doktorkimlik,DateTime saat, DateTime tarih)
        {
            try
            {
                OleDbConnection connection = baglanti.BaglantiAc();
                OleDbCommand komut = new OleDbCommand("insert into Randevu (DoktorKimlik, HastaKimlik, Saat, Tarih) values (@DoktorKimlik, @HastaKimlik,@Saat,@Tarih)", connection);
                komut.Parameters.AddWithValue("@DoktorKimlik", doktorkimlik);
                komut.Parameters.AddWithValue("@HastaKimlik", hastakimlik);
                komut.Parameters.AddWithValue("@Saat", saat);
                komut.Parameters.AddWithValue("@Tarih", tarih.Date);

                komut.ExecuteNonQuery();
                

                connection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void RandevuAktifligi(string dkimlik, DateTime randevutarihi, DateTime randevusaati,ref int dolu)
        {
            OleDbConnection connection = baglanti.BaglantiAc();
            try
            {
                OleDbCommand checkCommand = new OleDbCommand("SELECT COUNT(*) FROM Randevu WHERE DoktorKimlik = @DoktorKimlik AND Tarih = @RandevuTarihi AND Saat = @RandevuSaati", connection);
                checkCommand.Parameters.AddWithValue("@DoktorKimlik", dkimlik);
                checkCommand.Parameters.AddWithValue("@RandevuTarihi", randevutarihi.Date);
                checkCommand.Parameters.AddWithValue("@RandevuSaati", randevusaati);
                checkCommand.ExecuteNonQuery();

                int existingAppointmentsCount = (int)checkCommand.ExecuteScalar();

                if (existingAppointmentsCount > 0)
                {
                    dolu = 1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            
        }
        public void RandevuKaydet(string kimlikno,string tanı,string gorus,string tahlil,string doktor_kimlik)
        {
            OleDbConnection connection = baglanti.BaglantiAc();

            try
            {
                OleDbCommand komut = new OleDbCommand("insert into HastaGecmisi" +
                "(kimlikno,tanı,gorus,tahlil,doktor_kimlik) values (@kimlikno,@tanı,@gorus,@tahlil,@doktor_kimlik)", connection);

                komut.Parameters.AddWithValue("@kimlikno", kimlikno);
                komut.Parameters.AddWithValue("@tanı", tanı);
                komut.Parameters.AddWithValue("@gorus", gorus);
                komut.Parameters.AddWithValue("@tahlil", tahlil);
                komut.Parameters.AddWithValue("@doktor_kimlik", doktor_kimlik);

                komut.ExecuteNonQuery();

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
        }

    }
}

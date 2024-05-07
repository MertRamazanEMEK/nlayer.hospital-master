using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class DataGrid
    {
        private DataAccess.Baglanti baglanti = new DataAccess.Baglanti();
        private DataAccess.Doktor doktor = new DataAccess.Doktor();
        private DataAccess.Hasta hasta = new DataAccess.Hasta();
        private DataAccess.Sekreter sekreter = new DataAccess.Sekreter();
        public DataTable filldatagriddoktor()
        {
            DataTable dt = new DataTable();
            using (OleDbConnection connection = baglanti.BaglantiAc())
            {
                try
                {
                    string query = "select * from Doktor";
                    OleDbCommand komut = new OleDbCommand(query, connection);
                    using (OleDbDataAdapter da = new OleDbDataAdapter(komut))
                    {
                        da.Fill(dt);
                    }
                }
                catch
                {
                    Console.WriteLine("Hata");
                }
            }
            return dt;
        }
        public DataTable filldatagridhasta()
        {
            DataTable dt = new DataTable();
            using (OleDbConnection connection = baglanti.BaglantiAc())
            {
                try
                {
                    string query = "select * from Hasta";
                    OleDbCommand komut = new OleDbCommand(query, connection);
                    using (OleDbDataAdapter da = new OleDbDataAdapter(komut))
                    {
                        da.Fill(dt);
                    }
                }
                catch
                {
                    Console.WriteLine("Hata");
                }
            }
            return dt;
        }
        public DataTable filldatagridsekreter()
        {
            DataTable dt = new DataTable();
            using (OleDbConnection connection = baglanti.BaglantiAc())
            {
                try
                {
                    string query = "select * from Sekreter";
                    OleDbCommand komut = new OleDbCommand(query, connection);
                    using (OleDbDataAdapter da = new OleDbDataAdapter(komut))
                    {
                        da.Fill(dt);
                    }
                }
                catch
                {
                    Console.WriteLine("Hata");
                }
            }
            return dt;
        }
        public DataTable filldatagridhastagecmis(string kimlik)
        {
            DataTable dt = new DataTable();
            using (OleDbConnection connection = baglanti.BaglantiAc())
            {
                try
                {
                    string query = "select * from HastaGecmisi where kimlikno=@kimlik";
                    OleDbCommand komut = new OleDbCommand(query, connection);
                    komut.Parameters.AddWithValue("@kimlik", kimlik);
                    using (OleDbDataAdapter da = new OleDbDataAdapter(komut))
                    {
                        da.Fill(dt);
                    }
                }
                catch
                {
                    Console.WriteLine("Hata");
                }
            }
            return dt;
        }
        public DataTable filldatagridhastarandevu(string DoktorKimlik , DateTime Tarih)
        {
            DataTable dt = new DataTable();
            using (OleDbConnection connection = baglanti.BaglantiAc())
            {
                try
                {
                    DateTime tarih = Tarih.Date;
                    string query = "select HastaKimlik,Tarih,Saat from Randevu where DoktorKimlik = @Doktorkimlik and Tarih = @Tarih";
                    OleDbCommand komut = new OleDbCommand(query, connection);
                    using (OleDbDataAdapter da = new OleDbDataAdapter(komut))
                    {
                        komut.Parameters.AddWithValue("@DoktorKimlik", DoktorKimlik);
                        komut.Parameters.AddWithValue("@Tarih", tarih);
                        komut.ExecuteNonQuery();
                        da.Fill(dt);
                    }
                }
                catch (Exception ex)
                {
                   Console.WriteLine(ex.Message);
                }
            }
            return dt;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using DataAccess;

namespace Business
{
    public class Sil
    {
        private DataAccess.Baglanti baglanti = new Baglanti();

        public void DoktorSil(string kn)
        {

            OleDbConnection connection = baglanti.BaglantiAc();
            try
            {
                OleDbCommand komut = new OleDbCommand("DELETE FROM Doktor WHERE kimlikno = @kimlikno", connection);
                komut.Parameters.AddWithValue("@kimlikno", kn);
                komut.ExecuteNonQuery();

            }
            catch
            {
                throw;
            }
            connection.Close();
        }
        public void HastaSil(string kn)
        {

            OleDbConnection connection = baglanti.BaglantiAc();
            try
            {
                OleDbCommand komut = new OleDbCommand("DELETE FROM Hasta WHERE kimlikno = @kimlikno", connection);

                komut.Parameters.AddWithValue("@kimlikno", kn);
                komut.ExecuteNonQuery();

            }
            catch
            {
                throw;
            }
            connection.Close();
        }
        public void SekreterSil(string kn)
        {

            OleDbConnection connection = baglanti.BaglantiAc();
            try
            {
                OleDbCommand komut = new OleDbCommand("DELETE FROM Sekreter WHERE kimlikno = @kimlikno", connection);
                komut.Parameters.AddWithValue("@kimlikno", kn);
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

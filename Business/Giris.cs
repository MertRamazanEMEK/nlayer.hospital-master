using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using DataAccess;

namespace Business
{
    public class Giris
    {
        private DataAccess.Baglanti baglanti = new Baglanti();

        public void GirisYap(string username,string password,ref string ad,ref string kimlik,ref int giris)
        {

            string query = "SELECT * FROM Doktor WHERE sifre = @sifre AND kimlikno = @kimlikno";
            string query2 = "SELECT * FROM Sekreter WHERE sifre = @sifre AND kimlikno = @kimlikno";

            using (OleDbConnection connection = baglanti.BaglantiAc())
            {

                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("@sifre", password);
                command.Parameters.AddWithValue("@kimlikno", username);

                OleDbCommand command2 = new OleDbCommand(query2, connection);
                command2.Parameters.AddWithValue("@sifre", password);
                command2.Parameters.AddWithValue("@kimlikno", username);

                try
                {
                    OleDbDataReader reader = command.ExecuteReader();
                    OleDbDataReader reader2 = command2.ExecuteReader();
                    if (reader.HasRows)
                    {
                        int i = 0;
                        while (reader.Read())
                        {
                            Doktor li = new Doktor()
                            {
                                ad = (string)reader["ad"],
                                soyad = (string)reader["soyad"],
                                kimlikno = (string)reader["kimlikno"],
                            };
                            ad =(li.ad + " " + li.soyad);
                            kimlik = li.kimlikno.ToString();
                            i = i + 1;
                        giris = 1;

                        }
                    }
                    else if (reader2.HasRows)
                    {
                        int i = 0;
                        while (reader2.Read())
                        {
                            Sekreter li = new Sekreter()
                            {
                                ad = (string)reader2["ad"],
                                soyad = (string)reader2["soyad"],
                                kimlikno = (string)reader2["kimlikno"],
                            };
                            ad = (li.ad + " " + li.soyad);
                            kimlik = li.kimlikno.ToString();
                            i = i + 1;
                        giris = 2;

                        }
                    }
                    else
                    {
                        giris = 0;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Giriş işlemi sırasında bir hata oluştu.", ex);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data.OleDb;
using ZedGraph;
using System.Collections;
using System.Windows.Forms;

namespace Business
{
    public class DoktorHastaSayısı_ZedGraph
    {
        private DataAccess.Baglanti baglanti = new DataAccess.Baglanti();

        public PointPairList LoadGraphData()
        {
            OleDbConnection connection = baglanti.BaglantiAc();
            PointPairList list = new PointPairList();

            string query = "SELECT d.ad AS doktorAd,COUNT(r.HastaKimlik) AS hastaSayisi FROM Doktor d LEFT JOIN Randevu r ON d.kimlikno = r.DoktorKimlik GROUP BY d.ad";
            ;

            using (OleDbCommand command = new OleDbCommand(query, connection))
            {
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    int indis = 1; 

                    while (reader.Read())
                    {
                        string doktorAd = reader["doktorAd"].ToString();
                        int hastaSayisi = Convert.ToInt32(reader["hastaSayisi"]);

                        list.Add(indis, hastaSayisi, doktorAd);
                        indis++; 
                    }
                }
            }

            return list;
        }
    }

}


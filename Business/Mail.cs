using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Business
{
    public class Mail
    {
        private DataAccess.Baglanti baglanti = new DataAccess.Baglanti();
        private DataAccess.Posta posta = new DataAccess.Posta();

        public void SendMail(List<string> list,string kimlik, string baslik, string konu)
        {   
            OleDbConnection connection = baglanti.BaglantiAc();

            try 
            { 

            string query = "SELECT mail FROM Hasta where kimlikno = @kimlik ";
            using (OleDbCommand command = new OleDbCommand(query, connection))
            {
                command.Parameters.AddWithValue("@kimlik", kimlik);
                command.ExecuteNonQuery();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Hasta posta = new Hasta()
                        {
                            mail = reader["mail"].ToString(),
                        };

                        list.Add(posta.mail.ToString());
                    }
                }
            }
        

            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential(posta.senderEmail, posta.senderpassword);
            smtp.Host = posta.smtphost;
            smtp.Port = posta.smtpport;
            smtp.EnableSsl = true;
            posta.baslik = baslik;
            posta.konu = konu;
            foreach (var mil in list)
            {
                MailMessage message = new MailMessage(posta.senderEmail, mil, baslik, konu);
                smtp.Send(message);
            }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
            connection.Close();            
            }

        }
    }
}


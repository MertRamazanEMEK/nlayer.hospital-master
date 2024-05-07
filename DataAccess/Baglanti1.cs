using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess
{
    public class Baglanti
    {
        private static string GetDatabasePath()
        {
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string dbPath = Path.Combine(appDirectory, "hastane.accdb");
            return dbPath;
        }
        public OleDbConnection BaglantiAc()
        {
            string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={GetDatabasePath()}";
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}


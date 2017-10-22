using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows;

namespace FinanseWPF
{
    class FinanseViewModel
    {
        private string dbConnectionString = @"Data Source=database.db;Version=3;";
        public int UserID { get; set; }

        public string WelcomeString(int id)
        {
            SQLiteConnection sqlite_conn = new SQLiteConnection(dbConnectionString);
            string name = null;
            try
            {
                sqlite_conn.Open();
                String Query = "select * from User where uid='" + id +"' ";
                SQLiteCommand sqlite_cmd = new SQLiteCommand(Query, sqlite_conn);

                sqlite_cmd.ExecuteNonQuery();
                SQLiteDataReader dr = sqlite_cmd.ExecuteReader();

                 while (dr.Read())
                {
                    name = dr.GetString(1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return name;
        }
    }
}

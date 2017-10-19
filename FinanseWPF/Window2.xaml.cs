using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SQLite;

namespace FinanseWPF
{
    /// <summary>
    /// Logika interakcji dla klasy Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        string dbConnectionString = @"Data Source=database.db;Version=3;";

        public Window2()
        {
            InitializeComponent();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection sqlite_conn = new SQLiteConnection(dbConnectionString);
            try
            {
                sqlite_conn.Open();
                String Query = "insert or IGNORE into User (Name, Cash, Token) values('" + this.textBox.Text + "', '" + this.textBox1.Text + "', '" + this.passwordBox.Password + "' )";
                SQLiteCommand sqlite_cmd = new SQLiteCommand(Query, sqlite_conn);

                sqlite_cmd.ExecuteNonQuery();
                SQLiteDataReader dr = sqlite_cmd.ExecuteReader();

                MessageBox.Show("Dodano użytkownika");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

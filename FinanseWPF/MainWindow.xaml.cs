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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;

namespace FinanseWPF
{
    /// <summary> commit ! <>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string dbConnectionString = @"Data Source=database.db;Version=3;";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
 
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            SQLiteConnection sqlite_conn = new SQLiteConnection(dbConnectionString);
            try
            {
                sqlite_conn.Open();
                String Query = "select * from User where token='" + this.passwordBox.Password +"' ";
                SQLiteCommand sqlite_cmd = new SQLiteCommand(Query,sqlite_conn);

                sqlite_cmd.ExecuteNonQuery();
                SQLiteDataReader dr = sqlite_cmd.ExecuteReader();

                int count = 0;
                while (dr.Read())
                {
                    count++;
                }
                
                if (count == 1)
                {
                    Window1 program = new Window1();
                    program.ShowDialog();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }

        }

        private void button_Click_2(object sender, RoutedEventArgs e)
        {
            Window2 sign_up = new Window2();
            sign_up.ShowDialog();
        }
    }
}

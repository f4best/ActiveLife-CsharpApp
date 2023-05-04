using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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

namespace programowanieIVprojekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string DbLocation = "Data Source=programowanieIVsqlite.sqlite";
        //główne okno
        public MainWindow()
        {
            InitializeComponent();

            using (SqliteConnection connection = new SqliteConnection(DbLocation))
            {
                connection.Open();

                string SqlTableProdukty = "CREATE TABLE IF NOT EXISTS Produkty (ID_produktu INTEGER PRIMARY KEY AUTOINCREMENT, nazwa VARCHAR(20), opis TEXT);";
                SqliteCommand SqlCommandProducts = new SqliteCommand(SqlTableProdukty, connection);
                string SqlTableUsers = "CREATE TABLE IF NOT EXISTS Uzytkownicy (ID_uzytkownika INTEGER PRIMARY KEY, login VARCHAR(16), haslo VARCHAR(20));" +
                    "INSERT INTO Uzytkownicy (ID_uzytkownika, login, haslo) SELECT 1, 'user', 'user' WHERE NOT EXISTS (SELECT 1 FROM Uzytkownicy WHERE login = 'user');" +
                    "INSERT INTO Uzytkownicy (ID_uzytkownika, login, haslo) SELECT 2, 'admin', 'admin' WHERE NOT EXISTS (SELECT 2 FROM Uzytkownicy WHERE login = 'admin');"; ;
                SqliteCommand SqlCommandUsers = new SqliteCommand(SqlTableUsers, connection);
                SqlCommandProducts.ExecuteNonQuery();
                SqlCommandUsers.ExecuteNonQuery();

                connection.Close();
            }
        }
        
        //przycisk "Zaloguj"
        private void logon_Click(object sender, RoutedEventArgs e)
        {
            string log = login.Text;
            string pass = password.Password;

            using (SqliteConnection connection = new SqliteConnection(DbLocation))
            {
                connection.Open();

                string SqlLogon = "SELECT COUNT(*) FROM Uzytkownicy WHERE login=@login AND haslo=@password;";
                SqliteCommand SqlCommandLogon = new SqliteCommand(SqlLogon, connection);
                SqlCommandLogon.Parameters.AddWithValue("@login", log);
                SqlCommandLogon.Parameters.AddWithValue("@password", pass);

                long count = (long)SqlCommandLogon.ExecuteScalar();
                //int count = int.Parse(SqlCommandLogon.ExecuteScalar().ToString()); <- też działa

                if (count > 0)
                {
                    //sprawdzanie czy konto to "admin"
                    if (log == "admin") 
                    {
                        StoreApp storeAppWindow = new StoreApp(log);
                        storeAppWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        StoreApp storeAppWindow = new StoreApp(log);
                        storeAppWindow.Show();
                        this.Close();
                    }

                }
                else
                {
                    message.Text = "Podano zły login lub hasło!";
                }
                connection.Close();
            }
        }
    }
}

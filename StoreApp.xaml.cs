using Microsoft.Data.Sqlite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
using System.Reflection.PortableExecutable;

namespace programowanieIVprojekt
{
    /// <summary>
    /// Logika interakcji dla klasy StoreApp.xaml
    /// </summary>
    public partial class StoreApp : Window
    {
        private string DbLocation = "Data Source=programowanieIVsqlite.sqlite";
        private string _username;
        public StoreApp(string username) //przekazanie wartości nazwy użytkownika
        {
            InitializeComponent();
            _username = username;
        }
        //textbox wyszukiwania czyści się po kliknięciu w niego
        private void search_GotFocus(object sender, RoutedEventArgs e)
        {
            search.Text = "";
        }
        //przycisk wylogowywania
        private void logout_Click(object sender, RoutedEventArgs e)
        {
            var MainWindowWin = new MainWindow();
            MainWindowWin.Show();
            this.Close();

            //zamykanie okna AdminPanel, jeżeli otwarty
            foreach (Window AdmPanel in Application.Current.Windows)
            {
                if (AdmPanel is AdminPanel)
                {
                    AdmPanel.Close();
                    break;
                }
            }
        }
        //wyświetlanie wyników w datagrid, pobierając tekst z textbox wyszukiwania
        private void search_Handler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string search_prod = search.Text;

                using (SqliteConnection connection = new SqliteConnection(DbLocation))
                {
                    connection.Open();

                    SqliteCommand SqlCommandSearch = new SqliteCommand("SELECT ID_produktu AS 'ID', nazwa AS 'Nazwa produktu', opis AS 'Opis produktu' FROM Produkty WHERE Nazwa LIKE @nazwa;", connection);
                    SqlCommandSearch.Parameters.AddWithValue("@nazwa", "%" + search_prod + "%");

                    DataTable dataTable = new DataTable();
                    SqliteDataReader reader = SqlCommandSearch.ExecuteReader();
                    dataTable.Load(reader);
                    data_products.ItemsSource = dataTable.DefaultView;

                    connection.Close();
                }
            }
        }

        //przycisk panelu administracyjnego
        private void button_AdminPanel(object sender, RoutedEventArgs e)
        {
            //jeżeli nie admin, wyskakuje msgBox
            if (_username == "admin")
            {
                var AdminPanelWindow = new AdminPanel();
                AdminPanelWindow.Show();
            }
            else
            {
                MessageBox.Show("Nie jesteś administratorem!");
            }
        }
        //zamykanie okna AdminPanel, po wciśnięciu krzyżyka, jeżeli otwarty
        private void storeApp_Closed(object sender, EventArgs e)
        {
            AdminPanel adminPanel = Application.Current.Windows.OfType<AdminPanel>().FirstOrDefault();

            if (adminPanel != null)
            {
                adminPanel.Close();
            }
        }
    }
}

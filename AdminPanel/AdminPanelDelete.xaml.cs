using Microsoft.Data.Sqlite;
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

namespace programowanieIVprojekt
{
    /// <summary>
    /// Interaction logic for AdminPanelDelete.xaml
    /// </summary>
    public partial class AdminPanelDelete : Page
    {
        private string DbLocation = "Data Source=programowanieIVsqlite.sqlite";
        public AdminPanelDelete()
        {
            InitializeComponent();
        }
        //ID produktu może posiadać jedynie liczby
        private void productdelete_id_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(productDelete_id.Text, "[^0-9]"))
            {
                MessageBox.Show("Wprowadź jedynie liczby!");
                productDelete_id.Text = productDelete_id.Text.Remove(productDelete_id.Text.Length - 1);
            }
        }
        //usuwanie produktu
        private void delete_Click(object sender, RoutedEventArgs e)
        {
            string id = productDelete_id.Text;

            using (SqliteConnection connection = new SqliteConnection(DbLocation))
            {
                connection.Open();

                string SqlAddProd = "DELETE FROM Produkty WHERE ID_produktu=@val;";
                SqliteCommand SqlCommandAddProd = new SqliteCommand(SqlAddProd, connection);
                SqlCommandAddProd.Parameters.AddWithValue("@val", id);

                //zabezpieczenie przed wykrzaczeniem
                try
                {
                    SqlCommandAddProd.ExecuteScalar();
                    MessageBox.Show("Produkt został usunięty.");
                }
                catch (SqliteException error)
                {
                    if (error.ErrorCode == 20)
                    {
                        MessageBox.Show("Wystąpił konflikt typów danych!");
                    }
                    else
                    {
                        _ = MessageBox.Show("ID produktu nie istnieje!");
                    }
                }

                connection.Close();
            }
        }
    }
}

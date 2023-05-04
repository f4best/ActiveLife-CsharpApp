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
    /// Interaction logic for AdminPanelAdd.xaml
    /// </summary>
    public partial class AdminPanelAdd : Page
    {
        private string DbLocation = "Data Source=programowanieIVsqlite.sqlite";
        public AdminPanelAdd()
        {
            InitializeComponent();
        }
        //przycisk wpisywania produktu
        private void insert_Click(object sender, RoutedEventArgs e)
        {
            string id = product_id.Text;
            string name = product_name.Text;
            string desc = product_desc.Text;

            using (SqliteConnection connection = new SqliteConnection(DbLocation))
            {
                connection.Open();

                //bez podanego ID
                if (id == "")
                {
                    string SqlAddProd = "INSERT INTO Produkty (nazwa, opis) VALUES (@name, @desc);";
                    SqliteCommand SqlCommandAddProd = new SqliteCommand(SqlAddProd, connection);
                    SqlCommandAddProd.Parameters.AddWithValue("@name", name);
                    SqlCommandAddProd.Parameters.AddWithValue("@desc", desc);

                    //zabezpieczenie przed wykrzaczeniem
                    try
                    {
                        SqlCommandAddProd.ExecuteScalar();
                        MessageBox.Show("Produkt został dodany.");
                    }
                    catch (SqliteException error)
                    {
                        if (error.ErrorCode == 20)
                        {
                            MessageBox.Show("Wystąpił konflikt typów danych!");
                        }
                        else
                        {
                            _ = MessageBox.Show("ID produktu już istnieje!");
                        }
                    }
                }
                //opcjonalne podanie ID
                else
                {
                    string SqlAddProd = "INSERT INTO Produkty (ID_produktu, nazwa, opis) VALUES (@val, @name, @desc);";
                    SqliteCommand SqlCommandAddProd = new SqliteCommand(SqlAddProd, connection);
                    SqlCommandAddProd.Parameters.AddWithValue("@val", id);
                    SqlCommandAddProd.Parameters.AddWithValue("@name", name);
                    SqlCommandAddProd.Parameters.AddWithValue("@desc", desc);

                    //zabezpieczenie przed wykrzaczeniem
                    try
                    {
                        SqlCommandAddProd.ExecuteScalar();
                        MessageBox.Show("Produkt został dodany.");
                    }
                    catch (SqliteException error)
                    {
                        if (error.ErrorCode == 20)
                        {
                            MessageBox.Show("Wystąpił konflikt typów danych!");
                        }
                        else
                        {
                            _ = MessageBox.Show("ID produktu już istnieje!");
                        }
                    }
                }

                connection.Close();
            }
        }
        //ID produktu może posiadać jedynie liczby
        private void product_id_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(product_id.Text, "[^0-9]"))
            {
                MessageBox.Show("Wprowadź jedynie liczby!");
                product_id.Text = product_id.Text.Remove(product_id.Text.Length - 1);
            }
        }
    }
}

/****************************
 * Name: - Rut Patel
 * SID: - 100774814
 * Searchoption.xaml.cs
 * References:-https://www.youtube.com/watch?v=V6NnrIXN6dY
 * ***************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Lab_2
{
    /// <summary>
    /// Interaction logic for Searchoption.xaml
    /// </summary>
    public partial class Searchoption : UserControl
    {
        public Searchoption()
        {
            InitializeComponent();
            FillDataGrid();
        }
        DataTable dt;
        private void FillDataGrid()
        {
            try
            {
                string connectString = Properties.Settings.Default.connect_string;

                SqlConnection cn = new SqlConnection(connectString);

                cn.Open();

                string selectionQuery = "SELECT * FROM equipment";

                SqlCommand command = new SqlCommand(selectionQuery, cn);

                SqlDataAdapter sda = new SqlDataAdapter(command);

                dt = new DataTable("equipment");
                sda.Fill(dt);


                resultGrid.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void txtID_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("Name LIKE '%{0}%'", txtID.Text);
            resultGrid.ItemsSource = dv;
        }


    }
}

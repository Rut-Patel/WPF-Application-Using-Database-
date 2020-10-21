/****************************
 * Name: - Rut Patel
 * SID: - 100774814
 * View  lendout.xaml.cs
 * **************************/

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

namespace Lab_2
{
    /// <summary>
    /// Interaction logic for Viewlendout.xaml
    /// </summary>
    public partial class Viewlendout : UserControl
    {
        public Viewlendout()
        {
            InitializeComponent();
            FillDataGrid();
        }

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
                
                DataTable dt = new DataTable("equipment");
                 sda.Fill(dt);


                viewGridData.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }
    }
}

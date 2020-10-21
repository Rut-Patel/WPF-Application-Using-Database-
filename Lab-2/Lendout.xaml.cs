/****************************
 * Name: - Rut Patel
 * SID: - 100774814
 * Lendout.xaml.cs
 * **************************/




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
using System.Data.SqlClient;

namespace Lab_2
{
    /// <summary>
    /// Interaction logic for lendout.xaml
    /// </summary>
    public partial class lendout : UserControl
    {
        public lendout()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int ID;
                string phone = txtPhone.Text;
                
                if(int.TryParse(txtID.Text,out ID))
                {
                    if (phone.Length == 12) //including hypen 999-999-9999   
                    {
                      
                            string connectString = Properties.Settings.Default.connect_string;
                            SqlConnection cn = new SqlConnection(connectString);

                            cn.Open();

                            string insertquery = "INSERT INTO equipment (ID, Name ,Description , Phone) VALUES ('" + ID + "','" + txtName.Text + "', '" + txtDesc.Text + "', '" + phone + " ' )";
                            SqlCommand command = new SqlCommand(insertquery, cn);
                            command.ExecuteNonQuery();
                            cn.Close();

                            MessageBox.Show("Your Data has been successfully added.");

                            txtID.Text = string.Empty;
                            txtName.Text = string.Empty;
                            txtPhone.Text = string.Empty;
                            txtDesc.Text = string.Empty;
                       
                       
                    }
                    else
                    {
                        MessageBox.Show("Please enter 10 digit mobile number");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter valid value for ID");
                }
               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}

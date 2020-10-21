/****************************
 * Name: - Rut Patel
 * SID: - 100774814
 * MainWindow.xaml.cs
 * Reference:- InClass Code, Aladdin Addas.
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

namespace Lab_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Event takes place when the user selects the Option
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Option_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView listview = e.Source as ListView;

            if(listview != null)
            {
                ContentPanel.Children.Clear();

                if(listview.SelectedItem.Equals(lstOptionLend))
                {
                    Control controlLendout = new lendout();
                    
                    this.ContentPanel.Children.Add(controlLendout);
                }
                if(listview.SelectedItem.Equals(lstOptionView))
                {
                    Control controlView = new Viewlendout();

                    this.ContentPanel.Children.Add(controlView);

                }
            }
        }
    }
}

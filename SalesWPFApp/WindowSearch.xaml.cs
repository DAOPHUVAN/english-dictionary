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
using BusinessObject;
using DataAccess;
using Microsoft.EntityFrameworkCore;
namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for WindowSearch.xaml
    /// </summary>
    public partial class WindowSearch : Window
    {
        IntefaceProductRepository intefaceProductRepository;
        public WindowSearch(IntefaceProductRepository productRepository)
        {
            InitializeComponent();
            intefaceProductRepository = productRepository;
        }


        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string input = txtInfo.Text;
            try
            {
                lvProducts.ItemsSource = intefaceProductRepository.Search(input);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Search product list");
                
            }
        }
    }



    }


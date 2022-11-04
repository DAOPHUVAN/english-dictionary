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
namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for WindowProducts.xaml
    /// </summary>
    public partial class WindowProducts : Window
    {
        IntefaceProductRepository interproductRepository;
        public WindowProducts(IntefaceProductRepository productRepository)
        {
            InitializeComponent();
            interproductRepository = productRepository;
        }

        private Product GetProductObject()
        {
            Product product = null;
            try
            {
                product = new Product
                {
                    ProductId = int.Parse(txtProductId.Text),
                    CategoryId = int.Parse(txtCategoryId.Text),
                    ProductName = txtProductName.Text,
                    Weight = txtWeight.Text,
                    UnitPrice = double.Parse(txtUnitPrice.Text),
                    UnitslnStock = int.Parse(txtUnitslnStock.Text)
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get product");
            }
            return product;
        }

        public void LoadProductList()
        {
            lvProducts.ItemsSource = interproductRepository.GetProducts();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadProductList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load product list");
            }
        }
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product _product = GetProductObject();
                interproductRepository.InsertProduct(_product);
                LoadProductList();
                MessageBox.Show($"{_product.ProductName} inserted successfully", "Insert Product");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert Product");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product _product = GetProductObject();
                interproductRepository.UpdateProduct(_product);
                LoadProductList();
                MessageBox.Show($"{_product.ProductName} updated successfully", "Update Product");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Product");
            }
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product _product = GetProductObject();
                interproductRepository.DeleteProduct(_product);
                LoadProductList();
                MessageBox.Show($"{_product.ProductName} deleted successfully", "Delete Product");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Product");
            }

        }
        private void btnClose_Click(object sender, RoutedEventArgs e) => Close();
    }
}

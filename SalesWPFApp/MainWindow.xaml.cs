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
using Microsoft.Extensions.DependencyInjection;
using DataAccess;
namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ServiceProvider serviceProvider;
        public MainWindow()
        {
            InitializeComponent();
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton(typeof(IntefaceMemberRepository), typeof(MemberRepository));
            services.AddSingleton<WindowMembers>();
            services.AddSingleton(typeof(IntefaceProductRepository), typeof(ProductRepository));
            services.AddSingleton<WindowProducts>();
            services.AddSingleton(typeof(IntefaceMemberRepository), typeof(MemberRepository));
            services.AddSingleton(typeof(IntefaceOrderRepository), typeof(OrderRepository));
            services.AddSingleton(typeof(IntefaceOrderDetailRepository), typeof(OrderDetailRepository));
            services.AddSingleton(typeof(IntefaceProductRepository), typeof(ProductRepository));
            services.AddSingleton<WindowOrders>();
            services.AddSingleton(typeof(IntefaceProductRepository), typeof(ProductRepository));
            services.AddSingleton<WindowSearch>();
        }

        private void Member_Click(object sender, RoutedEventArgs e)
        {
            var windowMembers = serviceProvider.GetService<WindowMembers>();
            windowMembers.Show();
        }
        private void Product_Click(object sender, RoutedEventArgs e)
        {
            var windowProduct = serviceProvider.GetService<WindowProducts>();
            windowProduct.Show();
        }
        private void Order_Click(object sender, RoutedEventArgs e)
        {
            var windowOrders = serviceProvider.GetService<WindowOrders>();
            windowOrders.Show();
        }
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            var windowOrders = serviceProvider.GetService<WindowSearch>();
            windowOrders.Show();
        }
    }
}

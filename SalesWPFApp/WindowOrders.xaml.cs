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
using DataAccess;
using BusinessObject;
namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for WindowOrders.xaml
    /// </summary>
    public partial class WindowOrders : Window
    {
        IntefaceMemberRepository intefaceMemberRepository;
        IntefaceOrderRepository intefaceOrderRepository;
        IntefaceOrderDetailRepository intefaceOrderDetailRepository;
        IntefaceProductRepository intefaceProductRepository;
        public WindowOrders(IntefaceMemberRepository memberRepository, IntefaceOrderRepository orderRepository, IntefaceOrderDetailRepository orderDetailRepository, IntefaceProductRepository productRepository)
        {
            InitializeComponent();
            intefaceMemberRepository = memberRepository;
            intefaceOrderRepository = orderRepository;
            intefaceOrderDetailRepository = orderDetailRepository;
            intefaceProductRepository = productRepository;
        }

        private Order1 GetOrderObject()
        {
            List<Member> members = (List<Member>)intefaceMemberRepository.GetAllMember();
            Order1 order = null;
            try
            {
                order = new Order1
                {
                    OrderId = int.Parse(txtOrderId.Text),
                    MemberId = members[0].MemberId,
                    OrderDate = DateTime.Parse(txtOrderDate.Text.Trim()),
                    RequiredDate = DateTime.Parse(txtRequiredDate.Text),
                    ShippedDate = DateTime.Parse(txtShippedDate.Text),
                    Freight = double.Parse(txtFreight.Text)
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get order");
            }
            return order;
        }

        private OrderDetail GetOrderDtailObject()
        {
            Product product = intefaceProductRepository.GetProductById(int.Parse(txtProductId.Text));
            OrderDetail orderDetail = null;
            try
            {
                orderDetail = new OrderDetail
                {
                    OrderId = int.Parse(txtOrderId.Text),
                    ProductId = int.Parse(txtProductId.Text),
                    UnitPrice = (double)product.UnitPrice * int.Parse(txtQuantity.Text),
                    Quantity = int.Parse(txtQuantity.Text),
                    Discount = double.Parse(txtDiscount.Text)
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get order detail");
            }
            return orderDetail;
        }

        public void LoadOrderList()
        {
            lvOrders.ItemsSource = intefaceOrderRepository.GetOrders();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadOrderList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Order list");
            }
        }
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order1 _order = GetOrderObject();
                intefaceOrderRepository.InsertOrder(_order);
                OrderDetail orderDetail = GetOrderDtailObject();
                intefaceOrderDetailRepository.InsertOrderDetail(orderDetail);

                LoadOrderList();
                MessageBox.Show($"{_order.OrderId} inserted successfully", "Insert order");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert Member");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order1 _order = GetOrderObject();
                intefaceOrderRepository.UpdateOrder(_order);
                LoadOrderList();
                MessageBox.Show($"{_order.OrderId} updated successfully", "Update order");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update order");
            }
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order1 _order = GetOrderObject();
                intefaceOrderRepository.DeleteOrder(_order);
                LoadOrderList();
                MessageBox.Show($"{_order.OrderId} deleted successfully", "Delete order");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete order");
            }

        }
        private void btnClose_Click(object sender, RoutedEventArgs e) => Close();
    }
}

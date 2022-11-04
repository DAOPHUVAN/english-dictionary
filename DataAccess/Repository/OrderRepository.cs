using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
namespace DataAccess
{

    public class OrderRepository : IntefaceOrderRepository
    {
        public Order1 GetOrderById(int orderId) => IOrderRepository.Instance.GetOrderById(orderId);
        public IEnumerable<Order1> GetOrders() => IOrderRepository.Instance.GetOrderList();
        public void InsertOrder(Order1 order) => IOrderRepository.Instance.AddNew(order);
        public void DeleteOrder(Order1 order) => IOrderRepository.Instance.Remove(order);
        public void UpdateOrder(Order1 order) => IOrderRepository.Instance.Update(order);

    }

    public interface IntefaceOrderRepository
    {
        IEnumerable<Order1> GetOrders();
        Order1 GetOrderById(int orderId);
        void InsertOrder(Order1 order);
        void DeleteOrder(Order1 order);
        void UpdateOrder(Order1 order);
    }

}

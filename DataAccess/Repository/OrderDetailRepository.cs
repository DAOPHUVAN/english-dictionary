using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
namespace DataAccess
{
    public class OrderDetailRepository : IntefaceOrderDetailRepository
    {
        public OrderDetail GetOrderDetailById(int orderId) => IOrderDetailRepository.Instance.GetOrderDetailById(orderId);
        public IEnumerable<OrderDetail> GetOrderDetails() => IOrderDetailRepository.Instance.GetOrderDetailList();
        public void InsertOrderDetail(OrderDetail orderDetail) => IOrderDetailRepository.Instance.AddNew(orderDetail);
        public void DeleteOrderDetail(OrderDetail orderDetail) => IOrderDetailRepository.Instance.Remove(orderDetail);
        public void UpdateOrderDetail(OrderDetail orderDetail) => IOrderDetailRepository.Instance.Update(orderDetail);

    }

    public interface IntefaceOrderDetailRepository
    {
        IEnumerable<OrderDetail> GetOrderDetails();
        OrderDetail GetOrderDetailById(int orderId);
        void InsertOrderDetail(OrderDetail orderDetail);
        void DeleteOrderDetail(OrderDetail orderDetail);
        void UpdateOrderDetail(OrderDetail orderDetail);
    }

}

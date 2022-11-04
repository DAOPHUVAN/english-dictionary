using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using Microsoft.EntityFrameworkCore;
namespace DataAccess
{
    public class IOrderDetailRepository
    {
        private static IOrderDetailRepository instance = null;
        private static readonly object instanceLock = new object();
        private IOrderDetailRepository() { }
        public static IOrderDetailRepository Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new IOrderDetailRepository();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<OrderDetail> GetOrderDetailList()
        {
            List<OrderDetail> orderDetails;
            try
            {
                var myStockDB = new MemberDAO();
                orderDetails = myStockDB.OrderDetail.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetails;
        }

        public OrderDetail GetOrderDetailById(int orderDetailId)
        {
            OrderDetail orderDetail = null;
            try
            {
                var myStockDB = new MemberDAO();
                orderDetail = myStockDB.OrderDetail.SingleOrDefault(x => x.OrderId == orderDetailId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetail;
        }

        public void AddNew(OrderDetail orderDetail)
        {
            try
            {
                OrderDetail _orderDetail = GetOrderDetailById(orderDetail.OrderId);
                if (_orderDetail == null)
                {
                    var myStockDB = new MemberDAO();
                    myStockDB.OrderDetail.Add(orderDetail);
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The order is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(OrderDetail orderDetail)
        {
            try
            {
                OrderDetail _orderDetail = GetOrderDetailById(orderDetail.OrderId);
                if (_orderDetail != null)
                {
                    var myStockDB = new MemberDAO();
                    myStockDB.Entry<OrderDetail>(orderDetail).State = EntityState.Modified;
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The order does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(OrderDetail orderDetail)
        {
            try
            {
                OrderDetail _orderDetail = GetOrderDetailById(orderDetail.OrderId);
                if (_orderDetail != null)
                {
                    var myStockDB = new MemberDAO();
                    myStockDB.OrderDetail.Remove(orderDetail);
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The order does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

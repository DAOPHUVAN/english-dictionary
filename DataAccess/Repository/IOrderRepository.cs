using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using Microsoft.EntityFrameworkCore;
namespace DataAccess
{
    public class IOrderRepository
    {
        private static IOrderRepository instance = null;
        private static readonly object instanceLock = new object();
        private IOrderRepository() { }
        public static IOrderRepository Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new IOrderRepository();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Order1> GetOrderList()
        {
            List<Order1> orders;
            try
            {
                var myStockDB = new MemberDAO();
                orders = myStockDB.IOrder.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orders;
        }

        public Order1 GetOrderById(int orderId)
        {
            Order1 order = null;
            try
            {
                var myStockDB = new MemberDAO();
                order = myStockDB.IOrder.SingleOrDefault(x => x.OrderId == orderId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return order;
        }

        public void AddNew(Order1 order)
        {
            try
            {
                Order1 _order = GetOrderById(order.OrderId);
                if (_order == null)
                {
                    var myStockDB = new MemberDAO();
                    myStockDB.IOrder.Add(order);
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

        public void Update(Order1 order)
        {
            try
            {
                Order1 _order = GetOrderById(order.OrderId);
                if (_order != null)
                {
                    var myStockDB = new MemberDAO();
                    myStockDB.Entry<Order1>(order).State = EntityState.Modified;
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

        public void Remove(Order1 order)
        {
            try
            {
                Order1 _order = GetOrderById(order.OrderId);
                if (_order != null)
                {
                    var myStockDB = new MemberDAO();
                    myStockDB.IOrder.Remove(order);
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

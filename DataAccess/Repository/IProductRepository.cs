using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using Microsoft.EntityFrameworkCore;
namespace DataAccess
{
    public class IProductRepository
    {
        private static IProductRepository instance = null;
        private static readonly object instanceLock = new object();
        private IProductRepository() { }
        public static IProductRepository Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new IProductRepository();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Product> GetProductList()
        {
            List<Product> products;
            try
            {
                var myStockDB = new MemberDAO();
                products = myStockDB.Product.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }
        public IEnumerable<Product> Search(string searchString)
        {
            // You could send back an empty result...
            if (String.IsNullOrWhiteSpace(searchString))
                return null;

            // Or you could convert it to a blank string
            if (searchString == null)
                searchString = "";
            List<Product> products;
            try
            {
                var myStockDB = new MemberDAO();
                products = myStockDB.Product.Where(                           
                         x =>     
                         x.ProductId == int.Parse(searchString) ||
                         (x.ProductName != null && x.ProductName.ToLower().Contains(searchString.ToLower())) ||
                         x.UnitPrice == double.Parse(searchString) ||
                         x.UnitslnStock == int.Parse(searchString) ).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }

        public Product GetProductById(int productId)
        {
            Product product = null;
            try
            {
                var myStockDB = new MemberDAO();
                product = myStockDB.Product.SingleOrDefault(x => x.ProductId == productId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }

        public void AddNew(Product product)
        {
            try
            {
                Product _product = GetProductById(product.ProductId);
                if (_product == null)
                {
                    var myStockDB = new MemberDAO();
                    myStockDB.Product.Add(product);
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The member is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Product product)
        {
            try
            {
                Product c = GetProductById(product.ProductId);
                if (c != null)
                {
                    var myStockDB = new MemberDAO();
                    myStockDB.Entry<Product>(product).State = EntityState.Modified;
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The member does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(Product product)
        {
            try
            {
                Product _product = GetProductById(product.ProductId);
                if (_product != null)
                {
                    var myStockDB = new MemberDAO();
                    myStockDB.Product.Remove(product);
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The member does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

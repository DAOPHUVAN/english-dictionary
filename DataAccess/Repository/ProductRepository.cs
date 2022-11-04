using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
namespace DataAccess
{
    public class ProductRepository : IntefaceProductRepository
    {
        public Product GetProductById(int productId) => IProductRepository.Instance.GetProductById(productId);
        public IEnumerable<Product> GetProducts() => IProductRepository.Instance.GetProductList();
        public IEnumerable<Product> Search(string input) => IProductRepository.Instance.Search(input);
        public void InsertProduct(Product product) => IProductRepository.Instance.AddNew(product);
        public void DeleteProduct(Product product) => IProductRepository.Instance.Remove(product);
        public void UpdateProduct(Product product) => IProductRepository.Instance.Update(product);

    }

    public interface IntefaceProductRepository
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> Search(string input);
        Product GetProductById(int productId);
        void InsertProduct(Product product);
        void DeleteProduct(Product product);
        void UpdateProduct(Product product);
    }

}

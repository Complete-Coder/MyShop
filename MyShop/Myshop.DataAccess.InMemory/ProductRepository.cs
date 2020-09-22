using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using MyShop.core.Models;

namespace Myshop.DataAccess.InMemory
{
    public class ProductRepository
    {
        ObjectCache Cache = MemoryCache.Default;
        List<Product> Products = new List<Product>();

        public ProductRepository() 
            {
            Products = Cache["Products"] as List<Product>;
            if (Products == null)
            {
                Products =new List<Product>();

            }
             }
        public void Commit()
        {
            Cache["Products"] = Products;
        }
        public void Insert(Product p)
        {
            Products.Add(p);
        }
        public void Update(Product Product)
        {
            Product productToUpdate = Products.Find(p => p.Id == Product.Id);

            if (productToUpdate != null)
            {
                productToUpdate = Product;
            }
            else
            {
                throw new Exception("Product Not Found");
            }
        }
        public Product Find(String Id)
        {
            Product product = Products.Find(p => p.Id == Id);

            if (product != null)
            {
                return product;
            }
            else
            {
                throw new Exception("Product Not Found");
            }
        }
        public IQueryable<Product> Collection()
        {
            return Products.AsQueryable();
        }

        public void Delete(String Id)
        {
            Product productToDelete = Products.Find(p => p.Id ==Id);

            if (productToDelete != null)
            {
                Products.Remove(productToDelete);
            }
            else
            {
                throw new Exception("Product Not Found");
            }
        }
    }
}

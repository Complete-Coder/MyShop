using MyShop.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using Myshop.DataAccess.InMemory;

namespace Myshop.DataAccess.InMemory
{
    public class ProductCategoryRepository
    {
        ObjectCache Cache = MemoryCache.Default;
        List<ProductCategory> ProductCategories = new List<ProductCategory>();

        public ProductCategoryRepository()
        {
            ProductCategories = Cache["ProductCategories"] as List<ProductCategory>;
            if (ProductCategories == null)
            {
                ProductCategories = new List<ProductCategory>();

            }
        }
        public void Commit()
        {
            Cache["ProductCategories"] = ProductCategories;
        }
        public void Insert(ProductCategory p)
        {
            ProductCategories.Add(p);
        }
        public void Update(ProductCategory ProductCategory)
        {
            ProductCategory productcategoryToUpdate = ProductCategories.Find(p => p.Id == ProductCategory.Id);

            if (productcategoryToUpdate != null)
            {
                productcategoryToUpdate = ProductCategory;
            }
            else
            {
                throw new Exception("Product Category Not Found");
            }
        }
        public ProductCategory Find(String Id)
        {
            ProductCategory productCategory = ProductCategories.Find(p => p.Id == Id);

            if (productCategory != null)
            {
                return productCategory;
            }
            else
            {
                throw new Exception("Product Category Not Found");
            }
        }
        public IQueryable<ProductCategory> Collection()
        {
            return ProductCategories.AsQueryable();
        }

        public void Delete(String Id)
        {
            ProductCategory productcategoryToDelete = ProductCategories.Find(p => p.Id == Id);

            if (productcategoryToDelete != null)
            {
                ProductCategories.Remove(productcategoryToDelete);
            }
            else
            {
                throw new Exception("Product Category Not Found");
            }
        }
    }
}


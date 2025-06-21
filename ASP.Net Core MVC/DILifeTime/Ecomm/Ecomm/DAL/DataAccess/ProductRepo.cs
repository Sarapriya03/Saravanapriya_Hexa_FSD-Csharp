using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.DataAccess
{
    public class ProductRepo : IProductRepo<Product>
    {
        public Product AddProduct(Product product)
        {
            using (ECommerceContext dbContext = new ECommerceContext())
            {
                dbContext.Products.Add(product); //This method will change entity state from Unchanged to ADDED
                dbContext.SaveChanges();//This method will observes current state of an entity and generates t-sql statement (insert into Product values(...)) 
                return product;
            }
        }

        public List<Product> GetAllProducts()
        {
            using (ECommerceContext dbContext = new ECommerceContext())
            {
                return dbContext.Products.ToList();
            }
        }

        public Product GetProductById(int id)
        {
            using (ECommerceContext dbContext = new ECommerceContext())
            {
                var existingProduct = dbContext.Products.Where(product => product.ProductId.Equals(id)).FirstOrDefault();

                return existingProduct;

            }
        }

        public Product RemoveProduct(int id)
        {
            using (ECommerceContext dbContext = new ECommerceContext())
            {
                var existingProduct = dbContext.Products.Where(product => product.ProductId.Equals(id)).FirstOrDefault();
                if (existingProduct != null)
                {
                    dbContext.Products.Remove(existingProduct);//This method will change entity state from Unchanged to REMOVED
                    dbContext.SaveChanges();//This method will observe current entity state and generate t-sql statement (delete from product where productid=id)
                }
                return existingProduct;

            }
        }

        public Product UpdateProduct(int id, Product product)
        {
            using (ECommerceContext dbContext = new ECommerceContext())
            {
                var existingProduct = dbContext.Products
                    .FirstOrDefault(p => p.ProductId == id);

                if (existingProduct != null)
                {
                    // Update the existing product's properties
                    existingProduct.ProductName = product.ProductName;
                    existingProduct.Category = product.Category;
                    existingProduct.ListPrice = product.ListPrice;

                    dbContext.SaveChanges(); // Apply changes to database
                }

                return existingProduct;
            }
        }


    }
}

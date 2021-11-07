using ShoppingCartAPI.Context;
using ShoppingCartAPI.Entities;
using ShoppingCartAPI.Repository.Contract;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartAPI.Repository.Implementation
{

    public class ProductRepository : IProductRepository<Product>
    {
        readonly ShoppingCartContext _shoppingCartContext;
        public ProductRepository(ShoppingCartContext context)
        {
            _shoppingCartContext = context;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _shoppingCartContext.Products.ToList();
        }

        public Product GetProduct(int Id)
        {
            return _shoppingCartContext.Products.FirstOrDefault(x=>x.Id == Id );
        }

        public Product CreateProduct(Product product)
        {
            _shoppingCartContext.Products.Add(product);
            _shoppingCartContext.SaveChanges();
            return product;
        }

        public Product UpdateProduct(Product product)
        {
            var oldProduct = _shoppingCartContext.Products.FirstOrDefault(s => s.Id == product.Id);
            if (oldProduct != null)
            {
                _shoppingCartContext.Entry<Product>(oldProduct).CurrentValues.SetValues(product);
                _shoppingCartContext.SaveChanges();
            }
            return product;
        }

        public Product DeleteProduct(int Id)
        {
            var product = _shoppingCartContext.Products.FirstOrDefault(s => s.Id == Id);
            if (product != null)
            {
                _shoppingCartContext.Products.Remove(product);
                _shoppingCartContext.SaveChanges();
            }
            return product;
        }
    }
}

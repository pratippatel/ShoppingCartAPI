using System.Collections.Generic;

namespace ShoppingCartAPI.Repository.Contract
{
    public interface IProductRepository<Product>
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProduct(int Id);
        Product CreateProduct(Product product);
        Product UpdateProduct(Product product);
        Product DeleteProduct(int Id);
    }
}

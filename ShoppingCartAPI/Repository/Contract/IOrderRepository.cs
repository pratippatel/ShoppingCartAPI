using System.Collections.Generic;

namespace ShoppingCartAPI.Repository.Contract
{
    public interface IOrderRepository<Order>
    {
        IEnumerable<Order> GetAllOrders();
        Order GetOrder(int Id);
        Order CreateOrder(Order product);
        Order UpdateOrder(Order product);
        Order DeleteOrder(int Id);
        IEnumerable<Order> GetUserOrders(int Id);
    }
}

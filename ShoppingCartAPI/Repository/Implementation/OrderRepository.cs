using Microsoft.EntityFrameworkCore;
using ShoppingCartAPI.Context;
using ShoppingCartAPI.Entities;
using ShoppingCartAPI.Repository.Contract;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartAPI.Repository.Implementation
{
    public class OrderRepository : IOrderRepository<Order>
    {
        readonly ShoppingCartContext _shoppingCartContext;
        public OrderRepository(ShoppingCartContext context)
        {
            _shoppingCartContext = context;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _shoppingCartContext.Orders.ToList();
        }

        public Order GetOrder(int Id)
        {
            return _shoppingCartContext.Orders.FirstOrDefault(x => x.Id == Id);
        }

        public Order CreateOrder(Order order)
        {
            _shoppingCartContext.Orders.Add(order);
            _shoppingCartContext.SaveChanges();
            return order;
        }

        public Order UpdateOrder(Order order)
        {
            var oldOrder = _shoppingCartContext.Orders.FirstOrDefault(s => s.Id == order.Id);
            if (oldOrder != null)
            {
                _shoppingCartContext.Entry<Order>(oldOrder).CurrentValues.SetValues(order);
                _shoppingCartContext.SaveChanges();
            }
            return order;
        }

        public Order DeleteOrder(int Id)
        {
            var order = _shoppingCartContext.Orders.FirstOrDefault(s => s.Id == Id);
            if (order != null)
            {
                _shoppingCartContext.Orders.Remove(order);
                _shoppingCartContext.SaveChanges();
            }
            return order;
        }

        public IEnumerable<Order> GetUserOrders(int Id)
        {
            return _shoppingCartContext.Orders.Include(x=>x.Product).Where(x=>x.UserId == Id);
        }
    }
}

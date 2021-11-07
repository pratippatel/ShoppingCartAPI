using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartAPI.Entities;
using ShoppingCartAPI.Repository.Contract;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingCartAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [EnableCors("AllowAll")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository<Order> _orderRepository;

        public OrdersController(IOrderRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // GET: api/<OrdersController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Order> orders = _orderRepository.GetAllOrders();
            return Ok(orders);
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_orderRepository.GetOrder(id));
        }

        // POST api/<OrdersController>
        [HttpPost]
        public IActionResult Post([FromForm] Order value)
        {
            return Ok(_orderRepository.CreateOrder(value));
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromForm] Order value)
        {
            return Ok(_orderRepository.UpdateOrder(value));
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_orderRepository.DeleteOrder(id));
        }

        [HttpGet]
        [Route("GetUserOrders/{id}")]
        public IActionResult GetUserOrders(int id)
        {
            return Ok(_orderRepository.GetUserOrders(id));
        }
    }
}

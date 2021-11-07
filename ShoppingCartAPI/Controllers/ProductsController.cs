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
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository<Product> _productRepository;

        public ProductsController(IProductRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            IEnumerable<Product> products = _productRepository.GetAllProducts();
            return Ok(products);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_productRepository.GetProduct(id));
        }

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Post([FromForm] Product value)
        {
            return Ok(_productRepository.CreateProduct(value));
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromForm] Product value)
        {
            return Ok(_productRepository.UpdateProduct(value));
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_productRepository.DeleteProduct(id));
        }
    }
}

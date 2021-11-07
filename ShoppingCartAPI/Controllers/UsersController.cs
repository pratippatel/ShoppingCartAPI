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
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository<User> _userRepository;

        public UsersController(IUserRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<User> users = _userRepository.GetAllUsers();
            return Ok(users);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_userRepository.GetUser(id));
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromForm] User value)
        {
            return Ok(_userRepository.CreateUser(value));
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromForm] User value)
        {
            return Ok(_userRepository.UpdateUser(value));
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_userRepository.DeleteUser(id));
        }
    }
}

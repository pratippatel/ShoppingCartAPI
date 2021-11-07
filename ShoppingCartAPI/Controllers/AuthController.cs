using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShoppingCartAPI.Context;
using ShoppingCartAPI.Entities;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace ShoppingCartAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    [EnableCors("AllowAll")]
    public class AuthController : ControllerBase
    {
        private IConfiguration _config;
        readonly ShoppingCartContext _shoppingCartContext;

        public AuthController(IConfiguration config, ShoppingCartContext context)
        {
            _config = config;
            _shoppingCartContext = context;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get([FromQuery] User login)
        {
            IActionResult response = Unauthorized();
            if (AuthenticateUser(login))
            {
                var user = _shoppingCartContext.Users.FirstOrDefault(x => x.Username == login.Username);
                var tokenString = GenerateJSONWebToken(login);
                response = Ok(new { token = tokenString, user = new { id = user.Id, username = user.Username } });
            }
            return response;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post([FromForm] User user)
        {
            IActionResult response = Unauthorized();
            var existedUser = _shoppingCartContext.Users.FirstOrDefault(x => x.Username == user.Username);
            if(existedUser != null)
            {
                return Conflict(new { message = "user already exist"  });
            }
            _shoppingCartContext.Users.Add(user);
            _shoppingCartContext.SaveChanges();
            if (AuthenticateUser(user))
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString, user = new { id = user.Id, username = user.Username  } });
            }
            return response;
        }

        private string GenerateJSONWebToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private bool AuthenticateUser(User login)
        {
            var user = _shoppingCartContext.Users.FirstOrDefault(x => x.Username == login.Username);
            if (user != null && user.Password == login.Password)
            {
                return true;
            }
            return false;
        }
    }
}

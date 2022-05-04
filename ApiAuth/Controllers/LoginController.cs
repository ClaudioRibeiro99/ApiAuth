using ApiAuth.Models;
using ApiAuth.Repositories;
using ApiAuth.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiAuth.Controllers
{
    [ApiController]
    [Route("v1")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] User model)
        {
            var user = UserRepositories.Get(model.Username, model.Password);

            if (user == null)
                return NotFound(new { message = "Usuario ou senha inválidos" });

            var token = TokenServices.GenerateToken(user);

            user.Password = "";

            return new
            {
                user = user,
                token = token
            };

        }
      
    }
}

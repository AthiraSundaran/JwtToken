using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JwtTocken1.Model;
using JwtTocken1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Serilog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JwtTocken1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly IuserService service;
        private IConfiguration config;
        public HomeController (IuserService services, IConfiguration confige)
        {
            service = services;
            config = confige;
        }
      
      

        // POST api/values
        [HttpPost]      
        public IActionResult Post([FromBody]UserLogin value)
        {
            if(value==null)
            {
                return BadRequest("invalid input");
            }
            var checking = service.Login(value);
            if(checking == null)
            {
                return BadRequest("No User Found");
            }
            var token = GetToken(checking);
            return Ok(token);
        }

        private string GetToken (User user)
        {
            var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var Credentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);
            Log.Information("hi");
            Log.Error(user.Role);
            var claims = new[]
            {
                new Claim (ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim (ClaimTypes.Name, user.UserName),
                new Claim (ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(
                    claims: claims,     
                    signingCredentials: Credentials,
                    expires: DateTime.Now.AddDays(1)
                 );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}


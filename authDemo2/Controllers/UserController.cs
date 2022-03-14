using authDemo2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace authDemo2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpGet("Admins")]
        [Authorize(Roles ="Administrator")]
        public IActionResult AdminsEndpoint() 
        {
            var currentUser = GetCurrentUser();
            return Ok($"Hi {currentUser.GivenName},you are an {currentUser.Role}");
        }
        [HttpGet("Sellers")]
        [Authorize(Roles = "Seller")]
        public IActionResult SellersEndpoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Hi {currentUser.GivenName},you are an {currentUser.Role}");
        }

        [HttpGet("with")]
        [Authorize(Roles = "Administrator,Seller")]
        public IActionResult AdminsAndSellerEndpoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Hi {currentUser.GivenName},you are an {currentUser.Role}");
        }

        [HttpGet("Public")]
        public IActionResult Public()
        {
            return Ok("Hi,you are public property");
        }
        private UserModel GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity!=null)
            {
                var userClaims = identity.Claims;
                return new UserModel
                {
                    UserName = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value,
                    EmailAdress = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value,
                    GivenName = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.GivenName)?.Value,
                    Surname = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Surname)?.Value,
                    Role = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value,
                };
            }
            return null;
        }
    }
}

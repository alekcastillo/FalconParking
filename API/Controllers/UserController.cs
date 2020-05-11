using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FalconParkingAPI.Controllers
{
    [ApiController]
    [Route("Users/")]
    public class UserController : Controller
    {
        [HttpPost("login")]
        [Produces("application/json")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult Login()
        {
            HttpContext.Session.SetString("CurrentUserId", "");
            return View();
        }
    }
}
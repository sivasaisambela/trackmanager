using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerCore.ServiceContracts;
using TaskManagerCore.ViewModels;

namespace TaskManagerCore.Controllers
{
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IUserService _usrSvc;

        public AccountController(IUserService usrSvc)
        {
            _usrSvc = usrSvc;
        }

        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]LoginViewModel loginViewModel)
        {
            var user = await _usrSvc.Authenticate(loginViewModel);
            if (user == null)
            {
                return BadRequest(new { message = "Username or Password is incorrect" });
            }
            else
            {
                return Ok(user);
            }
        }
    }
}

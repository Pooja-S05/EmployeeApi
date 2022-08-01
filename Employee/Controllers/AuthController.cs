using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee.Models;
using Employee.Services;
using Employee.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Controllers
{
    [ApiController]
     [Route("[controller]/[action]")]

    public class AuthController:ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService=authService;
        }
        [HttpPost]
        public ActionResult Login(Login User)
        {
              return Ok(_authService.LoginUser(User));
        }
    }
}

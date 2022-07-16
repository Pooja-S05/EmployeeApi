using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EmplyeeController : ControllerBase
    {
        public EmplyeeController()
        {
            
        }
        [HttpPost]
        public ActionResult CreateEmployee()
        {
            return Ok("Employee Created Successfully");
        }
    }
}
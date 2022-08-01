using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Employee.Models;
using Microsoft.IdentityModel.Tokens;
using Employee;
using Employee.DAL.Interface;

namespace Employee.Services
{
    public class AuthService
    {
        private readonly IEmployeeRepository _EmployeeRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration,IEmployeeRepository employeeRepository)
        {
            _EmployeeRepository = employeeRepository;
            _configuration=configuration;
        }

        public Dictionary<string, string> LoginUser(Login User)

    {

        User.Password = HashPassword.Sha256(User.Password);

        var result = new Dictionary<string, string>();

        var student = _EmployeeRepository.login(User);

        var tokenString = generateToken(student);

        result.Add("token", tokenString);

        return result;

    }
        private string generateToken(Employees employee)

        {

            var claims = setClaims(employee);

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityTokenHandler().CreateJwtSecurityToken(

                _configuration["Jwt:Issuer"],

                _configuration["Jwt:Audience"],

                    new ClaimsIdentity(claims),

                    DateTime.Now,

                    DateTime.Now.AddDays(1),

                    DateTime.Now,

                    signinCredentials);



            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return tokenString;

        }
        public  List<Claim> setClaims(Employees employee)
        {
            return new List<Claim>()
            {
                new Claim("Email",employee.EmailId),
                new Claim("Name",employee.Employeename),
            };
        }
    }
}

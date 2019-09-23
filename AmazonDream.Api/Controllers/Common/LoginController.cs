using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AmazonDream.BLL;
using AmazonDream.ViewModels;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace AmazonDream.Api.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        Login_BLL obj = new Login_BLL();

        private Microsoft.Extensions.Configuration.IConfiguration _config;





        public LoginController(Microsoft.Extensions.Configuration.IConfiguration config)
        {
            _config = config;
        }


        public string generateToken(string user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);




            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, user)
            };


            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);




            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        // GET: api/Login
        [HttpPost]
        public String Post([FromBody]LoginModel model)
        {
            var value = obj.login(model.Email, model.Password);

            if (value != null)
            {
                string[] user = value.Split(",");

                var token = generateToken(user[0]);
                value += "," + token;

            }


            return Newtonsoft.Json.JsonConvert.SerializeObject(value);
        }

    }
}

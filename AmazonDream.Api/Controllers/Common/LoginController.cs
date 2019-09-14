using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonDream.BLL;
using AmazonDream.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AmazonDream.Api.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        Login_BLL obj = new Login_BLL();


        // GET: api/Login
        [HttpPost]
        public String Post([FromBody]LoginModel model)
        {
            return obj.login(model.Email,model.Password);         
        }

    }
}

using System.Linq;
using AmazonDream.BLL;
using AmazonDream.DAL;
using AmazonDream.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AmazonDream.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerRegistrationController : ControllerBase
    {
        private Registration_BLL obj;
        public CustomerRegistrationController(IMapper mapper)
        {
            obj = new Registration_BLL(mapper);
        }

        public IActionResult Post([FromBody] CustomerModel model)           //User Registration
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (obj.CustomerRegistration(model))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}

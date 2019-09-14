using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonDream.BLL;
using AmazonDream.DAL;
using AmazonDream.Entities;
using AmazonDream.Models;
using AmazonDream.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AmazonDream.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerHomeController : ControllerBase
    {
        private Registration_BLL obj;
        public  SellerHomeController(IMapper mapper)
        {
            obj = new Registration_BLL(mapper);
        }

        // POST: api/sellerhome
        [HttpPost]
        public IActionResult Post([FromBody]  SellerModel model)
        {

            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            if(obj.SellerRegistration(model))
            {
                return Ok();
            }
            return BadRequest();
            
        }
    }
}

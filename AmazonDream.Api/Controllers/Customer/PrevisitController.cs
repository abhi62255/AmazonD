using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonDream.BLL;
using AmazonDream.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AmazonDream.Api.Controllers.Customer
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Customer")]
    public class PrevisitController : ControllerBase
    {
        private readonly Previsit_BLL obj;
        public PrevisitController(IMapper mapper)
        {
            obj = new Previsit_BLL(mapper);
        }

        [HttpGet("{id}")]
        public List<ProductModel> GetPrevisitedProducts(long id)         //returning list of productModel by customer ID
        {
            return obj.GetPrevisitedProducts(id);
        }

        [HttpPost("{Customer_ID}/{Product_ID}")]
        public IActionResult setPrevisit(long Customer_ID, long Product_ID)     //set previsit
        {
            if(obj.setPrevisit(Customer_ID, Product_ID))
            {
                return Ok();
            }
            return BadRequest();
        }



    }
}

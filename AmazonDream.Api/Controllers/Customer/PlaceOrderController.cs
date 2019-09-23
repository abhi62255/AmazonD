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
    public class PlaceOrderController : ControllerBase
    {
        private readonly PlaceOrder_BLL obj;
        public PlaceOrderController(IMapper mapper)
        {
            obj = new PlaceOrder_BLL(mapper);
        }


        // POST: api/PlaceOrder/add
        [HttpPost("add")]
        public IActionResult Post([FromBody] PlacedOrderModel model)
        {
            if(obj.PlaceOrder(model))
                return Ok();
            return BadRequest();
        }

        // GET: api/PlaceOrder/1
        [HttpGet("{id}")]
        public List<RecivedOrderModel> GetPlacedOrder(long id)
        {
           return obj.GetplacedOrder(id);
        }
        
    }
}

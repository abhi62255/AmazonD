using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonDream.BLL;
using AmazonDream.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AmazonDream.Api.Controllers.Customer
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerKartController : ControllerBase
    {
        private CustomerKart_BLL obj;

        public CustomerKartController(IMapper mapper)
        {
            obj = new CustomerKart_BLL(mapper);
        }



        

        // POST: api/CustomerKart/add
        [HttpPost("add")]
        public string Post([FromBody] KartModel model)           //Adding product to kart
        {
            var result = obj.AddToKart(model);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);

        }

        // PUT: api/CustomerKart/Increse/1
        [HttpPut("Increse/{id}")]                                       //incresing product Quantity in kart
        public string PutIncreseKartQuantity(long id)
        {
            var result =obj.IncreseKartQuantity(id);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }

        // PUT: api/CustomerKart/Decrese/1
        [HttpPut("Decrese/{id}")]                                       //Decresing product Quantity in kart
        public IActionResult PutDecreseKartQuantity(long id)
        {
            if (obj.DecreseKartQuantity(id))
            {
                return Ok();
            }
            return BadRequest();
        }

        // PUT: api/CustomerKart/RemoveItem
        [HttpPut("RemoveItem/{id}")]                                        //Remove One item from Kart
        public IActionResult PutRemoveKartItem(long id)
        {
            if (obj.RemoveKartItem(id))
            {
                return Ok();
            }
            return BadRequest();
        }

        // PUT: api/CustomerKart/Remove
        [HttpPut("Remove/{id}")]                                        //Clear KArt for customer by customer ID
        public IActionResult PutRemoveKart(long id)
        {
            if (obj.RemoveKart(id))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public List<ProductAndKartModel> GetKartForCustomer(long id)
        {
            return obj.GetKartForCustomer(id);
        }


    }
}

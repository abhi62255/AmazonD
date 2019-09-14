using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonDream.BLL;
using AmazonDream.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AmazonDream.Api.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private Address_BLL obj; 

        public AddressController(IMapper mapper)
        {
            obj = new Address_BLL(mapper);
        }

        // GET: api/Address/customer/1
        [HttpGet("customer/{id}")]
        public List<AddressModel> GetAddressCustomer(long id)         //get address with customer ID
        {
            return obj.GetAddressCustomer(id);
            
        }

        // GET: api/Address/seller/1
        [HttpGet("seller/{id}")]
        public List<AddressModel> GetAddressSeller(long id)         //get address with seller ID
        {
            return obj.GetAddressSeller(id);
        }

        //POST: api/address/add
        [HttpPost("add")]
        public IActionResult PostAddress(AddressModel address)           //add Address for Customer:Seller
        {
            if(obj.AddAddress(address))
            {
                return Ok();
            }
            return BadRequest();
        }

         [HttpDelete("delete/{id}")]
        public IActionResult DeleteAddress(long id)           //Delete Address for Customer:Seller by address ID
        {
            if (obj.DeleteAddress(id))
            {
                return Ok();
            }
            return BadRequest();
        }

    }
}

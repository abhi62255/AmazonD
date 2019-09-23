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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AmazonDream.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerHomeController : ControllerBase
    {
        private Registration_BLL obj;
        private SellerHome_BLL _sellerHome_BLL;
        private Address_BLL _address_BLL;
        public  SellerHomeController(IMapper mapper)
        {
            obj = new Registration_BLL(mapper);
            _sellerHome_BLL = new SellerHome_BLL(mapper);
            _address_BLL = new Address_BLL(mapper);
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

        // GET: api/sellerhome/placedorder/1
        [HttpGet("placedorder/{id}")]
        [Authorize(Roles = "Seller")]
        public List<RecivedOrderModel> GetPlacedOrder(long id)
        {
            return _sellerHome_BLL.OrderRecived(id);
        }

        [Authorize(Roles = "Seller")]
        [HttpPost("updateStatus/{status}/{id}")]
        public Boolean UpdateStatus(string status,long id)
        {
            return _sellerHome_BLL.UpdateStatus(status, id);
        }

    }
}

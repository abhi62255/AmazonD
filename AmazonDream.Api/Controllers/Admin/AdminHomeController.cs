using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonDream.BLL;
using AmazonDream.Models;
using AmazonDream.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AmazonDream.Api.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminHomeController : ControllerBase
    {

        private AdminHome_BLL obj;

        public AdminHomeController(IMapper mapper)
        {
            obj = new AdminHome_BLL(mapper);
        }


        // GET: api/AdminHome/product/Pending:Accepted:Deleted:All(Except deleted)
        [HttpGet("Product/{value}")]
        public List<ProductModel> GetProduct(string value)             //get all PRODUCT which are Pending:Accepted:Deleted
        {

            return obj.GetProduct(value);
        }

        // GET: api/AdminHome/Seller/Pending:Accepted:Deleted:All(Except deleted)
        [HttpGet("Seller/{value}")]
        public List<SellerModel> GetSeller(string value)             //get all SELLER which are Pending:Accepted:Deleted
        {

            return obj.GetSeller(value);
        }

        // PUT: api/AdminHome/Seller/Accepted:Deleted
        [HttpPut("Seller/{value}/{id}")]
        public IActionResult PutSeller(string value,long id)             //Respond to seller Request :Accepted:Deleted
        {
            var model = obj.PutSeller(value,id);

            if (model)
                return Ok();

            return BadRequest();
        }

        // PUT: api/AdminHome/Product/Accepted:Deleted
        [HttpPut("Product/{value}/{id}")]
        public IActionResult PutProduct(string value, long id)             //Respond to seller Product Request :Accepted:Deleted
        {
            var model = obj.PutProduct(value, id);

            if (model)
                return Ok();

            return BadRequest();
        }

        [HttpGet("ProductTrend")]
        public List<ProductModel> TrendingProduct()         //Get Trending Product
        {
            return obj.TrendingProduct(); 
        }


        [HttpGet("ProductTrendRequest")]
        public List<ProductModel> TrendRequestProduct()         //Get Trending Product
        {
            return obj.TrendRequestProduct();
        }

        [HttpPut("TrendResponse/{value}/{id}")]
        public IActionResult TrendResponse(string value,int id)         //Give Trend response True:False
        {
            var model = obj.TrendResponse(value, id);
            if (model)
                return Ok();

            return BadRequest();
        }

        [HttpGet("PlacedOrder")]
        public List<RecivedOrderModel> GetPlacedOrder()
        {
            return obj.OrderRecived();
        }


    }
}

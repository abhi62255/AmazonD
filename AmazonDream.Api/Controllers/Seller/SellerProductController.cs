using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonDream.BLL;
using AmazonDream.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Serialization.Json;


namespace AmazonDream.Api.Controllers.Seller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerProductController : ControllerBase
    {

        private SellerProduct_BLL obj;
        public SellerProductController(IMapper mapper)
        {
            obj = new SellerProduct_BLL(mapper);
        }


        // POST: api/SellerProduct/product
        [HttpPost("product")]
        public long PostProduct([FromBody] ProductModel model)        //add product
        {
            return (obj.AddProduct(model));   
        }


        // POST: api/SellerProduct/productPicture
        [HttpPost("productPicture")]
        public IActionResult PostProductPicture([FromBody] ProductPictureModel model)        //add product Picture
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (obj.AddProductPicture(model))
            {
                return Ok();
            }
            return BadRequest();
        }


        // GET: api/SellerProduct/1
        [HttpGet("{id}")]
        public ProductModel GetProduct(long id)       //Get Product by ProductID
        {
            return obj.GetProduct(id);
        }

        // GET: api/SellerProduct/all/1
        [HttpGet("all/{id}")]
        public List<ProductModel> GetProductsAll(long id)       //Get product by sellerID
        { 
            return obj.GetProductsAll(id);
        }

        // GET: api/SellerProduct/pending/1
        [HttpGet("Pending/{id}")]
        public List<ProductModel> GetProductsPending(long id)       //Get product by sellerID
        {
            return obj.GetProductsPending(id);
        }

        // GET: api/SellerProduct/accepted/1
        [HttpGet("Accepted/{id}")]
        public List<ProductModel> GetProductsActive(long id)       //Get product by sellerID
        {
            return obj.GetProductsActive(id);
        }

        // GET: api/SellerProduct/trending/True:False:Requested/1
        [HttpGet("Trending/{value}/{id}")]
        public List<ProductModel> GetProductsTrending(string value, long id)       //Get Trending product by sellerID
        {
            return obj.GetProductsTrending(value,id);
        }



        [HttpPut("update")]
        public IActionResult UpdateProduct(ProductModel model)          //update whole product 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (obj.UpdateProduct(model))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("updateValues")]
        public IActionResult UpdateProductValues(ProductValuesModel model)      //update product values
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (obj.UpdateProductValues(model))
            {
                return Ok();
            }
            return BadRequest();
        }


        [HttpPut("trendRequest/{value}/{id}")]
        public IActionResult ProductTrendRequest(string value,long id)      //Request product for trend 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (obj.ProductTrendRequest(value,id))
            {
                return Ok();
            }
            return BadRequest();
        }


        // PATCH: api/SellerProduct/delete/1
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteProduct(long id)             //soft delete product 
        {
            if (obj.DeleteProduct(id))
            {
                return Ok();
            }
            return BadRequest();
        }

    }
}

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
    [Authorize(Roles = "Customer")]
    public class WishlistController : ControllerBase
    {


        private readonly Wishlist_BLL obj;
        public WishlistController(IMapper mapper)
        {
            obj = new Wishlist_BLL(mapper);
        }


        // GET: api/Wishlist
        [HttpGet("customer/{id}")]
        public List<ProductModel> Get(long id)                  //Getting wishlist by customer ID
        {
            return obj.Getwishlist(id);



        }

        // POST: api/Wishlist
        [HttpPost]
        public IActionResult Post([FromBody] WishlistModel model)           //adding item to wishlist
        {
            if (obj.PostWIshlist(model))
                return Ok();
            return BadRequest();

        }

        [HttpDelete("item/{id}")]                       
        public Boolean DeleteWishlistItem(long id)                  //removing item from wishlist
        {
            if (obj.DeleteWishlistItem(id))
                return true;
            return false;
        }


        [HttpDelete("{id}")]
        public Boolean ClearWishlist(long id)                     //Clear Wishlist
        {
            if (obj.ClearWishlist(id))
                return true;
            return false;
        }
    }
}

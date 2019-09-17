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
    public class ProductController : ControllerBase
    {
        private readonly ProductSuggestion_BLL obj;
        public ProductController(IMapper mapper)
        {
            obj = new ProductSuggestion_BLL(mapper);
        }



        // GET: api/Product/1
        [HttpGet("{id}")]
        public ProductModel Get(long id)
        {
            return obj.GetProduct(id);
        }


        // GET: api/Product/picture/1
        [HttpGet("picture/{id}")]
        public List<string> GetProductPicture(long id)
        {
            return obj.GetProductPicture(id);
        }

       
    }
}

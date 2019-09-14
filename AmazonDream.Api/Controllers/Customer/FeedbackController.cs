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
    public class FeedbackController : ControllerBase
    {
        private readonly Feedback_BLL obj;
        public FeedbackController(IMapper mapper)
        {
            obj = new Feedback_BLL(mapper);
        }

        // Get: api/Feedback
        [HttpGet("{id}")]
        public List<FeedbackModel> GetFeedbacks(long id)            //Get feedback by product ID
        {
            return obj.GetFeedbacks(id);

            
        }


        // POST: api/Feedback
        [HttpPost]
        public IActionResult Post([FromBody] FeedbackModel model)             //Add review to Product
        {
            if(obj.AddFeedback(model))
            {
                return Ok();
            }
            return BadRequest();
        }


       
    }
}

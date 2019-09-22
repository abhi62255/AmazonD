using AmazonDream.DAL;
using AmazonDream.ViewModels;
using AmazonDream.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonDream.BLL
{
    public class Feedback_BLL
    {
        private readonly IMapper _mapper;
        public Feedback_BLL(IMapper mapper)
        {
            _mapper = mapper;
        }
        FeedbackDA _feedbackDA = new FeedbackDA();
        CustomerDA _customerDA = new CustomerDA();

        public Boolean AddFeedback(FeedbackModel model)             //Add review to Product
        {
            var entity = _mapper.Map<FeedbackModel, Feedback>(model);
            var ExistedFeedback = _feedbackDA.FeedbackExist(model.Product_ID, model.Customer_ID);
            if(ExistedFeedback != null)
            {
                ExistedFeedback.Rating = model.Rating;
                ExistedFeedback.Review = model.Review;
                if (_feedbackDA.UpdateFeedback(ExistedFeedback))            //if already existed then update
                    return true;
                return false;
            }


            
            if(_feedbackDA.AddFeedback(entity))                     //if not exist then add new
            {   
                return true;
            }
            return false;
        }

        public List<FeedbackModel> GetFeedbacks(long id)              //Get feedback by product ID
        {
            var entity = _feedbackDA.GetFeedbacksByProductID(id);
            var feedbacks = new List<FeedbackModel>();
            foreach(var feed in entity)
            {
                var model = _mapper.Map<Feedback, FeedbackModel>(feed);
                var customer = _customerDA.CustomerDetails(model.Customer_ID);

                model.CustomerName = customer.Name;

                feedbacks.Add(model);

            }
            
            return feedbacks;
        }

    }
}

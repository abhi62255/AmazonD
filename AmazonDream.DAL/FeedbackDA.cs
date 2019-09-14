using AmazonDream.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmazonDream.DAL
{
    public class FeedbackDA
    {
        AmazonDreamDbContext db = new AmazonDreamDbContext();

        public Boolean AddFeedback(Feedback entity)             //add feedback to product 
        {
            db.Feedback.Add(entity);
            db.SaveChanges();
            return true;
        }
        public List<Feedback> GetFeedbacksByProductID(long id)      //Getting Feedbacks by Product ID
        {
            return db.Feedback.Where(f => f.Product_ID == id).ToList();
        }
        public Feedback GetFeedback(long id)                //Getting Feedback by Feedback ID
        {
            return db.Feedback.Where(f => f.ID == id).FirstOrDefault();
        }
        public Boolean UpdateFeedback(Feedback entity)              //update feedback by Feedback ID
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        public Feedback FeedbackExist(long productID,long customerID)            //check if feedback of customer exist for product
        {
            var entity = db.Feedback.Where(f => f.Product_ID == productID && f.Customer_ID == customerID).FirstOrDefault();
            return entity;
        }

    }
}

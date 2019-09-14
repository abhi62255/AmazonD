using AmazonDream.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmazonDream.DAL
{
    public class SellerDA
    {
        AmazonDreamDbContext db = new AmazonDreamDbContext();



        public List<Seller> GetSellerByStatus(string value)           //Get all SELLER which are Pending:Accepted:Deleted:All
        {
            var entity = new List<Seller>();
            value = value.ToLower();
            if (value == "all")
            {
                entity = db.Seller.Where(o => o.Status != "Deleted").ToList();
                return entity;
            }

            entity = db.Seller.Where(o => o.Status == value).ToList();
            return entity;
        }




        public Boolean SellerRegistration(Seller model)         //Add Seller to database
        {
            db.Seller.Add(model);
            db.SaveChanges();
            return true;
        }


        public Seller GetSellerByID(long id)            //Get seller by ID
        {
            return db.Seller.Where(s => s.ID == id).FirstOrDefault();
        }

        public Boolean UpdateSeller(Seller entity)      //Update SELLER
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
            return true;

        }



    }
}

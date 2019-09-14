using AmazonDream.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonDream.DAL
{
    public class CustomerDA
    {
        AmazonDreamDbContext db = new AmazonDreamDbContext();


        public Boolean CustomerRegistration(Customer model)             //Add Customer to database(Registration)
        {
            db.Customer.Add(model);
            db.SaveChanges();
            return true;
        }

    }
}

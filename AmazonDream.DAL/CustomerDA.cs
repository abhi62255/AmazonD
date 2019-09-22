using AmazonDream.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Customer CustomerDetails(long id)                //get customer details
        {
            var customer = db.Customer.Where(c => c.ID == id).FirstOrDefault();
            return customer;

        }

    }
}

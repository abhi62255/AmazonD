using AmazonDream.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmazonDream.DAL
{
    public class CommonDA
    {
        AmazonDreamDbContext db = new AmazonDreamDbContext();

        public Boolean EmailExistance(string email)            //Checking if email is already registered or not
        {
            if (db.Admin.Where(e => e.Email == email).FirstOrDefault() == null)
            {
                if (db.Seller.Where(e => e.Email == email).FirstOrDefault() == null)
                {
                    if (db.Customer.Where(e => e.Email == email).FirstOrDefault() == null)
                    {
                        return false;
                    }

                }
            }
            return true;
        }


        public string login(string email,string password)
        {
            if (db.Admin.Where(e => e.Email == email && e.Password == password).FirstOrDefault() == null)
            {
                var seller = db.Seller.Where(e => e.Email == email && e.Password == password).FirstOrDefault();
                if (seller == null)
                {
                    var customer = db.Customer.Where(e => e.Email == email && e.Password == password).FirstOrDefault();
                    if (customer == null)
                    {
                        return null;
                    }
                    return "Customer,"+customer.ID;
                }
                else if(seller.Status == "Pending")
                {
                    return "SellerPending";
                }
                else if (seller.Status == "Deleted")
                {
                    return "SellerDeleted";
                }
                return "Seller,"+seller.ID;
            }
            return "Admin,1";
        }
    }
}

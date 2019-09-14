using AmazonDream.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AmazonDream.DAL
{
    public class AddressDA
    {
        AmazonDreamDbContext db = new AmazonDreamDbContext();


        public List<Address> GetAddressCustomer(long id)            //getting customer address by customer id
        {
            return db.Address.Where(a => a.Customer_ID == id).ToList();
        }
        public List<Address> GetAddressSeller(long id)            //getting Seller address by seller ID
        {
            return db.Address.Where(a => a.Seller_ID == id).ToList();
        }
        public Address GetAddress(long id)              //getting Address by address ID
        {
            return db.Address.Where(a => a.ID == id).FirstOrDefault();
        }

        public List<string> GetCity()           //retrive Cities name
        {
            return db.City.Select(c=>c.CityName).ToList();
        }
        public List<string> GetState()          //retrive States Name
        {
            return db.State.Select(c => c.StateName).ToList();
        }


        public Boolean AddAddress(Address entity)           //add Address for Customer:Seller
        {
            db.Address.Add(entity);
            try
            {
                db.SaveChanges();
            }
            catch { return false; }
            return true;
        }

       

        public Boolean DeleteAddress(long id)           //Delete Address for Customer:Seller by address ID
        {
            var address = db.Address.Where(a => a.ID == id).FirstOrDefault();
            db.Address.Remove(address);
            try
            {
                db.SaveChanges();
            }
            catch { return false; }
            return true;
        }

       



    }
}

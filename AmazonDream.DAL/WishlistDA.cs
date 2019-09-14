using AmazonDream.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmazonDream.DAL
{
    public class WishlistDA
    {
        AmazonDreamDbContext db = new AmazonDreamDbContext();

        public List<Wishlist> GetWishlist(long id)          //Get WIshlist product by customer ID
        {
            return db.Wishlist.Where(w => w.Customer_ID == id).ToList();
        }

        public Wishlist GetWishlistByID(long id)            //Get WIshlist by ID
        {
            return db.Wishlist.Where(w => w.ID == id).FirstOrDefault();
        }

        public Boolean PostWishlist(Wishlist entity)        //Add Wishlist
        {
            db.Wishlist.Add(entity);
            db.SaveChanges();
            return true;
        }

        public Boolean DeleteWishlist(long id)              //Clear Whole Wishlist by Customer ID
        {
            var wishlist = GetWishlist(id);
            foreach(var wish in wishlist)
            {
                db.Wishlist.Remove(wish);
                db.SaveChanges();
            }
            return true;
        }

        public Boolean DeleteWishItem(long id)          //delete item from kart  by Kart ID
        {
            var wish = GetWishlistByID(id);
            db.Wishlist.Remove(wish);
            db.SaveChanges();
            return true;
        }

        public Boolean checkingExistance(long customerID,long productID)        //Checking if row with Both id's exist or not
        {
            var entity = db.Wishlist.Where(k => k.Product_ID == productID && k.Customer_ID == customerID).FirstOrDefault();
            if (entity != null)
                return true;
            return false;
        }

    }
}

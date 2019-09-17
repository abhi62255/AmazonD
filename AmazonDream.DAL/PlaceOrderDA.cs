using AmazonDream.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmazonDream.DAL
{
    public class PlaceOrderDA
    {
        AmazonDreamDbContext db = new AmazonDreamDbContext();



        public long GetOrderNumber()                //get last order number
        {
            return db.PlacedOrder.OrderByDescending(o => o.ID).Select(o => o.OrderNumber).FirstOrDefault();
        }


        public Boolean PlaceOrder(List<PlacedOrder> entity)         //Place Order
        {

            foreach(var order in entity)
            {
                db.PlacedOrder.Add(order);
                try
                {
                    db.SaveChanges();
                    return true;
                }
                catch { return false; }
            }
            return true;
        }

        public List<PlacedOrder> OrderRecived(long id)              //By seller ID
        {
            return db.PlacedOrder.Where(o => o.Product.Seller_ID == id).ToList();
        }

        public Boolean UpdateStatus(string status,long id)           //Update Order Status
        {
            var order = db.PlacedOrder.Where(o => o.ID == id).FirstOrDefault();
            order.Status = status;
            db.Entry(order).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        public List<PlacedOrder> OrderRecived()              //Order Recived (for admin)
        {
            return db.PlacedOrder.ToList();
        }

        public List<PlacedOrder> OrderPlaced(long id)              //Order Placed (for Customer)
        {
            return db.PlacedOrder.Where(o => o.Customer_ID == id).ToList();
        }

    }
}

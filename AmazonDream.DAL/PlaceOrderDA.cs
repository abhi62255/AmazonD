using AmazonDream.Entities;
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

      


    }
}

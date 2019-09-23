using AmazonDream.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmazonDream.DAL
{
    public class KartDA
    {
        AmazonDreamDbContext db = new AmazonDreamDbContext();
        ProductDA _productDA = new ProductDA();



        public Kart GetKart(long id)                //Get Kart value by Kart ID
        {
            return db.Kart.Where(k => k.ID == id).FirstOrDefault();
        }

        public List<Kart> GetCustomerKart(long id)                //Get For a customer by customer ID
        {
            return db.Kart.Where(k => k.Customer_ID == id).ToList();
        }





        public Boolean AddToKart(Kart entity,Product product)               //Adding product to kart
        {
            if(_productDA.UpdateProduct(product))
            {
                var model = db.Kart.Where(k => k.Product_ID == entity.Product_ID && k.Customer_ID == entity.Customer_ID).FirstOrDefault();

                if (model == null)          //checking if that product alreday exist in kart or not
                {
                    db.Kart.Add(entity);
                }
                else    //If exit then only update Quantity in Kart
                {
                    model.Quantity += entity.Quantity; 
                    db.Entry(model).State = EntityState.Modified;
                }

                try
                {
                    db.SaveChanges();
                }
                catch { return false; }
                return true;
            }
            return false;
            
        }

       

        public Boolean UpdateKart(Kart entity,Product product)                //UpdateKart
        {
            if (_productDA.UpdateProduct(product))
            {
                db.Entry(entity).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                }
                catch { return false; }
                return true;
            }
            return false;
        }

        public Boolean RemoveKartItem(long id,Product product)          //remove one row from Kart
        {
            if (_productDA.UpdateProduct(product))
            {
                db.Kart.Remove(GetKart(id));
                try
                {
                    db.SaveChanges();
                }
                catch { return false; }
                return true;
            }
            return false;
        }

        public Boolean RemoveKart(long id,List<Product> products)          //remove Whole Kart for a customer
        {
            var entity = GetCustomerKart(id);
            foreach (var pro in products)               //update all products IN kart value
            {
                if (_productDA.UpdateProduct(pro) == false)
                    return false;
                
            }
            foreach(var kartItem in entity)             //removing product from kart
            {
                db.Kart.Remove(kartItem);

            }
            try
            {
                db.SaveChanges();
            }
            catch { return false; }
            return true;
        }

        public List<Kart> GetWholeKart()
        {
            return db.Kart.ToList();
        }

    }
}

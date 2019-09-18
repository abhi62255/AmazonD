using AmazonDream.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmazonDream.DAL
{
    public class PreVisitDA
    {
        AmazonDreamDbContext db = new AmazonDreamDbContext();
        ProductDA _productDA = new ProductDA();

        public Boolean AddPrevist(PreVisit entity)          //Add previsit for Cusromer
        {
            db.PreVisit.Add(entity);
            db.SaveChanges();
            return true;
        }

        public List<Product> GetPrevistProducts(long id)            //Return previst products for Customer by customer ID
        {
            var previsitProductID = db.PreVisit.Where(p => p.Customer_ID == id).Select(p => p.Product_ID).ToList();
            var products = new List<Product>();
            foreach(var productID in previsitProductID)
            {
                var product = db.Product.Where(p => p.ID == productID).FirstOrDefault();
                products.Add(product);
            }
            return products;
        }

        public Boolean checkExistance(long Customer_ID, long Product_ID)
        {
            var model = db.PreVisit.Where(p => p.Product_ID == Product_ID & p.Customer_ID == Customer_ID).FirstOrDefault();

            if (model == null)
                return false;
            return true;
        }

    }
}

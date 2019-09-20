using AmazonDream.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AmazonDream.DAL
{
    public class ProductDA
    {
        AmazonDreamDbContext db = new AmazonDreamDbContext();

       

        public Product GetProduct(long id)          //get Product by Product ID
        {
            return (db.Product.Where(p => p.ID == id).FirstOrDefault());
        }
        public List<Product> GetProductsAll(long id)        //get all product by seller ID
        {
            return (db.Product.Where(p => p.Seller_ID == id && p.ProductStatus != "Deleted").ToList());
        }
        public List<Product> GetProductsPending(long id)        //get Pending product by seller ID
        {
            return (db.Product.Where(p => p.Seller_ID == id && p.ProductStatus =="Pending").ToList());
        }
        public List<Product> GetProductsActive(long id)         //get Active product by seller ID
        {
            return (db.Product.Where(p => p.Seller_ID == id && p.ProductStatus == "Accepted").ToList());
        }
        public List<Product> GetProductsTrending(string value,long id)         //get Trending or non trending product by seller ID
        {
            return (db.Product.Where(p => p.Seller_ID == id && p.ProductTrend == value).ToList());
        }

        public List<ProductPicture> GetProductPicture(long id)              //get product picture
        {
            return db.ProductPicture.Where(p => p.Product_ID == id).ToList();
        }

        public string GetSingleProductPicture(long id)              //get single product picture(use for thumb nail)
        {
            return db.ProductPicture.Where(p => p.Product_ID == id).Select(p=>p.PicturePath).FirstOrDefault();
        }


        public List<Product> GetProductByProductStatus(string value)           //get all product which are Pending:Accepted:Deleted:all
        {
            var entity = new List<Product>();
            value = value.ToLower();
            if (value == "all")
            {
                entity = db.Product.Where(o => o.ProductStatus != "Deleted").ToList();
                return entity;
            }

            entity = db.Product.Where(o => o.ProductStatus == value).ToList();
            return entity;
        }

        public List<Product> TrendingProduct()              //Get Trending Product
        {
            return db.Product.Where(p => p.ProductTrend == "True").ToList();
        }

        public List<Product> TrendRequestProduct()              //Get Trend Request Product
        {
            return db.Product.Where(p => p.ProductTrend == "Requested").ToList();
        }

        public List<Product> GetProductsBySearch(string searchTag)          //find a product by search tag
        {
            return db.Product.Where(p => p.ProductName.Contains(searchTag) || p.ProductCategory == searchTag || p.ProductSubCategory == searchTag).ToList();
        }

        public List<Product> GetProductsBYCategory(string category)             //To suggest similar products in single produts details
        {
            return db.Product.Where(p => p.ProductCategory == category && p.ProductStatus == "Accepted").ToList();
        }

        public List<Product> GetProductsBYSubCategory(string SubCategory)             //To suggest similar products by sub category
        {
            return db.Product.Where(p => p.ProductSubCategory == SubCategory && p.ProductStatus == "Accepted").ToList();
        }



        public long AddProduct(Product entity)       //add Product 
        {
            db.Product.Add(entity);
            db.SaveChanges();
            return entity.ID;

        }


        public Boolean AddProductPicture(ProductPicture entity)     //add Product Picture
        {
            db.ProductPicture.Add(entity);
            try { db.SaveChanges(); }
            catch { return false; }

            return true;

        }
        public Boolean UpdateProduct(Product entity)        //Update Product
        {
            db.Entry(entity).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch { return false; }
            return true;

        }


        public Boolean DeleteProduct(Product entity)        //Soft Delete Product
        {
            db.Entry(entity).State = EntityState.Modified;
            try { db.SaveChanges(); }
            catch { return false; }
            return true;

        }
    }
}

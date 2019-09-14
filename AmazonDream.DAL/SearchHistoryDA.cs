using AmazonDream.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmazonDream.DAL
{
    public class SearchHistoryDA
    {
        AmazonDreamDbContext db = new AmazonDreamDbContext();


        public Boolean AddSearchHistory(SearchHistory entity)           //Add search history
        {
            db.SearchHistory.Add(entity);
            db.SaveChanges();
            return true;
        }
        public List<string> GetSearchTagsForCustomer(long id)       //get search Tags By customer ID
        {
            var searchTags = db.SearchHistory.Where(s => s.Customer_ID == id).Select(s => s.SearchTag).ToList();

            return searchTags;          //use search Tags for Product Suggessions
        }
    }
}

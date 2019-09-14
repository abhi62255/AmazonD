using AmazonDream.DAL;
using AmazonDream.Entities;
using AmazonDream.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AmazonDream.BLL
{
    public class ProductSuggestion_BLL
    {
        private readonly IMapper _mapper;
        public ProductSuggestion_BLL(IMapper mapper)
        {
            _mapper = mapper;
        }
        PreVisitDA _preVisitDA = new PreVisitDA();
        ProductDA _productDA = new ProductDA();
        WishlistDA _wishlistDA = new WishlistDA();

        List<ProductModel> suggestedProductsList = new List<ProductModel>();

        public List<ProductModel> GetSuggestedProductsKnownUser(long id)                 //product Suggession for for know user
        {

            
            var products = _productDA.TrendingProduct();            //by trending

            if (products != null)
                AddProductToSuggestionList(products);

            products = _preVisitDA.GetPrevistProducts(id);          //by previst

            if (products != null)
                AddProductToSuggestionList(products);


            var wishlists = _wishlistDA.GetWishlist(id);             //by wishlist
            products = null;
            foreach(var wish in wishlists)
            {
                var product = _productDA.GetProduct(wish.Product_ID);
                products.Add(product);
            }

            if (products != null)
                AddProductToSuggestionList(products);
            

            return suggestedProductsList;
        }


        public List<ProductModel> GetSuggestedProductsUnknownUser()                 //product Suggession for for unknow user
        {
            var products = _productDA.TrendingProduct();            //by trending

            if (products != null)
                AddProductToSuggestionList(products);

            return suggestedProductsList;
        }
        

        public void AddProductToSuggestionList(List<Product> products)
        {
            foreach (var product in products)
            {
                var productBySubCategoryList = _productDA.GetProductsBYSubCategory(product.ProductSubCategory);

                foreach (var pro in productBySubCategoryList)
                {
                    var model = _mapper.Map<Product, ProductModel>(pro);
                    if(suggestedProductsList.FirstOrDefault(p=>p.ID == model.ID) == null)
                        suggestedProductsList.Add(model);
                }
            }
        }




    }
}

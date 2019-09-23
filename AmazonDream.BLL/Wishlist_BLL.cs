using AmazonDream.DAL;
using AmazonDream.ViewModels;
using AmazonDream.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonDream.BLL
{
    public class Wishlist_BLL
    {
        private readonly IMapper _mapper;
        public Wishlist_BLL(IMapper mapper)
        {
            _mapper = mapper;
        }
        WishlistDA _wishlistDA = new WishlistDA();
        ProductDA _productDA = new ProductDA();
        SellerDA _sellerDA = new SellerDA();



        public Boolean PostWIshlist(WishlistModel model)            //adding product ot wishlist
        {
            if (_wishlistDA.checkingExistance(model.Customer_ID, model.Product_ID))         //If already exist then do nothing
                return true;

            var entity = _mapper.Map<WishlistModel, Wishlist>(model);
            if (_wishlistDA.PostWishlist(entity))
                return true;
            return false;

        }

        public List<ProductModel> Getwishlist(long id)
        {
            var productList = new List<ProductModel>();
            var entity = _wishlistDA.GetWishlist(id);           // Getting Wishlist Rows
              
            foreach(var wish in entity)
            {
                var product = _productDA.GetProduct(wish.Product_ID);           //finding product by product ID
                var modelP = _mapper.Map<Product, ProductModel>(product);       //converting product to productModel   
                modelP.Seller_ID = wish.ID;             //assign wish id to seller ID(need to change it later)
                var seller = _sellerDA.GetSellerByID(product.Seller_ID);
                modelP.SellerName = seller.Name;
                modelP.PicturePath = _productDA.GetSingleProductPicture(product.ID);
                productList.Add(modelP);
            }
            return productList;
        }


        public Boolean DeleteWishlistItem(long id)          //delete one row from Wishlist
        {
            if (_wishlistDA.DeleteWishItem(id))
                return true;
            return false;

        }

        public Boolean ClearWishlist(long id)          //Clear Wishlist
        {
            if (_wishlistDA.DeleteWishlist(id))
                return true;
            return false;

        }



    }
}

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

        public List<ProductModel> GetProducts()                         //get product for all user 
        {
            var products = _productDA.GetProductByProductStatus("Accepted");
            var productList = new List<ProductModel>();
            foreach(var product in products)
            {
                var model = _mapper.Map<Product, ProductModel>(product);
                productList.Add(model);
            }

            return productList;
        }



        public void AddProductToSuggestionList(List<Product> products)
        {
            foreach (var product in products)
            {
                var productBySubCategoryList = _productDA.GetProductsBYSubCategory(product.ProductSubCategory);

                foreach (var pro in productBySubCategoryList)
                {
                    if(pro.ProductStatus == "Accepted")
                    {
                        var model = _mapper.Map<Product, ProductModel>(pro);
                        if (suggestedProductsList.FirstOrDefault(p => p.ID == model.ID) == null)
                            suggestedProductsList.Add(model);
                    }
                    
                }
            }
        }

        public List<ProductModel> SimilarProducts(long id)
        {
            var productModelList = new List<ProductModel>();
            var productByID = _productDA.GetProduct(id);
            var SimilarProductList = _productDA.GetProductsBYSubCategory(productByID.ProductSubCategory);

            foreach(var product in SimilarProductList)
            {
                var model = _mapper.Map<Product, ProductModel>(product);
                productModelList.Add(model);
            }
            return productModelList;

        }



        public ProductModel GetProduct(long id)                 //get Product
        {
            var entity = _productDA.GetProduct(id);
            return _mapper.Map<Product, ProductModel>(entity);
        }

        public List<string> GetProductPicture(long id)          //get ProductPicture
        {
            var pictureList = new List<string>();
            var modelPP = _productDA.GetProductPicture(id);

            foreach(var pic in modelPP)
            {
                pictureList.Add(pic.PicturePath);
            }

            return pictureList;
        }


    }
}

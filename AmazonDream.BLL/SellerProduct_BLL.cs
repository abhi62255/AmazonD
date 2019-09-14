using AmazonDream.DAL;
using AmazonDream.Entities;
using AmazonDream.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonDream.BLL
{
    public class SellerProduct_BLL
    {
        ProductDA obj = new ProductDA();

        private readonly IMapper _mapper;
        public SellerProduct_BLL(IMapper mapper)
        {
            _mapper = mapper;
        }


        public Boolean AddProduct(ProductModel model)       //Add Product 
        {
            var entity = _mapper.Map<ProductModel, Product>(model);
            entity.ProductStatus = "Pending";
            entity.ProductQuantityInKart = 0;
            entity.ProductTrend = "False";

            if(obj.AddProduct(entity))
            {
                return true;
            }
            return false;

        }

        public Boolean AddProductPicture(ProductPictureModel model)     //add Product Picture
        {
            var entity = _mapper.Map<ProductPictureModel, ProductPicture>(model);

            if (obj.AddProductPicture(entity))
            {
                return true;
            }
            return false;

        }



        public ProductModel GetProduct(long id)         //get product by product ID
        {
            var entity = _mapper.Map<Product, ProductModel>(obj.GetProduct(id));
            return (entity);

        }

        public List<ProductModel> GetProductsAll(long id)       //get all product by seller ID
        {
            var model = new List<ProductModel>();
            var entity = obj.GetProductsAll(id);
            foreach (var i in entity)
            {
                model.Add(_mapper.Map<Product, ProductModel>(i));
            }

            return (model);



        }
        public List<ProductModel> GetProductsPending(long id)       //get pending product by seller ID
        {
            var model = new List<ProductModel>();
            var entity = obj.GetProductsPending(id);
            foreach (var i in entity)
            {
                model.Add(_mapper.Map<Product, ProductModel>(i));
            }

            return (model);



        }
        public List<ProductModel> GetProductsActive(long id)        //get Active product by seller ID
        {
            var model = new List<ProductModel>();
            var entity = obj.GetProductsActive(id);
            foreach (var i in entity)
            {
                model.Add(_mapper.Map<Product, ProductModel>(i));
            }

            return (model);
        }
        public List<ProductModel> GetProductsTrending(string value, long id)        //get Trending product by seller ID
        {
            var model = new List<ProductModel>();
            var entity = obj.GetProductsTrending(value,id);
            foreach (var i in entity)
            {
                model.Add(_mapper.Map<Product, ProductModel>(i));
            }

            return (model);
        }

        public Boolean UpdateProduct(ProductModel model)        //Update Whole product
        {
            var entity = _mapper.Map<ProductModel, Product>(model);
            entity.ProductStatus = "Pending";

            if (obj.UpdateProduct(entity))
            {
                return true;
            }
            return false;

        }


        public Boolean UpdateProductValues(ProductValuesModel model)        //change(Update) values of quantity,price,discount
        {
            var entity = obj.GetProduct(model.ID);

            if (entity != null)
            {
                entity.ProductPrice = model.ProductPrice;
                entity.ProductQuantity = model.ProductQuantity;
                entity.ProductDiscount = model.ProductDiscount;
                if (obj.UpdateProduct(entity))
                {
                    return true;
                }
                return false;

            }
            else
            {
                return false;
            }

        }

        public Boolean ProductTrendRequest(long id)           //product trend request
        {
            var model = obj.GetProduct(id);
            if (model != null)
            {
                model.ProductTrend = "Requested";
                if (obj.UpdateProduct(model))
                {
                    return true;
                }
                return false;

            }
            else
            {
                return false;
            }
        }

        public Boolean DeleteProduct(long id)           //to soft delete product
        {
            var model = obj.GetProduct(id);
            if (model != null)
            {
                model.ProductStatus = "Deleted";
                if(obj.DeleteProduct(model))
                {
                    return true;
                }
                return false;

            }
            else
            {
                return false;
            }
        }



    }
}

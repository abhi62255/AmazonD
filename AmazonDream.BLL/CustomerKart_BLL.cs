using AmazonDream.DAL;
using AmazonDream.Entities;
using AmazonDream.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonDream.BLL
{
    public class CustomerKart_BLL
    {
        KartDA obj = new KartDA();
        ProductDA _productDA = new ProductDA();

        private readonly IMapper _mapper;
        public CustomerKart_BLL(IMapper mapper)
        {
            _mapper = mapper;
        }

        public string AddToKart(KartModel model)           //Adding product to kart
        {
            var productEntity = ProductAvailability(model.Product_ID, model.Quantity);
            if (productEntity != null)                                                          //Checking Product Availability
            {
                    productEntity.ProductQuantityInKart += model.Quantity;

                    var entity = _mapper.Map<KartModel, Entities.Kart>(model);
                    entity.DateTime = DateTime.Now;

                    if (obj.AddToKart(entity, productEntity))
                    {
                        return "Product Added to Kart";
                    }
                    return "Bad Request";

            }
            return "Product Not Available";
        }

        public Product ProductAvailability(long id, int quantity)               //Checking Product Availability
        {
            var productEntity = _productDA.GetProduct(id);       //checking if product exists
            if (productEntity != null)
            {
                var availableQuantity = productEntity.ProductQuantity - productEntity.ProductQuantityInKart;
                if (availableQuantity >= quantity)             //checking if the required quantity is available or not 
                {
                    return productEntity;
                }
            }
            return null;
        }

        public string IncreseKartQuantity(long id)         //Incresing Quantity By One
        {
            var kart = obj.GetKart(id);
            if (kart != null)
            {
                var product = ProductAvailability(kart.Product_ID, 1);
                if (product != null)        //checking Product Availability
                {
                    product.ProductQuantityInKart += 1;

                    kart.Quantity += 1;
                    if (obj.UpdateKart(kart, product))
                        return "true";
                }
                return "Product Not Available";
            }
            return "false";
        }
        public Boolean DecreseKartQuantity(long id)             //Decresing Quantity By One
        {
            var kart = obj.GetKart(id);
            if (kart != null)
            {
                if (kart.Quantity != 0)
                {
                    var product = _productDA.GetProduct(kart.Product_ID);          //getting product whose ProductQuantityInKart in kart need to be alter
                    product.ProductQuantityInKart -= 1;

                    kart.Quantity -= 1;
                    if (obj.UpdateKart(kart, product))
                        return true;
                }
                return true;
            }
            return false;
        }

        public Boolean RemoveKartItem(long id)              //Remove One item from Kart
        {
            var kart = obj.GetKart(id);
            
            if(kart != null)
            {
                var product = _productDA.GetProduct(kart.Product_ID);
                product.ProductQuantityInKart -= kart.Quantity;

                if (obj.RemoveKartItem(id,product))
                    return true;
            }
            return false;

           
        }

        public Boolean RemoveKart(long id)              //Clear KArt for customer by customer ID
        {
            var products = new List<Product>();
            var modelK = obj.GetCustomerKart(id);

            foreach(var kart in modelK)
            {
                var pro = _productDA.GetProduct(kart.Product_ID);
                pro.ProductQuantityInKart -= kart.Quantity;
                products.Add(pro);
            }
            if (obj.RemoveKart(id,products))
                return true;
            return false;
        }

        public List<ProductAndKartModel> GetKartForCustomer(long id)
        {
            var kart = obj.GetCustomerKart(id);
            var _productAndKartList = new List<ProductAndKartModel>();

            foreach(var kartItem in kart)
            {
                var product = _productDA.GetProduct(kartItem.Product_ID);
                var model = new ProductAndKartModel();
                model = _mapper.Map<Product, ProductAndKartModel>(product);
                model.Quantity = kartItem.Quantity;
                model.DateTime = kartItem.DateTime;
                model.Product_ID = product.ID;
                model.ID = kartItem.ID;
                model.PicturePath = _productDA.GetSingleProductPicture(product.ID);
                model.Amount = (model.ProductPrice - (model.ProductPrice * model.ProductDiscount)/100)*model.Quantity;  //Calculating amout for product

                _productAndKartList.Add(model);

            }
            return _productAndKartList;


        }




    }
}

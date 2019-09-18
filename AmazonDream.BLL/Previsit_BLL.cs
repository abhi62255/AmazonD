using AmazonDream.DAL;
using AmazonDream.Entities;
using AmazonDream.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonDream.BLL
{
    public class Previsit_BLL
    {
        private readonly IMapper _mapper;
        public Previsit_BLL(IMapper mapper)
        {
            _mapper = mapper;
        }
        PreVisitDA _preVisitDA = new PreVisitDA();


        public List<ProductModel> GetPrevisitedProducts(long id)            //returning list of productModel
        {
            var listProduct = _preVisitDA.GetPrevistProducts(id);
            var listProductModel = new List<ProductModel>();

            foreach(var product in listProduct)
            {
                var productmodel = _mapper.Map<Product, ProductModel>(product);
                listProductModel.Add(productmodel);
            }
            return listProductModel;
        }

        public Boolean setPrevisit(long Customer_ID, long Product_ID)
        {
            var check = _preVisitDA.checkExistance(Customer_ID, Product_ID);        
            if (check == true)      //if exist then do nothing
                return true;

            var entity = new PreVisit();
            entity.Date = DateTime.Now;
            entity.Customer_ID = Customer_ID;
            entity.Product_ID = Product_ID;
            if(_preVisitDA.AddPrevist(entity))
            {
                return true;
            }
            return false;
        }


    }
}

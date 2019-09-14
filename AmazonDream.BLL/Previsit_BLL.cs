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


    }
}

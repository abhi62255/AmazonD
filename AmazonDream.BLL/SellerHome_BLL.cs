using AmazonDream.DAL;
using AutoMapper;
using System;
using System.Collections.Generic;
using AmazonDream.ViewModels;
using AmazonDream.Entities;

namespace AmazonDream.BLL
{
    public class SellerHome_BLL
    {


        private readonly IMapper _mapper;
        public SellerHome_BLL(IMapper mapper)
        {
            _mapper = mapper;
        }

        PlaceOrderDA _placeOrderDA = new PlaceOrderDA();
        ProductDA _productDA = new ProductDA();




        public List<RecivedOrderModel> OrderRecived(long id)
        {
            var entityList = _placeOrderDA.OrderRecived(id);
            var modelList = new List<RecivedOrderModel>();

            foreach(var entity in entityList)
            {
                var model = _mapper.Map<PlacedOrder, RecivedOrderModel>(entity);
                var product = _productDA.GetProduct(entity.Product_ID);
                model.ProductName = product.ProductName;
                model.Product_ID = product.ID;
                modelList.Add(model);
            }
            return modelList;
        }

        public Boolean UpdateStatus(string status,long id)
        {
            return _placeOrderDA.UpdateStatus(status, id);
        }



    }
}

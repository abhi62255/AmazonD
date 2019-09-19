using AmazonDream.DAL;
using AmazonDream.Entities;
using AmazonDream.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonDream.BLL
{
    public class PlaceOrder_BLL
    {
        PlaceOrderDA _placeOrderDA = new PlaceOrderDA();
        KartDA _kartDA = new KartDA();
        AddressDA _addressDA = new AddressDA();
        ProductDA _productDA = new ProductDA();
        SellerDA _sellerDA = new SellerDA();

        private readonly IMapper _mapper;
        public PlaceOrder_BLL(IMapper mapper)
        {
            _mapper = mapper;
        }


        public Boolean PlaceOrder(PlacedOrderModel model)
        {
            var orders = new List<PlacedOrder>();
            var modelK = _kartDA.GetCustomerKart(model.Customer_ID);

            var orderNumber = _placeOrderDA.GetOrderNumber();     //Creating Order number
            if (orderNumber == 0)
                orderNumber = 999;
            orderNumber += 1;

            var modelA = _addressDA.GetAddress(model.Address_ID);      //Creating Address
            string address = "Address Line : " + modelA.AddressLine + " City : " + modelA.City + " State : " + modelA.State +
                              " Postal Code : " + modelA.PostalCode + " Address Type : " + modelA.AddressType;

            foreach (var k in modelK)
            {

                //common start
                var order = new PlacedOrder();
                order.Customer_ID = model.Customer_ID;
                order.PaymentType = model.PaymentType;
                
                order.Address = address;
                order.DateTime = DateTime.Now;
                order.Status = "Order Placed";
                
                order.OrderNumber = orderNumber;
                //common finish


                var product = _productDA.GetProduct(k.Product_ID);
                order.Quantity = k.Quantity;
                var ActualPrice = product.ProductPrice - (product.ProductPrice * product.ProductDiscount) / 100;

                order.Amount = k.Quantity * ActualPrice;
                order.Product_ID = k.Product_ID;
                product.ProductQuantityInKart -= k.Quantity;            //releasing product IN kart value
                product.ProductQuantity -= k.Quantity;                  //Normelizing Quantity
                _kartDA.RemoveKartItem(k.ID,product);                   //remove from kart and updating product IN Kart value
                orders.Add(order);
            }
            if(_placeOrderDA.PlaceOrder(orders))
                return true;
            return false;
        }


        public List<RecivedOrderModel> GetplacedOrder(long id)
        {
            var entityList = _placeOrderDA.OrderPlaced(id);
            var modelList = new List<RecivedOrderModel>();

            foreach (var entity in entityList)
            {
                var model = _mapper.Map<PlacedOrder, RecivedOrderModel>(entity);
                var product = _productDA.GetProduct(entity.Product_ID);
                model.ProductName = product.ProductName;
                model.Product_ID = product.ID;
                model.Seller_ID = product.Seller_ID;
                var seller = _sellerDA.GetSellerByID(product.Seller_ID);
                model.SellerName = seller.Name;
                modelList.Add(model);
            }
            return modelList;
        }


    }
}

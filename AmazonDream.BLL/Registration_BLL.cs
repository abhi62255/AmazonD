using AmazonDream.Entities;
using System;
using AmazonDream.DAL;
using AutoMapper;
using AmazonDream.Models;
using AmazonDream.Common;
using AmazonDream.ViewModels;

namespace AmazonDream.BLL
{
    public class Registration_BLL
    {
        
        CustomerDA _customerDA = new CustomerDA();
        SellerDA _sellerDA = new SellerDA();
        CommonDA _commonDA = new CommonDA();
       
        private readonly IMapper _mapper;
        public Registration_BLL(IMapper mapper)
        {
            _mapper = mapper;
        }


        public Boolean SellerRegistration(SellerModel model)            //Seller Registration
        {
            if(_commonDA.EmailExistance(model.Email))
            {
                return false;
            }
            
            var entity = _mapper.Map<SellerModel, Seller>(model);
            entity.Password = Hashing.Hash(entity.Password);
            entity.Status = "Pending";
          

            if(_sellerDA.SellerRegistration(entity))
            {
                return true;
            }
            return false;
        }


        public Boolean CustomerRegistration(CustomerModel model)        //Customer Registration
        {
            if (_commonDA.EmailExistance(model.Email))
            {
                return false;
            }

            var entity = _mapper.Map<CustomerModel, Customer>(model);
            entity.Password = Hashing.Hash(entity.Password);

            if(_customerDA.CustomerRegistration(entity))
            {
                return true;
            }
            return false;
        }
    }
}

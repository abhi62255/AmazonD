using AmazonDream.DAL;
using AmazonDream.Entities;
using AmazonDream.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonDream.BLL
{
    public class Address_BLL
    {
        AddressDA _addressDA = new AddressDA();
        private readonly IMapper _mapper;

        public Address_BLL(IMapper mapper)
        {
            _mapper = mapper;
        }


        public Boolean AddAddress(AddressModel model)           //add Address for Customer:Seller
        {
            var entity = _mapper.Map<AddressModel, Address>(model);

            if(_addressDA.AddAddress(entity))
            {
                return true;
            }
            return false;
        }


        public List<AddressModel> GetAddressCustomer(long id)         //get address with customer ID
        {
            var addressList = new List<AddressModel>();
            var entity = _addressDA.GetAddressCustomer(id);

            foreach(var add in entity)
            {
                addressList.Add(_mapper.Map<Address, AddressModel>(add));
            }
            return addressList;
        
        }
        public List<AddressModel> GetAddressSeller(long id)         //get address with seller ID
        {
            var addressList = new List<AddressModel>();
            var entity = _addressDA.GetAddressSeller(id);

            foreach (var add in entity)
            {
                addressList.Add(_mapper.Map<Address, AddressModel>(add));
            }
            return addressList;

        }

        public Boolean DeleteAddress(long id)           //Delete Address for Customer:Seller by address ID
        {
            if (_addressDA.DeleteAddress(id))
                return true;
            return false;
        }

        public AddressModel GetAddress(long id)             //return address by address ID
        {
            var entity = _addressDA.GetAddress(id);
            var model = _mapper.Map<Address, AddressModel>(entity);
            return model;
        }

    }
}

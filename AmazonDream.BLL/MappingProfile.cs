using AmazonDream.Entities;
using AmazonDream.Models;
using AmazonDream.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonDream.BLL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Seller, SellerModel>();
            CreateMap<SellerModel, Seller>();

            CreateMap<Customer, CustomerModel>();
            CreateMap<CustomerModel, Customer>();

            CreateMap<Admin, AdminModel>();
            CreateMap<Admin, AdminModel>();

            CreateMap<Product, ProductModel>();
            CreateMap<ProductModel, Product>();

            CreateMap<ProductPicture, ProductPictureModel>();
            CreateMap<ProductPictureModel, ProductPicture>();

            CreateMap<Kart, KartModel>();
            CreateMap<KartModel, Kart>();

            CreateMap<Address, AddressModel>();
            CreateMap<AddressModel, Address>();

            CreateMap<PlacedOrder, PlacedOrderModel>();
            CreateMap<PlacedOrderModel, PlacedOrder>();

            CreateMap<Wishlist, WishlistModel>();
            CreateMap<WishlistModel, Wishlist>();

            CreateMap<Feedback, FeedbackModel>();
            CreateMap<FeedbackModel, Feedback>();

            CreateMap<PreVisit, PreVisitModel>();
            CreateMap<PreVisitModel, PreVisit>();

            CreateMap<PlacedOrder, RecivedOrderModel>();
            CreateMap<RecivedOrderModel, PlacedOrder>();

            CreateMap<Seller_AddressModel, Seller>();
            CreateMap<Seller, Seller_AddressModel>();
            CreateMap<Seller_AddressModel, Address>();
            CreateMap<Address, Seller_AddressModel>();
            
            CreateMap<ProductAndKartModel, Product>();
            CreateMap<Product, ProductAndKartModel>();



        }
    }
}

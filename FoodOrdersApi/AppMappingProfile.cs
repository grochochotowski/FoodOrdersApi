﻿using AutoMapper;
using FoodOrdersApi.Entities.Objects;
using FoodOrdersApi.Models.Address;
using FoodOrdersApi.Models.Cart;
using FoodOrdersApi.Models.Order;
using FoodOrdersApi.Models.Org;
using FoodOrdersApi.Models.Restaurant;
using FoodOrdersApi.Models.User;

namespace FoodOrdersApi
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<Address, AddressDto>();
            CreateMap<CreateAddressDto, Address>();

            CreateMap<Cart, CartDto>();
            CreateMap<CreateCartDto, Cart>();

            CreateMap<Meal, MealDto>();
            CreateMap<CreateMealDto, Meal>();

            CreateMap<Order, OrderDto>();
            CreateMap<CreateOrderDto, Order>();
            CreateMap<UpdateOrderDto, Order>();

            CreateMap<Org, OrgDto>();
            CreateMap<CreateOrgDto, Org>();
            CreateMap<UpdateOrgDto, Org>();

            CreateMap<Restaurant, RestaurantDto>();
            CreateMap<CreateRestaurantDto, Restaurant>();
            CreateMap<UpdateRestaurantDto, Restaurant>();

            CreateMap<User, UserDto>();
            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>();
        }
    }
}

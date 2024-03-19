﻿using AutoMapper;
using FoodOrdersApi.Entities.Objects;
using FoodOrdersApi.Entities;
using FoodOrdersApi.Models.Restaurant;

namespace FoodOrdersApi.Services
{
    public interface IRestaurantService
    {
        int Create(CreateRestaurantDto dto);
        IEnumerable<RestaurantDto> GetAll();
        RestaurantDto GetByID(int id);
        int Update(int id, UpdateRestaurantDto dto);
        int Delete(int id);
    }

    public class RestaurantService : IRestaurantService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public RestaurantService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        // Create new order
        public int Create(CreateRestaurantDto dto)
        {
            var order = _mapper.Map<Order>(dto);

            _context.Orders.Add(order);
            _context.SaveChanges();
            return order.Id;
        }


        // Get all orders
        public IEnumerable<RestaurantDto> GetAll()
        {
            var restaurants = _context.Restaurants.ToList();
            var restaurantDtos = _mapper.Map<List<RestaurantDto>>(restaurants);

            return restaurantDtos;
        }


        // Get order by ID
        public RestaurantDto GetByID(int id)
        {
            var restaurant = _context.Orders.FirstOrDefault(o => o.Id == id);
            if (restaurant == null) return null;

            var restaurantDto = _mapper.Map<RestaurantDto>(restaurant);

            return restaurantDto;
        }


        // Update order with id
        public int Update(int id, UpdateRestaurantDto dto)
        {
            var restaurant = _context.Restaurants.FirstOrDefault(o => o.Id == id);
            if (restaurant == null) return -1;

            restaurant.Name = dto.Name ?? restaurant.Name;
            restaurant.Description = dto.Description ?? restaurant.Description;

            _context.SaveChanges();
            return restaurant.Id;
        }


        // Update order with id
        public int Delete(int id)
        {
            var restaurant = _context.Restaurants.FirstOrDefault(o => o.Id == id);
            if (restaurant == null) return -1;

            _context.Restaurants.Remove(restaurant);
            _context.SaveChanges();
            return 1;
        }

    }
}

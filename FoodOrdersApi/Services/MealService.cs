﻿using AutoMapper;
using FoodOrdersApi.Entities;
using FoodOrdersApi.Entities.Objects;
using FoodOrdersApi.Models.Meal;

namespace FoodOrdersApi.Services
{
    public interface IMealService
    {
        int Create(CreateMealDto dto);
        IEnumerable<MealDto> GetAll();
        MealDto GetByID(int id);
        int Update(int id, UpdateMealDto dto);
        int Delete(int id);
    }

    public class MealService : IMealService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public MealService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        // Create new meal
        public int Create(CreateMealDto dto)
        {
            var meal = _mapper.Map<Meal>(dto);

            var isOrg = _context.Organizations.FirstOrDefault(o => o.Id == meal.RestaurantId);
            if (isOrg == null) return -1;

            _context.Meals.Add(meal);
            _context.SaveChanges();
            return meal.Id;
        }


        // Get all meal
        public IEnumerable<MealDto> GetAll()
        {
            var meals = _context.Meals.ToList();
            var mealDtos = _mapper.Map<List<MealDto>>(meals);

            return mealDtos;
        }


        // Get meal by ID
        public MealDto GetByID(int id)
        {
            var meal = _context.Meals.FirstOrDefault(o => o.Id == id);
            if (meal == null) return null;

            var mealDto = _mapper.Map<MealDto>(meal);

            return mealDto;
        }


        // Update meal with id
        public int Update(int id, UpdateMealDto dto)
        {
            var meal = _context.Meals.FirstOrDefault(o => o.Id == id);
            if (meal == null) return -1;

            meal.Name = dto.Name ?? meal.Name;
            meal.Description = dto.Description ?? meal.Description;

            _context.SaveChanges();
            return meal.Id;
        }


        // Update meal with id
        public int Delete(int id)
        {
            var meal = _context.Meals.FirstOrDefault(o => o.Id == id);
            if (meal == null) return -1;

            _context.Meals.Remove(meal);
            _context.SaveChanges();
            return 1;
        }

    }
}

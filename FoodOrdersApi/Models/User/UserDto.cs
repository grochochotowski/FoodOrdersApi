﻿using FoodOrdersApi.Models.Cart;

namespace FoodOrdersApi.Models.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string? SecondName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Note { get; set; }


        public int OrganizationId { get; set; }
    }
}

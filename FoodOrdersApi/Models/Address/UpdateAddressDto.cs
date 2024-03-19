﻿namespace FoodOrdersApi.Models.Address
{
    public class UpdateAddressDto
    {
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? Building { get; set; }
        public string? Premises { get; set; }
    }
}

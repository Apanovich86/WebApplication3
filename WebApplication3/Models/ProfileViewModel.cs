using System;

namespace WebApplication3.Models
{
    public class ProfileViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public DateTime? BirthDate { get; set; }
        public string ImagePath { get; set; }
    }
}
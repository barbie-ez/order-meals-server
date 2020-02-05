using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace order_meals_data.Entities
{
    public class UserModel : IdentityUser
    {
        [Required(ErrorMessage = "The first name field is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "The last name field is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "The date of birth field is required")]
        public DateTimeOffset DateOfBirth { get; set; }
        public string Token { get; set; }
        public ICollection<RoleModel> Roles { get; set; } = new List<RoleModel>();
        public ICollection<UserModel> Friends { get; set; } = new List<UserModel>();
    }
}

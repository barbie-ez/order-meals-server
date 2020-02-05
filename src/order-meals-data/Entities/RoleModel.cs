using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace order_meals_data.Entities
{
    public class RoleModel : IdentityRole
    {
        public RoleModel()
        {

        }

        public RoleModel(string roleName) : this()
        {
            Name = NormalizedName = roleName;
        }
        public string Description { get; set; }
    }
}

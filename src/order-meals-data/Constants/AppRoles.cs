using System;
using System.Collections.Generic;
using System.Text;

namespace order_meals_data.Constants
{
    public class AppRoles
    {
        public const string Administrator = "Administrator";
        public const string Member = "Member";

        public static IEnumerable<AppRoles> roles { get; set; }

    }
}

using order_meals_data.Repositories.Base.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace order_meals_data.Entities
{
    public class BaseModel :IEntityBase
    {
        public BaseModel()
        {
            this.DateCreated = DateUpdated = DateTime.Now;
        }
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}

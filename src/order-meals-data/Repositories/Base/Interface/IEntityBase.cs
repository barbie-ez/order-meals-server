using System;
using System.Collections.Generic;
using System.Text;

namespace order_meals_data.Repositories.Base.Interface
{
    public interface IEntityBase
    {
        Guid Id { get; set; }
        DateTime DateCreated { get; set; }
        DateTime DateUpdated { get; set; }
    }
}

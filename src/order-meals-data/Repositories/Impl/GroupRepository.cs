using order_meals_api.Data;
using order_meals_data.Entities;
using order_meals_data.Repositories.Base.Impl;
using order_meals_data.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace order_meals_data.Repositories.Impl
{
    public class GroupRepository : EntityBaseRepository<GroupModel>, IGroupRepository
    {
        public GroupRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

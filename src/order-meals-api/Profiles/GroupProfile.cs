using AutoMapper;
using order_meals_data.DTOs.Group;
using order_meals_data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace order_meals_api.Profiles
{
    public class GroupProfile : Profile
    {
        public GroupProfile()
        {
            CreateMap<GroupModel, GroupDTO>();
        }
    }
}

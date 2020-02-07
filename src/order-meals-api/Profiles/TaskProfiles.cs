using AutoMapper;
using order_meals_data.DTOs.Task;
using order_meals_data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace order_meals_api.Profiles
{
    public class TaskProfiles : Profile
    {
        public TaskProfiles()
        {
            CreateMap<TaskModel, CreateTaskDTO>();
            CreateMap<TaskModel, TaskDTO>();
            CreateMap<CreateTaskDTO, TaskModel>();
            CreateMap<UpdateTaskDTO, TaskModel>();
        }
    }
}

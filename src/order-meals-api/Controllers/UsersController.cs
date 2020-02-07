using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using order_meals_data.DTOs;
using order_meals_data.DTOs.Group;
using order_meals_data.DTOs.Task;
using order_meals_data.Entities;
using order_meals_data.Repositories.Impl;
using order_meals_data.Repositories.Interface;
using order_meals_data.Response;

namespace order_meals_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        ITaskRepository _taskRepository;
        IGroupRepository _groupRepository;
        private static UserRepository _manager;
        IMapper _mapper;
        public UsersController(UserRepository manager, ITaskRepository taskRepository, IGroupRepository groupRepository, IMapper mapper)
        {
            _taskRepository = taskRepository ??
                throw new ArgumentNullException(nameof(taskRepository));
            _groupRepository = groupRepository ??
                throw new ArgumentNullException(nameof(groupRepository));
            _manager = manager ??
               throw new ArgumentNullException(nameof(manager));
            _mapper = mapper ??
               throw new ArgumentNullException(nameof(mapper));
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login ([FromBody] UserDTO model)
        {
            var response = await _manager.Autheticate(model.Username, model.Password);

            var groupFromDb = await _groupRepository.GetAllAsync();

            var tasksFromDb= !string.IsNullOrEmpty(response.UserId) ? await _taskRepository.GetAllAsync(r=>r.OwnerId==response.UserId) : new List<TaskModel>();

            var group = new List<GroupDTO>();

            var task = new List<TaskDTO>();

            _mapper.Map(groupFromDb, group);

            _mapper.Map(tasksFromDb, task);

            response.State = new AppState()
            {
                Tasks = task,
                Groups = group,
                Session= new Session()
                {
                    Authenticated= !string.IsNullOrEmpty(response.UserId)?"AUTHENTICATED":"NOT_AUTHENTICATED",
                    Id=response.UserId
                }
            };

            return Ok(response);
        }


    }
}
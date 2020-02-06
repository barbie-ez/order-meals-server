using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using order_meals_data.DTOs.Task;
using order_meals_data.Entities;
using order_meals_data.Repositories.Impl;
using order_meals_data.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace order_meals_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class TaskController: ControllerBase
    {
        ITaskRepository _taskRepository;
        IGroupRepository _groupRepository;
        private static UserRepository _manager;
        IMapper _mapper;
        public TaskController(ITaskRepository taskRepository, IGroupRepository groupRepository, UserRepository manager, IMapper mapper)
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

        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            var tasks = await  _taskRepository.GetAllAsync();
            return new JsonResult(tasks);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskDTO taskDTO)
        {
            if (taskDTO == null)
            {
                return BadRequest();
            }

            var taskToAdd = new TaskModel();

            _mapper.Map(taskDTO, taskToAdd);

            taskToAdd.GroupId = _groupRepository.GetFirstAsync().GetAwaiter().GetResult().Id;

            //taskToAdd.OwnerId = _manager.FindByEmailAsync(User.Identity.Name).GetAwaiter().GetResult().Id;

            var user = _manager.Users.FirstOrDefault();

            taskToAdd.OwnerId =user.Id;

            var tasks = await _taskRepository.AddAsync(taskToAdd);

            return new JsonResult(tasks);
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateTask([FromBody] UpdateTaskDTO taskDTO)
        {
            if (taskDTO == null)
            {
                return BadRequest();
            }

            var taskToUpdate = await _taskRepository.GetFirstAsync(r => r.Id == taskDTO.Id);

            _mapper.Map(taskDTO, taskToUpdate);

            try
            {
                await _taskRepository.UpdateAsync(taskToUpdate);
            }
            catch (Exception)
            {
                throw new Exception("Update of task failed");
            }
            

            return NoContent();
        }
    }
}

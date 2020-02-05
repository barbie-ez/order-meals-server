using Microsoft.AspNetCore.Mvc;
using order_meals_data.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace order_meals_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskContoller: ControllerBase
    {
        ITaskRepository _taskRepository;
        public TaskContoller(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository ??
                throw new ArgumentNullException(nameof(taskRepository));
        }
        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            var tasks = await  _taskRepository.GetAllAsync();
            return new JsonResult(tasks);
        }
    }
}

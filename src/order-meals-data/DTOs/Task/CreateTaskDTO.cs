using System;
using System.Collections.Generic;
using System.Text;

namespace order_meals_data.DTOs.Task
{
    public class CreateTaskDTO
    {
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        public string Comments { get; set; }
    }
}

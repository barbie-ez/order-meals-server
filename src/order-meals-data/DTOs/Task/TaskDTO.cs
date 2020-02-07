using System;
using System.Collections.Generic;
using System.Text;

namespace order_meals_data.DTOs.Task
{
    public class TaskDTO
    {
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        public string Comments { get; set; }
        public string GroupId { get; set; }
        public string OwnerId { get; set; }
    }
}

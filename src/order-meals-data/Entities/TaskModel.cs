using System;
using System.Collections.Generic;
using System.Text;

namespace order_meals_data.Entities
{
    public class TaskModel: BaseModel
    {
        public string Name { get; set; }
        public Guid GroupId { get; set; }
        public GroupModel Group { get; set; }
        public string OwnerId { get; set; }
        public UserModel Owner { get; set; }
        public bool IsComplete { get; set; }
        public string Comments { get; set; }
    }
}

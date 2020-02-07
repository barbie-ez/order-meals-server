using order_meals_data.DTOs.Group;
using order_meals_data.DTOs.Task;
using System;
using System.Collections.Generic;
using System.Text;

namespace order_meals_data.Response
{
    public class ResponseData
    {
        public string  UserId { get; set; }
        public string  Token { get; set; }
        public string  ErrorMessage { get; set; }
        public AppState State { get; set; }
    }

    public class AppState
    {
        public List<TaskDTO> Tasks { get; set; }
        public List<GroupDTO> Groups { get; set; }
        public Session Session { get; set; }
    }

    public class Session
    {
        public string Authenticated { get; set; }
        public string Id { get; set; }
    }
}

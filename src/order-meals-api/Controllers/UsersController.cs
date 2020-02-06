using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using order_meals_data.DTOs;
using order_meals_data.Repositories.Impl;

namespace order_meals_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private static UserRepository _manager;
        public UsersController(UserRepository manager)
        {
            _manager = manager;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login ([FromBody] UserDTO model)
        {
            var user = await _manager.Autheticate(model.Username, model.Password);

            return Ok(user);
        }


    }
}
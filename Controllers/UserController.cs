using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishAPI.Data;
using WishAPI.Models;

namespace WishAPI.Controllers
{
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("{id}")]
        public ActionResult <User> GetUserById(int id)
        {
            var user = _userRepository.GetUserById(id);
            if (user != null)
                return Ok(user);
            else
                return NotFound();
        }
    }
}

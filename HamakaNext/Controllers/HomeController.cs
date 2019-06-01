using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HamakaNext.Models;
using Microsoft.EntityFrameworkCore;

namespace HamakaNext.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly HmkContext _dbContext;

        public HomeController (HmkContext context)
        {
            _dbContext = context;
            _dbContext.Database.EnsureCreated();
        }

        [HttpGet]
        public List<User> Index()
        {
            return _dbContext.User.ToList();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            _dbContext.User.Add(user);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(User user)
        {
            _dbContext.User.Remove(user);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(User user)
        {
            _dbContext.User.Update(user);
            return Ok();
        }

    }
}

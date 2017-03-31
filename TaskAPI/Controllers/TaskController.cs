using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using System.Net.Http;


namespace TaskAPI.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class TaskController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            var tasks = new List<Models.Task>
            {
                new Models.Task
                {
                    Id = "1",
                    Name = "Task1",
                    Description = "Desc of Task1",
                    StartDate = DateTime.Now
                },
                new Models.Task
                {
                    Id = "2",
                    Name = "Task2",
                    Description = "Desc of Task2",
                    StartDate = DateTime.Now
                },
                new Models.Task
                {
                    Id = "3",
                    Name = "Task3",
                    Description = "Desc of Task3",
                    StartDate = DateTime.Now
                }
            };

            return new ObjectResult(tasks);
        }
    }
}
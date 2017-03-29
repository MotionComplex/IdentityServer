using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace TaskAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/task")]
    [Authorize]
    public class TaskController : Controller
    {
        [HttpGet]
        public string[] Get()
        {
            return new string[] { "Task1", "Task2" };
        }
    }
}
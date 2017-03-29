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
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response;
            //string value = "Task3";
            //response = value;

            return response;
        }
    }
}
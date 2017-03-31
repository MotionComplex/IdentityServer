using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using AuthenticationClient.ViewModels;
using Newtonsoft.Json;

namespace AuthenticationClient.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Secure()
        {
            ViewData["Message"] = "Secure page.";

            return View();
        }

        [Authorize]
        public async Task<IActionResult> Task()
        {
            ViewData["Message"] = "Task page.";

            var accessToken = await HttpContext.Authentication.GetTokenAsync("access_token");

            HttpClient client = new HttpClient();
            client.SetBearerToken(accessToken);

            var result = client.GetAsync("http://localhost:5003/task").Result;
            var content = string.Empty;
            var viewContent = new List<TaskViewModel>();

            if (result.IsSuccessStatusCode)
            {
                viewContent = ConvertContentToModel(result);
            }
            
            return View(viewContent);
        }

        [Authorize]
        public async Task<IActionResult> Flights()
        {
            ViewData["Message"] = "Task page.";

            var accessToken = await HttpContext.Authentication.GetTokenAsync("access_token");

            HttpClient client = new HttpClient();
            client.SetBearerToken(accessToken);

            var result = client.GetAsync("http://localhost:5777/api/flight").Result;
            var content = string.Empty;
            var viewContent = new List<FlightViewModel>();

            if (result.IsSuccessStatusCode)
            {
                content = result.Content.ReadAsStringAsync().Result;
                viewContent = JsonConvert.DeserializeObject<List<FlightViewModel>>(content);

                return View(viewContent);
            }

            return View("../Shared/Error/Unauthorized");           
        }

        private List<TaskViewModel> ConvertContentToModel(HttpResponseMessage result)
        {
            var content = result.Content.ReadAsStringAsync().Result;
            var tasklist = JsonConvert.DeserializeObject<List<TaskViewModel>>(content);

            return tasklist;
        }
        
        public async Task Logout()
        {
            await HttpContext.Authentication.SignOutAsync("Cookies");
            await HttpContext.Authentication.SignOutAsync("oidc");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
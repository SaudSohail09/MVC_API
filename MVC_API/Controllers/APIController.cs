using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MVC_API.Controllers
{
    public class APIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> CallApi()
        {
            using (var client = new HttpClient())
            {
             
                client.BaseAddress = new Uri("http://localhost:");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                // Call the Web API
                HttpResponseMessage response = await client.GetAsync("api/Flights/Get");

                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as a string
                    string result = await response.Content.ReadAsStringAsync();

                    // Do something with the result
                    ViewBag.Result = result;
                }
                else
                {
                    ViewBag.Result = "Error: " + response.StatusCode;
                }
                }

                return View();
            }
        }
    }

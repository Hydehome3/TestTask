using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace TestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public ContentResult Get()
        {
            var client = new RestClient("https://docs.microsoft.com/api/");
            var request = new RestRequest("search?search=LINQ&locale=ru-ru&facet=category&%24skip=0&%24top=5");

            var queryResult = client.Execute(request);

            return Content(queryResult.Content);
        }

    }
}

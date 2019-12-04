using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace TestTask.Controllers
{
    [ApiController]
    public class ValuesController : Controller
    {
        [HttpGet("search/{word}")]
        //Метод принимает на вход искомое слово и количество первых пропущенных (нерассматриваемых) результатов
        public ContentResult Get(string word, int skip=0)
        {            
            var client = new RestClient("https://docs.microsoft.com/api/");            
            var request = new RestRequest($"search?locale=ru-ru&facet=category&%24skip={skip}&%24top=25&search={word}");
            var response = client.Execute(request);
            //результат запроса в виде json строки
            var content = response.Content; 
            return Content(content);
        }

    }
}

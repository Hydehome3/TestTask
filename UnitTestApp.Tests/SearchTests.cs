using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using NUnit.Framework;
using TestTask.Controllers;
using UnitTestApp.Tests.Deserialization;
using System.Text.RegularExpressions;

namespace UnitTestApp.Tests
{
    [TestFixture]
    class SearchTests
    {
        [Test]
        public void Test_Search_By_Word()
        {
            //В переменную записывается фактический результат теста
            bool test_result = true;
            //Контроллер для выполнения запроса
            ValuesController controller = new ValuesController();
            //Получаем результаты запроса
            var results = controller.Get();
            //Десериализуем результаты запроса
            var deserialized_results = JsonConvert.DeserializeObject<RootObject>(results.Content);            
            //Проверка на нахождение искомого слова в каждом результате
            for (int i = 0; i < deserialized_results.Results.Length; i++)
            {
                for (int j = 0; j < deserialized_results.Results[i].Description.Length; j++)
                {
                    if ((Regex.IsMatch(deserialized_results.Results[i].Description[j].Content, "\\bLINQ\\b", RegexOptions.IgnoreCase)) != true)
                    {
                        test_result = false;
                        break;
                    }
                }                
            }
            Assert.True(test_result);
        }
    }
}

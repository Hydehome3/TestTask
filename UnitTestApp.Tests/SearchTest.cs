using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using NUnit.Framework;
using TestTask.Controllers;
using UnitTestApp.Tests.Deserialization;
using System.Text.RegularExpressions;
using System.Linq;

namespace UnitTestApp.Tests
{
    [TestFixture]
    class SearchTest
    {
        [Test]
        public void Test_Search_By_Word()
        {
            //Искомое слово
            string word = "LINQ";
            //Параметр для пропуска уже полученных результатов поиска
            int skip = 0;
            //Количество тестируемых результатов поиска по слову
            int results_count = 50;
            //Список дессериализованных результатов поиска
            List<RootObject> deserialized_results = new List<RootObject>();

            //Контроллер для выполнения запроса
            ValuesController controller = new ValuesController();

            //API Microsoft представляет возможным получить только 25 результатов поиска
            //за один запрос, поэтому с помощью цикла выполняется множество запросов,
            //чтобы получить необходимое количество результатов
            do
            {
                //Получаем результаты поиска в виде Json строки
                var results = controller.Get(word, skip);
                //Дессериализуем результаты
                deserialized_results.Add(JsonConvert.DeserializeObject<RootObject>(results.Content));
                //Увеличиваем параметр для пропуска уже полученных результатов для дальнейшей итерации
                skip += 25;
            }
            while (skip < results_count);

            //Проверяем наличие искомого слова с помощью регулярного выражения
            //путем прохода по всем результатам поиска
            foreach (var item in deserialized_results)
            {
                for (int i = 0; i < item.Results.Length; i++)
                {
                    for (int j = 0; j < item.Results[i].Descriptions.Length; j++)
                    {
                        if (string.IsNullOrEmpty(item.Results[i].Descriptions[j].Content))
                        {
                            break;
                        }
                        Assert.True(Regex.IsMatch(item.Results[i].Descriptions[j].Content, $"\\b{word}\\b", RegexOptions.IgnoreCase));                       
                    }
                }
            }
        }
    }
}
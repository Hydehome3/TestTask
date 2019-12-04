using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace UnitTestApp.Tests
{
    [TestFixture]
    class RegularExpressionTest
    {
        [Test]
        public void Regular_Expression ()
        {
            //Arrange
            string word = "LINQ";
            string expression = $"\\b{word}\\b";
            List<string> strings = new List<string>()
            {
                "Enumerable.Join Метод (System.Linq)",
                "Синтаксис LINQ на C# | Microsoft Docs",
                "Language-Integrated Query (LINQ) is the name for",
                "Пространство имен: System.Linq.Expressions",
                "Пространство имен: System.Linq"
            };
            //Act & Assert
            foreach (string item in strings)
            {
                Assert.AreEqual(true, Regex.IsMatch(item, expression, RegexOptions.IgnoreCase));
            }
        }
    }
}

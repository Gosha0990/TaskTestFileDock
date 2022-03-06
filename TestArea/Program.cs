using System;
using System.Text.RegularExpressions;

namespace TestArea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("!!!!!!!!!!!!!!!!");
            var str = @"Название продукта: 
                        01472478 ""Быстров""
                        Тип продукта: 
                        Каша.блюдо из разваренных в воде (или в молоке) зёрен или крупы злаков, иногда с такими добавками как соль, сахар, приправы, молоко, фрукты и сухофрукты, варенье. Каша отличается от гарнира из сваренной крупы (зёрен или злаков) более жидкой консистенцией.
                        Состав продукта: 
                        1. 
                        Зерна овса
                        2. 
                        Пшеница
                        3. 
                        Сахар
                        4. 
                        Соль
                        5. 
                        Сухое молоко
                        Похожие продукты: 
                        хлопья овсяные
                        хлопья кукурузные
                        мюсли";
            Console.WriteLine(str);
            var regex = new Regex(".+?(?=Состав продукта:|Тип продукта:|Похожие продукты:|$)", RegexOptions.Singleline);
            var matches = regex.Matches(str);
            int count = 0;
            foreach (Match match in matches)
            {
                Console.WriteLine("Часть" + count + ":");
                Console.WriteLine(match.Value);
                count++;
            }
            Console.ReadLine();
        }
    }
}

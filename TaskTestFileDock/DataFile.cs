using System.Collections.Generic;
using System.Linq;

namespace TaskTestFileDock
{
    internal class DataFile
    {
        // Сортировка исходых данных
        public List<string> SortData(string content)
        {
            var list = new List<string>();
            foreach (var item in content.Split('\n'))
            {
                if (item != "")
                    list.Add(item);
            }
            list.Sort();
            return list;
        }
        // Поиск минимального значения в отсартированном списке
        public string GetMinList(List<string> content)
        {
            string min = content[0].ToString();
            return min;
        }
        // Поиск максимального значения в отсартированном списке
        public string GetMaxList(List<string> content)
        {
            string max = content.Last().ToString();
            return max;
        }
    }
}

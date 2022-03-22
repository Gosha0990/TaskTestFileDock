using System.Collections.Generic;
using System.Linq;

namespace TaskTestFileDock
{
    internal class DataFile
    {
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
        public string GetMinList(List<string> content)
        {
            string min = content[0].ToString();
            return min;
        }
        public string GetMaxList(List<string> content)
        {
            string max = content.Last().ToString();
            return max;
        }
    }
}

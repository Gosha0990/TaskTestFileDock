using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTestFileDock
{
    internal class ControlFile
    {
        public void CreationFile(string path, string content)
        {
            using(FileStream fileStream = new FileStream(path,FileMode.OpenOrCreate))
            {
                byte[] buffer = Encoding.Default.GetBytes(content);
                fileStream.Write(buffer, 0, buffer.Length);
            }
        }
        public List<string> SortDate (string content)
        {
            var  list = new List<string>();
            foreach (var item in content.Split('\n'))
            { 
                if(item!="")
                    list.Add(item);
            }
            list.Sort();
            return list;
        }
        public string GetMin(List<string> content)
        {
            string min = content[0].ToString();
            return min;
        }
        public string GetMax(List<string> content)
        {
            string max = content.Last().ToString();
            return max;
        }
    }
}

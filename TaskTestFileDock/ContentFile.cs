using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace TaskTestFileDock
{
    internal class ContentFile
    {
        private string _patterRegex;
        private string _pathFile;
        private string resultString;
        public ContentFile(string pathFile)
        {
            _patterRegex = @"(\d{2}\.\d{2}\.\d{4}),(\d{2}:\d{2}:\d{2}),(\d{3}\.\d{3}),(\d{3}\.\d{3}),(\d{3}\.\d{3})";
            _pathFile = pathFile;            
        }
        public void ParseFileDate()
        {           
            string path = Path.GetFullPath(_pathFile);           
            using (StreamReader sr = new StreamReader(path))
            {
                string currentDate = null;
                string nextDate = null;
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    var math = Regex.Matches(s, _pathFile, RegexOptions.IgnoreCase);
                    foreach (Match m in math)
                        currentDate = m.Groups[1].Value.ToString();
                    if(nextDate == null)
                        nextDate = currentDate;
                    else
                    {
                        if (nextDate != currentDate)
                            resultString = "New date";
                    }
                }
            }            
        }
        public string GetResultString()
        {
            return resultString;
        }
    }
}

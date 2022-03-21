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
        public string High { get; set; }
        public ContentFile(string pathFile)
        {
            _patterRegex = @"(\d{2}\.\d{2}\.\d{4}),(\d{2}:\d{2}:\d{2}),(\d{3}\.\d{3}),(\d{3}\.\d{3}),(\d{3}\.\d{3})";
            _pathFile = pathFile;            
        }
        public string ParseFileDate()
        {
            var control = new ControlFile();       
            string path = Path.GetFullPath(_pathFile);           
            using (StreamReader sr = new StreamReader(path))
            {
                string currentDate = null;
                string PreviousDate = null;
                string s;                
                while ((s = sr.ReadLine()) != null)
                {
                    var math = Regex.Matches(s, _patterRegex, RegexOptions.IgnoreCase);
                    foreach (Match m in math)
                    {
                        currentDate = m.Groups[1].Value.ToString();

                        if (PreviousDate == null)
                        {
                            PreviousDate = currentDate;
                            High += "\n" + m.Groups[4].Value.ToString();
                        }                           
                        else
                        {
                            if (PreviousDate == currentDate)
                                High +="\n" + m.Groups[4].Value.ToString();
                            else
                            {
                                var hRes = control.SortDate(High);
                                var min = control.GetMin(hRes);
                                var max = control.GetMax(hRes);
                                control.CreationFile(PreviousDate + ".txt", min + "\n" + max);
                                High = null;
                                PreviousDate = currentDate;
                            }                            
                        }
                    }
                }
            }
            return "Good!";
        }
    }
}

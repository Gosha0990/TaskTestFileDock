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
            var dataFile = new DataFile();
            var controlFile = new ControlFile();
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
                                var hRes = dataFile.SortData(High);
                                var min = dataFile.GetMinList(hRes);
                                var max = dataFile.GetMaxList(hRes);
                                controlFile.CreationFile(PreviousDate + ".txt","Task_1", min + "\n" + max);
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

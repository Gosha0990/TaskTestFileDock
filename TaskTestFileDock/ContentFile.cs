using System.IO;
using System.Text.RegularExpressions;

namespace TaskTestFileDock
{
    internal class ContentFile
    {
        private string _patterRegex;
        private string _pathFile;
        private string dataHighLow = "High \t low";
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
                            dataHighLow += "\n" + m.Groups[4].Value.ToString() + "  " + m.Groups[5].Value.ToString();
                                            
                        }                           
                        else
                        {
                            if (PreviousDate == currentDate)
                                dataHighLow += "\n" + m.Groups[4].Value.ToString() + "  " + m.Groups[5].Value.ToString();
                            else
                            {
                                
                                controlFile.CreationFile(PreviousDate + ".txt","Task_1", dataHighLow);
                                dataHighLow = "High \t low";
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TaskTestFileDock
{
    internal class ContentFile
    {
        private string _patterRegex;
        private string _pathFile;
        private string resultString;
        public ContentFile(string patternRegex,string pathFile)
        {
            _patterRegex = patternRegex;
            _pathFile = pathFile;            
        }
        private void ParseFile()
        {
            string path = Path.GetFullPath(_pathFile);
            string srt = null;

            using (StreamReader sr = new StreamReader(path))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    
                }
            }
            
        }
        public string GetResultString()
        {
            return resultString;
        }

    }
}

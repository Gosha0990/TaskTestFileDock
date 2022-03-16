using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TaskTestFileDock
{
    internal class ControlFile
    {
        public string ParseFile(string nameFile)
        {
            string path = Path.GetFullPath(nameFile);
            string resultStr = null;
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        resultStr +=s;
                    }
                }
            }
            return resultStr;
        }

    }
}

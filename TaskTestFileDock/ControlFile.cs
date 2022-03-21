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
    }
}

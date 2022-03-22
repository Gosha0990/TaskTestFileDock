using System.IO;
using System.Text;

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

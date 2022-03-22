using System.IO;
using System.Text;

namespace TaskTestFileDock
{
    internal class ControlFile
    {
        public void CreationFile(string nameFile,string nameFolder, string content)
        {
            nameFolder = CreationFolder(nameFolder);
            using(FileStream fileStream = new FileStream(nameFolder + nameFile,FileMode.OpenOrCreate))
            {
                byte[] buffer = Encoding.Default.GetBytes(content);
                fileStream.Write(buffer, 0, buffer.Length);
            }
        }
        private string CreationFolder(string nameFolder)
        {
            var folder = new DirectoryInfo(nameFolder);
            folder.Create();
            return nameFolder + "\\";
        }
    }
}

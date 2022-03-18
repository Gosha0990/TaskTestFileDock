using System;

namespace TaskTestFileDock
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var path = "File\\TextFile1.txt";
            var content = new ContentFile(path);
            var res = content.ParseFileDate();
            Console.WriteLine(res);
        }
    }
}

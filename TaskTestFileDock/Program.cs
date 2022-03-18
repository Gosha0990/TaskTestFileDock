using System;

namespace TaskTestFileDock
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var testFileStr = new ControlFile();
            var res = testFileStr.ParseFile("File\\AAPL-IQFeed-SMART-Stocks-Minute-Trade.txt");
            Console.WriteLine(res);
        }
    }
}

﻿using System;

namespace TaskTestFileDock
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var path = "File\\AAPL-IQFeed-SMART-Stocks-Minute-Trade.txt";
            var content = new ContentFile(path);
            var res = content.ParseFileDate();
            Console.WriteLine(res);
        }
    }
}

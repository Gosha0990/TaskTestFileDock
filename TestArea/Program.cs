using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;

namespace TestArea
{   
    internal class Data
    {
        public string Date { get; set; }
        public string H { get; set; }
        public string L { get; set; }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("!!!!!!!!!!!!!!!!");
            var str = @"""Symbol"",""Description"",""Date"",""Time"",""Open"",""High"",""Low"",""Close"",""TotalVolume""
                                    AAPL,NASDAQ,02.01.2020,08:01:00,295.890,296.190,295.435,296.098,24333
                                    AAPL,NASDAQ,02.01.2020,08:02:00,296.144,296.150,296.090,296.150,2517
                                    AAPL,NASDAQ,02.01.2020,08:03:00,296.160,296.180,296.030,296.030,7210
                                    AAPL,NASDAQ,03.01.2020,08:07:00,296.000,296.000,295.980,295.980,1807
                                    AAPL,NASDAQ,03.01.2020,08:07:00,296.000,296.000,295.980,295.980,1807";
            Console.WriteLine(str);
            string pattern = @"(\d{2}\.\d{2}\.\d{4}),(\d{2}:\d{2}:\d{2}),(\d{3}\.\d{3}),(\d{3}\.\d{3}),(\d{3}\.\d{3})";
            var matches = Regex.Matches(str, pattern, RegexOptions.Multiline);
            var listLoc = new List<Data>() { }; 
            
            foreach(Match match in matches)
            {                
                var date = new Data();
                date.Date = match.Groups[1].Value.ToString();
                date.H = match.Groups[4].Value.ToString();
                date.L = match.Groups[5].Value.ToString();
                listLoc.Add(date);
            }

            for (int i = 0; i < listLoc.Count; i++)
            {
                if (i >= listLoc.Count)
                {
                    break;
                }
                // удаляется часть списка которая нам не нужна при изменение даты
                //Необходимо добавить сортировку и запись дапустим в ноый список 
                if (listLoc[i].Date != listLoc[i + 1].Date)
                {

                    listLoc.RemoveRange(0,i+1);
                    i = 1;
                }
                Console.WriteLine(listLoc[i].Date.ToString());
                
            }
            // проблемма с работой относительного пути
            string path = Path.GetFullPath("TextFile1.txt");
            //string di = @"TaskTestFileDock\TaskTestFileDock\File\AAPL-IQFeed-SMART-Stocks-Minute-Trade.txt";
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }
            Console.ReadLine();            
        }
        public static string ParseFile(string directory)
        {
            DirectoryInfo di = new DirectoryInfo(directory);
            foreach (var f in di.GetFiles("*.txt"))
            { 
                return f.Name;
            }
            return null;
        }
    }
}

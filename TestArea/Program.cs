﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;

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

            // Через Using проходим по строчно по нужному файлу и внутри 
            // Используя регулярные выражения отслеживае изменение даты
            // Сюда необходимо добавить сохранение в List другие значения из файла
            // Далее их отсортировать и сохранить в отдельный файл с названием и дато
            string path = Path.GetFullPath("TextFile1.txt");
            //Тест парсинг файла используя регулярные выражения
            using (StreamReader sw = new StreamReader(path))
            {
                string pat = @"(\d{2}\.\d{2}\.\d{4}),(\d{2}:\d{2}:\d{2}),(\d{3}\.\d{3}),(\d{3}\.\d{3}),(\d{3}\.\d{3})";
                string s;
                string dateCurrent = null;
                string dateLast = null;
                while((s=sw.ReadLine())!=null)
                {

                    var math = Regex.Matches(s, pat, RegexOptions.Multiline);
                    foreach (Match match in math)
                        dateCurrent = match.Groups[1].Value.ToString();
                    Console.WriteLine(dateCurrent);
                    if(dateLast == null)
                    {
                        dateLast = dateCurrent;
                    }
                    else
                    {
                        if (dateCurrent != dateLast)
                            Console.WriteLine("Новая дата");
                    }

                }
            }
            //Создание файла и запись тексто в файл
            string nameFile = "newFile.txt";
            string nameFolder = "ResData1";
            var drInfo = new DirectoryInfo(nameFolder);
            drInfo.Create();
            string text = "Hello world";
            using (FileStream sr = new FileStream(nameFolder +"\\"+ nameFile, FileMode.OpenOrCreate))
            {
                Console.WriteLine("Файл создан");
                byte[] input = Encoding.Default.GetBytes(text);
                sr.Write(input, 0, input.Length);
                Console.WriteLine("Текст записан");

            }
                Console.ReadLine();
        }
    }
}

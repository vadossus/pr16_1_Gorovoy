using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Threading;

namespace ConsoleApp16
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите слово: ");
                string poisk = Console.ReadLine().ToLower();
                if (string.IsNullOrEmpty(poisk))
                {
                    Console.WriteLine("Не введено значение");
                    Thread.Sleep(1000);
                    Environment.Exit(0);
                }
                else
                {
                    string file = "test.txt";
                    if (File.Exists(file))
                    {
                        string text = File.ReadAllText(file).ToLower();
                        int vxod = text
                            .Split(new char[] { ' ', '.', ',', '?', '!', '\n', '\t', ';', ':' }, StringSplitOptions.RemoveEmptyEntries)
                            .Count(word => word == poisk);
                        if (vxod > 0)
                        {
                            Console.WriteLine($"Были найдены {vxod} вхождения (ий) поискового запроса \"{poisk}\"");
                        }
                        else
                        {
                            Console.WriteLine($"Не найдены вхождения поискового запроса \"{poisk}\"");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Файл не существует");
                        Thread.Sleep(1000);
                        Environment.Exit(0);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                Thread.Sleep(1000);
                Environment.Exit(0);
            }
            Console.Read();

        }
    }
}

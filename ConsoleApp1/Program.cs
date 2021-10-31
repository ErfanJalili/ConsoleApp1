using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the path");
            string FILENAME = Console.ReadLine();
            
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;

            StreamReader reader = new StreamReader(FILENAME);
            //using var fs = new FileStream(FILENAME, FileMode.Open, FileAccess.Read);
            //using var reader = new StreamReader(fs, Encoding.Unicode);
            string line = "";
                string category = "";
                string pattern = @"(?'name'.*)\s+(?'price'\d+)";
                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Trim();
                    if (line.Length > 0)
                    {
                        if (line.StartsWith("#"))
                        {
                            category = line.Substring(1);
                        }
                        else
                        {
                            Match match = Regex.Match(line, pattern);
                            string name = match.Groups["name"].Value.Trim();
                            string price = match.Groups["price"].Value.Trim();
                        Console.WriteLine("category : '{0}', Time : '{1}' (hours), Price : '{2}' (Rials)",  category, name, price);

                        }
                    }
                }
                Console.ReadLine();
            
        }
    }
}

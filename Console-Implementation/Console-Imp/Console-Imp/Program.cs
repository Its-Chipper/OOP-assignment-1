using System;
using System.IO;

namespace Console_Imp
{
    class Program
    {
        static void Main(string[] args)
        {
            string Path = Directory.GetCurrentDirectory();
            string Text = File.ReadAllText(Path.Substring(0, Path.Length - 23) + "CountriesInfo.txt");
            Console.WriteLine(Text);
        }
    }
}

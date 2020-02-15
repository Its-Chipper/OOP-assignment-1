using System;
using System.IO;

namespace Console_Imp
{
    class Program
    {
        static void Main(string[] args)
        {
            Country[] CountryInfo = new Country[27];


            string Path = Directory.GetCurrentDirectory();
            string Text = File.ReadAllText(Path.Substring(0, Path.Length - 23) + "CountriesInfo.txt");

            string[] CountriesInfo = Text.Split('\n');

            for(int i = 0; i < CountriesInfo.Length; i++)
            {
                string[] infoarray = CountriesInfo[i].Split(' ');
                CountryInfo[i] = new Country();
                CountryInfo[i].Name = infoarray[0];
                CountryInfo[i].Population = Convert.ToInt32(infoarray[1]);
            }
            foreach(Country info in CountryInfo)
            {
                Console.WriteLine(info.Name + ":" + info.Population);
            }
        }
    }
}

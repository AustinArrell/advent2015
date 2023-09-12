using advent2015.solutions;
using System.Reflection;

namespace advent2015
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            string dataPath = $"..\\..\\..\\input\\";
            var fileText = File.ReadAllText($"{dataPath}day1.txt");


            Console.WriteLine(day1.DetermineSantasEndFloor(fileText));
            Console.WriteLine(day1.DetermineSantasFirstNegativeFloor(fileText));
        }
    }
}
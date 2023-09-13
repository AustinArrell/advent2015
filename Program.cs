using advent2015.solutions;
using System.Reflection;

namespace advent2015
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            Day1 day1 = new Day1();


            Console.WriteLine(day1.DetermineSantasEndFloor());
            Console.WriteLine(day1.DetermineSantasFirstNegativeFloor());
        }
    }
}
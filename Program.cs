using advent2015.solutions;
using System.Reflection;

namespace advent2015
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            var fileText = File.ReadAllText($"{projectDirectory}\\input\\day1.txt");


            Console.WriteLine(day1.DetermineSantasEndFloor(fileText));
            Console.WriteLine(day1.DetermineSantasFirstNegativeFloor(fileText));
        }
    }
}
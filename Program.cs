﻿using advent2015.solutions;
using BenchmarkDotNet.Running;

namespace advent2015
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            Day1 day1 = new Day1();
            Day2 day2 = new Day2();
            Day3 day3 = new Day3();
            Day4 day4 = new Day4();

            //BenchmarkRunner.Run<Day3>();

            Console.WriteLine("Day 1 Part 1: " + day1.DetermineSantasEndFloor());
            Console.WriteLine("Day 1 Part 2: " + day1.DetermineSantasFirstNegativeFloor());
            
            Console.WriteLine("Day 2 Part 1: " + day2.calculatePaperInFeet());
            Console.WriteLine("Day 2 Part 2: " + day2.calculateRibbonInFeet());

            Console.WriteLine("Day 3 Part 1: " + day3.calculateNumberOfVisitedHouses());
            Console.WriteLine("Day 3 Part 2: " + day3.calculateNumberOfVisitedHousesRoboMode());

            Console.WriteLine("Day 4 Part 1: " + day4.mineAdventCoin());
            Console.WriteLine("Day 4 Part 2: " + day4.mineAdventCoin2());
        }
    }
}
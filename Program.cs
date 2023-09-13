﻿using advent2015.solutions;
using BenchmarkDotNet.Running;

namespace advent2015
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            Day1 day1 = new Day1();

            //BenchmarkRunner.Run<Day1>();

            Console.WriteLine("Day 1 Part 1: " + day1.DetermineSantasEndFloor());
            Console.WriteLine("Day 1 Part 2: " + day1.DetermineSantasFirstNegativeFloor());
        }
    }
}
using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent2015.solutions
{

    public class Day3
    {
        private string projectDirectory { get; set; }
        private string inputInstructions { get; set; }

        public Day3()
        {
            projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

            inputInstructions = File.ReadAllText($"D:\\dev\\dotNet\\advent2015\\input\\day3.txt");
        }

        [Benchmark]
        public int calculateNumberOfVisitedHouses() 
        {
            (int, int) currentPosition = (0,0);
            HashSet<(int,int)> visitedPositions = new HashSet<(int,int)>();
            visitedPositions.Add(currentPosition);

            foreach (var movementCommand in inputInstructions) 
            {
                switch (movementCommand) 
                {
                    case '^':
                        currentPosition = (currentPosition.Item1,currentPosition.Item2 -1);
                        break;
                    case 'v':
                        currentPosition = (currentPosition.Item1, currentPosition.Item2 +1);
                        break;
                    case '>':
                        currentPosition = (currentPosition.Item1 +1, currentPosition.Item2);
                        break;
                    case '<':
                        currentPosition = (currentPosition.Item1 -1, currentPosition.Item2);
                        break;
                }
                visitedPositions.Add((currentPosition.Item1, currentPosition.Item2));
            }

            return visitedPositions.Count();
        }

        [Benchmark]
        public int calculateNumberOfVisitedHousesRoboMode()
        {
            (int, int) santaPosition = (0, 0);
            (int, int) roboPosition = (0, 0);
            HashSet<(int, int)> visitedPositions = new HashSet<(int, int)>();
            visitedPositions.Add(santaPosition);

            for (int i =0; i < inputInstructions.Length; i++)
            {
                (int, int) newPosition = (0,0);
                switch (inputInstructions[i])
                {
                    case '^':
                        newPosition = (0,-1);
                        break;
                    case 'v':
                        newPosition = (0,1);
                        break;
                    case '>':
                        newPosition = (1,0);
                        break;
                    case '<':
                        newPosition = (-1,0);
                        break;
                }

                // Robo moves if command position divisible by 2
                if (i % 2 == 0)
                {
                    roboPosition = (roboPosition.Item1 + newPosition.Item1,roboPosition.Item2 + newPosition.Item2);
                    visitedPositions.Add(roboPosition);
                }
                else
                {
                    santaPosition = (santaPosition.Item1 + newPosition.Item1,santaPosition.Item2 + newPosition.Item2);
                    visitedPositions.Add(santaPosition);
                }
            }

            return visitedPositions.Count();
        }
    }
}

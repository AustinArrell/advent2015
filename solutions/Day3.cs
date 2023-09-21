using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace advent2015.solutions
{

    public class Day3
    {
        private string inputInstructions { get; set; }

        public Day3()
        {
            inputInstructions = File.ReadAllText($"G:\\dev\\advent2015\\input\\day3.txt");
        }

        /*
         * Santa is delivering presents to an infinite two-dimensional grid of houses.
         * He begins by delivering a present to the house at his starting location, 
         * and then an elf at the North Pole calls him via radio and tells him where 
         * to move next.Moves are always exactly one house to the north (^), south(v), east(>), or west(<). 
         * After each move, he delivers another present to the house at his new location.
         * However, the elf back at the north pole has had a little too much eggnog, 
         * and so his directions are a little off, and Santa ends up visiting some houses 
         * more than once.How many houses receive at least one present?
        */

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

        /*
         * The next year, to speed up the process, Santa creates a robot version of himself, 
         * Robo-Santa, to deliver presents with him. Santa and Robo-Santa start at the same
         * location(delivering two presents to the same starting house), then take turns moving 
         * based on instructions from the elf, who is eggnoggedly reading from the same script as the previous year.
         * 
         * This year, how many houses receive at least one present?
        */

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

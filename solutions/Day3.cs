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

            inputInstructions = File.ReadAllText($"{projectDirectory}\\input\\day3.txt");
        }

        public int calculateNumberOfVisitedHouses() 
        {
            (int, int) currentPosition = (0,0);
            List<(int,int)> visitedPositions = new List<(int,int)>();
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

            visitedPositions = visitedPositions.Distinct().ToList(); 
            return visitedPositions.Count();
        }
    }
}

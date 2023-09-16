
using BenchmarkDotNet.Columns;

namespace advent2015.solutions
{
    public class Day2
    {
        /* The elves are running low on wrapping paper, and so they need to submit an order for more.
         * They have a list of the dimensions(length l, width w, and height h) of each present, and 
         * only want to order exactly as much as they need.
         * Fortunately, every present is a box (a perfect right rectangular prism), which makes calculating 
         * the required wrapping paper for each gift a little easier: find the surface area of the box, 
         * which is 2*l* w + 2*w* h + 2*h* l.The elves also need a little extra paper for each present: 
         * the area of the smallest side.

         * For example:

            A present with dimensions 2x3x4 requires 2*6 + 2*12 + 2*8 = 52 square feet of wrapping paper plus
                6 square feet of slack, for a total of 58 square feet.
            A present with dimensions 1x1x10 requires 2*1 + 2*10 + 2*10 = 42 square feet of wrapping paper plus 
                1 square foot of slack, for a total of 43 square feet.

         * All numbers in the elves' list are in feet. How many total square feet of wrapping paper should they order?*/


        private string projectDirectory { get; set; }
        private string inputInstructions { get; set; }

        public Day2()
        {
            projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

            inputInstructions = File.ReadAllText($"{projectDirectory}\\input\\day2.txt");
        }

        public int calculatePaperInFeet() 
        {

            var instructionLines = inputInstructions.Split('\n').ToList();
            var totalRequiredPaperInFeet = 0;

            foreach (var line in instructionLines) 
            {
                var measurements = line.Split('x');

                List<int> sides = new List<int>();
                
                // Calculate all sides
                // l w h ========= 0 1 2
                // [0]*[1]
                sides.Add(Int16.Parse(measurements[0]) * Int32.Parse(measurements[1]));
                // [1]*[2]
                sides.Add(Int16.Parse(measurements[1]) * Int32.Parse(measurements[2]));
                // [2]*[0]
                sides.Add(Int16.Parse(measurements[2]) * Int32.Parse(measurements[0]));

                // Calculate smallest side and total area
                int smallestSide = sides[0];
                var totalPaperThisPresent = 0;
                foreach (var side in sides) 
                {
                    if (side < smallestSide) 
                    {
                        smallestSide = side;
                    }
                    totalPaperThisPresent += (side*2);
                }

                totalPaperThisPresent += (smallestSide);
                totalRequiredPaperInFeet += totalPaperThisPresent;
            }

            return totalRequiredPaperInFeet;
        }

        /* The elves are also running low on ribbon.Ribbon is all the same width, 
         * so they only have to worry about the length they need to order, which 
         * they would again like to be exact. The ribbon required to wrap a present 
         * is the shortest distance around its sides, or the smallest perimeter of 
         * any one face. Each present also requires a bow made out of ribbon as well; 
         * the feet of ribbon required for the perfect bow is equal to the cubic feet 
         * of volume of the present.Don't ask how they tie the bow, though; they'll never tell.
        */

        public int calculateRibbonInFeet()
        {

            var instructionLines = inputInstructions.Split('\n').ToList();
            var totalRequiredRibbonInFeet = 0;

            foreach (var line in instructionLines)
            {
                var sides = line.Split('x').Select(side => int.Parse(side));

                List<int> faces = new List<int>();

                // Calculate all sides
                // l w h ========= 0 1 2
                // [0]*[1]
                faces.Add(sides.ElementAt(0) * sides.ElementAt(1));
                // [1]*[2]
                faces.Add(sides.ElementAt(1) * sides.ElementAt(2));
                // [2]*[0]
                faces.Add(sides.ElementAt(2) * sides.ElementAt(0));

                // Calculate total area
                var totalPaperThisPresent = 0;
                foreach (var face in faces)
                {
                    totalPaperThisPresent += (face * 2);
                }
                // Area: A = L*W
                // Unknown Side: A/L = W
                // Perimeter: 2*(L+W)
                var perimeter = 2 * (sides.Min() + (faces.Min() / sides.Min()));
                var bow = sides.Aggregate((x,y) => x*y);
                totalRequiredRibbonInFeet += (perimeter + bow);
            }

            return totalRequiredRibbonInFeet;
        }
    }
}

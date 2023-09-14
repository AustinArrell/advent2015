
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

    }
}

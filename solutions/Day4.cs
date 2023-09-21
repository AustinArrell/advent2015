using System.Security.Cryptography;
using System.Text;

namespace advent2015.solutions
{
    public class Day4
    {
        private string inputInstructions { get; set; }

        public Day4()
        {
            inputInstructions = File.ReadAllText($"G:\\dev\\advent2015\\input\\day4.txt");
        }

        /*
         * Santa needs help mining some AdventCoins(very similar to bitcoins) to use as gifts for all 
         * the economically forward-thinking little girls and boys. To do this, he needs to find MD5 hashes 
         * which, in hexadecimal, start with at least five zeroes.The input to the MD5 hash is some secret 
         * key (your puzzle input, given below) followed by a number in decimal. To mine AdventCoins, you 
         * must find Santa the lowest positive number(no leading zeroes: 1, 2, 3, ...) that produces such a hash.
        */

        public int mineAdventCoin() 
        {
            HashAlgorithm hashAlgorithm= MD5.Create();
            string hash = "";
            int coinSolution = 0;

            while (!hash.StartsWith("00000")) 
            {
                hash = GetHash(hashAlgorithm, inputInstructions + coinSolution.ToString());
                coinSolution++;
            }

            return coinSolution-1;
            
        }

        /*Now find one that starts with six zeroes.*/

        public int mineAdventCoin2()
        {
            HashAlgorithm hashAlgorithm = MD5.Create();
            string hash = "";
            int coinSolution = 0;

            while (!hash.StartsWith("000000"))
            {
                hash = GetHash(hashAlgorithm, inputInstructions + coinSolution.ToString());
                coinSolution++;
            }

            return coinSolution - 1;

        }


        // Source https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.hashalgorithm.computehash?view=net-7.0
        private static string GetHash(HashAlgorithm hashAlgorithm, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }


    }
}

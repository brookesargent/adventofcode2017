using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventOfCode2017
{
    class CorruptionChecksum
    {
        public void CalculateCorruptionChecksums()
        {
            CalculateChecksum();
            CalculateDivisibleChecksum();
        }
        private void CalculateChecksum()
        {
            string path = "C:\\Users\\bsargent\\Documents\\adventofcode2017\\inputday2.txt";
            
            string[] readText = File.ReadAllLines(path);
            int checksum = 0;
            int min;
            int max;

            foreach (string s in readText)
            {
                string[] array = s.Split(new Char[] { '\t' });
                List<int> convertedToInt = new List<int>();
                
                 foreach (string s2 in array)
                 {
                    convertedToInt.Add(Int32.Parse(s2));
                 }

                min = convertedToInt.Min();
                max = convertedToInt.Max();
                checksum += (max - min);
            }
            Console.WriteLine("The checksum is " + checksum);
        }

        private void CalculateDivisibleChecksum()
        {
            string path = "C:\\Users\\bsargent\\Documents\\adventofcode2017\\inputday2.txt";

            string[] readText = File.ReadAllLines(path);
            int checksum = 0;

            foreach (string s in readText)
            {
                string[] array1 = s.Split(new Char[] { '\t' });
                string[] array2 = s.Split(new Char[] { '\t' });

                int currentNumberToCheck = 0;
                int currentNumberToCheckAgainst = 0;
                for (int i = 0; i < array1.Length; i++)
                {

                   currentNumberToCheck = Int32.Parse(array1[i]);
                    for (int j = i +1; j < array2.Length; j++)
                    {
                        currentNumberToCheckAgainst = Int32.Parse(array2[j]);
                        if (currentNumberToCheck % currentNumberToCheckAgainst == 0)
                        {
                            checksum += (currentNumberToCheck / currentNumberToCheckAgainst);
                        }
                        else if (currentNumberToCheckAgainst % currentNumberToCheck == 0)
                        {
                            checksum += (currentNumberToCheckAgainst / currentNumberToCheck);
                        }
                    }
                }
            }
            Console.WriteLine("The checksum is " + checksum);
        }
    }
}

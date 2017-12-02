using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    public class InverseCaptcha
    {
        public void DecodeCaptcha(string input)
        {
            PartOne(input);
            PartTwo(input);
        }

        private void PartOne(string input)
        {
             int sum  = 0;
             int previousInt = 0;
             for (int i = 0; i < input.Length; i++)
             {
                 if (i != 0)
                 {
                     if(Int32.Parse(input[i].ToString()) == previousInt)
                     {
                         sum += previousInt;
                     }
                 }

                 if ((i + 1) == input.Length)
                 {
                     if (Int32.Parse(input[i].ToString()) == Int32.Parse(input[0].ToString()))
                     {
                         sum += Int32.Parse(input[i].ToString());
                     }
                 }
                 previousInt = Int32.Parse(input[i].ToString());
             }
            Console.WriteLine("The sum for part one is: " + sum);
        }

        private void PartTwo(string input)
        {
            int sum = 0;
            int digitToCompare = 0;
            int currentInt = 0;
            int stepsForward = input.Length / 2;

            for (int i = 0; i < input.Length; i++)
            {
                currentInt = Int32.Parse(input[i].ToString());
                digitToCompare = getDigitToCompare(stepsForward, i, input);
                if (currentInt == digitToCompare)
                {
                    sum += digitToCompare;
                }
            }
            Console.WriteLine("The sum for part two is: " + sum);
        }

        private int getDigitToCompare(int stepsForward, int currentPosition, string input)
        {
            int digitToCompare = 0;
            int newPosition = currentPosition + stepsForward;
            if (!(newPosition > (input.Length -1)))
            {
                digitToCompare = Int32.Parse(input[newPosition].ToString());
            }
            else
            {
                digitToCompare = Int32.Parse(input[stepsForward - (input.Length - currentPosition)].ToString());
            }

            return digitToCompare;
        }
    }
}

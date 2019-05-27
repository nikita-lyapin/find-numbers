using System;
using System.Collections;

namespace CnslFindTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var countOfMissingNumbers = 2;
            var initialArray = new int[] { 1,2,3,4,5,6,7,8,9,11,12,13,14,15,17,18 };

            BitArray bitArray = new BitArray(initialArray.Length + countOfMissingNumbers);

            foreach (var item in initialArray)
            {
                bitArray[item - 1] = true;
            }

            for (int i = 0; i < bitArray.Length; i++)
            {
                if (bitArray[i] == false)
                {
                    Console.WriteLine($"В изначальном массиве отсутсвовало число {i + 1}");
                }
            }
        }
    }
}

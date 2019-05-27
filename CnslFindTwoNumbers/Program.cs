using System;
using System.Collections;

namespace CnslFindTwoNumbers
{
    public class Program
    {
        /// <summary>
        /// Метод находит два пропущенных числа в неотсортированном массиве.
        /// Общая идея. Т.к. числа не повторяются одно из них должно быть меньше другого. 
        /// Т.е. меньшее попадает в диапозон меньших арифметического среднего представленных в массиве. Большее в диапозон больших.
        /// 1. Считаем сумму представленных чисел.
        /// 2. Считаем среднее представленных чисел.
        /// 3. Считаем сумму для всех представленных чисел, меньших среднего из п. 2
        /// 4. Считаем сумму для всех представленных чисел, больших среднего из п. 2
        /// 5. По аналогии с поиском одного числа находим число в меньшем диапозоне.
        /// 6. Аналогично в большем.
        /// Сложность О(2N) = O(N).
        /// </summary>
        /// <param name="initialArray"></param>
        static void ImplementationWithAvg(int[] initialArray)
        {
            var countOfMissingNumbers = 2;
            var n = initialArray.Length + countOfMissingNumbers;

            var sumOfInitialArray = 0;
            for (int i = 0; i < initialArray.Length; i++)
            {
                sumOfInitialArray += initialArray[i];
            }
            
            var sumOfMissingNumbers = (n * (n + 1)) / 2 - sumOfInitialArray;

            var averangeOfMissingNumbers = (sumOfMissingNumbers / 2);

            var sumSmallerHalf = 0;
            var sumGreaterHalf = 0;
            for (int i = 0; i < n - countOfMissingNumbers; i++)
            {
                if (initialArray[i] <= averangeOfMissingNumbers)
                {
                    sumSmallerHalf += initialArray[i];
                }
                else
                {
                    sumGreaterHalf += initialArray[i];
                }
            }

            var totalSmallerHalf = (averangeOfMissingNumbers *
                                   (averangeOfMissingNumbers + 1)) / 2;
            var firstNumber = (totalSmallerHalf - sumSmallerHalf);
            var secondNumber = ((n * (n + 1)) / 2 - totalSmallerHalf) - sumGreaterHalf;

            Console.WriteLine($"В изначальном массиве отсутсвовало число {firstNumber}");
            Console.WriteLine($"В изначальном массиве отсутсвовало число {secondNumber}");
        }

        /// <summary>
        /// Общая идея - пробежатся по всему массиву, 
        /// завести битовый массив и проставлять флаги для найденных значений.
        /// </summary>
        /// <param name="initialArray"></param>
        public static void ImplementationsWithBitArray(int[] initialArray)
        {
            var countOfMissingNumbers = 2;
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
        


        static void Main(string[] args)
        {
            var initialArray = new int[] { 1,2,3,4,5,6,7,8,9,11,12,13,14,15,17,18, 19 };

            ImplementationWithAvg(initialArray);

            Console.WriteLine("Решение с битовым массивом");

            ImplementationsWithBitArray(initialArray);
        }
    }
}

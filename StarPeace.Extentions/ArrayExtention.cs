using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarPeace.Extentions
{
    public static class ArrayExtension
    {
        /// <summary>
        /// Write a program, which creates an array of 20 elements of type integer 
        /// and initializes each of the elements with a value equals to the index 
        /// of the element multiplied by 5. Print the elements to the console.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int[] IndexMultipliedByFive(this int[] array)
        {
            var newArray = new int[array.Length];

            for (int i = 0; i < newArray.Length; i++)
            {
                newArray[i] = i * 5;
            }

            return newArray;
        }

        /// <summary>
        /// reads two arrays from the console and checks whether they are equal 
        /// (two arrays are equal when they are of equal length and all of their elements, which have the same index, are equal).
        /// </summary>
        /// <param name="array"></param>
        /// <param name="array"></param>
        /// <returns>Boolean</returns>
        public static bool CompareTwoArrays(this int[] inputArrayOne, int[] inputArrayTwo)
        {
            // Transforming the input
            //string[] inputArrayOne = inputArrayOne.Split(' ');
            //string[] inputArrayTwotArrayOne = inputArrayTwo.Split(' ');

            int[] arr1 = new int[inputArrayOne.Length];
            for (int i = 0; i < inputArrayOne.Length; i++)
            {
                arr1[i] = inputArrayOne[i];
            }
            int[] arr2 = new int[inputArrayTwo.Length];
            for (int i = 0; i < inputArrayTwo.Length; i++)
            {
                arr2[i] = inputArrayTwo[i];
            }

            int counterOfEqualElements = 0;
            if (arr1.Length != arr2.Length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < arr1.Length; i++)
                {
                    if (arr1[i] == arr2[i])
                    {
                        counterOfEqualElements++;
                    }
                }
                if (counterOfEqualElements == arr1.Length)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Write a program, which compares two arrays of type char 
        /// lexicographically (character by character) and checks, 
        /// which one is first in the lexicographical order.
        /// </summary>
        public static void CharLexicographicalComparison(this char[] arr1, char[] arr2)
        {
            //string inputArr1 = Console.ReadLine();
            //string inputArr2 = Console.ReadLine();

            //char[] arr1 = inputArr1.ToCharArray();
            //char[] arr2 = inputArr2.ToCharArray();

            //int i = 0;
            //int j = 0;
            //bool equal = false;

            //while (i < arr1.Length && j < arr2.Length)
            //{
            //    if (arr1[i] > arr2[j])
            //    {
            //        Console.WriteLine(inputArr2);
            //        //return arr1[i];
            //        equal = false;
            //        break;
            //    }
            //    else if (arr1[i] < arr2[j])
            //    {
            //        Console.WriteLine(inputArr1);
            //        equal = false;
            //        break;
            //    }
            //    else
            //    {
            //        equal = true;
            //    }

            //    i++;
            //    j++;
            //}

            //if (equal == true)
            //{
            //    if (arr1.Length < arr2.Length)
            //    {
            //        Console.WriteLine(inputArr1);

            //    }
            //    else if (arr1.Length > arr2.Length)
            //    {
            //        Console.WriteLine(inputArr2);
            //    }
            //    else
            //    {
            //        Console.WriteLine("No difference");
            //    }
            //}
        }

        /// <summary>
        /// Finds the maximal sequence of 
        /// consecutive equal elements in an array. 
        /// </summary>
        public static int[] MaxSequenceEqualElements(this int[] inputArray)
        {
            string inputArrayOne = Console.ReadLine();
            char[] delimiter = new char[] { ',', ' ' };
            string[] inputOne = inputArrayOne.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

            int[] arr = new int[inputOne.Length];
            for (int i = 0; i < inputOne.Length; i++)
            {
                arr[i] = int.Parse(inputOne[i]);
            }
            int counter = 0;
            int maxSequence = 0;
            int index = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                counter = 0;
                int j = i;

                while (arr[i] == arr[j])
                {
                    counter++;
                    j++;
                    if (j >= arr.Length)
                    {
                        break;
                    }
                }

                if (counter > maxSequence)
                {
                    maxSequence = counter;
                    index = i;
                }
            }


            int[] arrayToReturn = new int[arr.Length];
            for (int i = index; i <= index + maxSequence - 1; i++)
            {
                if (i != index + maxSequence - 1)
                {
                    arrayToReturn[i] = arr[i];
                }

            }
            return arrayToReturn;
        }

        /// <summary>
        /// Write a program, which finds the maximal sequence of 
        /// consecutively placed increasing integers. 
        /// Example: {3, 2, 3, 4, 2, 2, 4}  {2, 3, 4}.
        /// </summary>
        public static int[] LongestIncreasingSequence(this int[] inputArry)
        {
            //string inputArrayOne = Console.ReadLine();
            //char[] delimiter = new char[] { ',', ' ' };
            //string[] inputOne = inputArrayOne.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

            int[] arr = new int[inputArry.Length];
            for (int i = 0; i < inputArry.Length; i++)
            {
                arr[i] = inputArry[i];
            }
            int counter = 0;
            int maxSequence = 0;
            int index = 0;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                counter = 1;
                int j = i + 1;
                int k = i;

                while (arr[k] < arr[j])
                {
                    counter++;
                    j++;
                    k++;
                    if (j >= arr.Length)
                    {
                        break;
                    }
                }
                if (counter > maxSequence)
                {
                    maxSequence = counter;
                    index = i;
                }
            }
            int[] arrayToReturn = new int[arr.Length-1];
            for (int i = index; i <= index + maxSequence - 1; i++)
            {
                if (i != index + maxSequence - 1)
                {
                    arrayToReturn[i] = arr[i];
                }

            }
            return arrayToReturn;
        }
    }
}

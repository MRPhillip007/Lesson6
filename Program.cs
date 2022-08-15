using System;
using System.Linq;

namespace Lesson6Homework
{
    class Homework
    {
        static void Main()
        {
            int[] myArray = GenerateArray();
            Console.WriteLine("Array before sorting:");
            PrintArray(myArray);
            Console.WriteLine("\n");
            Console.WriteLine("After bubble sorting: ");
            BubbleSort(myArray);
            PrintArray(myArray);

            Console.WriteLine("\n");
            Console.WriteLine("After insertation sorting: ");
            InsertionSort(myArray);
            PrintArray(myArray);

            Console.WriteLine("\n");
            Console.WriteLine("After selection sorting: ");
            SelectionSort(myArray);
            PrintArray(myArray);

            Console.WriteLine("\n");
            Console.WriteLine("Sort method calling..");
            SortAlgorithmType sortType = SortAlgorithmType.InsertionSort;
            OrderBy orderBy = OrderBy.Ask;
            Sort(myArray, sortType, orderBy);
        }
        static void BubbleSort(int[] array)
        {
            int count = array.Length;
            for (int j = 0; j < count; j++)
            {
                for (int i = 0; i < count - j - 1; i++)
                {
                    int firstElement = array[i];
                    int secondElement = array[i + 1];

                    if (firstElement > secondElement)
                    {
                        // Swap the elements
                        int temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                    }
                }
            }
        }
        static void InsertionSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                // Taking element from right side
                int temp = array[i];
                int j = i;

                while (j > 0 && temp < array[j - 1])
                {
                    array[j] = array[j - 1];
                    j--;
                }
                array[j] = temp;
            }
        }

        static void SelectionSort(int[] array)
        {
            int minIndex = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                minIndex = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                    if (i != minIndex)
                    {
                        int temp = array[i];
                        array[i] = array[minIndex];
                        array[minIndex] = temp; 
                    }
                }
            }
        }

        static int[] GenerateArray(int size = 10)
        {
            int[] array = new int[size];

            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(0, 1000);
            }
            return array;
        }
        static void PrintArray(int[] array)
        {
            foreach (int item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        // Extra task
        enum SortAlgorithmType: byte
        {
            BubbleSort,
            InsertionSort,
            SelectionSort
        }

        enum OrderBy: byte
        {
            Ask,        // Sorts from the lowest value to highest value
            Desk        // Sorts from highest value to lowest value
        }

        static void Sort(int[] array, SortAlgorithmType sortType, OrderBy orderBy)
        {
            switch (sortType)
            {
                case SortAlgorithmType.BubbleSort:
                    BubbleSort(array);
                    PrintArray(array);
                    break;
                case SortAlgorithmType.InsertionSort:
                    InsertionSort(array);
                    PrintArray(array);
                    break;
                case SortAlgorithmType.SelectionSort:
                    SelectionSort(array);
                    PrintArray(array);
                    break;
                default:
                    break;
            }

            switch (orderBy)
            {
                case OrderBy.Ask:
                    Console.WriteLine("Default sorting");
                    PrintArray(array);
                    break;
                case OrderBy.Desk:
                    Console.WriteLine("Reversed aray: ");
                    for (int i = array.Length - 1; i >= 0; i--)
                    {
                        Console.Write(array[i] + " ");
                    }
                    break;
                default:
                    break;
            }
        }
    }

}
//checked

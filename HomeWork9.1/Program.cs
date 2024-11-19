using System;
using System.Linq;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Find the second largest element of an array");
            Console.WriteLine("2. Sort a two-dimensional array in ascending order");
            Console.WriteLine("3. Remove an item from an array by index");
            Console.WriteLine("4. Find the sum of elements diagonally in a two-dimensional array");
            Console.WriteLine("0. Exit");
            Console.Write("Select an option: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    FindSecondLargestDemo();
                    break;
                case "2":
                    SortMatrixDemo();
                    break;
                case "3":
                    RemoveElementDemo();
                    break;
                case "4":
                    SumDiagonalDemo();
                    break;
                case "0":
                    Console.WriteLine("The program is complete.");
                    return;
                default:
                    Console.WriteLine("Something's wrong, try again..");
                    break;
            }
        }
    }
    static void FindSecondLargestDemo()
    {
        int[] array = { 43, 15, 27, 244, 58, 96, 2 };
        int? secondLargest = FindSecondLargest(array);

        if (secondLargest.HasValue)
            Console.WriteLine("The second largest element: " + secondLargest);
        else
            Console.WriteLine("Array is too small to determine the second largest element.");
    }
    static int? FindSecondLargest(int[] arr)
    {
        if (arr.Length < 2) return null;

        int largest = int.MinValue, secondLargest = int.MinValue;

        foreach (int num in arr)
        {
            if (num > largest)
            {
                secondLargest = largest;
                largest = num;
            }
            else if (num > secondLargest && num != largest)
            {
                secondLargest = num;
            }
        }

        return secondLargest == int.MinValue ? (int?)null : secondLargest;
    }
    static void SortMatrixDemo()
    {
        int[,] matrix = {
            { 19, 55, 23 },
            { 81, 32, 323 },
            { 45, 6, 11 }
        };

        Console.WriteLine("The initial array:");
        PrintMatrix(matrix);

        SortMatrix(matrix);

        Console.WriteLine("Sorted array:");
        PrintMatrix(matrix);
    }

    static void SortMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int[] tempArray = new int[rows * cols];
        int index = 0;

        foreach (int value in matrix)
            tempArray[index++] = value;

        Array.Sort(tempArray);

        index = 0;
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                matrix[i, j] = tempArray[index++];
    }

    static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
                Console.Write(matrix[i, j] + " ");
            Console.WriteLine();
        }
    }
    static void RemoveElementDemo()
    {
        int[] array = { 34, 95, 23, 222, 38, 996, 11 };
        Console.WriteLine("The initial array: " + string.Join(", ", array));

        Console.Write("Enter the zip code to delete: ");
        int indexToRemove = int.Parse(Console.ReadLine());

        try
        {
            int[] newArray = RemoveElement(array, indexToRemove);
            Console.WriteLine("The array after deletion: " + string.Join(", ", newArray));
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("The index is outside the array!");
        }
    }

    static int[] RemoveElement(int[] array, int index)
    {
        if (index < 0 || index >= array.Length)
            throw new ArgumentOutOfRangeException("Index outside the array");

        return array.Where((val, idx) => idx != index).ToArray();
    }
    static void SumDiagonalDemo()
    {
        int[,] matrix = {
            { 12, 52, 44 },
            { 994, 35, 16 },
            { 7, 38, 9 }
        };

        Console.WriteLine("The initial array:");
        PrintMatrix(matrix);

        int sum = SumDiagonal(matrix);

        Console.WriteLine("Sum of diagonal elements: " + sum);
    }

    static int SumDiagonal(int[,] matrix)
    {
        int sum = 0;

        for (int i = 0; i < Math.Min(matrix.GetLength(0), matrix.GetLength(1)); i++)
            sum += matrix[i, i];

        return sum;
    }
}

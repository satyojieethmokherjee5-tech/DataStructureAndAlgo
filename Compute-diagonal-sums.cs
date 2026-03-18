using System;

class DiagonalSumMatrix
{
    static void Main()
    {
        // Accept size of square matrix
        Console.Write("Enter the size of square matrix: ");
        int n = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n, n];

        // Accept elements of the matrix
        Console.WriteLine("Enter the elements of the matrix:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }

        // Display the matrix
        Console.WriteLine("\nThe matrix is:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }

        // Compute diagonal sums
        int primarySum = 0, secondarySum = 0;
        for (int i = 0; i < n; i++)
        {
            primarySum += matrix[i, i];               // Primary diagonal
            secondarySum += matrix[i, n - i - 1];     // Secondary diagonal
        }

        // Avoid double-counting center element for odd-sized matrix
        int totalSum = primarySum + secondarySum;
        if (n % 2 == 1)
        {
            totalSum -= matrix[n / 2, n / 2];
        }

        // Display results
        Console.WriteLine("\nSum of primary diagonal elements: " + primarySum);
        Console.WriteLine("Sum of secondary diagonal elements: " + secondarySum);
        Console.WriteLine("Total diagonal sum: " + totalSum);
    }
}

This problem requires us to find the most frequent item in a list (the "Mode") while handling ties using alphabetical sorting.
The logic boils down to:
 * Count the occurrences of each product.
 * Find the maximum count.
 * Handle Ties: If multiple products have that maximum count, pick the one that comes last alphabetically.
C# Implementation
In C#, the most efficient way to handle counting is using a Dictionary<string, int>.
using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public static string GetFeaturedProduct(string[] products)
    {
        if (products == null || products.Length == 0) return null;

        // Step 1: Count occurrences
        Dictionary<string, int> counts = new Dictionary<string, int>();
        foreach (string product in products)
        {
            if (counts.ContainsKey(product))
                counts[product]++;
            else
                counts[product] = 1;
        }

        // Step 2: Find the maximum frequency
        int maxCount = counts.Values.Max();

        // Step 3: Filter products with max frequency and sort them
        // The problem asks for the LAST product in an A-Z sorted list
        string featuredProduct = counts
            .Where(pair => pair.Value == maxCount)
            .Select(pair => pair.Key)
            .OrderBy(name => name)
            .Last();

        return featuredProduct;
    }

    public static void Main()
    {
        string[] example = { "redShirt", "greenPants", "redShirt", "orangeShoes", "blackPants", "blackPants" };
        Console.WriteLine($"Featured Product: {GetFeaturedProduct(example)}"); 
        // Output should be redShirt
    }
}

Step-by-Step Logic for Example 1
 * Input: ["redShirt", "greenPants", "redShirt", "orangeShoes", "blackPants", "blackPants"]
 * Counting:
   * redShirt: 2
   * greenPants: 1
   * orangeShoes: 1
   * blackPants: 2
 * Identify Max: The maximum count is 2.
 * Tied Products: Both redShirt and blackPants have 2 purchases.
 * Sort Alphabetically:
   *      * blackPants
   *      * redShirt
 * Final Selection: The last name in the sorted list is redShirt.
Performance Optimization
If the list of products is extremely large, the LINQ OrderBy and Last approach is clear and concise. However, you could also find the winner in a single pass over the Dictionary by comparing the count first, and then the string name using string.CompareTo() if the counts are equal.
Would you like to see how to write that "single-pass" version to avoid using LINQ?

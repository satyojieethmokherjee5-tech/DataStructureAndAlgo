using System;
using System.Collections.Generic;
using System.Linq;

					
public class Program
{
	public static void Main()
	{
		var monthDays = new Dictionary<int, int>
{
    {1, 31}, {2, 28}, {3, 31}, {4, 30}, {5, 31}, {6, 30},
    {7, 31}, {8, 31}, {9, 30}, {10, 31}, {11, 30}, {12, 31}
};
		
		Console.Write(ResolveDate("?2-1?"));
		
	}

static string ResolveDate(string input)
{
    var monthDays = new Dictionary<int, int>
    {
        {1, 31}, {2, 28}, {3, 31}, {4, 30}, {5, 31}, {6, 30},
        {7, 31}, {8, 31}, {9, 30}, {10, 31}, {11, 30}, {12, 31}
    };

    var parts = input.Split('-');
    string monthPart = parts[0];
    string dayPart = parts[1];

    // Resolve month
    if (monthPart.Contains("?"))
    {
        // Replace ? with 9 first
        string candidate = monthPart.Replace("?", "9");
        int month = int.Parse(candidate);
        if (month > 12) month = 0;
        monthPart = month.ToString("D2");
    }

    // Resolve day
    if (dayPart.Contains("?"))
    {
        int month = int.Parse(monthPart);
        int maxDay = monthDays[month];

        // Try all possible replacements for '?'
        int bestDay = -1;
        for (int d = 0; d <= 9; d++)
        {
            string candidate = dayPart.Replace("?", d.ToString());
            int day = int.Parse(candidate);
            if (day <= maxDay && day > bestDay)
            {
                bestDay = day;
            }
        }

        dayPart = bestDay.ToString("D2");
    }

    return $"{monthPart}-{dayPart}";
}

			
	}

	
	
	






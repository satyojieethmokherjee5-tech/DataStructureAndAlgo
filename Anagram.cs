

using System;
using System.Collections.Generic;
using System.Linq;
					
public class Program
{
	public static void Main()
	{
		//Console.WriteLine(IsAnaagram("Fried1",  "Fired"));
		Console.WriteLine(IsPolyndrom("caaac"));
	}
	
	public static bool IsPolyndrom(string data)
	{
		int left = 0, right = data.Length - 1;
        while (left < right) {
            if (data[left] != data[right]) {
                return false;
            }
            left++;
            right--;
        }
        return true;	
	}
	
	public static bool IsAnaagram(string s1,  string s2)
	{
		 if (s1.Length != s2.Length){ return false;}

		var dict= new Dictionary<char,int>();
		
		foreach(var c in s1)
		{
			if(!dict.ContainsKey(c)) {dict[c]=0;}
			dict[c]++;
		}
		
		foreach(var c in s2)
		{
			if(!dict.ContainsKey(c)) return false;
			dict[c]--;
			if(dict[c]<0){ return false;}
		}
		
		return true;
	}
	
	public static int MaxProfit(int[] prices) {
        if (prices == null || prices.Length < 2) return 0;

        int varOcg = prices[0];       // track minimum price seen so far
        int varFiltersCg = 0;         // track maximum profit

        for (int i = 1; i < prices.Length; i++) {
            // update maximum profit if selling today is better
            varFiltersCg = Math.Max(varFiltersCg, prices[i] - varOcg);

            // update minimum price if today’s price is lower
            varOcg = Math.Min(varOcg, prices[i]);
        }

        return varFiltersCg;
    }
	

}

using System;

namespace StarPeace.Extension
{
    public static class IndexMultiplied
    {
        public static int[] MultplyByFive(this Array[] arrays)
        {
            int[] arr = new int[20];
 
        	for (int i = 0; i <arr.Length; i ++)
        	{
            	arr [i] = i * 5;
        	}
 
        	for (int i = 0; i <arr.Length; i ++)
        	{
            	Console.WriteLine ("element {0} = {1}", i + 1, arr [i]);
        	}
            return arr;
    	   // Console.ReadLine();
        }
    }
}

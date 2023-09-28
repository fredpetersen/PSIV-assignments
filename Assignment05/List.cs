// (* CHANGED FOR ASSIGNMENT 5 *)
// Exercise 5.1
// B) Implement a similar method in C# as to Exercise 5.1 A) from List.fs
using System;

public class Program
{
    public static void Main()
    {
        int[] xs = { 3, 5, 12 };
        int[] ys = { 2, 3, 4, 7 };

        var mergelist = merge(xs, ys);
		foreach (var x in mergelist)
		{
			Console.WriteLine(x);
		}
			
    }

    public static int[] merge(int[] xs, int[] ys)
    {
        int xi = 0, yi = 0;
        int[] newlist = new int[xs.Length + ys.Length];
        while (xi + yi < newlist.Length)
        {
            if (xi < xs.Length)
            {
                if (yi < ys.Length && ys[yi] < xs[xi])
                {
                    newlist[yi+xi] = ys[yi++];
                }
                else
                {
                    newlist[yi+xi] = xs[xi++];
                }
            }
            else
            {
                newlist[xi+yi] = ys[yi++];
            }
        }
		return newlist;
    }
}
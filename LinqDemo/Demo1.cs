using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace LinqDemo
{
    public class Demo1
    {
        public static void Go()
        {
            // Expand list "6,1-5,7,3-4,0,8" to list 0,1,2,3,4,5,6,7,8
            string input = "6,1-5,7,3-4,0,8";
            var result = input.Split(",")// [6, 1-5, 7, 3-4, 0, 8]
                .Select(s => s.Split('-'))
                .Select(l => new { First = int.Parse(l.First()), Last = int.Parse(l.Last()) })
                .SelectMany(n => Enumerable.Range(n.First, n.Last - n.First + 1))
                .Distinct()
                .OrderBy(n => n);

            foreach (var i in result)
            {
                Console.WriteLine(i);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace LinqDemo
{
    public class Demo6
    {
        public static void Go()
        {
            Stopwatch stopwatch = new Stopwatch();
            int listSize = 1000;
            var list = Enumerable.Range(1, listSize).ToList();

            stopwatch.Restart();
            var result1 = list
                .Select(d => Math.Pow(Math.Cos(d * 2), 2))
                .Sum();
            stopwatch.Stop();

            Console.WriteLine($"LINQ query ran for {stopwatch.ElapsedMilliseconds}ms");

            stopwatch.Restart();
            double sum = 0.0;
            foreach (int i in list)
            {
                var c = Math.Pow(Math.Cos(i * 2), 2);
                sum += c;
            }
            stopwatch.Stop();

            Console.WriteLine($"For loop ran for {stopwatch.ElapsedMilliseconds}ms");


            stopwatch.Restart();
            var result3 = list.AsParallel()
                .Select(d => Math.Pow(Math.Cos(d * 2), 2))
                .Sum();
            stopwatch.Stop();

            Console.WriteLine($"LINQ parallel query ran for {stopwatch.ElapsedMilliseconds}ms");
        }
    }
}

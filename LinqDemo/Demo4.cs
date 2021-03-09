using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqDemo
{
    public class Demo4
    {
        public static void Go()
        {
            var strs = "Alice,Bob,Charlie,John"
                .Split(",")
                .Select(s =>
                {
                    Console.WriteLine(s);
                    return s.ToUpper();
                });

            //Console.WriteLine("Using Where:");
            //Console.WriteLine(strs.Where(s => s == "BOB").First());
            //Console.WriteLine();
            //Console.WriteLine("Using Filter:");
            //Console.WriteLine(strs.Filter(s => s == "BOB").First());


            // Streaming vs Non-streaming
            //var numbers = GetRandomNumber().Where(n => n > 0.5).Take(10);
            //foreach (var number in numbers)
            //{
            //    Console.WriteLine(number);
            //}

            // Multiple iteration
            //Console.WriteLine(strs.Count());
            //Console.WriteLine(strs.Any(s => s == "JOHN"));

            // Multiple iteration correctness
            var list = GetRandomNumber2().ToList();
            Console.WriteLine(list.Sum());
            Console.WriteLine(list.Sum());
            Console.WriteLine(list.Sum());
            Console.WriteLine(list.Sum());
        }

        private static IEnumerable<double> GetRandomNumber()
        {
            Random rand = new Random();
            while (true)
            {
                yield return rand.NextDouble();
            }
        }

        private static IEnumerable<int> GetRandomNumber2()
        {
            Random rand = new Random();
            for (int i = 0; i < 10; ++i)
            {
                yield return rand.Next(10);
            }
        }
    }

    public static class MyLinq1
    {
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, Func<T, bool> filterFunc)
        {
            foreach (T s in source)
            {
                if (filterFunc(s))
                {
                    yield return s;
                }
            }
        }
    }
}

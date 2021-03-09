using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace LinqDemo
{
    public class Demo5
    {
        public static void Go()
        {
            var query = Enumerable.Empty<string>();
            try
            {
                query = "Alice,Bob,Charlie,John"
                    .Split(",")
                    .Select(n =>
                    {
                        throw new Exception("Error!");
                        return n.ToUpper();
                    });
            }
            catch (Exception e)
            {
                Console.WriteLine("Got an error: " + e.Message);
                return;
            }

            foreach (var s in query)
            {
                Console.WriteLine(s);
            }
        }
    }
}

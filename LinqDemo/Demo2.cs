using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqDemo
{
    public class Demo2
    {
        public static void Go()
        {
            var cities = new City[]
            {
                new City {Name = "Austin", State = "Texas", Population = 978908},
                new City {Name = "Charlotte", State = "North Carolina", Population = 885708},
                new City {Name = "Chicago", State = "Illinois", Population = 2693976},
                new City {Name = "Columbus", State = "Ohio", Population = 898553},
                new City {Name = "Dallas", State = "Texas", Population = 1343573},
                new City {Name = "Denver", State = "Colorado", Population = 727211},
                new City {Name = "Fort Worth", State = "Texas", Population = 909585},
                new City {Name = "Houston", State = "Texas", Population = 2320268},
                new City {Name = "Indianapolis", State = "Indiana", Population = 876384},
                new City {Name = "Jacksonville", State = "Florida", Population = 911507},
                new City {Name = "Los Angeles", State = "California", Population = 3979576},
                new City {Name = "New York City", State = "New York", Population = 8335817},
                new City {Name = "Phoenix", State = "Arizona", Population = 1680992},
                new City {Name = "Philadelphia", State = "Pennsylvania", Population = 1584064},
                new City {Name = "San Antonio", State = "Texas", Population = 1547253},
                new City {Name = "San Diego", State = "California", Population = 1423851},
                new City {Name = "San Francisco", State = "California", Population = 881549},
                new City {Name = "San Jose", State = "Florida", Population = 1021795},
                new City {Name = "Seattle", State = "Washington", Population = 753675},
            };

            int maxPopulation = cities.Max(c => c.Population);
            Console.WriteLine($"Max population is: {maxPopulation}");
            Console.WriteLine(cities.First(c => c.Population == maxPopulation).Name);

            Console.WriteLine(cities.MyMax(c => c.Population).Name);
        }
    }

    public static class MyLinq
    {
        public static T MyMax<T>(this IEnumerable<T> source, Func<T, int> selector)
        {
            if (source == null || selector == null)
            {
                throw new ArgumentNullException();
            }

            T ret = default(T);
            int max = Int32.MinValue;
            foreach (T s in source)
            {
                int currentValue = selector(s);
                if (currentValue > max)
                {
                    ret = s;
                    max = currentValue;
                }
            }

            return ret;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqDemo
{
    public class Demo0
    {
        public static void Go()
        {
            var cities = new City[]
            {
                new City() {Name = "Austin", State = "Texas", Population = 978908},
                new City() {Name = "Charlotte", State = "North Carolina", Population = 885708},
                new City() {Name = "Chicago", State = "Illinois", Population = 2693976},
                new City() {Name = "Columbus", State = "Ohio", Population = 898553},
                new City() {Name = "Dallas", State = "Texas", Population = 1343573},
                new City() {Name = "Denver", State = "Colorado", Population = 727211},
                new City() {Name = "Fort Worth", State = "Texas", Population = 909585},
                new City() {Name = "Houston", State = "Texas", Population = 2320268},
                new City() {Name = "Indianapolis", State = "Indiana", Population = 876384},
                new City() {Name = "Jacksonville", State = "Florida", Population = 911507},
                new City() {Name = "Los Angeles", State = "California", Population = 3979576},
                new City() {Name = "New York City", State = "New York", Population = 8335817},
                new City() {Name = "Phoenix", State = "Arizona", Population = 1680992},
                new City() {Name = "Philadelphia", State = "Pennsylvania", Population = 1584064},
                new City() {Name = "San Antonio", State = "Texas", Population = 1547253},
                new City() {Name = "San Diego", State = "California", Population = 1423851},
                new City() {Name = "San Francisco", State = "California", Population = 881549},
                new City() {Name = "San Jose", State = "Florida", Population = 1021795},
                new City() {Name = "Seattle", State = "Washington", Population = 753675},
            };

            //SelectDemo(cities);
            //WhereDemo(cities);
            //FirstDemo(cities);
            //AllAnyDemo(cities);
            //CountSumDemo(cities);
            //GroupByDemo(cities);
            //OrderByDemo(cities);
        }

        private static void SelectDemo(IEnumerable<City> cities)
        {
            var result = new List<string>();
            foreach (var city in cities)
            {
                result.Add($"{city.Name}, {city.State}");
            }

            //var result = cities.Select(c => $"{c.Name}, {c.State}");

            foreach (var s in result)
            {
                Console.WriteLine(s);
            }
        }

        private static void WhereDemo(IEnumerable<City> cities)
        {
            var result = new List<City>();
            foreach (var city in cities)
            {
                if (string.Equals("California", city.State))
                {
                    result.Add(city);
                }
            }

            //var result = cities.Where(c => string.Equals("California", c.State));

            foreach (var s in result)
            {
                Console.WriteLine(s.Name);
            }
        }

        private static void FirstDemo(IEnumerable<City> cities)
        {
            City result = null;
            foreach (var city in cities)
            {
                if (string.Equals(city.Name, "Indianapolis"))
                {
                    result = city;
                    break;
                }
            }

            //var result = cities.FirstOrDefault(c => string.Equals(c.Name, "Indianapolis"));

            if (result != null)
            {
                Console.WriteLine($"{result.Name} has population {result.Population}");
            }
        }

        private static void AnyAllDemo(IEnumerable<City> cities)
        {
            // If any city has population larger than 2 million
            bool result1 = false;
            foreach (var city in cities)
            {
                if (city.Population > 2000000)
                {
                    result1 = true;
                    break;
                }
            }

            //var result1 = cities.Any(c => c.Population > 2000000);
            Console.WriteLine($"Does any city has population larger than 2 million? {(result1 ? "Yes" : "No")}");

            // If all the cities has population larger than 1 million
            bool result2 = true;
            foreach (var city in cities)
            {
                if (!(city.Population > 1000000))
                {
                    result2 = false;
                    break;
                }
            }

            //var result2 = cities.All(c => c.Population > 1000000);
            Console.WriteLine($"Do all the cities has population larger than 1 million? {(result2 ? "Yes" : "No")}");
        }

        private static void CountSumDemo(IEnumerable<City> cities)
        {
            int count = 0;
            foreach (var city in cities)
            {
                if (string.Equals("California", city.State))
                {
                    count++;
                }
            }

            //int count = cities.Count(c => string.Equals("California", c.State));
            Console.WriteLine($"There are {count} cities from California in this list.");

            long sum = 0;
            foreach (var city in cities)
            {
                sum += city.Population;
            }

            //long sum = cities.Sum(c => c.Population);
            Console.WriteLine($"Total population from the list: {sum}");
        }

        private static void GroupByDemo(IEnumerable<City> cities)
        {
            var dict = new Dictionary<string, IList<City>>();
            foreach (var city in cities)
            {
                if (!dict.ContainsKey(city.State))
                {
                    dict[city.State] = new List<City>();
                }

                dict[city.State].Add(city);
            }

            //var dict = cities
            //    .GroupBy(c => c.State)
            //    .ToDictionary(g => g.Key, g => g.ToList());
        }

        private static void OrderByDemo(City[] cities)
        {
            Array.Sort(cities, new CityPopulationComparer());
            for (int i = 0; i < 5; ++i)
            {
                Console.WriteLine($"{cities[i].Name}: \t{cities[i].Population}");
            }

            // Method syntax
            var top5Population = cities
                .OrderByDescending(c => c.Population)
                .Take(5);

            // Query syntax
            //var top5Population = from city in cities
            //    orderby city.Population descending
            //    select city;

            foreach (var city in top5Population)
            {
                Console.WriteLine($"{city.Name}: \t{city.Population}");
            }
        }

        class CityPopulationComparer : IComparer<City>
        {
            public int Compare(City x, City y)
            {
                if (x == null || y == null) throw new ArgumentNullException();

                return y.Population.CompareTo(x.Population);
            }
        }

        private static void SelectManyDemo()
        {
            var lists = new List<List<int>>()
            {
                new List<int>() {1, 2},
                new List<int>() {3},
                new List<int>() {4, 5, 6},
                new List<int>() {7, 8},
            };

            var singleList = new List<int>();
            foreach (var list in lists)
            {
                singleList.AddRange(list);
            }

            //var singleList = lists.SelectMany(l => l);

            foreach (int element in singleList)
            {
                Console.WriteLine(element);
            }
        }
    }
}

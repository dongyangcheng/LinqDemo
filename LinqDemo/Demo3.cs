using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqDemo
{
    public class Demo3
    {
        private class City2
        {
            public string Name { get; set; }

            public string State { get; set; }

            private int _population;

            public int Population
            {
                get
                {
                    Console.WriteLine($"Reading property {nameof(Population)} for city {Name}");
                    return _population;
                }
                set => _population = value;
            }
        }

        public static void Go()
        {
            var cities = new City2[]
            {
                new City2() {Name = "Austin", State = "Texas", Population = 978908},
                new City2() {Name = "Charlotte", State = "North Carolina", Population = 885708},
                new City2() {Name = "Chicago", State = "Illinois", Population = 2693976},
                new City2() {Name = "Columbus", State = "Ohio", Population = 898553},
                new City2() {Name = "Dallas", State = "Texas", Population = 1343573},
                new City2() {Name = "Denver", State = "Colorado", Population = 727211},
                new City2() {Name = "Fort Worth", State = "Texas", Population = 909585},
                new City2() {Name = "Houston", State = "Texas", Population = 2320268},
                new City2() {Name = "Indianapolis", State = "Indiana", Population = 876384},
                new City2() {Name = "Jacksonville", State = "Florida", Population = 911507},
                new City2() {Name = "Los Angeles", State = "California", Population = 3979576},
                new City2() {Name = "New York City", State = "New York", Population = 8335817},
                new City2() {Name = "Phoenix", State = "Arizona", Population = 1680992},
                new City2() {Name = "Philadelphia", State = "Pennsylvania", Population = 1584064},
                new City2() {Name = "San Antonio", State = "Texas", Population = 1547253},
                new City2() {Name = "San Diego", State = "California", Population = 1423851},
                new City2() {Name = "San Francisco", State = "California", Population = 881549},
                new City2() {Name = "San Jose", State = "Florida", Population = 1021795},
                new City2() {Name = "Seattle", State = "Washington", Population = 753675},
            };

            var query = cities
                .Where(c => c.Population > 2000000).OrderByDescending(c => c.Population);
            //foreach (var city in query)
            //{
            //    Console.WriteLine(city.Name);
            //}

            //var result = cities.Any(c => c.Population > 2000000);
        }
    }
}

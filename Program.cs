using System;
using System.Collections;

    
namespace LinQ
{

    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string RegNumber { get; set; }

        public double EngineSize { get; set; }


        public override string ToString()
        {
            return $"Make: {Make}\nModel: {Model}\nReg Number: {RegNumber}\nEngine Size: {EngineSize}";
        }
        static class Program
        {
            static void Main()
            {
                var fleet = new List<Car>()
                {
                    new Car() { Make = "Mercedes", Model = "c180", RegNumber = "82u37w", EngineSize = 1.25 },
                     new Car() { Make = "Mazda", Model = "Elantra", RegNumber = "55u37w", EngineSize = 3.25 },
                      new Car() { Make = "Mercedes", Model = "e250", RegNumber = "66u37w", EngineSize = 5.25 },
                       new Car() { Make = "Mazda", Model = "Excel", RegNumber = "77u37w", EngineSize = 4.25 },
                        new Car() { Make = "Toyota", Model = "dhr", RegNumber = "22u37w", EngineSize = 2.25 },
                        new Car() { Make = "Audi", Model = "TT", RegNumber = "99u37w", EngineSize = 6.25 },
                };


                var ListAscending = fleet.OrderBy(car => car.RegNumber);
                Console.WriteLine("Cars in Ascending order: ", ListAscending);
                foreach( var car in ListAscending)
                {
                    Console.WriteLine(car);
                }

                // Type 2

                var AscendingOrder = from car in fleet
                                     orderby car.RegNumber
                                     select car;

                var MazdaCars = fleet.Where(car => car.Make == "Mazda").Select(car => car.Model);
                Console.WriteLine("Mazda cars: ", MazdaCars);
                foreach( var car in MazdaCars)
                { Console.WriteLine(car); }

                // Type 2

                var MazdaType = from car in fleet
                                where car.Make == "Mazda"
                                select car.Model;

                var CarDescendingEngineSize = fleet.OrderByDescending(car => car.EngineSize);
                Console.WriteLine("Descending Engine Size: ", CarDescendingEngineSize);
                foreach( var car in CarDescendingEngineSize)
                { Console.WriteLine(car); }

                // Type 2
                var DescendingOrder = from car in fleet
                                      orderby car.EngineSize descending
                                      select car;

                var MakeModel1600 = fleet.Where(car => car.EngineSize == 2.25).Select(car => $"{car.Make}, {car.Model}");
                Console.WriteLine("1600: ", MakeModel1600);
                foreach( var car in MakeModel1600)
                { Console.WriteLine(car); }

                // Type 2

                var Model1600 = from car in fleet
                                where car.EngineSize == 1.25
                                select new {car.Make, car.Model};

                var CountSmallCars = fleet.Where(car => car.EngineSize >= 2.25).Count();
                Console.WriteLine("Count: ", CountSmallCars);

                // Type 2

                var CountSmallCar = (from car in fleet
                                      where car.EngineSize >= 1.25
                                      select car).Count();
           




            }


        }
    }
}
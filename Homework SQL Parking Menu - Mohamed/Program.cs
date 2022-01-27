using System;
using System.Diagnostics;

namespace Homework_SQL_Parking_Menu___Mohamed
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Stopwatch stopwatch = new Stopwatch();

            Console.WriteLine("Alla bilar: ");
            var cars = DataBaseADO.GetAllCars();
            // var cars = DataBaseDapper.GetAllCars();

            stopwatch.Start();
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Id}\t{car.Plate}\t{car.Make}\t{car.Color}\t{car.ParkingSlotsId}");
            }
            stopwatch.Stop();

            Console.WriteLine("Tid: " + stopwatch.ElapsedMilliseconds);
            Console.WriteLine("---------------------------------------------");
            stopwatch.Restart();
            var allParkingspots = DataBaseADO.GetAllSpots();
            //var allParkingspots = DataBaseDapper.GetAllSpots();

            foreach (var house in allParkingspots)
            {
                Console.WriteLine($"{house.HouseName}   \t{house.PlatserPerHus}\t{house.Slots}");
            }

            stopwatch.Stop();
            Console.WriteLine("Tid: " + stopwatch.ElapsedMilliseconds);
            Console.WriteLine("----------------------------------------------");


            // Lägg till ny bil
            Random rnd = new Random();
            var rNumber = rnd.Next(100, 999);

            var newCar = new Models.Car
            {
                Plate = "XPW" + rNumber,
                Make = "Tesla",
                Color = "Röd"
            };
            int rowsAffected = DataBaseDapper.InsertCar(newCar);
            Console.WriteLine("Antal bilar tillagda: " + rowsAffected);
            Console.WriteLine("----------------------------------------------");

            // Parkera bil
            rowsAffected = DataBaseDapper.ParkCar(6, 12);
            Console.WriteLine("Antal bilar parkerade: " + rowsAffected);


            Console.WriteLine("----------------------------------------------");


            var listOfCities = DataBaseDapper.GetAllCities();
            foreach (var city in listOfCities)
            {
                Console.WriteLine($"{city.Id}\t {city.CityName}");
            }
            */

            //var newCity = new Models.City { CityName = "Rio"};

            /*
            int rowsAffected = DataBaseDapper.InsertCity(newCity);
            Console.WriteLine("Antal Städer tillagda: " + rowsAffected);
            Console.WriteLine("----------------------------------------------");
            */

            var listOfCities = DataBaseDapper.GetAllCities();
            foreach (var city in listOfCities)
            {
                Console.WriteLine($"{city.Id}\t {city.CityName}");
            }

            int test1 = DataBaseDapper.RemoveCity("Ifzan");

            Console.WriteLine(test1);
            Console.WriteLine("---------------------------------------------");
            var ParkingHouses = DataBaseDapper.GetAllParkingHouse();
            foreach (var House in ParkingHouses)
            {
                Console.WriteLine($"{House.Id}\t {House.HouseName}\t     {House.CityId}");
            }

        }
    }
}

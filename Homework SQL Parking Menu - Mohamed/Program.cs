using System;
using System.Diagnostics;

namespace Homework_SQL_Parking_Menu___Mohamed
{
    class Program
    {
        static void Main(string[] args)
        {
            bool runProgram = true;
            
            while (runProgram)
            {
                Prints.Print.Menu();
                switch (Console.ReadLine())
                {
                    case "1":
                        Input1();
                        break;
                    case "2":
                        Input2();
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    default:
                        Console.WriteLine("Incorect Input!");
                        Console.WriteLine("\nPress Enter To Continue...");
                        Console.ReadKey(); 
                        break;
                }
            }        
        }
        public static void Input1()
        {

            Prints.Print.MenuShow();

            switch (Console.ReadLine())
            {
                case "1":
                    Input1_1();
                    break;
                case "2":
                    Input1_2();
                    break;
                case "3":
                    Input1_3();
                    break;
                default:
                    Console.WriteLine("Incorect Input!");
                    Console.WriteLine("\nPress Enter To Continue...");
                    Console.ReadKey();
                    break;
            }

        }
        public static void Input1_1()
        {
            var cars = DataBaseDapper.GetAllCars();
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Id}\t {car.Make} \t{car.Plate}");
            }
            Console.WriteLine("\nPress Enter To Continue");
            Console.ReadKey();
        }
        public static void Input1_2()
        {
            var cities = DataBaseDapper.GetAllCities();
            foreach (var city in cities)
            {
                Console.WriteLine($"{city.Id}\t {city.CityName}");
            }
            Console.WriteLine("\nPress Enter To Continue");
            Console.ReadKey();
        }
        public static void Input1_3()
        {
            Prints.Print.MenuShowSpot();
            switch (Console.ReadLine())
            {
                case "1":
                    var allspots = DataBaseDapper.GetAllSpots();
                    foreach (var spot in allspots)
                    {
                        Console.WriteLine($"{spot.PlatserPerHus}\t {spot.HouseName} \t {spot.Slots}");
                    }
                    break;
                case "2":
                    var spotsElectric = DataBaseDapper.GetElectricSpots();
                    foreach (var spot in spotsElectric)
                    {
                        Console.WriteLine($"{spot.PlatserPerHus}\t {spot.HouseName} \t {spot.Slots}");
                    }
                    break;
                default:
                    break;
            }
            Console.WriteLine("\nPress Enter To Continue");
            Console.ReadKey();

        }
        public static void Input2()
        {
            Prints.Print.MenuCreate();
            Console.ReadKey();

            switch (Console.ReadLine())
            {
                case "1":
                    
                    break;
                case "2":
                    
                    break;
                case "3":
                    
                    break;
                default:
                    Console.WriteLine("Incorect Input!");
                    Console.WriteLine("\nPress Enter To Continue...");
                    Console.ReadKey();
                    break;
            }
        }




    }

}

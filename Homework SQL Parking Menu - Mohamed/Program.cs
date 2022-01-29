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
                        Input3();
                        break;
                    case "4":
                        Input4();
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
                case "4":
                    Input1_4();
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
        public static void Input1_4()
        {
            var allHouses = DataBaseDapper.GetAllParkingHouse();
            Console.WriteLine($"ID:\t Name:\t Location:");

            foreach (var house in allHouses)
            {
                Console.WriteLine($"{house.Id}\t{house.HouseName}\t{house.CityId}");
            }
            Console.WriteLine("\nPress Enter To Continue");
            Console.ReadKey();
        }
        public static void Input2()
        {
            Prints.Print.MenuCreate();

            switch (Console.ReadLine())
            {
                case "1":
                    Input2_1();
                    break;
                case "2":
                    Input2_2();
                    break;
                case "3":
                    Input2_3();
                    break;
                case "4":
                    Input2_4();
                    break;
                default:
                    Console.WriteLine("Incorect Input!");
                    Console.WriteLine("\nPress Enter To Continue...");
                    Console.ReadKey();
                    break;
            }
        }
        public static void Input2_1()
        {
            Models.Car newCar = new Models.Car {ParkingSlotsId = null};
            Console.Write("\nPlease Enter The Car Plate: ");
            newCar.Plate = Console.ReadLine();
            Console.Write("\nPlease Enter The Maker Of The Car: ");
            newCar.Make = Console.ReadLine();
            Console.Write("\nPlease Enter The Color of the Car: ");
            newCar.Color = Console.ReadLine();

            Console.WriteLine($"\n{DataBaseDapper.InsertCar(newCar)} Rows Affected");
            Console.WriteLine("Press Enter To Continue...");
            Console.ReadKey();
        }
        public static void Input2_2()
        {
            Models.City newCity = new Models.City();
            Console.Write("\nPlease Enter The City Name: ");
            newCity.CityName = Console.ReadLine();

            Console.WriteLine($"\n{DataBaseDapper.InsertCity(newCity)} Rows Affected");
            Console.WriteLine("Press Enter To Continue...");
            Console.ReadKey();
        }
        public static void Input2_3()
        {
            var cities = DataBaseDapper.GetAllCities();
            foreach (var city in cities)
            {
                Console.WriteLine($"{city.Id}\t {city.CityName}");
            }

            Models.ParkingHouse house = new Models.ParkingHouse();
            Console.Write("\n\nEnter Existing City Id:  ");
            try
            {
                int InputId = Convert.ToInt32(Console.ReadLine());
                house.CityId = InputId;
                Console.Write("\nEnter Parking Garage Name:");
                house.HouseName = Console.ReadLine();
                Console.WriteLine($"\n{DataBaseDapper.InsertParkeringHouse(house)} Rows Affected");
                Console.WriteLine("Press Enter To Continue...");
                Console.ReadKey();

            }
            catch
            {
                Console.WriteLine("The Id Enterd was not a valid number!");
                Console.WriteLine("Press Enter To Continue...");
                Console.ReadKey();
            }
        }
        public static void Input2_4()
        {
            var allHouses = DataBaseDapper.GetAllParkingHouse();
            Console.WriteLine($"ID:\t Name:\t Location:");

            foreach (var house in allHouses)
            {
                Console.WriteLine($"{house.Id}\t{house.HouseName}\t{house.CityId}");
            }

            var spot = new Models.ParkingSlot();

            Console.Write("\n\nEnter Existing Parking House Id:  ");
            try
            {
                int inputId = Convert.ToInt32(Console.ReadLine());
                spot.SlotNumber = 1 + DataBaseDapper.GetSpecificParkingSpotsAmount(inputId);
                spot.ParkingHouseId = inputId;
                Console.WriteLine("Enter [1] For Electric, [2] For Non Electric Spot");
                spot.ElectricOutlet = Convert.ToByte(Console.ReadLine());
                Console.WriteLine($"\n{DataBaseDapper.InsertParkingSpot(spot)} Rows Affected");
                Console.WriteLine("Press Enter To Continue...");
                Console.ReadKey();

            }
            catch
            {
                Console.WriteLine("The Number Enterd was not a valid number!");
                Console.WriteLine("Press Enter To Continue...");
                Console.ReadKey();
            }


        }
        public static void Input3()
        {
            var cars = DataBaseDapper.GetAllCars();
            Console.WriteLine($"Id\tMake\tPlate\n");
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Id}\t {car.Make} \t{car.Plate}");
            }
            Console.WriteLine("\nSelect Existing Car Id: ");
            try
            {
                int chosenCarId = Convert.ToInt32(Console.ReadLine());

                Prints.Print.MenuInteract();
                switch (Console.ReadLine())
                {
                    case "1":
                        Input3_1(chosenCarId);
                        break;
                    case "2":
                        Console.WriteLine($"{DataBaseDapper.DriveAwayCar(chosenCarId)} Rows Affected");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Incorect Input!");
                        Console.WriteLine("\nPress Enter To Continue...");
                        Console.ReadKey();
                        break;
                }
            }
            catch
            {
                Console.WriteLine("The Id Enterd was not a valid number!");
                Console.WriteLine("Press Enter To Continue...");
                Console.ReadKey();
            }

        }
        public static void Input3_1(int chosenCar)
        {
            var allHouses = DataBaseDapper.GetAllParkingHouse();
            Console.WriteLine($"ID:\t Name:\t Location:");

            foreach (var house in allHouses)
            {
                Console.WriteLine($"{house.Id}\t{house.HouseName}\t{house.CityId}");
            }
            try
            {
                Console.WriteLine("\nSelect Parking House Id: ");
                var parkings = DataBaseDapper.GetSpecificParkingSpots(Convert.ToInt32(Console.ReadLine()));

                Console.WriteLine($"Id:\t Electric(1 = Y / 0 = N)");
                foreach (var spot in parkings)
                {
                    Console.WriteLine($"{spot.Id}\t{spot.ElectricOutlet}");
                }
                Console.WriteLine("\nSelect Existing Spot Id: ");
                int chosenSpot = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine($"\n{DataBaseDapper.ParkCar(chosenCar, chosenSpot)} Rows Affected");
                Console.ReadKey();
            }
            catch
            {
                Console.WriteLine("The Id Enterd was not a valid number!");
                Console.WriteLine("Press Enter To Continue...");
                Console.ReadKey();
            }
        }
        public static void Input4()
        {
            Prints.Print.MenuDelete();
            switch (Console.ReadLine())
            {
                case "1":
                    Input4_1();
                    break;
                case "2":
                    Input4_2();
                    break;
                case "3":
                    Input4_3();
                    break;
                case "4":
                    Input4_4();
                    break;
                default:
                    Console.WriteLine("Incorect Input!");
                    Console.WriteLine("\nPress Enter To Continue...");
                    Console.ReadKey();
                    break;
            }
        }
        public static void Input4_1()
        {
            var Citis = DataBaseDapper.GetAllCities();
            foreach (var City in Citis)
            {
                Console.WriteLine($"{City.Id}\t {City.CityName}");
            }

            Console.Write("\nInput The City Name: ");

            Console.WriteLine($"\n{DataBaseDapper.RemoveCity(Console.ReadLine())} Rows Affected");
            Console.WriteLine("Press Enter To Continue...");
            Console.ReadKey();

        }
        public static void Input4_2()
        {
            var houses = DataBaseDapper.GetAllParkingHouse();
            foreach (var house in houses)
            {
                Console.WriteLine($"{house.Id}\t {house.HouseName}");
            }
            Console.Write("\nInput A Valid Parking House Id: ");

            try
            {
                int input = Convert.ToInt32(Console.ReadLine());
                var spots = DataBaseDapper.GetSpecificParkingSpots(input);
                Console.WriteLine($"Id\t Electric[1 = Y/ 0 = N]");
                foreach (var spot in spots)
                {
                    Console.WriteLine($"{spot.Id}\t {spot.ElectricOutlet}");
                }
                Console.Write("\nInput A Valid Parking House Id: ");

                input = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"\n{DataBaseDapper.RemoveParkingSpot(input)} Rows Affected");
                Console.ReadKey();
            }
            catch
            {
                Console.WriteLine("The Number Enterd was not a valid number!");
                Console.WriteLine("Press Enter To Continue...");
                Console.ReadKey();
            }
        }
        public static void Input4_3()
        {
            var houses = DataBaseDapper.GetAllParkingHouse();
            foreach (var house in houses)
            {
                Console.WriteLine($"{house.Id}\t {house.HouseName}");
            }

            Console.Write("\nInput The Parking House Name: ");

            Console.WriteLine($"\n{DataBaseDapper.RemoveParkingHouse(Console.ReadLine())} Rows Affected");
            Console.WriteLine("Press Enter To Continue...");
            Console.ReadKey();
        }
        public static void Input4_4()
        {
            var cars = DataBaseDapper.GetAllCars();
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Id}\t {car.Make} \t{car.Plate}");
            }
            Console.Write("\nInput Plate Number (123ABC): ");
            Console.WriteLine($"\n{DataBaseDapper.RemoveCar(Console.ReadLine())} Rows Affected");


            Console.WriteLine("Press Enter To Continue...");
            Console.ReadKey();
        }

    }

}

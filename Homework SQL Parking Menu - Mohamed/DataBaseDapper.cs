using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Homework_SQL_Parking_Menu___Mohamed
{
    class DataBaseDapper
    {
        static string connString = "data source=.\\SQLEXPRESS; initial catalog = Parking2; persist security info = True; Integrated Security = True;";

        #region Car
        //Car
        public static List<Models.Car> GetAllCars()
        {
            var sql = "SELECT * FROM Cars";
            var cars = new List<Models.Car>();
            using (var connection = new SqlConnection(connString))
            {
                cars = connection.Query<Models.Car>(sql).ToList();
            }
            return cars;
        }
        public static int ParkCar(int carId, int spotId)
        {
            int affectedRows = 0;
            var sql = $"update Cars set ParkingSlotsId = {spotId} where Id = {carId}";
            using (var connection = new SqlConnection(connString))
            {
                affectedRows = connection.Execute(sql);
            }
            return affectedRows;
        }
        public static int DriveAwayCar(int Id)
        {
            int affectedRows = 0;
            var sql = $"update Cars set ParkingSlotsId = NULL where Id = '{Id}'";
            using (var connection = new SqlConnection(connString))
            {
                affectedRows = connection.Execute(sql);
            }
            return affectedRows;
        }
        public static int InsertCar(Models.Car car)
        {
            int affectedRows = 0;

            var sql = $"insert into Cars(Plate, Make, Color) values ('{car.Plate.ToUpper()}', '{car.Make}', '{car.Color}')";

            using (var connection = new SqlConnection(connString))
            {
                try
                {
                    affectedRows = connection.Execute(sql);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return affectedRows;
        }
        public static int RemoveCar(string plate)
        {
            var sql = $"DELETE FROM Car WHERE Plate = '{plate.ToUpper()}'";
            var affectedRows = 0;

            using (var connection = new SqlConnection(connString))
                affectedRows = connection.Execute(sql);

            return affectedRows;
        }
        #endregion

        #region City
        
        public static List<Models.City> GetAllCities()
        {
            var sql = "SELECT * FROM Cities";
            var cities = new List<Models.City>();
            using (var connection = new SqlConnection(connString))
            {
                cities = connection.Query<Models.City>(sql).ToList();
            }
            return cities;
        }

        public static int InsertCity(Models.City city)
        {
            int affectedRows = 0;

            var sql = $"insert into Cities(CityName) values ('{city.CityName}')";

            using (var connection = new SqlConnection(connString))
            {
                try
                {
                    affectedRows = connection.Execute(sql);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return affectedRows;
        }
      
        public static int RemoveCity(string cityName)
        {
            var sql = $"DELETE FROM Cities WHERE Cityname = '{cityName}'";
            var affectedRows = 0;

            using (var connection = new SqlConnection(connString))
                affectedRows = connection.Execute(sql);

            return affectedRows;
        }
        #endregion

        #region ParkingHouse
        public static List<Models.ParkingHouse> GetAllParkingHouse()
        {
            var sql = "SELECT * FROM ParkingHouses";
            var Houses = new List<Models.ParkingHouse>();
            using (var connection = new SqlConnection(connString))
            {
                Houses = connection.Query<Models.ParkingHouse>(sql).ToList();
            }
            return Houses;
        }
        public static int InsertParkeringHouse(Models.ParkingHouse PHouse)
        {
            int affectedRows = 0;

            var sql = $"INSERT INTO ParkingHouses (HouseName, CityId) VALUES('{PHouse.HouseName}', {PHouse.CityId})";

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    affectedRows = connection.Execute(sql);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return affectedRows;
        }
        public static int RemoveParkingHouse(string houseName)
        {
            var sql = $"delete from ParkingHouses where HouseName = '{houseName}'";
            var affectedRows = 0;

            using (var connection = new SqlConnection(connString))
                affectedRows = connection.Execute(sql);

            return affectedRows;
        }
        #endregion

        #region Spots
        public static List<Models.AllSpots> GetAllSpots()
        {
            var sql = @"
                        SELECT
                            count(*) AS PlatserPerHus,
                            ph.HouseName,
	                        STRING_AGG(ps.SlotNumber, ', ') AS Slots
                        FROM
                            ParkingHouses ph
                        JOIN
                            ParkingSlots ps ON ph.Id = ps.ParkingHouseId
                        GROUP BY
                            ph.HouseName";

            var spotsPerHouse = new List<Models.AllSpots>();
            using (var connection = new SqlConnection(connString))
            {
                spotsPerHouse = connection.Query<Models.AllSpots>(sql).ToList();

            }
            return spotsPerHouse;
        }

        public static List<Models.AllSpots> GetElectricSpots()
        {
            var sql = @"
                        SELECT
                            count(*) AS PlatserPerHus,
                            ph.HouseName,
	                        STRING_AGG(ps.SlotNumber, ', ') AS Slots
                        FROM
                            ParkingHouses ph
                        JOIN
                            ParkingSlots ps ON ph.Id = ps.ParkingHouseId
                        WHERE
							ps.ElectricOutlet = 1
                        GROUP BY
                            ph.HouseName";

            var spotsPerHouse = new List<Models.AllSpots>();
            using (var connection = new SqlConnection(connString))
            {
                spotsPerHouse = connection.Query<Models.AllSpots>(sql).ToList();

            }
            return spotsPerHouse;
        }
        public static int InsertParkingSpot(Models.ParkingSlot parkingSlot)
        {
            int affectedRows = 0;

            var sql = $"INSERT INTO ParkingSlots (SlotNumber, ElectricOutlet, ParkingHouseId) VALUES({parkingSlot.SlotNumber}, {parkingSlot.ElectricOutlet}, {parkingSlot.ParkingHouseId})";

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    affectedRows = connection.Execute(sql);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return affectedRows;
        }
        public static int RemoveParkingSpot(int slot)
        {
            var sql = $"delete from ParkingSlots where Id = {slot}";
            var affectedRows = 0;

            using (var connection = new SqlConnection(connString))
                affectedRows = connection.Execute(sql);

            return affectedRows;
        }
        #endregion

        public static int GetSpecificParkingSpotsAmount(int input)
        {
            string sql = @$"SELECT Count(SlotNumber)
            FROM ParkingSlots
            Where[ParkingHouseId] = {input}";


            int Specific;
            using (var connection = new SqlConnection(connString))
            {
                Specific = connection.ExecuteScalar<int>(sql);
            }
            return Specific;
        }
        public static List<Models.ParkingsInGarage> GetSpecificParkingSpots(int input)
        {
            string sql = @$"Select Id, ElectricOutlet 
                           FROM ParkingSlots
                           WHERE ParkingHouseId = {input}";

            var spotList = new List<Models.ParkingsInGarage>();
            using (var connection = new SqlConnection(connString))
            {
                spotList = connection.Query<Models.ParkingsInGarage>(sql).ToList();
            }
            return spotList;
        }
    }
}

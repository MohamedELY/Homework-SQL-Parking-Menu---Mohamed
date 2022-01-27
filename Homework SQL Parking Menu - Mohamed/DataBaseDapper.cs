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

        public static int InsertCar(Models.Car car)
        {
            int affectedRows = 0;

            var sql = $"insert into Cars(Plate, Make, Color) values ('{car.Plate}', '{car.Make}', '{car.Color}')";

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

        //City
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

        //ParkingHouse

        public static 

    }
}

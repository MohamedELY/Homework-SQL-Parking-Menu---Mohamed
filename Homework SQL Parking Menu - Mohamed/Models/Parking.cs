using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_SQL_Parking_Menu___Mohamed.Models
{
    class Parking
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public string HouseName { get; set; }
        public int SlotNumber { get; set; }
        public byte ElectricOutlet { get; set; }
        public string Plate { get; set; }
        public string CarData { get; set; }
    }
}

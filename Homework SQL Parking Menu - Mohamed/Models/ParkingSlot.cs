using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_SQL_Parking_Menu___Mohamed.Models
{
    class ParkingSlot
    {
        public int Id { get; set; }
        public int SlotNumber { get; set; }
        public byte ElectricOutlet { get; set; }
        public int ParkingHouseId { get; set; }
    }
}

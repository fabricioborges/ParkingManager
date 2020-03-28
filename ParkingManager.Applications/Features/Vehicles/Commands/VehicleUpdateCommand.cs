using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManager.Application.Features.Vehicles.Commands
{
    public class VehicleUpdateCommand
    {
        public long Id { get; set; }
        public string LicensePlate { get; set; }
        public DateTime Input { get; set; }
    }
}

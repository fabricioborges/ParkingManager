using ParkingManager.Domain.Features.Prices;
using ParkingManager.Domain.Features.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManager.Domain.Features.Payments
{
    public class Payment
    {
        public long Id { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public long VehicleId { get; set; }
        public virtual Price Price { get; set; }
        public long PriceId { get; set; }
        public TimeSpan ExitTime { get; set; }
        public float Value { get; set; }

        
    }
}

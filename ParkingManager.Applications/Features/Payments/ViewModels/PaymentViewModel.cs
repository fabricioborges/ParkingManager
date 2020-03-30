using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManager.Applications.Features.Payments.ViewModels
{
    public class PaymentViewModel
    {
        public long Id { get; set; }
        public string VehicleLicensePlate { get; set; }
        public DateTime VehicleInput { get; set; }
        public DateTime? ExitTime { get; set; }
        public TimeSpan Duration { get; set; }
        public float PriceValueInitial { get; set; }
        public float PriceValueAdditional { get; set; }
        
        public float Value { get; set; }
    }
}

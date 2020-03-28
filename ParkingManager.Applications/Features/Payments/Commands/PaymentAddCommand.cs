using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManager.Applications.Features.Payments.Commands
{
    public class PaymentAddCommand
    {
        public long VehicleId { get; set; }
        public long PriceId { get; set; }
        public TimeSpan ExitTime { get; set; }
        public float Value { get; set; }
    }
}

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
        public DateTime? ExitTime { get; set; }
        public TimeSpan Duration { get; set; }
        public float Value { get; set; }

        public void Calculate()
        {
            Duration = ExitTime.Value - Vehicle.Input;
            var hours = Duration.Hours;
            var minutes = Duration.Minutes;
            var targetMinutes = 30;

            if (hours >= 1)
            {
                Value = Price.InitialValue;

                if (10 < minutes)
                    Value += hours * Price.AdditionalValue;
            }
            else if (10 >= minutes)
                Value = 0;
            else if (targetMinutes >= minutes)
                Value = Price.InitialValue / 2;
        }
    }
}

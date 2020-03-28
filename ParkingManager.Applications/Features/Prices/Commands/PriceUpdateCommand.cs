using System;

namespace ParkingManager.Application.Features.Prices.Commands
{
    public class PriceUpdateCommand
    {
        public long Id { get; set; }
        public float InitialValue { get; set; }
        public float AdditionalValue { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
    }
}

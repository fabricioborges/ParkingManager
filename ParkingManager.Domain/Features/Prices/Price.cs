using ParkingManager.Domain.Features.Base.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManager.Domain.Features.Prices
{
    public class Price
    {
        public long Id { get; set; }
        public float InitialValue { get; set; }
        public float AdditionalValue { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }

        public void Validate()
        {
            ValidateInitialValue();
            ValidateAdditionalValue();
            ValidateInitialDate();
            ValidateFinalDate();
        }

        private void ValidateFinalDate()
        {
            if (FinalDate == DateTime.MinValue || FinalDate < InitialDate)
                throw new PriceException("Data final inválida!");
        }

        private void ValidateInitialDate()
        {
            if (InitialDate == DateTime.MinValue || InitialDate > FinalDate)
                throw new PriceException("Data inicial inválida!");
        }

        private void ValidateAdditionalValue()
        {
            if (AdditionalValue <= 0)
                throw new PriceException("Valor adicional inválido!");
        }

        private void ValidateInitialValue()
        {
            if (InitialValue <= 0)
                throw new PriceException("valor inicial inválido!");
        }
    }
}

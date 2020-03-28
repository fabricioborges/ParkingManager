using ParkingManager.Application.Features.Prices.Commands;
using ParkingManager.Domain.Features.Prices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManager.Common.Tests.Features
{
    public static partial class ObjectMother
    {
        public static Price PriceDefault
        {
            get
            {
                return new Price()
                {
                    InitialValue = 2,
                    InitialDate = DateTime.Now.AddDays(-10),
                    FinalDate = DateTime.Now.AddDays(1),
                    AdditionalValue = 1
                };
            }
        }

        public static PriceAddCommand PriceAddCommand
        {
            get
            {
                return new PriceAddCommand()
                {
                    InitialValue = 2,
                    InitialDate = DateTime.Now.AddDays(-10),
                    FinalDate = DateTime.Now.AddDays(1),
                    AdditionalValue = 1
                };
            }
        }

        public static PriceUpdateCommand PriceUpdateCommand
        {
            get
            {
                return new PriceUpdateCommand()
                {
                    Id = 1,
                    InitialValue = 2,
                    InitialDate = DateTime.Now.AddDays(-10),
                    FinalDate = DateTime.Now.AddDays(1),
                    AdditionalValue = 1
                };
            }
        }

        public static PriceDeleteCommand PriceDeleteCommand
        {
            get
            {
                return new PriceDeleteCommand()
                {
                    Id = 1
                };
            }
        }

        public static IQueryable<Price> PriceDefaultList
        {
            get
            {
                List<Price> prices = new List<Price>();

                prices.Add(PriceDefault);
                prices.Add(PriceDefault);
                prices.Add(PriceDefault);

                return prices.AsQueryable();
            }
        }
    }
}

using ParkingManager.Application.Features.Prices.Commands;
using ParkingManager.Domain.Features.Prices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManager.Application.Features.Prices
{
    public interface IPriceAppService
    {
        long Add(PriceAddCommand price);

        IQueryable<Price> GetAll();

        Price GetById(long Id);

        bool Update(PriceUpdateCommand price);

        bool Delete(PriceDeleteCommand price);
    }
}

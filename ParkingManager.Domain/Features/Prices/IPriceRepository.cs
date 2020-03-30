using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManager.Domain.Features.Prices
{
    public interface IPriceRepository
    {
        Price Add(Price price);

        IQueryable<Price> GetAll();

        long GetByDateInput(DateTime vehicleInput);

        Price GetById(long Id);

        bool Update(Price price);

        bool Delete(long Id);
    }
}

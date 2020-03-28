using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManager.Domain.Features.Vehicles
{
    public interface IVehicleRepository
    {
        Vehicle Add(Vehicle vehicle);

        IQueryable<Vehicle> GetAll();

        Vehicle GetById(long Id);

        bool Update(Vehicle vehicle);

        bool Delete(long Id);
    }
}

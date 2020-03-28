using ParkingManager.Application.Features.Vehicles.Commands;
using ParkingManager.Domain.Features.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManager.Application.Features.Vehicles
{
    public interface IVehicleAppService
    {
        long Add(VehicleAddCommand vehicle);

        IQueryable<Vehicle> GetAll();

        Vehicle GetById(long Id);

        bool Update(VehicleUpdateCommand vehicle);

        bool Delete(VehicleDeleteCommand vehicle);
    }
}

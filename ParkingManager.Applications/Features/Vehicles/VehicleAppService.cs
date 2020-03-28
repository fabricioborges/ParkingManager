using System;
using System.Linq;
using AutoMapper;
using ParkingManager.Application.Features.Vehicles;
using ParkingManager.Application.Features.Vehicles.Commands;
using ParkingManager.Domain.Features.Base.Exceptions;
using ParkingManager.Domain.Features.Vehicles;

namespace ParkingManager.Applications.Features.Vehicles
{
    public class VehicleAppService : IVehicleAppService
    {
        IVehicleRepository Repository;

        public VehicleAppService(IVehicleRepository _repository)
        {
            Repository = _repository;
        }

        public long Add(VehicleAddCommand vehicle)
        {
            var vehicleAdd = Mapper.Map<VehicleAddCommand, Vehicle>(vehicle);
            var newVehicle = Repository.Add(vehicleAdd);

            return newVehicle.Id;
        }

        public bool Delete(VehicleDeleteCommand vehicle)
        {
            return Repository.Delete(vehicle.Id);
        }

        public IQueryable<Vehicle> GetAll()
        {
            return Repository.GetAll();
        }

        public Vehicle GetById(long Id)
        {
            return Repository.GetById(Id);
        }

        public bool Update(VehicleUpdateCommand vehicle)
        {
            var vehicleDb = Repository.GetById(vehicle.Id);
            if (vehicleDb == null)
                throw new NotFoundException("Registro não encontrado!");

            var vehicleEdit = Mapper.Map(vehicle, vehicleDb);

            return Repository.Update(vehicleEdit);
        }
    }
}

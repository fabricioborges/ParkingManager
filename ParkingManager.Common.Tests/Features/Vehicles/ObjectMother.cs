using ParkingManager.Application.Features.Vehicles.Commands;
using ParkingManager.Domain.Features.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManager.Common.Tests.Features
{
    public static partial class ObjectMother
    {
        public static Vehicle VehicleDefault
        {
            get
            {
                return new Vehicle()
                {
                    Input = DateTime.Now,
                    LicensePlate = "abc123"
                };
            }
        }

        public static VehicleAddCommand VehicleAddCommand
        {
            get
            {
                return new VehicleAddCommand()
                {
                    Input = DateTime.Now.AddHours(-1),
                    LicensePlate = "abc123"
                };
            }
        }

        public static VehicleDeleteCommand VehicleDeleteCommand
        {
            get
            {
                return new VehicleDeleteCommand()
                {
                    Id = 1
                };
              }
        }

        public static VehicleUpdateCommand VehicleUpdateCommand
        {
            get
            {
                return new VehicleUpdateCommand()
                {
                    Id = 1,
                    Input = DateTime.Now.AddHours(-1),
                    LicensePlate = "abc123"
                };
            }
        }

        public static IQueryable<Vehicle> VehicleDefaultList
        {
            get
            {
                List<Vehicle> vehicles = new List<Vehicle>();

                vehicles.Add(VehicleDefault);
                vehicles.Add(VehicleDefault);
                vehicles.Add(VehicleDefault);

                return vehicles.AsQueryable();
            }
        }
    }
}

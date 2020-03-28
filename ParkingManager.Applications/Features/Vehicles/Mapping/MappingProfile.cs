using AutoMapper;
using ParkingManager.Application.Features.Vehicles.Commands;
using ParkingManager.Domain.Features.Vehicles;

namespace ParkingManager.Application.Features.Vehicles.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<VehicleAddCommand, Vehicle>();

            CreateMap<VehicleUpdateCommand, Vehicle>();
        }
    }
}

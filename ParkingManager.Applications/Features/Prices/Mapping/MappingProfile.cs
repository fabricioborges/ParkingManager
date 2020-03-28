using AutoMapper;
using ParkingManager.Application.Features.Prices.Commands;
using ParkingManager.Domain.Features.Prices;

namespace ParkingManager.Application.Features.Prices.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PriceAddCommand, Price>();

            CreateMap<PriceUpdateCommand, Price>();
        }
    }
}

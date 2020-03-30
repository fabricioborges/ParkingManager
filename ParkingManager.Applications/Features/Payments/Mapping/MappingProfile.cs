using AutoMapper;
using ParkingManager.Applications.Features.Payments.Commands;
using ParkingManager.Applications.Features.Payments.ViewModels;
using ParkingManager.Domain.Features.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManager.Applications.Features.Payments.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PaymentAddCommand, Payment>();

            CreateMap<PaymentUpdateCommand, Payment>();

            CreateMap<Payment, PaymentViewModel>(MemberList.Source)
                .ForPath(src => src.VehicleLicensePlate, m => m.MapFrom(dest => dest.Vehicle.LicensePlate))
                .ForPath(src => src.PriceValueInitial, m => m.MapFrom(dest => dest.Price.InitialValue))
                .ForPath(src => src.PriceValueAdditional, m => m.MapFrom(dest => dest.Price.AdditionalValue));
        }
    }
}

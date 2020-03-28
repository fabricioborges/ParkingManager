using AutoMapper;
using ParkingManager.Applications.Features.Payments.Commands;
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
        }
    }
}

using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManager.Application.Features.Vehicles.Commands
{
    public class VehicleAddCommand
    {
        public string LicensePlate { get; set; }
        public DateTime Input { get; set; }

        public virtual ValidationResult Validation()
        {
            return new VehicleAddCommandValidator().Validate(this);
        }

        class VehicleAddCommandValidator : AbstractValidator<VehicleAddCommand>
        {
            public VehicleAddCommandValidator()
            {
                RuleFor(x => x.LicensePlate).NotNull().NotEmpty();
                RuleFor(x => x.Input).NotNull();
               
            }
        }
    }
}

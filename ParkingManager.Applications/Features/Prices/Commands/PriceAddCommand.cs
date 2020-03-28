using FluentValidation;
using FluentValidation.Results;
using System;

namespace ParkingManager.Application.Features.Prices.Commands
{
    public class PriceAddCommand
    {
        public float InitialValue { get; set; }
        public float AdditionalValue { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }

        public virtual ValidationResult Validation()
        {
            return new PriceAddCommandValidator().Validate(this);
        }

        class PriceAddCommandValidator : AbstractValidator<PriceAddCommand>
        {
            public PriceAddCommandValidator()
            {
                RuleFor(x => x.AdditionalValue).NotNull().NotEmpty();
                RuleFor(x => x.InitialValue).NotNull();
                RuleFor(x => x.InitialDate).NotNull();
                RuleFor(x => x.FinalDate).NotNull();

            }
        }
    }
}

using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManager.Applications.Features.Payments.Commands
{
    public class PaymentUpdateCommand
    {
        public long Id { get; set; }
        public long VehicleId { get; set; }
        public long PriceId { get; set; }
        public DateTime? ExitTime { get; set; }
        public TimeSpan Duration { get; set; }
        public float Value { get; set; }

        public virtual ValidationResult Validation()
        {
            return new PaymentUpdateCommandValidator().Validate(this);
        }

        class PaymentUpdateCommandValidator : AbstractValidator<PaymentUpdateCommand>
        {
            public PaymentUpdateCommandValidator()
            {
                RuleFor(x => x.Duration).NotNull().NotEmpty();
                RuleFor(x => x.ExitTime).NotNull();
                RuleFor(x => x.Value).NotNull();
            }
        }
    }
}

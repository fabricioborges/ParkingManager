using ParkingManager.Applications.Features.Payments.Commands;
using ParkingManager.Domain.Features.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManager.Common.Tests.Features
{
    public static partial class ObjectMother
    {
        public static Payment PaymentDefault
        {
            get
            {
                return new Payment()
                {
                    Vehicle = VehicleDefault,
                    Price = PriceDefault,
                    Value = 5,
                    ExitTime = TimeSpan.FromHours(1),
                    PriceId = 1,
                    VehicleId = 1
                };
            }
        }

        public static PaymentAddCommand PaymentAddCommand
        {
            get
            {
                return new PaymentAddCommand()
                {
                    Value = 5,
                    ExitTime = TimeSpan.FromHours(1),
                    PriceId = 1,
                    VehicleId = 1
                };
            }
        }

        public static PaymentUpdateCommand PaymentUpdateCommand
        {
            get
            {
                return new PaymentUpdateCommand()
                {
                    Value = 5,
                    ExitTime = TimeSpan.FromHours(1),
                    PriceId = 1,
                    VehicleId = 1
                };
            }
        }

        public static PaymentDeleteCommand PaymentDeleteCommand
        {
            get
            {
                return new PaymentDeleteCommand()
                {
                    Id = 1
                };
            }
        }

        public static IQueryable<Payment> PaymentDefaultList
        {
            get
            {
                List<Payment> payments = new List<Payment>();

                payments.Add(PaymentDefault);
                payments.Add(PaymentDefault);
                payments.Add(PaymentDefault);

                return payments.AsQueryable();
            }
        }
    }
}

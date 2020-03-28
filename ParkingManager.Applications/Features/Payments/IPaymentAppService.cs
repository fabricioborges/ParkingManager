using ParkingManager.Applications.Features.Payments.Commands;
using ParkingManager.Domain.Features.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManager.Applications.Features.Payments
{
    public interface IPaymentAppService
    {
        long Add(PaymentAddCommand payment);

        IQueryable<Payment> GetAll();

        Payment GetById(long Id);

        bool Update(PaymentUpdateCommand payment);

        bool Delete(PaymentDeleteCommand payment);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManager.Domain.Features.Payments
{
    public interface IPaymentRepository
    {
        Payment Add(Payment payment);

        IQueryable<Payment> GetAll();

        IQueryable<Payment> GetByLicensePlate(string licensePlate);

        Payment GetById(long Id);

        bool Update(Payment payment);

        bool Delete(long Id);
    }
}

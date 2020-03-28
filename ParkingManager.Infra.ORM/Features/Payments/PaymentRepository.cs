using ParkingManager.Domain.Features.Base.Exceptions;
using ParkingManager.Domain.Features.Payments;
using ParkingManager.Infra.ORM.Context;
using System.Data.Entity;
using System.Linq;

namespace ParkingManager.Infra.ORM.Features.Payments
{
    public class PaymentRepository : IPaymentRepository
    {
        ParkingManagerContext Context;

        public PaymentRepository(ParkingManagerContext context)
        {
            Context = context;
        }

        public Payment Add(Payment payment)
        {
            Context.Payments.Add(payment);
            Context.SaveChanges();
            return payment;
        }

        public bool Delete(long Id)
        {
            var payment = Context.Payments.Where(c => c.Id == Id).FirstOrDefault();
            if (payment == null)
                throw new NotFoundException("Registro não encontrado!");
            Context.Entry(payment).State = EntityState.Deleted;
            return Context.SaveChanges() > 0;
        }

        public IQueryable<Payment> GetAll()
        {
            return Context.Payments;
        }

        public Payment GetById(long Id)
        {
            return Context.Payments.FirstOrDefault(m => m.Id == Id);
        }

        public bool Update(Payment payment)
        {
            Context.Entry(payment).State = EntityState.Modified;
            return Context.SaveChanges() > 0;
        }
    }
}

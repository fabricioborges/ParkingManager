using System.Linq;
using AutoMapper;
using ParkingManager.Applications.Features.Payments.Commands;
using ParkingManager.Domain.Features.Base.Exceptions;
using ParkingManager.Domain.Features.Payments;

namespace ParkingManager.Applications.Features.Payments
{
    public class PaymentAppService : IPaymentAppService
    {
        IPaymentRepository Repository;

        public PaymentAppService(IPaymentRepository paymentRepository)
        {
            Repository = paymentRepository;
        }

        public long Add(PaymentAddCommand payment)
        {
            var paymentAdd = Mapper.Map<PaymentAddCommand, Payment>(payment);
            var newPayment = Repository.Add(paymentAdd);

            return newPayment.Id;
        }

        public bool Delete(PaymentDeleteCommand payment)
        {
            return Repository.Delete(payment.Id);
        }

        public IQueryable<Payment> GetAll()
        {
            return Repository.GetAll();
        }

        public Payment GetById(long Id)
        {
            return Repository.GetById(Id);
        }

        public bool Update(PaymentUpdateCommand payment)
        {
            var paymentDb = Repository.GetById(payment.Id);
            if (paymentDb == null)
                throw new NotFoundException("Registro não encontrado!");

            var paymentEdit = Mapper.Map(payment, paymentDb);

            return Repository.Update(paymentEdit);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ParkingManager.Applications.Features.Payments.Commands;
using ParkingManager.Domain.Features.Base.Exceptions;
using ParkingManager.Domain.Features.Payments;
using ParkingManager.Domain.Features.Prices;
using ParkingManager.Domain.Features.Vehicles;

namespace ParkingManager.Applications.Features.Payments
{
    public class PaymentAppService : IPaymentAppService
    {
        IPaymentRepository PaymentRepository;
        IVehicleRepository VehicleRepository;
        IPriceRepository PriceRepository;

        public PaymentAppService(IPaymentRepository paymentRepository, IVehicleRepository vehicleRepository, IPriceRepository priceRepository)
        {
            PaymentRepository = paymentRepository;
            VehicleRepository = vehicleRepository;
            PriceRepository = priceRepository;
        }

        public long Add(PaymentAddCommand payment)
        {
            var paymentAdd = Mapper.Map<PaymentAddCommand, Payment>(payment);
            var newPayment = PaymentRepository.Add(paymentAdd);

            return newPayment.Id;
        }

        public PaymentAddCommand BuildCommand(long vehicleId)
        {
            var vehicleInput = VehicleRepository.GetById(vehicleId).Input;

            var priceId = PriceRepository.GetByDateInput(vehicleInput);

            return new PaymentAddCommand()
            {
                PriceId = priceId,
                VehicleId = vehicleId
            };
        }

        public bool Delete(PaymentDeleteCommand payment)
        { 
            return PaymentRepository.Delete(payment.Id);
        }

        public IQueryable<Payment> GetAll()
        {
            return PaymentRepository.GetAll();
        }

        public Payment GetById(long Id)
        {
            return PaymentRepository.GetById(Id);
        }

        public bool Update(PaymentUpdateCommand payment)
        {
            var paymentDb = PaymentRepository.GetById(payment.Id);
            if (paymentDb == null)
                throw new NotFoundException("Registro não encontrado!");

            var paymentEdit = Mapper.Map(payment, paymentDb);
            paymentEdit.Calculate();

            return PaymentRepository.Update(paymentEdit);
        }

        public List<Payment> GetByLicensePlate(string licensePlate)
        {
            return PaymentRepository.GetByLicensePlate(licensePlate).ToList();
        }
    }
}

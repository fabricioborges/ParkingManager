using FluentAssertions;
using Moq;
using NUnit.Framework;
using ParkingManager.Application.Tests.Initializer;
using ParkingManager.Applications.Features.Payments;
using ParkingManager.Common.Tests.Features;
using ParkingManager.Domain.Features.Base.Exceptions;
using ParkingManager.Domain.Features.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManager.Application.Tests.Features.Payments
{
    [TestFixture]
    public class PaymentAppServiceTest : TestBase
    {
        Mock<IPaymentRepository> _repository;
        PaymentAppService _appService;

        [SetUp]
        public void SetUp()
        {
            _repository = new Mock<IPaymentRepository>();
            _appService = new PaymentAppService(_repository.Object);
        }

        [Test]
        public void ApplService_Payment_deveria_adicionar()
        {
            //Arrange
            long expectedId = 1;
            var payment = ObjectMother.PaymentDefault;
            payment.Id = expectedId;
            var paymentAddCommand = ObjectMother.PaymentAddCommand;
            _repository.Setup(x => x.Add(It.IsAny<Payment>())).Returns(payment);

            //Action
            var result = _appService.Add(paymentAddCommand);

            //Assert
            result.Should().Be((int)payment.Id);
            _repository.Verify(x => x.Add(It.IsAny<Payment>()), Times.Once);
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void ApplService_Payment_deveria_deletar_pagamento()
        {
            //Arrange
            var payment = ObjectMother.PaymentDeleteCommand;

            _repository.Setup(x => x.Delete(payment.Id)).Returns(true);

            //Action
            var paymentDeleteAction = _appService.Delete(payment);

            //Assert
            paymentDeleteAction.Should().BeTrue();
            _repository.Verify(x => x.Delete(payment.Id), Times.Once());
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void ApplService_Payment_nao_deveria_deletar_pagamento()
        {
            //Arrange
            var payment = ObjectMother.PaymentDeleteCommand;

            _repository.Setup(x => x.Delete(payment.Id)).Returns(false);

            //Action
            var paymentDeleteAction = _appService.Delete(payment);

            //Assert
            paymentDeleteAction.Should().BeFalse();
            _repository.Verify(x => x.Delete(payment.Id), Times.Once());
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void ApplService_Payment_deveria_atualizar_pagamento()
        {
            //Arrange
            var payment = ObjectMother.PaymentDefault;
            var paymentCmd = ObjectMother.PaymentUpdateCommand;
            var updated = true;
            _repository.Setup(x => x.GetById(paymentCmd.Id)).Returns(payment);
            _repository.Setup(pr => pr.Update(payment)).Returns(updated);

            //Action
            var paymentUpdated = _appService.Update(paymentCmd);

            //Assert
            _repository.Verify(pr => pr.GetById(paymentCmd.Id), Times.Once);
            _repository.Verify(pr => pr.Update(payment), Times.Once);
            paymentUpdated.Should().BeTrue();
        }

        [Test]
        public void ApplService_Payment_deveria_retornar_excecao()
        {
            //Arrange
            var paymentCmd = ObjectMother.PaymentUpdateCommand;
            _repository.Setup(x => x.GetById(paymentCmd.Id)).Returns((Payment)null);

            //Action
            Action act = () => _appService.Update(paymentCmd);

            //Assert
            act.Should().Throw<NotFoundException>();
            _repository.Verify(pr => pr.GetById(paymentCmd.Id), Times.Once);
            _repository.Verify(pr => pr.Update(It.IsAny<Payment>()), Times.Never);
        }

        [Test]
        public void ApplService_Payment_deveria_retornar_pagamento()
        {
            //Arrange
            Payment payment = ObjectMother.PaymentDefault;
            _repository.Setup(x => x.GetById(It.IsAny<long>())).Returns(payment);

            //Action
            Payment paymentResult = _appService.GetById(payment.Id);

            //Assert
            _repository.Verify(p => p.GetById(It.IsAny<long>()), Times.Once());
            paymentResult.Should().NotBeNull();
            paymentResult.Id.Should().Be(payment.Id);
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void ApplService_Payment_GetAll_Deve_Chamar_OMetodo_GetAll()
        {
            //Arrange
            IQueryable<Payment> paymentList = ObjectMother.PaymentDefaultList;
            _repository.Setup(x => x.GetAll()).Returns(paymentList);

            //Action
            List<Payment> paymentResultList = _appService.GetAll().ToList();

            //Assert
            _repository.Verify(x => x.GetAll());
            paymentResultList.Should().NotBeNull();
            paymentResultList.Should().HaveCount(3);
            _repository.VerifyNoOtherCalls();
        }
    }
}

using Effort;
using FluentAssertions;
using NUnit.Framework;
using ParkingManager.Common.Tests.Features;
using ParkingManager.Domain.Features.Base.Exceptions;
using ParkingManager.Domain.Features.Payments;
using ParkingManager.Infra.ORM.Features.Payments;
using ParkingManager.Infra.ORM.Tests.Context;
using ParkingManager.Infra.ORM.Tests.Initializer;
using System;
using System.Linq;

namespace ParkingManager.Infra.ORM.Tests.Features.Payments
{
    [TestFixture]
    public class PaymentRepositoryTest : EffortTestBase
    {
        FakeDbContext Context;
        Payment _payment;
        PaymentRepository _repository;

        [SetUp]
        public void SetUp()
        {
            var connection = DbConnectionFactory.CreatePersistent(Guid.NewGuid().ToString());
            Context = new FakeDbContext(connection);
            _payment = ObjectMother.PaymentDefault;
            _repository = new PaymentRepository(Context);

            Context.Payments.Add(_payment);
            Context.SaveChanges();
        }

        [Test]
        public void Repositorio_payment_deveria_gravar_um_novo_pagamento()
        {
            //Action
            var result = _repository.Add(_payment);

            //Assert
            result.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Repository_payment_deveria_retornar_um_pagamento()
        {
            //Arrange
            var payment = _repository.Add(_payment);

            //Action
            var result = _repository.GetById(payment.Id);

            //Assert
            result.Value.Should().Be(payment.Value);
            result.Id.Should().Be(payment.Id);
        }

        [Test]
        public void Repository_payment_deveria_alterar_um_novo_pagamento()
        {
            //Arrange
            var newPayment = _repository.Add(_payment);
            newPayment.Value = 5;

            //Action
            _repository.Update(newPayment);

            //Assert
            var result = _repository.GetById(newPayment.Id);
            result.Value.Should().Be(newPayment.Value);
        }

        [Test]
        public void Repository_payment_deveria_deletar_um_pagamento()
        {
            //Arrange
            var newPayment = _repository.Add(_payment);

            //Action
            _repository.Delete(newPayment.Id);

            //Assert
            var result = _repository.GetById(newPayment.Id);
            result.Should().BeNull();
        }

        [Test]
        public void Repository_payment_deveria_lancar_notFoundException()
        {
            //Action
            Action removing = () => _repository.Delete(0);

            // Assert
            removing.Should().Throw<NotFoundException>();
        }

        [Test]
        public void Repository_payment_deveria_buscar_todos_os_pagamentos()
        {
            //Action
            var payments = _repository.GetAll().ToList();

            //Assert
            payments.Should().NotBeNull();
            payments.Should().HaveCount(Context.Payments.Count());
            payments.First().Should().Be(_payment);

        }
    }
}

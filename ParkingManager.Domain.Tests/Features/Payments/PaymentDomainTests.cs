using FluentAssertions;
using NUnit.Framework;
using ParkingManager.Common.Tests.Features;
using ParkingManager.Domain.Features.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManager.Domain.Tests.Features.Payments
{
    [TestFixture]
    public class PaymentDomainTests
    {
        Payment _payment;

        [SetUp]
        public void SetUp()
        {
            _payment = ObjectMother.PaymentDefault;
        }

        [Test]
        public void Dominio_payment_deveria_calcular_a_hora_adicionaL_3_horas()
        {
            //Arrange
            _payment.ExitTime = DateTime.Now.AddHours(3).AddMinutes(15);

            //Action
            _payment.Calculate();

            //Assert
            _payment.Value.Should().Be(5);
        }

        [Test]
        public void Dominio_payment_deveria_calcular_a_hora_30_minutos()
        {
            //Arrange
            _payment.ExitTime = DateTime.Now.AddMinutes(15);

            //Action
            _payment.Calculate();

            //Assert
            _payment.Value.Should().Be(1);
        }

        [Test]
        public void Dominio_payment_deveria_calcular_uma_hora()
        {
            //Arrange
            _payment.ExitTime = DateTime.Now.AddHours(1);

            //Action
            _payment.Calculate();

            //Assert
            _payment.Value.Should().Be(2);
        }

        [Test]
        public void Dominio_payment_deveria_calcular_uma_hora_e_15_minutos()
        {
            //Arrange
            _payment.ExitTime = DateTime.Now.AddHours(1).AddMinutes(15);

            //Action
            _payment.Calculate();

            //Assert
            _payment.Value.Should().Be(3);
        }
    }
}

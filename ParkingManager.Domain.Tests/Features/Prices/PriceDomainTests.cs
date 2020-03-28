using FluentAssertions;
using NUnit.Framework;
using ParkingManager.Common.Tests.Features;
using ParkingManager.Domain.Features.Base.Exceptions;
using ParkingManager.Domain.Features.Prices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManager.Domain.Tests.Features.Prices
{
    [TestFixture]
    public class PriceDomainTests
    {
        Price _price;

        [SetUp]
        public void SetUp()
        {
            _price = ObjectMother.PriceDefault;
        }

        [Test]
        public void Dominio_price_Deveria_validar_campos_obrigatorios()
        {
            //Action 
            Action validate = () => _price.Validate();

            //Assert 
            validate.Should().NotThrow<PriceException>();
        }

        [Test]
        public void Dominio_price_nao_deveria_validar_com_valor_invalido()
        {
            //Arrange
            _price.InitialValue = 0;

            //Action 
            Action validate = () => _price.Validate();

            //Assert 
            validate.Should().Throw<PriceException>();
        }

        [Test]
        public void Dominio_price_nao_deveria_validar_com_data_invalida()
        {
            //Arrange
            _price.InitialDate = DateTime.MinValue;

            //Action 
            Action validate = () => _price.Validate();

            //Assert 
            validate.Should().Throw<PriceException>();
        }
    }
}

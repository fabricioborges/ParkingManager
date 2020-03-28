using Effort;
using FluentAssertions;
using NUnit.Framework;
using ParkingManager.Common.Tests.Features;
using ParkingManager.Domain.Features.Base.Exceptions;
using ParkingManager.Domain.Features.Prices;
using ParkingManager.Infra.ORM.Context;
using ParkingManager.Infra.ORM.Features.Prices;
using ParkingManager.Infra.ORM.Tests.Context;
using ParkingManager.Infra.ORM.Tests.Initializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManager.Infra.ORM.Tests.Features
{
    [TestFixture]
    public class PriceRepositoryTest : EffortTestBase
    {
        Price _price;
        ParkingManagerContext Context;
        PriceRepository _repository;

        [SetUp]
        public void SetUp()
        {
            var connection = DbConnectionFactory.CreatePersistent(Guid.NewGuid().ToString());
            Context = new FakeDbContext(connection);
            _price = ObjectMother.PriceDefault;

            _repository = new PriceRepository(Context);

            Context.Prices.Add(_price);
            Context.SaveChanges();
        }

        [Test]
        public void Repositorio_price_deveria_gravar_um_novo_preco()
        {
            //Action
            var result = _repository.Add(_price);

            //Assert
            result.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Repository_price_deveria_retornar_um_preco()
        {
            //Arrange
            var price = _repository.Add(_price);

            //Action
            var result = _repository.GetById(price.Id);

            //Assert
            result.AdditionalValue.Should().Be(price.AdditionalValue);
            result.Id.Should().Be(price.Id);
        }

        [Test]
        public void Repository_price_deveria_alterar_um_novo_preco()
        {
            //Arrange
            var nrePrice = _repository.Add(_price);
            nrePrice.AdditionalValue = 2;

            //Action
            _repository.Update(nrePrice);

            //Assert
            var result = _repository.GetById(nrePrice.Id);
            result.AdditionalValue.Should().Be(nrePrice.AdditionalValue);
        }

        [Test]
        public void Repository_price_deveria_deletar_um_preco()
        {
            //Arrange
            var newPrice = _repository.Add(_price);

            //Action
            _repository.Delete(newPrice.Id);

            //Assert
            var result = _repository.GetById(newPrice.Id);
            result.Should().BeNull();
        }

        [Test]
        public void Repository_price_deveria_lancar_notFoundException()
        {
            //Action
            Action removing = () => _repository.Delete(0);

            // Assert
            removing.Should().Throw<NotFoundException>();
        }

        [Test]
        public void Repository_price_deveria_buscar_todos_os_precos()
        {
            //Action
            var prices = _repository.GetAll().ToList();

            //Assert
            prices.Should().NotBeNull();
            prices.Should().HaveCount(Context.Prices.Count());
            prices.First().Should().Be(_price);

        }
    }
}

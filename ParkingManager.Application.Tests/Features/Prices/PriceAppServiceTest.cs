using FluentAssertions;
using Moq;
using NUnit.Framework;
using ParkingManager.Application.Features.Prices;
using ParkingManager.Application.Tests.Initializer;
using ParkingManager.Common.Tests.Features;
using ParkingManager.Domain.Features.Base.Exceptions;
using ParkingManager.Domain.Features.Prices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManager.Application.Tests.Features.Prices
{
    [TestFixture]
    public class PriceAppServiceTest : TestBase
    {
        Mock<IPriceRepository> _repository;
        PriceAppService _appService;

        [SetUp]
        public void SetUp()
        {
            _repository = new Mock<IPriceRepository>();
            _appService = new PriceAppService(_repository.Object);
        }

        [Test]
        public void ApplService_Price_deveria_adicionar()
        {
            //Arrange
            long expectedId = 1;
            var price = ObjectMother.PriceDefault;
            price.Id = expectedId;
            var priceAddCommand = ObjectMother.PriceAddCommand;
            _repository.Setup(x => x.Add(It.IsAny<Price>())).Returns(price);

            //Action
            var result = _appService.Add(priceAddCommand);

            //Assert
            result.Should().Be((int)price.Id);
            _repository.Verify(x => x.Add(It.IsAny<Price>()), Times.Once);
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void ApplService_Price_deveria_deletar_preco()
        {
            //Arrange
            var price = ObjectMother.PriceDeleteCommand;

            _repository.Setup(x => x.Delete(price.Id)).Returns(true);

            //Action
            var priceDeleteAction = _appService.Delete(price);

            //Assert
            priceDeleteAction.Should().BeTrue();
            _repository.Verify(x => x.Delete(price.Id), Times.Once());
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void ApplService_Price_nao_deveria_deletar_preco()
        {
            //Arrange
            var price = ObjectMother.PriceDeleteCommand;

            _repository.Setup(x => x.Delete(price.Id)).Returns(false);

            //Action
            var priceDeleteAction = _appService.Delete(price);

            //Assert
            priceDeleteAction.Should().BeFalse();
            _repository.Verify(x => x.Delete(price.Id), Times.Once());
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void ApplService_Price_deveria_atualizar_preco()
        {
            //Arrange
            var price = ObjectMother.PriceDefault;
            var priceCmd = ObjectMother.PriceUpdateCommand;
            var updated = true;
            _repository.Setup(x => x.GetById(priceCmd.Id)).Returns(price);
            _repository.Setup(pr => pr.Update(price)).Returns(updated);

            //Action
            var priceUpdated = _appService.Update(priceCmd);

            //Assert
            _repository.Verify(pr => pr.GetById(priceCmd.Id), Times.Once);
            _repository.Verify(pr => pr.Update(price), Times.Once);
            priceUpdated.Should().BeTrue();
        }

        [Test]
        public void ApplService_Price_deveria_retornar_excecao()
        {
            //Arrange
            var priceCmd = ObjectMother.PriceUpdateCommand;
            _repository.Setup(x => x.GetById(priceCmd.Id)).Returns((Price)null);

            //Action
            Action act = () => _appService.Update(priceCmd);

            //Assert
            act.Should().Throw<NotFoundException>();
            _repository.Verify(pr => pr.GetById(priceCmd.Id), Times.Once);
            _repository.Verify(pr => pr.Update(It.IsAny<Price>()), Times.Never);
        }

        [Test]
        public void ApplService_Price_deveria_retornar_preco()
        {
            //Arrange
            Price price = ObjectMother.PriceDefault;
            _repository.Setup(x => x.GetById(It.IsAny<long>())).Returns(price);

            //Action
            Price priceResult = _appService.GetById(price.Id);

            //Assert
            _repository.Verify(p => p.GetById(It.IsAny<long>()), Times.Once());
            priceResult.Should().NotBeNull();
            priceResult.Id.Should().Be(price.Id);
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void ApplService_Price_GetAll_Deve_Chamar_OMetodo_GetAll()
        {
            //Arrange
            IQueryable<Price> priceList = ObjectMother.PriceDefaultList;
            _repository.Setup(x => x.GetAll()).Returns(priceList);

            //Action
            List<Price> priceResultList = _appService.GetAll().ToList();

            //Assert
            _repository.Verify(x => x.GetAll());
            priceResultList.Should().NotBeNull();
            priceResultList.Should().HaveCount(3);
            _repository.VerifyNoOtherCalls();
        }
    }
}

using FluentAssertions;
using Moq;
using NUnit.Framework;
using ParkingManager.Application.Tests.Initializer;
using ParkingManager.Applications.Features.Vehicles;
using ParkingManager.Common.Tests.Features;
using ParkingManager.Domain.Features.Base.Exceptions;
using ParkingManager.Domain.Features.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingManager.Application.Tests.Features.Vehicles
{
    [TestFixture]
    public class VehicleAppServiceTest : TestBase
    {
        Mock<IVehicleRepository> _repository;
        VehicleAppService _appService;

        [SetUp]
        public void SetUp()
        {
            _repository = new Mock<IVehicleRepository>();
            _appService = new VehicleAppService(_repository.Object);
        }

        [Test]
        public void ApplService_Vehicle_deveria_adicionar()
        {
            //Arrange
            long expectedId = 1;
            var vehicle = ObjectMother.VehicleDefault;
            vehicle.Id = expectedId;
            var vehicleAddCommand = ObjectMother.VehicleAddCommand;
            _repository.Setup(x => x.Add(It.IsAny<Vehicle>())).Returns(vehicle);

            //Action
            var result = _appService.Add(vehicleAddCommand);

            //Assert
            result.Should().Be((int)vehicle.Id);
            _repository.Verify(x => x.Add(It.IsAny<Vehicle>()), Times.Once);
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void ApplService_Vehicle_deveria_deletar_veiculo()
        {
            //Arrange
            var vehicle = ObjectMother.VehicleDeleteCommand;

            _repository.Setup(x => x.Delete(vehicle.Id)).Returns(true);

            //Action
            var vehicleDeleteAction = _appService.Delete(vehicle);

            //Assert
            vehicleDeleteAction.Should().BeTrue();
            _repository.Verify(x => x.Delete(vehicle.Id), Times.Once());
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void ApplService_Vehicle_nao_deveria_deletar_veiculo()
        {
            //Arrange
            var vehicle = ObjectMother.VehicleDeleteCommand;

            _repository.Setup(x => x.Delete(vehicle.Id)).Returns(false);

            //Action
            var vehicleDeleteAction = _appService.Delete(vehicle);

            //Assert
            vehicleDeleteAction.Should().BeFalse();
            _repository.Verify(x => x.Delete(vehicle.Id), Times.Once());
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void ApplService_Vehicle_deveria_atualizar_veiculo()
        {
            //Arrange
            var vehicle = ObjectMother.VehicleDefault;
            var vehicleCmd = ObjectMother.VehicleUpdateCommand;
            var updated = true;
            _repository.Setup(x => x.GetById(vehicleCmd.Id)).Returns(vehicle);
            _repository.Setup(pr => pr.Update(vehicle)).Returns(updated);

            //Action
            var vehicleUpdated = _appService.Update(vehicleCmd);

            //Assert
            _repository.Verify(pr => pr.GetById(vehicleCmd.Id), Times.Once);
            _repository.Verify(pr => pr.Update(vehicle), Times.Once);
            vehicleUpdated.Should().BeTrue();
        }

        [Test]
        public void ApplService_Vehicle_deveria_retornar_excecao()
        {
            //Arrange
            var vehicleCmd = ObjectMother.VehicleUpdateCommand;
            _repository.Setup(x => x.GetById(vehicleCmd.Id)).Returns((Vehicle)null);

            //Action
            Action act = () => _appService.Update(vehicleCmd);

            //Assert
            act.Should().Throw<NotFoundException>();
            _repository.Verify(pr => pr.GetById(vehicleCmd.Id), Times.Once);
            _repository.Verify(pr => pr.Update(It.IsAny<Vehicle>()), Times.Never);
        }

        [Test]
        public void ApplService_Vehicle_deveria_retornar_veiculo()
        {
            //Arrange
            Vehicle vehicle = ObjectMother.VehicleDefault;
            _repository.Setup(x => x.GetById(It.IsAny<long>())).Returns(vehicle);

            //Action
            Vehicle vehicleResult = _appService.GetById(vehicle.Id);

            //Assert
            _repository.Verify(p => p.GetById(It.IsAny<long>()), Times.Once());
            vehicleResult.Should().NotBeNull();
            vehicleResult.Id.Should().Be(vehicle.Id);
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void ApplService_Vehicle_GetAll_Deve_Chamar_OMetodo_GetAll()
        {
            //Arrange
            IQueryable<Vehicle> vehicleList = ObjectMother.VehicleDefaultList;
            _repository.Setup(x => x.GetAll()).Returns(vehicleList);

            //Action
            List<Vehicle> vehicleResultList = _appService.GetAll().ToList();

            //Assert
            _repository.Verify(x => x.GetAll());
            vehicleResultList.Should().NotBeNull();
            vehicleResultList.Should().HaveCount(3);
            _repository.VerifyNoOtherCalls();
        }
    }
}

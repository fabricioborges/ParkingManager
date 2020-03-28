using Effort;
using FluentAssertions;
using NUnit.Framework;
using ParkingManager.Common.Tests.Features;
using ParkingManager.Domain.Features.Base.Exceptions;
using ParkingManager.Domain.Features.Vehicles;
using ParkingManager.Infra.ORM.Features.Vehicles;
using ParkingManager.Infra.ORM.Tests.Context;
using ParkingManager.Infra.ORM.Tests.Initializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManager.Infra.ORM.Tests.Features.Vehicles
{
    [TestFixture]
    public class VehicleRepositoryTest : EffortTestBase
    {
        FakeDbContext Context;
        Vehicle _vehicle;
        VehicleRepository _repository;

        [SetUp]
        public void SetUp()
        {
            var connection = DbConnectionFactory.CreatePersistent(Guid.NewGuid().ToString());
            Context = new FakeDbContext(connection);
            _vehicle = ObjectMother.VehicleDefault;
            _repository = new VehicleRepository(Context);

            Context.Vehicles.Add(_vehicle);
            Context.SaveChanges();
        }

        [Test]
        public void Repositorio_vehicle_deveria_gravar_um_novo_veiculo()
        {
            //Action
            var result = _repository.Add(_vehicle);

            //Assert
            result.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Repository_vehicle_deveria_retornar_um_vehicle()
        {
            //Arrange
            var vehicle = _repository.Add(_vehicle);

            //Action
            var result = _repository.GetById(vehicle.Id);

            //Assert
            result.LicensePlate.Should().Be(vehicle.LicensePlate);
            result.Id.Should().Be(vehicle.Id);
        }

        [Test]
        public void Repository_vehicle_deveria_alterar_um_novo_veiculo()
        {
            //Arrange
            var newVehicle = _repository.Add(_vehicle);
            newVehicle.LicensePlate = "cde456";

            //Action
            _repository.Update(newVehicle);

            //Assert
            var result = _repository.GetById(newVehicle.Id);
            result.LicensePlate.Should().Be(newVehicle.LicensePlate);
        }

        [Test]
        public void Repository_vehicle_deveria_deletar_um_veiculo()
        {
            //Arrange
            var newVehicle = _repository.Add(_vehicle);

            //Action
            _repository.Delete(newVehicle.Id);

            //Assert
            var result = _repository.GetById(newVehicle.Id);
            result.Should().BeNull();
        }

        [Test]
        public void Repository_vehicle_deveria_lancar_notFoundException()
        {
            //Action
            Action removing = () => _repository.Delete(0);

            // Assert
            removing.Should().Throw<NotFoundException>();
        }

        [Test]
        public void Repository_vehicle_deveria_buscar_todos_os_veiculos()
        {
            //Action
            var vehicles = _repository.GetAll().ToList();

            //Assert
            vehicles.Should().NotBeNull();
            vehicles.Should().HaveCount(Context.Vehicles.Count());
            vehicles.First().Should().Be(_vehicle);

        }
    }
}

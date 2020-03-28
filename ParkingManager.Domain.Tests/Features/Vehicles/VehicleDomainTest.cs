using FluentAssertions;
using NUnit.Framework;
using ParkingManager.Common.Tests.Features;
using ParkingManager.Domain.Features.Base.Exceptions;
using ParkingManager.Domain.Features.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManager.Domain.Tests.Features.Vehicles
{
    [TestFixture]
    public class VehicleDomainTest
    {
        Vehicle _vehicle;

        [SetUp]
        public void SetUp()
        {
            _vehicle = ObjectMother.VehicleDefault;
        }

        [Test]
        public void Dominio_vehicle_Deveria_validar_campos_obrigatorios()
        {
            //Action
            Action validate = () => _vehicle.Validate();

            //Assert
            validate.Should().NotThrow<VehicleException>();    
        }

        [Test]
        public void Dominio_vehicle_nao_deveria_validar_um_veiculo_sem_placa()
        {
            //Arrange
            _vehicle.LicensePlate = string.Empty;

            //Action
            Action validate = () => _vehicle.Validate();

            //Assert
            validate.Should().Throw<VehicleException>();
        }

        [Test]
        public void Dominio_vehicle_nao_deveria_validar_um_veiculo_sem_data_de_entrada()
        {
            //Arrange
            _vehicle.Input = DateTime.MinValue;

            //Action
            Action validate = () => _vehicle.Validate();

            //Assert
            validate.Should().Throw<VehicleException>();
        }
    }
}

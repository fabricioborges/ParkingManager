using ParkingManager.Domain.Features.Base.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManager.Domain.Features.Vehicles
{
    public class Vehicle
    {
        public long Id { get; set; }
        public string LicensePlate { get; set; }
        public DateTime Input { get; set; }

        public void Validate()
        {
            ValidateDateInput();
            ValidateLicensePlate();
        }

        private void ValidateDateInput()
        {
            if (Input == DateTime.MinValue)
                throw new VehicleException("Data de entrada do veículo não pode ser vazio!");
        }

        private void ValidateLicensePlate()
        {
            if (String.IsNullOrEmpty(LicensePlate))
                throw new VehicleException("Placa do veículo não pode ser vazia!");
        }
    }
}

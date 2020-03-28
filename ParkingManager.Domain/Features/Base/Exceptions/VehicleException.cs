using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManager.Domain.Features.Base.Exceptions
{
    public class VehicleException : Exception
    {
        public VehicleException(string message) : base(message)
        {
        }
    }
}

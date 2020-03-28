﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManager.Domain.Features.Base.Exceptions
{
    public class PriceException : Exception
    {
        public PriceException(string message) : base(message)
        {
        }
    }
}

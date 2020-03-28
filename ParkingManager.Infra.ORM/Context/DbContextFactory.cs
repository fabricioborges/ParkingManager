using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManager.Infra.ORM.Context
{
    public class DbContextFactory : IDbContextFactory<ParkingManagerContext>
    {
        public ParkingManagerContext Create()
        {
            return new ParkingManagerContext();
        }
    }
}

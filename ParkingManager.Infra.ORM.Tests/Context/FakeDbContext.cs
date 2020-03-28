using ParkingManager.Infra.ORM.Context;
using System.Data.Common;

namespace ParkingManager.Infra.ORM.Tests.Context
{
    public class FakeDbContext : ParkingManagerContext
    {
        public FakeDbContext(DbConnection connection) : base(connection)
        {
        }
    }
}

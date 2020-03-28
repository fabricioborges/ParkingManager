using NUnit.Framework;
using ParkingManager.Application.Config;

namespace ParkingManager.Application.Tests.Initializer
{
    [TestFixture]
    public class TestBase
    {
        [OneTimeSetUp]
        public void Initialize()
        {
            AutoMapperConfig.Reset();
            AutoMapperConfig.Initialize();
        }
    }
}

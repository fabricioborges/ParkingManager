using AutoMapper;

namespace ParkingManager.Application.Config
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfiles(typeof(AutoMapperConfig));
            });
        }

        public static void Reset() => Mapper.Reset();
    }
}

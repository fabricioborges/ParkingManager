using ParkingManager.Domain.Features.Vehicles;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManager.Infra.ORM.Configurations.Vehicles
{
    public class VehicleConfiguration : EntityTypeConfiguration<Vehicle>
    {
        public VehicleConfiguration()
        {
            ToTable("TbVehicles");

            HasKey(i => i.Id);

            Property(v => v.Input).IsRequired();
            Property(v => v.LicensePlate).IsRequired();            
        }
    }
}

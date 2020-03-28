using ParkingManager.Domain.Features.Prices;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManager.Infra.ORM.Configurations.Prices
{
    public class PriceConfiguration : EntityTypeConfiguration<Price>
    {
        public PriceConfiguration()
        {
            ToTable("TbPrice");

            HasKey(i => i.Id);

            Property(p => p.InitialDate).IsRequired();
            Property(p => p.FinalDate).IsRequired();
            Property(p => p.InitialValue).IsRequired();
            Property(p => p.AdditionalValue).IsRequired();            
        }
    }
}

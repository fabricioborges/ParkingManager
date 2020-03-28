using ParkingManager.Domain.Features.Payments;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManager.Infra.ORM.Configurations.Payments
{
    public class PaymentConfiguration : EntityTypeConfiguration<Payment>
    {
        public PaymentConfiguration()
        {
            ToTable("TbPayment");

            HasKey(i => i.Id);

            Property(p => p.ExitTime).IsOptional();
            Property(p => p.Value).IsOptional();

            Property(p => p.VehicleId).HasColumnName("VehicleId").IsRequired();
            HasRequired(f => f.Vehicle).WithMany().HasForeignKey(k => k.VehicleId);

            Property(p => p.PriceId).HasColumnName("PriceId").IsOptional();
            HasRequired(f => f.Price).WithMany().HasForeignKey(k => k.PriceId);
        }
    }
}

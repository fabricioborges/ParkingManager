using ParkingManager.Domain.Features.Payments;
using ParkingManager.Domain.Features.Prices;
using ParkingManager.Domain.Features.Vehicles;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManager.Infra.ORM.Context
{
    public class ParkingManagerContext : DbContext
    {
        public ParkingManagerContext() : base("ParkingManager_Db")
        {
            Configuration.LazyLoadingEnabled = true;
        }

        public ParkingManagerContext(DbConnection connection) : base(connection, true) { }

        public DbSet<Price> Prices { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}


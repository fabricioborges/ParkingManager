using ParkingManager.Domain.Features.Base.Exceptions;
using ParkingManager.Domain.Features.Vehicles;
using ParkingManager.Infra.ORM.Context;
using System.Data.Entity;
using System.Linq;

namespace ParkingManager.Infra.ORM.Features.Vehicles
{
    public class VehicleRepository : IVehicleRepository
    {
        ParkingManagerContext Context;

        public VehicleRepository(ParkingManagerContext _context)
        {
            Context = _context;
        }

        public Vehicle Add(Vehicle vehicle)
        {
            Context.Vehicles.Add(vehicle);
            Context.SaveChanges();
            return vehicle;
        }

        public bool Delete(long Id)
        {
            var vehicle = Context.Vehicles.Where(c => c.Id == Id).FirstOrDefault();
            if (vehicle == null)
                throw new NotFoundException("Registro não encontrado!");
            Context.Entry(vehicle).State = EntityState.Deleted;
            return Context.SaveChanges() > 0;
        }

        public IQueryable<Vehicle> GetAll()
        {
            return Context.Vehicles;
        }

        public Vehicle GetById(long Id)
        {
            return Context.Vehicles.FirstOrDefault(m => m.Id == Id);
        }

        public bool Update(Vehicle vehicle)
        {
            Context.Entry(vehicle).State = EntityState.Modified;
            return Context.SaveChanges() > 0;
        }
    }
}

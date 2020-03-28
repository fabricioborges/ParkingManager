using ParkingManager.Domain.Features.Base.Exceptions;
using ParkingManager.Domain.Features.Prices;
using ParkingManager.Infra.ORM.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManager.Infra.ORM.Features.Prices
{
    public class PriceRepository : IPriceRepository
    {
        ParkingManagerContext Context;

        public PriceRepository(ParkingManagerContext _context)
        {
            Context = _context;
        }

        public Price Add(Price price)
        {
            Context.Prices.Add(price);
            Context.SaveChanges();
            return price;
        }

        public bool Delete(long Id)
        {
            var price = Context.Prices.Where(c => c.Id == Id).FirstOrDefault();
            if (price == null)
                throw new NotFoundException("Registro não encontrado!");
            Context.Entry(price).State = EntityState.Deleted;
            return Context.SaveChanges() > 0;
        }

        public IQueryable<Price> GetAll()
        {
            return Context.Prices;
        }

        public Price GetById(long Id)
        {
            return Context.Prices.FirstOrDefault(m => m.Id == Id);
        }

        public bool Update(Price price)
        {
            Context.Entry(price).State = EntityState.Modified;
            return Context.SaveChanges() > 0;
        }
    }
}

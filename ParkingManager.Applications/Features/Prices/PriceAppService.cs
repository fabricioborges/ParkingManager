using System;
using System.Linq;
using AutoMapper;
using ParkingManager.Application.Features.Prices.Commands;
using ParkingManager.Domain.Features.Base.Exceptions;
using ParkingManager.Domain.Features.Prices;

namespace ParkingManager.Application.Features.Prices
{
    public class PriceAppService : IPriceAppService
    {
        IPriceRepository Repository;

        public PriceAppService(IPriceRepository _priceRepository)
        {
            Repository = _priceRepository;
        }

        public long Add(PriceAddCommand price)
        {
            var priceAdd = Mapper.Map<PriceAddCommand, Price>(price);
            priceAdd.Validate();
            var newPrice = Repository.Add(priceAdd);

            return newPrice.Id;
        }

        public bool Delete(PriceDeleteCommand price)
        {
            return Repository.Delete(price.Id);
        }

        public IQueryable<Price> GetAll()
        {
            return Repository.GetAll();
        }

        public Price GetById(long Id)
        {
            return Repository.GetById(Id);
        }

        public bool Update(PriceUpdateCommand price)
        {
            var priceDb = Repository.GetById(price.Id);
            if (priceDb == null)
                throw new NotFoundException("Registro não encontrado!");

            var priceEdit = Mapper.Map(price, priceDb);

            return Repository.Update(priceEdit);
        }
    }
}

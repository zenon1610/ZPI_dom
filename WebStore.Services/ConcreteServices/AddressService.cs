using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WebStore.DAL.EF;
using WebStore.Model.DataModels;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;

namespace WebStore.Services.ConcreteServices
{
    public class AddressService : BaseService, IAddressService
    {
        public AddressService(ApplicationDbContext dbContext, ILogger logger, IMapper mapper) : base(dbContext, logger, mapper)
        {
        }

        public AddressVm AddOrUpdateAddress(AddressVm addressVm)
        {
            try
            {
                if (addressVm == null)
                    throw new ArgumentNullException("View model parameter is null");
                var addressEntity = Mapper.Map<Address>(addressVm);
                if (addressVm.Id.HasValue && addressVm.Id > 0)
                    DbContext.Addresses.Update(addressEntity);
                else
                    DbContext.Addresses.Add(addressEntity);
                DbContext.SaveChanges();
                var addressVm_ = Mapper.Map<AddressVm>(addressEntity);
                return addressVm_;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public AddressVm GetAddressById(Expression<Func<Address, bool>> filterExpression)
        {
            try
            {
                if (filterExpression == null)
                    throw new ArgumentNullException("Filter expression parameter is null");
                var addressEntity = DbContext.Addresses.FirstOrDefault(filterExpression);
                var addressVm = Mapper.Map<AddressVm>(addressEntity);
                return addressVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public IEnumerable<AddressVm> GetAddresses(Expression<Func<Address, bool>>? filterExpression)
        {
            try
            {
                var addressesQuery = DbContext.Addresses.AsQueryable();
                if (filterExpression != null)
                    addressesQuery = addressesQuery.Where(filterExpression);
                var addressVms = Mapper.Map<IEnumerable<AddressVm>>(addressesQuery.ToList());
                return addressVms;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
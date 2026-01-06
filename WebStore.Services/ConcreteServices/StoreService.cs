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
    public class StoreService : BaseService, IStoreService
    {
        public StoreService(ApplicationDbContext dbContext, ILogger logger, IMapper mapper) : base(dbContext, logger, mapper)
        {
        }

        public StoreVm AddOrUpdateStore(StoreVm storeVm)
        {
            try
            {
                if (storeVm == null)
                    throw new ArgumentNullException("View model parameter is null");
                var storeEntity = Mapper.Map<StationaryStore>(storeVm);
                if (storeVm.Id.HasValue && storeVm.Id > 0)
                    DbContext.StationaryStores.Update(storeEntity);
                else
                    DbContext.StationaryStores.Add(storeEntity);
                DbContext.SaveChanges();
                var storeVm_ = Mapper.Map<StoreVm>(storeEntity);
                return storeVm_;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public StoreVm GetStore(Expression<Func<StationaryStore, bool>> filterExpression)
        {
            try
            {
                if (filterExpression == null)
                    throw new ArgumentNullException("Filter expression parameter is null");
                var storeEntity = DbContext.StationaryStores.FirstOrDefault(filterExpression);
                var storeVm = Mapper.Map<StoreVm>(storeEntity);
                return storeVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public IEnumerable<StoreVm> GetStores(Expression<Func<StationaryStore, bool>> filterExpression)
        {
            try
            {
                var storesQuery = DbContext.StationaryStores.AsQueryable();
                if (filterExpression != null)
                    storesQuery = storesQuery.Where(filterExpression);
                var storeVms = Mapper.Map<IEnumerable<StoreVm>>(storesQuery.ToList());
                return storeVms;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
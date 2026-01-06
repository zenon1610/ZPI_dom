using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebStore.Model.DataModels;
using WebStore.ViewModels.VM;

namespace WebStore.Services.Interfaces
{
    public interface IStoreService
    {
        StoreVm AddOrUpdateStore(StoreVm storeVm);
        StoreVm GetStore(Expression<Func<StationaryStore, bool>> filterExpression);
        IEnumerable<StoreVm> GetStores(Expression<Func<StationaryStore, bool>>? filterExpression = null);
    }
}

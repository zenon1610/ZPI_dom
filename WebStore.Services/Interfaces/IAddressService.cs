using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebStore.Model.DataModels;
using WebStore.ViewModels.VM;

namespace WebStore.Services.Interfaces
{
    public interface IAddressService
    {
        AddressVm AddOrUpdateAddress(AddressVm addressVm);
        AddressVm GetAddressById(Expression<Func<Address, bool>> filterExpression);
        IEnumerable<AddressVm> GetAddresses(Expression<Func<Address, bool>>? filterExpression = null);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DAL.EF;
using WebStore.Services.Interfaces;
using WebStore.Tests.UnitTests;
using Xunit;

namespace WebStore.Tests.UnitTest
{
    public class StoreServiceUnitTests : BaseUnitTests
    {
        private readonly IStoreService _storeService;
        public StoreServiceUnitTests(ApplicationDbContext dbContext, IStoreService storeService) : base(dbContext)
        {
            _storeService = storeService;
        }

        [Fact]
        public void GetAllStoresTest()
        {
            var stores = _storeService.GetStores();
            Assert.NotNull(stores);
        }
    }
}
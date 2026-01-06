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
    public class AddressServiceUnitTest : BaseUnitTests
    {
        private readonly IAddressService _addressService;

        public AddressServiceUnitTest(ApplicationDbContext dbContext, IAddressService addressService) : base(dbContext)
        {
            _addressService = addressService;
        }

        [Fact]
        public void GetAllAddressesTest()
        {
            var addresses = _addressService.GetAddresses();
            Assert.NotNull(addresses);
        }
    }
}
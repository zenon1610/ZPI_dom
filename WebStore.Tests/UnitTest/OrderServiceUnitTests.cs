using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DAL.EF;
using WebStore.Services.Interfaces;
using WebStore.Tests.UnitTests;
using WebStore.ViewModels.VM;
using Xunit;

namespace WebStore.Tests.UnitTest
{
    public class OrderServiceUnitTests : BaseUnitTests
    {
        private readonly IOrderService _orderService;

        public OrderServiceUnitTests(ApplicationDbContext dbContext, IOrderService orderService) : base(dbContext)
        {
            _orderService = orderService;
        }

        [Fact]
        public void GetAllOrdersTest()
        {
            var orders = _orderService.GetOrders();
            Assert.NotNull(orders);
            Assert.True(orders.Any());
        }

        [Fact]
        public void AddNewOrderTest()
        {
            var newOrderVm = new OrderVm
            {
                CustomerId = 1,
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(7),
                TotalAmount = 1500,
                TrackingNumber = 123456789
            };

            var createdOrder = _orderService.AddOrUpdateOrder(newOrderVm);
            Assert.NotNull(createdOrder);
        }
    }
}
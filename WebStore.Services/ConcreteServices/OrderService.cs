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
    public class OrderService : BaseService, IOrderService
    {
        public OrderService(ApplicationDbContext dbContext, ILogger logger, IMapper mapper) : base(dbContext, logger, mapper)
        {
        }

        public OrderVm AddOrUpdateOrder(OrderVm orderVm)
        {
            try
            {
                if (orderVm == null)
                    throw new ArgumentNullException("View model parameter is null");
                var orderEntity = Mapper.Map<Order>(orderVm);
                if (orderVm.Id.HasValue && orderVm.Id > 0)
                    DbContext.Orders.Update(orderEntity);
                else
                    DbContext.Orders.Add(orderEntity);
                DbContext.SaveChanges();
                var orderVm_ = Mapper.Map<OrderVm>(orderEntity);
                return orderVm_;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public OrderVm GetOrder(Expression<Func<Order, bool>> filterExpression)
        {
            try
            {
                if (filterExpression == null)
                    throw new ArgumentNullException("Filter expression parameter is null");
                var orderEntity = DbContext.Orders.FirstOrDefault(filterExpression);
                var orderVm = Mapper.Map<OrderVm>(orderEntity);
                return orderVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public IEnumerable<OrderVm> GetOrders(Expression<Func<Order, bool>>? filterExpression = null)
        {
            try
            {
                var ordersQuery = DbContext.Orders.AsQueryable();
                if (filterExpression != null)
                    ordersQuery = ordersQuery.Where(filterExpression);
                var orderVms = Mapper.Map<IEnumerable<OrderVm>>(ordersQuery.ToList());
                return orderVms;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}




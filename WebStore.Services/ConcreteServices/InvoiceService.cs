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
    public class InvoiceService : BaseService, IInvoiceService
    {
        public InvoiceService(ApplicationDbContext dbContext, ILogger logger, IMapper mapper) : base(dbContext, logger, mapper)
        {
        }

        public InvoiceVm AddOrUpdateInvoice(InvoiceVm invoiceVm)
        {
            try
            {
                if (invoiceVm == null)
                    throw new ArgumentNullException("View model parameter is null");
                var invoiceEntity = Mapper.Map<Invoice>(invoiceVm);
                if (invoiceVm.Id.HasValue && invoiceVm.Id > 0)
                    DbContext.Invoices.Update(invoiceEntity);
                else
                    DbContext.Invoices.Add(invoiceEntity);
                DbContext.SaveChanges();
                var invoiceVm_ = Mapper.Map<InvoiceVm>(invoiceEntity);
                return invoiceVm_;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public InvoiceVm GetInvoice(Expression<Func<Invoice, bool>> filterExpression)
        {
            try
            {
                if (filterExpression == null)
                    throw new ArgumentNullException("Filter expression parameter is null");
                var invoiceEntity = DbContext.Invoices.FirstOrDefault(filterExpression);
                var invoiceVm = Mapper.Map<InvoiceVm>(invoiceEntity);
                return invoiceVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public IEnumerable<InvoiceVm> GetInvoices(Expression<Func<Invoice, bool>> filterExpression)
        {
            try
            {
                var invoicesQuery = DbContext.Invoices.AsQueryable();
                if (filterExpression != null)
                    invoicesQuery = invoicesQuery.Where(filterExpression);
                var invoiceVms = Mapper.Map<IEnumerable<InvoiceVm>>(invoicesQuery.ToList());
                return invoiceVms;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
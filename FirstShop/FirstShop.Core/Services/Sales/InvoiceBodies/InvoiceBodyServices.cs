using AutoMapper;
using FirstShop.Core.ViewModels.Sales;
using FirstShop.Data.Context;
using FirstShop.Data.Repository;
using FirstShop.Data.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.Services.Sales.InvoiceBodies
{
    public class InvoiceBodyServices : GenericRepository<InvoiceBody> , IInvoiceBodyServices
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public InvoiceBodyServices(AppDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

		public async Task<long> AddInvoiceBody(InvoiceBodyViewModel Invoice)
        {
            var Invoices = _mapper.Map<InvoiceBodyViewModel, InvoiceBody>(Invoice);
          
                await AddEntity(Invoices);
            await _context.SaveChangesAsync();
            return Invoice.Id;
        }

        public void DeleteInvoiceBody(InvoiceBodyViewModel Invoice)
        {
            Invoice.IsDeleted = true;
            EditInvoiceBody(Invoice);
        }

        public async void EditInvoiceBody(InvoiceBodyViewModel Invoice)
        {
            var Invoices = _mapper.Map<InvoiceBodyViewModel, InvoiceBody>(Invoice);
            EditEntity(Invoices);
            await SaveChanges();
        }

        public IEnumerable<InvoiceBodyViewModel> GetAllInvoiceBody()
        {
            var Invoices = _mapper.Map<IEnumerable<InvoiceBody>, IEnumerable<InvoiceBodyViewModel>>(GetAll());
            return Invoices;
        }

        public async Task<InvoiceBodyViewModel> GetInvoiceBodyByIdAsync(long id)
        {
            var Invoice = _mapper.Map<InvoiceBody, InvoiceBodyViewModel>(await GetEntityByIdAsync(id));
            return Invoice;
        }
    }
}

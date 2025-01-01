using AutoMapper;
using FirstShop.Core.Services.Sales.InvoiceBodies;
using FirstShop.Core.ViewModels.Sales;
using FirstShop.Data.Context;
using FirstShop.Data.Repository;
using FirstShop.Data.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.Services.Sales.InvoiceHeads
{
    public class InvoiceHeadServices : GenericRepository<InvoiceHead> , IInvoiceHeadServices
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IInvoiceBodyServices _invoiceBodyServices;
        public InvoiceHeadServices(AppDbContext context, IMapper mapper , IInvoiceBodyServices invoiceBodyServices) : base(context)
        {
            _context = context;
            _mapper = mapper;
            _invoiceBodyServices = invoiceBodyServices;
        }

        public async Task<long> AddInvoiceHead(InvoiceHeadViewModel invoice)
        {
            var Invoicehead = _mapper.Map<InvoiceHeadViewModel, InvoiceHead>(invoice);
            await AddEntity(Invoicehead);
            _context.SaveChanges();
            return invoice.Id;
        }


        public async Task<long> AddInvoiceHead(InvoiceHeadViewModel invoice, List<InvoiceBodyViewModel> invoiceBodyList)
        {
            var Invoicehead = _mapper.Map<InvoiceHeadViewModel, InvoiceHead>(invoice);
            await AddEntity(Invoicehead);
            await SaveChanges();

            foreach (var item in invoiceBodyList)
            {
                item.InvoiceHeadId = Invoicehead.id;
                await _invoiceBodyServices.AddInvoiceBody(item);
            }

            await SaveChanges();

            return Invoicehead.id;
        }


        public void DeleteInvoiceHead(InvoiceHeadViewModel invoice)
        {
            invoice.IsDeleted = true;
            EditInvoiceHead(invoice);
        }

        public async void EditInvoiceHead(InvoiceHeadViewModel invoice)
        {
            var InvoiceHead = _mapper.Map<InvoiceHeadViewModel, InvoiceHead>(invoice);
            EditEntity(InvoiceHead);
            await SaveChanges();
        }

        public IEnumerable<InvoiceHeadViewModel> GetAllInvoiceHead()
        {
            var InvoiceHead = _mapper.Map<IEnumerable<InvoiceHead>, IEnumerable<InvoiceHeadViewModel>>(GetAll());
            return InvoiceHead;
        }

        public async Task<InvoiceHeadViewModel> GetInvoiceHeadByIdAsync(long id)
        {
            var InvoiceHead = _mapper.Map<InvoiceHead, InvoiceHeadViewModel>(await GetEntityByIdAsync(id));
            return InvoiceHead;
        }
    }
}

using FirstShop.Core.ViewModels.Sales;
using FirstShop.Data.Repository;
using FirstShop.Data.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.Services.Sales.InvoiceHeads
{
    public interface IInvoiceHeadServices : IGenericRepository<InvoiceHead>
    {
        IEnumerable<InvoiceHeadViewModel> GetAllInvoiceHead();
        Task<InvoiceHeadViewModel> GetInvoiceHeadByIdAsync(long id);
        Task<long> AddInvoiceHead(InvoiceHeadViewModel invoice);
        Task<long> AddInvoiceHead(InvoiceHeadViewModel invoice , List<InvoiceBodyViewModel> invoiceBodyList);
        void EditInvoiceHead(InvoiceHeadViewModel invoice);
        void DeleteInvoiceHead(InvoiceHeadViewModel invoice);
    }
}

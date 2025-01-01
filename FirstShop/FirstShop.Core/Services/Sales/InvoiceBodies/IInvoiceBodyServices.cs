using FirstShop.Core.ViewModels.Sales;
using FirstShop.Data.Repository;
using FirstShop.Data.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.Services.Sales.InvoiceBodies
{
    public interface IInvoiceBodyServices : IGenericRepository<InvoiceBody>
    {
        IEnumerable<InvoiceBodyViewModel> GetAllInvoiceBody();
        Task<InvoiceBodyViewModel> GetInvoiceBodyByIdAsync(long id);
        Task<long> AddInvoiceBody(InvoiceBodyViewModel Invoice);
        void EditInvoiceBody(InvoiceBodyViewModel Invoice);
        void DeleteInvoiceBody(InvoiceBodyViewModel Invoice);
    }
}

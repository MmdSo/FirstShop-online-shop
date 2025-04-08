using FirstShop.Core.ViewModels.Sales;
using FirstShop.Data.Repository;
using FirstShop.Data.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.Services.Sales.Taxes
{
    public interface ITaxServices : IGenericRepository<TaxPercent>
    {
        IEnumerable<TaxViewModel> GetAllTax();
        Task<long> AddTax(TaxViewModel tax);
        Task<TaxViewModel> GetTaxById(long Id);
        Task EditTax(TaxViewModel tax);
    }
}

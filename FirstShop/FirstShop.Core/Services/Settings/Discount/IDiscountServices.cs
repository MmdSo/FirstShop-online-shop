using FirstShop.Core.ViewModels.Settings;
using FirstShop.Data.Repository;
using FirstShop.Data.setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.Services.Settings.Discount
{
    public interface IDiscountServices : IGenericRepository<DiscountCode>
    {
        IEnumerable<DiscountCodeViewModel> GetAllCodes();
        Task<DiscountCodeViewModel> GetCodesByIdAsync(long? id);
        Task<long> AddCodes(DiscountCodeViewModel codes);
        void EditCodes(DiscountCodeViewModel codes);
        Task<DiscountCodeViewModel> GetCodesByCodeAsync(string? code);
        Task DeleteCodes(long codeId);
    }
}

using FirstShop.Core.ViewModels.Settings;
using FirstShop.Data.Repository;
using FirstShop.Data.setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.Services.Settings.UsedDiscountCode
{
    public interface IUsedCodeServices : IGenericRepository<UsedCode>
    {
        IEnumerable<UsedCodeViewModel> GetAllCodes();
        Task<UsedCodeViewModel> GetCodesByIdAsync(long? id);
        Task<long> AddCodes(UsedCodeViewModel codes);
        void EditCodes(UsedCodeViewModel codes);
        Task DeleteCodes(long codeId);
    }
}

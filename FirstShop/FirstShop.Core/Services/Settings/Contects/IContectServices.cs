using FirstShop.Core.ViewModels.Settings;
using FirstShop.Data.Repository;
using FirstShop.Data.setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.Services.Settings.Contects
{
    public interface IContectServices :IGenericRepository<Contect>
    {
        IEnumerable<ContectViewModel> GetAllContects ();
        Task<ContectViewModel> AddContect(ContectViewModel contect);
        Task<ContectViewModel> GetContectById(long Id);
        Task EditContect(ContectViewModel contect);
    }
}


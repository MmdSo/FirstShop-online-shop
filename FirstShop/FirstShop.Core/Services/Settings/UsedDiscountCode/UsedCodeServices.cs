using AutoMapper;
using FirstShop.Core.Services.Settings.Discount;
using FirstShop.Core.ViewModels.Settings;
using FirstShop.Data.Context;
using FirstShop.Data.Repository;
using FirstShop.Data.setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.Services.Settings.UsedDiscountCode
{
    public class UsedCodeServices : GenericRepository<UsedCode>, IUsedCodeServices
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        

        public UsedCodeServices(AppDbContext context , IMapper mapper ) : base(context)
        {
            _context = context;
            _mapper = mapper;   
        }

        public async Task<long> AddCodes(UsedCodeViewModel codes)
        {
            var cd = _mapper.Map<UsedCodeViewModel, UsedCode>(codes);
            await AddEntity(cd);
            _context.SaveChanges();
            return codes.Id;
        }

        public async Task DeleteCodes(long codeId)
        {
            UsedCodeViewModel Used = await GetCodesByIdAsync(codeId);
            var cd = _mapper.Map<UsedCodeViewModel, UsedCode>(Used);

            cd.IsDeleted = true;

            EditEntity(cd);
            await SaveChanges();
        }

        public void EditCodes(UsedCodeViewModel codes)
        {
            var cd = _mapper.Map<UsedCodeViewModel, UsedCode>(codes);
            EditEntity(cd);
            SaveChanges();
        }

        public IEnumerable<UsedCodeViewModel> GetAllCodes()
        {
            var cd = _mapper.Map<IEnumerable<UsedCode>, IEnumerable<UsedCodeViewModel>>(GetAll());
            return cd;
        }

        public async Task<UsedCodeViewModel> GetCodesByIdAsync(long? id)
        {
            var cd = _mapper.Map<UsedCode, UsedCodeViewModel>(await GetEntityByIdAsync(id));
            return cd;
        }

        public List<UsedCodeViewModel> IsCodesUsed(long userId, long CodeId)
        {
            var code = GetAllCodes().Where(c => c.UserId == userId && c.CodeId == CodeId).ToList();
            return code;
        }
    }
}

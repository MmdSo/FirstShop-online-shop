using AutoMapper;
using FirstShop.Core.ViewModels.Settings;
using FirstShop.Data.Context;
using FirstShop.Data.Repository;
using FirstShop.Data.setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.Services.Settings.Discount
{
    public class DiscountServices : GenericRepository<DiscountCode>, IDiscountServices
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public DiscountServices(AppDbContext context , IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<long> AddCodes(DiscountCodeViewModel codes)
        {
            var cd = _mapper.Map<DiscountCodeViewModel, DiscountCode>(codes);
            await AddEntity(cd);
            _context.SaveChanges();
            return codes.Id;
        }

        public async Task DeleteCodes(long codeId)
        {
            DiscountCodeViewModel DisCount =await GetCodesByIdAsync(codeId);

            var cd = _mapper.Map<DiscountCodeViewModel, DiscountCode>(DisCount);

            cd.IsDeleted = true;

            EditEntity(cd);
            await SaveChanges();
        }

        public void EditCodes(DiscountCodeViewModel codes)
        {
            var cd = _mapper.Map<DiscountCodeViewModel, DiscountCode>(codes);
            EditEntity(cd);
            SaveChanges();
        }

        public IEnumerable<DiscountCodeViewModel> GetAllCodes()
        {
            var cd = _mapper.Map<IEnumerable<DiscountCode>, IEnumerable<DiscountCodeViewModel>>(GetAll());
            return cd;
        }

        public async Task<DiscountCodeViewModel> GetCodesByIdAsync(long? id)
        {
            var cd = _mapper.Map<DiscountCode, DiscountCodeViewModel>(await GetEntityByIdAsync(id));
            return cd;
        }

        public async Task<DiscountCodeViewModel> GetCodesByCodeAsync(string? code)
        {
            var cd = _mapper.Map<DiscountCode, DiscountCodeViewModel>(GetAll().SingleOrDefault(c => c.Code == code));
            return cd;
        }
    }
}

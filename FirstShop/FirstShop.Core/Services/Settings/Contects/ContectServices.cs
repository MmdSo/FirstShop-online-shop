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

namespace FirstShop.Core.Services.Settings.Contects
{
    public class ContectServices : GenericRepository<Contect>, IContectServices
    {

        public readonly AppDbContext _context;
        public readonly IMapper _mapper;

        public ContectServices(AppDbContext context , IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ContectViewModel> AddContect(ContectViewModel contect)
        {
            var Co = _mapper.Map<ContectViewModel, Contect>(contect);
            await AddEntity(Co);
            await SaveChanges();
            return contect;
        }

        public async Task EditContect(ContectViewModel contect)
        {
            var Co = _mapper.Map<ContectViewModel, Contect>(contect);
            EditEntity(Co);
            await SaveChanges();
        }

        public IEnumerable<ContectViewModel> GetAllContects()
        {
            var Con = _mapper.Map<IEnumerable<Contect>, IEnumerable<ContectViewModel>>(GetAll());
            return Con;
        }

        public async Task<ContectViewModel> GetContectById(long Id)
        {
            var Co = _mapper.Map<Contect, ContectViewModel  >(await GetEntityByIdAsync(Id));
            return Co;
        }
    }
}

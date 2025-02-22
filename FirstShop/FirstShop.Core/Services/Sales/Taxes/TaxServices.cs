using AutoMapper;
using FirstShop.Core.ViewModels.Sales;
using FirstShop.Data.Context;
using FirstShop.Data.Repository;
using FirstShop.Data.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.Services.Sales.Taxes
{
    public class TaxServices : GenericRepository<TaxPercent>, ITaxServices
    {
        public readonly AppDbContext _context;
        public readonly IMapper _mapper;

        public TaxServices(AppDbContext context , IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TaxViewModel> AddTax(TaxViewModel tax)
        {
            var ta = _mapper.Map<TaxViewModel, TaxPercent>(tax);
            await AddEntity(ta);
            await SaveChanges();
            return tax;
        }

        public async Task EditTax(TaxViewModel tax)
        {
            var ta = _mapper.Map<TaxViewModel, TaxPercent>(tax);
            EditEntity(ta);
            await SaveChanges();
        }

        public IEnumerable<TaxViewModel> GetAllTax()
        {
            var ta = _mapper.Map<IEnumerable<TaxPercent>, IEnumerable<TaxViewModel>>(GetAll());
            return ta;
        }

        public async Task<TaxViewModel> GetTaxById(long Id)
        {
            var ta = _mapper.Map<TaxPercent, TaxViewModel>(await GetEntityByIdAsync(Id));
            return ta;
        }
    }
}

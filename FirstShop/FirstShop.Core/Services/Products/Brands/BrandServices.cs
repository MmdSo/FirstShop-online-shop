using AutoMapper;
using FirstShop.Core.ViewModels.Products;
using FirstShop.Data.Context;
using FirstShop.Data.Products;
using FirstShop.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.Services.Products.Brands
{
    public class BrandServices : GenericRepository<Brand> , IBrandServices
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;


        public BrandServices(AppDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<long> AddBrands(BrandViewModel brand)
        {
            var Brands = _mapper.Map<BrandViewModel, Brand>(brand);
            await AddEntity(Brands);
            _context.SaveChanges();
            return brand.Id;
        }

        public async Task EditBrands(BrandViewModel brand)
        {
            var Ba = _mapper.Map<BrandViewModel, Brand>(brand);
            EditEntity(Ba);
            await SaveChanges();
        }

        public IEnumerable<BrandViewModel> GetAllBrand()
        {
            var Brands = _mapper.Map<IEnumerable<Brand>, IEnumerable<BrandViewModel>>(GetAll());
            return Brands;
        }

        public async Task<BrandViewModel> GetBrandsByIdAsync(long? id)
        {
            var Brands = _mapper.Map<Brand, BrandViewModel>(await GetEntityByIdAsync(id));
            return Brands;
        }
        public BrandViewModel GetBrandsById(long? id)
        {
            var brand = _mapper.Map<Brand, BrandViewModel>(GetEntityById(id));
            return brand;
        }

        public async Task DeleteBrands(long brandId)
        {
            BrandViewModel brand = GetBrandsById(brandId);

            var ba = _mapper.Map<BrandViewModel, Brand>(brand);

            ba.IsDeleted = true;

            EditEntity(ba);
            await SaveChanges();
        }
    }
}

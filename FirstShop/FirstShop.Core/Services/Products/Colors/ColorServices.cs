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

namespace FirstShop.Core.Services.Products.Colors
{
    public class ColorServices : GenericRepository<Color> , IColorServices
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ColorServices(AppDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<long> AddColors(ColorViewModel color)
        {
            var co = _mapper.Map<ColorViewModel, Color>(color);
            await AddEntity(co);
            _context.SaveChanges();
            return color.Id;
        }

        public async Task EditColors(ColorViewModel color)
        {
            var co = _mapper.Map<ColorViewModel, Color>(color);
            EditEntity(co);
            await SaveChanges();
        }

        public async Task DeleteColor(long colorId)
        {
            ColorViewModel co = GetColorById(colorId);

            var col = _mapper.Map<ColorViewModel, Color>(co);

            col.IsDeleted = true;

            EditEntity(col);
            await SaveChanges();
        }

        public IEnumerable<ColorViewModel> GetAllColor()
        {
            var co = _mapper.Map<IEnumerable<Color>, IEnumerable<ColorViewModel>>(GetAll());
            return co;
        }

        public async Task<ColorViewModel> GetColorByIdAsync(long? id)
        {
            var co = _mapper.Map<Color, ColorViewModel>(await GetEntityByIdAsync(id));
            return co;
        }

        public ColorViewModel GetColorById(long? id)
        {
            var co = _mapper.Map<Color, ColorViewModel>(GetEntityById(id));
            return co;
        }
    }
}

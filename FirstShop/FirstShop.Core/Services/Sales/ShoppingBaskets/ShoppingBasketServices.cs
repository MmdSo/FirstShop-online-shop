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

namespace FirstShop.Core.Services.Sales.ShoppingBaskets
{
    public class ShoppingBasketServices :GenericRepository<ShoppingBasket> , IShoppingBasketServices
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ShoppingBasketServices(AppDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<long> AddShoppingBasket(ShoppingBassketViewModel shoppingBasket)
        {
            var sp = _mapper.Map<ShoppingBassketViewModel, ShoppingBasket>(shoppingBasket);
            await AddEntity(sp);
            _context.SaveChanges();
            return shoppingBasket.Id;
        }

        public void DeleteShoppingBasket(ShoppingBassketViewModel shoppingBasket)
        {
            shoppingBasket.IsDeleted = true;
            EditShoppingBasket(shoppingBasket);
        }

        public async Task EditShoppingBasket(ShoppingBassketViewModel shoppingBasket)
        {
            var sp = _mapper.Map<ShoppingBassketViewModel, ShoppingBasket>(shoppingBasket);
            EditEntity(sp);
            await SaveChanges();
        }

        public IEnumerable<ShoppingBassketViewModel> GetAllShoppingBaskets()
        {
            var sp = _mapper.Map<IEnumerable<ShoppingBasket>, IEnumerable<ShoppingBassketViewModel>>(GetAll());
            return sp;
        }

        public async Task<ShoppingBassketViewModel> GetShoppingBasketByIdAsync(long id)
        {
            var sp = _mapper.Map<ShoppingBasket, ShoppingBassketViewModel>(await GetEntityByIdAsync(id));
            return sp;
        }

        public  ShoppingBassketViewModel GetShoppingBasketById(long? id)
        {
            var sp = _mapper.Map<ShoppingBasket, ShoppingBassketViewModel>(GetEntityById(id));
            return sp;
        }

        public async Task<ShoppingBassketViewModel> GetActiveShoppingBasketByUserIdAsync(long? id)
        {
            var sp = _mapper.Map<ShoppingBasket, ShoppingBassketViewModel>(GetAll().FirstOrDefault(s => s.UserId == id && s.IsComplete == false));
            return sp;
        }
    }
}

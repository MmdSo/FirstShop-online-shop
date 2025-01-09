using AutoMapper;
using FirstShop.Core.Services.Products.Product;
using FirstShop.Core.Services.Sales.ShoppingBaskets;
using FirstShop.Core.ViewModels.Sales;
using FirstShop.Data.Context;
using FirstShop.Data.Repository;
using FirstShop.Data.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.Services.Sales.ShoppingBasketDetailServices
{
    public class ShoppingBasketDetailServices : GenericRepository<ShoppingBasketDetail>, IShoppingBasketDetailServices
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IProductServices _productServices;
        private readonly IShoppingBasketServices _shoppingBasket;

        public ShoppingBasketDetailServices(AppDbContext context, IMapper mapper,
            IProductServices productServices, IShoppingBasketServices shoppingBasket) : base(context)
        {
            _context = context;
            _mapper = mapper;
            _productServices = productServices;
            _shoppingBasket = shoppingBasket;
        }

        public async Task<long> AddShoppingBasketDetail(ShoppingBassketDetailViewModel shoppingBasketDetail)
        {
            var sp = _mapper.Map<ShoppingBassketDetailViewModel, ShoppingBasketDetail>(shoppingBasketDetail);

            if (_context.shoppingBasketDetail.Any(d => d.BasketId == sp.BasketId && d.ProductId == sp.ProductId))
            {
                var sbd = _context.shoppingBasketDetail.SingleOrDefault(d => d.BasketId == sp.BasketId && d.ProductId == sp.ProductId);
                var sbdVM = _mapper.Map<ShoppingBasketDetail, ShoppingBassketDetailViewModel>(sbd);
                sbdVM.Quantity += 1;
                sbdVM.Price = _productServices.GetProductsById(sp.ProductId).Price;
                await EditShoppingBasketDetail(sbdVM);

                var shopBasket = await _shoppingBasket.GetShoppingBasketByIdAsync(sbd.BasketId);
                shopBasket.TotalCount = Convert.ToInt32(GetAllShoppingBasketsDetail().Where(d => d.BasketId == sbd.BasketId).Sum(bd => bd.Quantity));
                shopBasket.TotalPrice = Convert.ToDecimal(GetAllShoppingBasketsDetail().Where(d => d.BasketId == sbd.BasketId).Sum(bd => bd.Price * bd.Quantity));

                await _shoppingBasket.EditShoppingBasket(shopBasket);
            }
            else
            {
                var product = _productServices.GetEntityById(sp.ProductId);
                sp.Quantity += 1;
                sp.Price = product.Price;
                sp.ProductName = product.Title;
                await AddEntity(sp);
                await SaveChanges();

                var shopBasket = _shoppingBasket.GetShoppingBasketById(sp.BasketId);
                shopBasket.TotalCount = Convert.ToInt32(GetAllShoppingBasketsDetail().Where(d => d.BasketId == sp.BasketId).Sum(bd => bd.Quantity));
                shopBasket.TotalPrice = Convert.ToDecimal(GetAllShoppingBasketsDetail().Where(d => d.BasketId == sp.BasketId).Sum(bd => bd.Price));

                _shoppingBasket.EditShoppingBasket(shopBasket);
            }

            await _context.SaveChangesAsync();
            return shoppingBasketDetail.Id;
        }

        public void DeleteShoppingBasketDetail(ShoppingBassketDetailViewModel shoppingBasketDetail)
        {
            var item = _mapper.Map<ShoppingBassketDetailViewModel, ShoppingBasketDetail>(GetShoppingBasketDetailByIdAsync(shoppingBasketDetail.Id).Result);
            _context.Remove(item);
            _context.SaveChanges();

            var shopBasket = _shoppingBasket.GetShoppingBasketByIdAsync(shoppingBasketDetail.BasketId).Result;

            shopBasket.TotalCount = 0;
            shopBasket.TotalPrice = 0;

            shopBasket.TotalCount = Convert.ToInt32(GetAllShoppingBasketsDetail().Where(d => d.BasketId == shoppingBasketDetail.BasketId).Sum(bd => bd.Quantity));
            shopBasket.TotalPrice = Convert.ToDecimal(GetAllShoppingBasketsDetail().Where(d => d.BasketId == shoppingBasketDetail.BasketId).Sum(bd => bd.Price * bd.Quantity));

            _shoppingBasket.EditShoppingBasket(shopBasket);
            _context.SaveChanges();
        }

        public async Task EditShoppingBasketDetail(ShoppingBassketDetailViewModel shoppingBasketDetail)
        {
            var sp = _mapper.Map<ShoppingBassketDetailViewModel, ShoppingBasketDetail>(shoppingBasketDetail);
            EditEntity(sp);
            await SaveChanges();
        }

        public IEnumerable<ShoppingBassketDetailViewModel> GetAllShoppingBasketsDetail()
        {
            var sp = _mapper.Map<IEnumerable<ShoppingBasketDetail>, IEnumerable<ShoppingBassketDetailViewModel>>(GetAll());
            
            foreach(var item in sp)
            {
                item.ProductImage = _productServices.GetProductsById(item.ProductId).ProductImage;
            }
            
            return sp;
        }

        public async Task<ShoppingBassketDetailViewModel> GetShoppingBasketDetailByIdAsync(long id)
        {
            var sp = _mapper.Map<ShoppingBasketDetail, ShoppingBassketDetailViewModel>(await GetEntityByIdAsync(id));
            return sp;
        }

        public async Task<List<ShoppingBassketDetailViewModel>> GetShoppingBasketDetailByBasketIdAsync(long id)
        {
            var sp = _mapper.Map<IEnumerable<ShoppingBasketDetail>, IEnumerable<ShoppingBassketDetailViewModel>>(GetAll().Where(b => b.BasketId == id));

            foreach (var item in sp)
            {
                item.ProductImage = _productServices.GetProductsById(item.ProductId).ProductImage;
            }

            return sp.ToList();
        }
    }
}
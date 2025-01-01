using FirstShop.Core.ViewModels.Sales;
using FirstShop.Data.Repository;
using FirstShop.Data.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.Services.Sales.ShoppingBasketDetailServices
{
    public interface IShoppingBasketDetailServices : IGenericRepository<ShoppingBasketDetail>
    {
        IEnumerable<ShoppingBassketDetailViewModel> GetAllShoppingBasketsDetail();
        Task<ShoppingBassketDetailViewModel> GetShoppingBasketDetailByIdAsync(long id);
        Task<long> AddShoppingBasketDetail(ShoppingBassketDetailViewModel shoppingBasketDetail);
        Task EditShoppingBasketDetail(ShoppingBassketDetailViewModel shoppingBasketDetail);
        void DeleteShoppingBasketDetail(ShoppingBassketDetailViewModel shoppingBasketDetail);
        Task<List<ShoppingBassketDetailViewModel>> GetShoppingBasketDetailByBasketIdAsync(long id);
    }
}

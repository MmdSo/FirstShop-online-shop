using FirstShop.Core.ViewModels.Sales;
using FirstShop.Data.Repository;
using FirstShop.Data.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.Services.Sales.ShoppingBaskets
{
    public interface IShoppingBasketServices : IGenericRepository<ShoppingBasket>
    {
        IEnumerable<ShoppingBassketViewModel> GetAllShoppingBaskets();
        Task<ShoppingBassketViewModel> GetShoppingBasketByIdAsync(long id);
        ShoppingBassketViewModel GetShoppingBasketById(long? id);
        Task<ShoppingBassketViewModel> GetActiveShoppingBasketByUserIdAsync(long? id);
        Task<long> AddShoppingBasket(ShoppingBassketViewModel shoppingBasket);
        Task EditShoppingBasket(ShoppingBassketViewModel shoppingBasket);
        void DeleteShoppingBasket(ShoppingBassketViewModel shoppingBasket);
    }
}

using FirstShop.Core.ViewModels.Sales;
using FirstShop.Data.Repository;
using FirstShop.Data.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.Services.Sales.Delivey
{
    public interface IDeliveryMethodServices : IGenericRepository<DeliveryMethods>
    {
        IEnumerable<DeliveryViewModel> GetAllMethods();
        Task<DeliveryViewModel> GetDeliveryByIdAsync(long? id);
        DeliveryViewModel GetDeliveryById(long? id);
        long GetDeliveryIdByName(string name);
        Task<long> AddDelivery(DeliveryViewModel delivery);
        Task EditDelivery(DeliveryViewModel delivery);
        Task DeleteDelivery(long deliveryId);
    }
}

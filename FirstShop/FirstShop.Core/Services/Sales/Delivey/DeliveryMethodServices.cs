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

namespace FirstShop.Core.Services.Sales.Delivey
{
    public class DeliveryMethodServices : GenericRepository<DeliveryMethods>, IDeliveryMethodServices
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public DeliveryMethodServices(AppDbContext context , IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<long> AddDelivery(DeliveryViewModel delivery)
        {
            var deliver = _mapper.Map<DeliveryViewModel, DeliveryMethods>(delivery);
            await AddEntity(deliver);
            _context.SaveChanges();
            return deliver.id;
        }

        public async Task DeleteDelivery(long deliveryId)
        {
            DeliveryViewModel deliver = GetDeliveryById(deliveryId);

            var de = _mapper.Map<DeliveryViewModel, DeliveryMethods>(deliver);

            de.IsDeleted = true;

            EditEntity(de);
            await SaveChanges();
        }

        public async Task EditDelivery(DeliveryViewModel delivery)
        {
            var deliver = _mapper.Map<DeliveryViewModel, DeliveryMethods>(delivery);
            EditEntity(deliver);
            await SaveChanges();
        }

        public IEnumerable<DeliveryViewModel> GetAllMethods()
        {
            var deliver = _mapper.Map<IEnumerable<DeliveryMethods>, IEnumerable<DeliveryViewModel>>(GetAll());
            return deliver;
        }

        public DeliveryViewModel GetDeliveryById(long? id)
        {
            var deliver = _mapper.Map<DeliveryMethods, DeliveryViewModel>(GetEntityById(id));
            return deliver;
        }

        public async Task<DeliveryViewModel> GetDeliveryByIdAsync(long? id)
        {
            var deliver = _mapper.Map<DeliveryMethods, DeliveryViewModel>(await GetEntityByIdAsync(id));
            return deliver;
        }

        public long GetDeliveryIdByName(string name)
        {
            var Deliv = _mapper.Map<DeliveryMethods , DeliveryViewModel>(GetAll().SingleOrDefault(d => d.DeliveryMethod == name));
            return Deliv.Id;
        }
    }
}

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

namespace FirstShop.Core.Services.Settings
{
    public class SendMessageServices : GenericRepository<SendMessage> , ISendMessageServices
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;


        public SendMessageServices(AppDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SendMessagesViewModel> AddMessages(SendMessagesViewModel Messages)
        {
            var M = _mapper.Map<SendMessagesViewModel  , SendMessage>(Messages);
            await AddEntity(M);
            await SaveChanges();
            return Messages;
        }

        public async Task EditMessages(SendMessagesViewModel Messages)
        {
            var Ma = _mapper.Map<SendMessagesViewModel , SendMessage>(Messages);
            EditEntity(Ma);
            await SaveChanges();
        }

        public IEnumerable<SendMessagesViewModel> GetAllMessages()
        {
            var M = _mapper.Map<IEnumerable<SendMessage>, IEnumerable<SendMessagesViewModel>>(GetAll());
            return M;
        }
    }
}

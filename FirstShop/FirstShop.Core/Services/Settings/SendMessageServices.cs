using AutoMapper;
using FirstShop.Core.ViewModels.Settings;
using FirstShop.Data.Context;
using FirstShop.Data.Repository;
using FirstShop.Data.setting;
using Microsoft.Extensions.Options;


namespace FirstShop.Core.Services.Settings
{
    public class SendMessageServices : GenericRepository<SendMessage> , ISendMessageServices
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly SendMessagesViewModel _smsPanel;


        public SendMessageServices(AppDbContext context, IMapper mapper , IOptions<SendMessagesViewModel> smsPanel) : base(context)
        {
            _context = context;
            _mapper = mapper;
            _smsPanel = smsPanel.Value;
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

        public async Task SendPublicSMS(string PhoneNumber, string Message)
        {
            try
            {
                var api = new Kavenegar.KavenegarApi(_smsPanel.ApiKey);

                var result = api.Send(_smsPanel.Sender, PhoneNumber, Message);
            }
            catch (Kavenegar.Core.Exceptions.ApiException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Kavenegar.Core.Exceptions.HttpException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task SendLookUpSms(string PhoneNumber, string TemplateName, string token1, string? token2 = "", string? token3 = "")
        {
            try
            {
                var api = new Kavenegar.KavenegarApi(_smsPanel.ApiKey);

                var result = api.VerifyLookup(PhoneNumber ,token1 , token2 , token3 ,TemplateName);
            }
            catch (Kavenegar.Core.Exceptions.ApiException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Kavenegar.Core.Exceptions.HttpException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

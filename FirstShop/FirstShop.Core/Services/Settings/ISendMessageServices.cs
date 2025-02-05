using FirstShop.Core.ViewModels.Settings;
using FirstShop.Data.Repository;
using FirstShop.Data.setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.Services.Settings
{
    public interface ISendMessageServices : IGenericRepository<SendMessage>
    {
        IEnumerable<SendMessagesViewModel> GetAllMessages();
        Task<SendMessagesViewModel> AddMessages(SendMessagesViewModel Messages);
        Task EditMessages(SendMessagesViewModel Messages);
        Task SendPublicSMS(string PhoneNumber, string Message);
        Task SendLookUpSms(string PhoneNumber, string TemplateName ,string token1, string? token2 = "" , string? token3 = "");
    }
}

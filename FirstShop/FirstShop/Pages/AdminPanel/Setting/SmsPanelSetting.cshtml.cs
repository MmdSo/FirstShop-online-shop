using Microsoft.AspNetCore.Mvc.RazorPages;
using Kavenegar.Core.Models;
using FirstShop.Core.Services.Settings;
using Microsoft.AspNetCore.Mvc;
using FirstShop.Core.ViewModels.Settings;
using FirstShop.Data.Context;

namespace FirstShop.Pages.AdminPanel.Setting
{
    public class SmsPanelSettingModel : PageModel
    {
        public AccountInfoResult accountInfoResult = new AccountInfoResult();

        private ISendMessageServices _smsPanel;

        public SmsPanelSettingModel(ISendMessageServices smsPanel)
        {
            _smsPanel = smsPanel;
        }

        public void OnPostSendSms(string receptorNumber, string testMessage)
        {
             _smsPanel.SendPublicSMS(receptorNumber, testMessage);
        }
    }
}

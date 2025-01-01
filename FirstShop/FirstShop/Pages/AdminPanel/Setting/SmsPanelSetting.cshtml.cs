using Microsoft.AspNetCore.Mvc.RazorPages;
using Kavenegar.Core.Models;
namespace FirstShop.Pages.AdminPanel.Setting
{
    public class SmsPanelSettingModel : PageModel
    {
        public AccountInfoResult accountInfoResult = new AccountInfoResult();
        public async Task OnGet()
        {
            var sms = new Kavenegar.KavenegarApi("31314134434B706D6F474954346C7567466C62383078566E7142443955374D67747233692B774774777A453D");
            accountInfoResult = await sms.AccountInfo();
        }

        public void OnPostSendTestMessage(string receptorNumber, string message)
        {
            var sms = new Kavenegar.KavenegarApi("31314134434B706D6F474954346C7567466C62383078566E7142443955374D67747233692B774774777A453D");

            var sender = "2000500666";
            var receptor = receptorNumber;
            var testMessage = message;

            sms.Send(sender,receptor,message);
        }
    }
}

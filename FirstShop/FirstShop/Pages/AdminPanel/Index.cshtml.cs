using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using shop.Core.Security;

namespace FirstShop.Pages.AdminPanel
{
    [Authorize]
    [PermissionChecker(8)]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}

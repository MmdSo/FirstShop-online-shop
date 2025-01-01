using FirstShop.Core.Services.Products.Colors;
using FirstShop.Core.ViewModels.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstShop.Pages.AdminPanel.Product
{
    public class ColorListModel : PageModel
    {
        private IColorServices _colorServices;

        public ColorListModel(IColorServices colorServices)
        {
            _colorServices = colorServices;
        }

        public List<ColorViewModel> colorlistmodel { get; set; }
        public void OnGet()
        {
            colorlistmodel = _colorServices.GetAllColor().ToList();
        }

        public IActionResult OnPostDelete(long colorDeleteID)
        {
            _colorServices.DeleteColor(colorDeleteID);
            return RedirectToPage();
        }
    }
}

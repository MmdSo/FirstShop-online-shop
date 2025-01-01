using FirstShop.Core.Services.Products.ProductComments;
using FirstShop.Core.ViewModels.Products;
using FirstShop.Data.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstShop.Pages.AdminPanel.Product
{
    public class ProductcommentListModel : PageModel
    {
        private IProductCommentServices _productComment;

        public ProductcommentListModel(IProductCommentServices productComment)
        {
            _productComment = productComment;
        }
        public List<ProductCommentViewModel> productCommentListModel { get; set; }

        public void OnGet()
        {
            productCommentListModel = _productComment.GetAllProductComments().ToList();
        }

        public IActionResult OnPostDelete(long CommentDeleteID)
        {
            _productComment.DeleteProductComments(_productComment.GetProductCommentsById(CommentDeleteID));
            return RedirectToPage();
        }
    }
}

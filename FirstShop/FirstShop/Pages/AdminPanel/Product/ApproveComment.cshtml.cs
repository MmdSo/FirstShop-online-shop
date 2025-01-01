using FirstShop.Core.Services.Products.ProductComments;
using FirstShop.Core.Services.UserServices;
using FirstShop.Core.ViewModels.Products;
using FirstShop.Core.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstShop.Pages.AdminPanel.Product
{
    public class ApproveCommentModel : PageModel
    {
        private IProductCommentServices _productComment;
        private IUserServices _userServices;

        public ApproveCommentModel (IProductCommentServices productComment , IUserServices userServices)
        {
            _productComment = productComment;
            _userServices = userServices;
        }
        public ProductCommentViewModel productComment { get; set; }
        public UserListViewModel userList { get; set; }

        public void OnGet(long? Id)
        {
            productComment = _productComment.GetCommentByProductId(Id);
            userList = _userServices.GetUserById(_userServices.GetUserIdByUserName(productComment.UserName));

            ViewData["UserList"] = userList;
            ViewData["comment"] = productComment;
        }

      
    }
}

﻿using FirstShop.Core.Services.Products.Category;
using FirstShop.Core.Services.Products.Product;
using FirstShop.Core.Services.Products.ProductComments;
using FirstShop.Core.Services.Sales.Delivey;
using FirstShop.Core.Services.Sales.InvoiceBodies;
using FirstShop.Core.Services.Sales.InvoiceHeads;
using FirstShop.Core.Services.Sales.ShoppingBasketDetailServices;
using FirstShop.Core.Services.Sales.ShoppingBaskets;
using FirstShop.Core.Services.Sales.Taxes;
using FirstShop.Core.Services.Settings.Discount;
using FirstShop.Core.Services.Settings.UsedDiscountCode;
using FirstShop.Core.Services.UserServices;
using FirstShop.Core.ViewModels.Products;
using FirstShop.Core.ViewModels.Sales;
using FirstShop.Core.ViewModels.Settings;
using FirstShop.Core.ViewModels.Users;
using FirstShop.Data.Context;
using FirstShop.Data.Sales;
using Microsoft.AspNetCore.Mvc;

namespace FirstShop.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ProductController : Controller
    {
        private IUserServices _userServices;
        private IProductServices _productServices;
        private IProductCommentServices _productCommentServices;
        private IHttpContextAccessor _Httpaccessor;
        private IShoppingBasketDetailServices _ShoppingBasketDetailServices;
        private IShoppingBasketServices _ShoppingBasketServices;
        private IInvoiceBodyServices _InvoiceBodyServices;
        private IInvoiceHeadServices _InvoiceHeadServices;
        private ICategoryServices _categoryServices;
        private IDeliveryMethodServices _delivery;
        private IDiscountServices _discount;
        private ITaxServices _taxServices;
        private IUsedCodeServices _usedCode;


        public ProductController(IUserServices userServices, IProductServices productServices, IProductCommentServices productCommentServices,
           IHttpContextAccessor Httpaccessor, IShoppingBasketDetailServices ShoppingBasketDetailServices, IShoppingBasketServices ShoppingBasketServices,
           IInvoiceBodyServices InvoiceBodyServices, IInvoiceHeadServices InvoiceHeadServices, ICategoryServices categoryServices, IDeliveryMethodServices delivery ,
           IDiscountServices discount , ITaxServices taxServices , IUsedCodeServices usedCode)
        {
            _userServices = userServices;
            _productServices = productServices;
            _productCommentServices = productCommentServices;
            _Httpaccessor = Httpaccessor;
            _ShoppingBasketDetailServices = ShoppingBasketDetailServices;
            _ShoppingBasketServices = ShoppingBasketServices;
            _InvoiceBodyServices = InvoiceBodyServices;
            _InvoiceHeadServices = InvoiceHeadServices;
            _categoryServices = categoryServices;
            _delivery = delivery;
            _discount = discount;
            _taxServices = taxServices;
            _usedCode = usedCode;
        }

        public long ProductID;

        [Route("ProductList/{title?}")]
        [HttpGet]
        public IActionResult ProductList(string? title)
        {
            if (string.IsNullOrEmpty(title))
            {
                List<ProductViewModel> products = new List<ProductViewModel>();
                products = _productServices.GetAllProducts().ToList();

                ViewBag.Products = products;

                return View();
            }
            else
            {
                List<ProductViewModel> products = new List<ProductViewModel>();
                products = _productServices.GetProductsByTitleAsync(title).Result.ToList();

                ViewBag.Products = products;

                return View();
            }
        }

        

        [Route("CategoryList")]
        public IActionResult CaregoryList()
        {
            List<CategoryViewModel> Category = new List<CategoryViewModel>();
            Category = _categoryServices.GetAllICategories().ToList();

            ViewBag.Category = Category;

            return View();
        }


        [Route("CategoryItemList/{id?}")]
        public IActionResult CategoryItemList(long id)
        {
            List<ProductViewModel> products = new List<ProductViewModel>();
            products = _productServices.GetProductsByCategoryId(id).ToList();

            ViewBag.Products = products;

            return View();
        }

        [Route("Product_Detail/{id?}")]
        public IActionResult Product_Detail(long id)
        {
            ProductViewModel product = new ProductViewModel();
            product = _productServices.GetProductsById(id);
            UserListViewModel user = new UserListViewModel();
            List<ProductCommentViewModel> commentList = _productCommentServices.GetAllProductCommentsByProductId(id);
            if (_Httpaccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                user = _userServices.GetUserById(_userServices.GetUserIdByUserName(_Httpaccessor.HttpContext.User.Identity.Name));
            }

            ProductID = id;

            ViewBag.Product = product;
            ViewBag.User = user;
            ViewBag.CommentList = commentList;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendComment(ProductCommentViewModel newComment)
        {
            if (string.IsNullOrEmpty(newComment.UserName))
            {

                return RedirectToPage("/Login");
            }
            else
            {
                await _productCommentServices.SendComment(newComment);
                return RedirectToPage("/Product_Detail/", newComment.ProductsId);
            }

        }

        [HttpPost]
        public async Task<IActionResult> sendReply(ProductCommentViewModel newComment, long parentCommentID)
        {
            //newComment.ProductID = prodID;
            newComment.CommentID = parentCommentID;
            await _productCommentServices.SendComment(newComment);

            return RedirectToPage("/Product_Detail/" + newComment.ProductsId);
        }


        [HttpPost]
        public async Task<IActionResult> AddToCart(long ProductId, long userId, int count)
        {
            //long BasketId = 0;
            if (userId == 0)
            {
                return Redirect("/Login");
            }

            var Cart = await _ShoppingBasketServices.GetActiveShoppingBasketByUserIdAsync(userId);
            if (Cart == null)
            {
                ShoppingBassketViewModel Basket = new ShoppingBassketViewModel();
                Basket.UserId = userId;
                var BasketId = await _ShoppingBasketServices.AddShoppingBasket(Basket);

                ShoppingBassketDetailViewModel Detail = new ShoppingBassketDetailViewModel();
                Detail.ProductId = ProductId;
                Detail.BasketId = BasketId;
                Detail.Quantity = count;

                await _ShoppingBasketDetailServices.AddShoppingBasketDetail(Detail);

                return Redirect("/ProductList");
            }
            else
            {
                ShoppingBassketDetailViewModel Detail = new ShoppingBassketDetailViewModel();

                Detail.ProductId = ProductId;
                Detail.BasketId = Cart.Id;
                Detail.Quantity = count;

                await _ShoppingBasketDetailServices.AddShoppingBasketDetail(Detail);

                return Redirect("/ProductList");
            }

        }
        public ErorrMessage errorMessage = new ErorrMessage();

        [HttpPost]
        public async Task<IActionResult> DeleteCartItem(long deleteItemId, long userId)
        {
            long BasketId = 0;
            if (userId == 0)
            {
                return Redirect("/Login");
            }

            var Cart = await _ShoppingBasketServices.GetActiveShoppingBasketByUserIdAsync(userId);

            var deleteItem = _ShoppingBasketDetailServices.GetShoppingBasketDetailByIdAsync(deleteItemId).Result;


            _ShoppingBasketDetailServices.DeleteShoppingBasketDetail(deleteItem);

            return Redirect("/ShoppingCart");

        }

        [Route("ShoppingCart")]
        public IActionResult ShoppingCart()
        {
            List<ShoppingBassketDetailViewModel> Cart = new List<ShoppingBassketDetailViewModel>();
            Cart = _ShoppingBasketDetailServices.GetAllShoppingBasketsDetail().ToList();

            ViewBag.Category = Cart;

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddToInvoice(long ShoppingCartId, long UserId, int deliveryPrice, long deliveryId , string discountCode)
        {

            long BasketId = 0;
            if (UserId == 0)
            {
                return Redirect("/Login");
            }
            else
            {
                var cart = await _ShoppingBasketServices.GetShoppingBasketByIdAsync(ShoppingCartId);
                if (cart == null)
                {
                    return Redirect("/");
                }
                else
                {

                    
                    List<ShoppingBassketDetailViewModel> Detail = await _ShoppingBasketDetailServices.GetShoppingBasketDetailByBasketIdAsync(ShoppingCartId);
                    List<InvoiceBodyViewModel> invoiceBodyList = new List<InvoiceBodyViewModel>();
                    var deliveryMethod = _delivery.GetDeliveryById(deliveryId);
                    var discount = await _discount.GetCodesByCodeAsync(discountCode);
                    var tax = _taxServices.GetAllTax().FirstOrDefault();

                    var usedCode = _usedCode.IsCodesUsed(UserId , discount.Id);

                    if (discount == null || usedCode.Any())
                    {
                        errorMessage.type = "error";
                        errorMessage.message = "Discount code is invalid or you used it before!";
                    }
                    else
                    {


                        foreach (var item in Detail)
                        {
                            InvoiceBodyViewModel invoiceBody = new InvoiceBodyViewModel()
                            {
                                Price = item.Price,
                                Quantity = item.Quantity,
                                ProductId = item.ProductId,
                                ProductName = item.ProductName,
                            };




                            //invoiceBody.Id = invoiceBodyId;
                            invoiceBodyList.Add(invoiceBody);
                            //long invoiceBodyId = await _InvoiceBodyServices.AddInvoiceBody(invoiceBody);
                        }
                        var user = await _userServices.GetUserByIdAsync(UserId);
                        InvoiceHeadViewModel invoiceHead = new InvoiceHeadViewModel()
                        {
                            CustomerName = user.FirstName,
                            CustomerLastName = user.LastName,
                            title = Detail.FirstOrDefault().ProductName,
                            description = "customer invoice",
                            UserID = user.id,
                            TotalPrice = cart.TotalPrice + deliveryPrice,
                            Tax = cart.TotalPrice * (tax.Percent / 100),
                            DeliveryPrice = deliveryMethod.DeliveryPrice,
                            Discount = discount.Percent,
                            FinalPrice = cart.TotalPrice + (deliveryPrice + (cart.TotalPrice * (tax.Percent / 100))) - (cart.TotalPrice * (discount.Percent / 100)),
                        };

                        await _InvoiceHeadServices.AddInvoiceHead(invoiceHead, invoiceBodyList);

                        UsedCodeViewModel UsedCodes = new UsedCodeViewModel()
                        {
                            CodeId = discount.Id,
                            UserId = UserId
                        };

                        await _usedCode.AddCodes(UsedCodes);

                        cart.IsComplete = true;
                        await _ShoppingBasketServices.EditShoppingBasket(cart);

                    }
                }
                return Redirect("/ProductList");
            }
        }
    


    }
}

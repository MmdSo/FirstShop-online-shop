using AutoMapper;
using FirstShop.Core.ViewModels.Blogs;
using FirstShop.Core.ViewModels.Products;
using FirstShop.Core.ViewModels.Sales;
using FirstShop.Core.ViewModels.Settings;
using FirstShop.Core.ViewModels.Users;
using FirstShop.Data.Blogs;
using FirstShop.Data.Products;
using FirstShop.Data.Sales;
using FirstShop.Data.setting;
using FirstShop.Data.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<SiteUser, UserListViewModel>();
            CreateMap<UserListViewModel, SiteUser>();

            CreateMap<UserListForApiViewModel, UserListViewModel>();
            CreateMap<UserListViewModel, UserListForApiViewModel>();

            CreateMap<SiteUser, ProfileViewModel>();
            CreateMap<ProfileViewModel, SiteUser>();

            CreateMap<ProfileForApiViewModel, ProfileViewModel>();
            CreateMap<ProfileViewModel, ProfileForApiViewModel>();

            CreateMap<SiteUser, ChangePasswordViewModel>();
            CreateMap<ChangePasswordViewModel, SiteUser>();

            CreateMap<ChangePasswordViewModel, ChangePasswordForApiViewModel>();
            CreateMap<ChangePasswordForApiViewModel, ChangePasswordViewModel>();

            CreateMap<SiteUser, AboutUserViewModel>();
            CreateMap<AboutUserViewModel, SiteUser>();

            CreateMap<AboutUserViewModel, AboutUserForApiViewModel>();
            CreateMap<AboutUserForApiViewModel, AboutUserViewModel>();

            CreateMap<ChangeEmailForApiViewModel, ChangeEmailViewModel>();
            CreateMap<ChangeEmailViewModel, ChangeEmailForApiViewModel>();

            CreateMap<SiteUser, ChangeEmailViewModel>();
            CreateMap<ChangeEmailViewModel, SiteUser>();

            CreateMap<SiteUser, LoginViewModel>();
            CreateMap<LoginViewModel, SiteUser>();

            CreateMap<LoginViewModel, LoginForApiViewModel>();
            CreateMap<LoginForApiViewModel, LoginViewModel>();

            CreateMap<SiteUser, UserRegisterViewModel>();
            CreateMap<UserRegisterViewModel, SiteUser>();

            CreateMap<UserRegisterForApiViewModel, UserRegisterViewModel>();
            CreateMap<UserRegisterViewModel, UserRegisterForApiViewModel>();

            CreateMap<Roles, RoleViewModel>();
            CreateMap<RoleViewModel, Roles>();

            CreateMap<RoleForApiViewModel, RoleViewModel>();
            CreateMap<RoleViewModel, RoleForApiViewModel>();

            CreateMap<Permissions, PermissionViewModel>();
            CreateMap<PermissionViewModel, Permissions>();

            CreateMap<PermissionForApiViewModel, PermissionViewModel>();
            CreateMap<PermissionViewModel, PermissionForApiViewModel>();

            

            CreateMap<Productss, ProductViewModel>();
            CreateMap<ProductViewModel, Productss>();

            CreateMap<ProductForApiViewModel, ProductViewModel>();
            CreateMap<ProductViewModel, ProductForApiViewModel>();

            CreateMap<Categories, CategoryViewModel>();
            CreateMap<CategoryViewModel, Categories>();

            CreateMap<CategoryForApiViewModel, CategoryViewModel>();
            CreateMap<CategoryViewModel, CategoryForApiViewModel>();

            CreateMap<Color, ColorViewModel>();
            CreateMap<ColorViewModel, Color>();

            CreateMap<ColorForApiViewModel, ColorViewModel>();
            CreateMap<ColorViewModel, ColorForApiViewModel>();

            CreateMap<Brand, BrandViewModel>();
            CreateMap<BrandViewModel, Brand>();

            CreateMap<BrandForApiViewModel, BrandViewModel>();
            CreateMap<BrandViewModel, BrandForApiViewModel>();

            CreateMap<IProductComment, ProductCommentViewModel>();
            CreateMap<ProductCommentViewModel, IProductComment>();

            CreateMap<ProductCommentForApiViewModel, ProductCommentViewModel>();
            CreateMap<ProductCommentViewModel, ProductCommentForApiViewModel>();

            CreateMap<InvoiceBody, InvoiceBodyViewModel>();
            CreateMap<InvoiceBodyViewModel, InvoiceBody>();

            CreateMap<InvoiceBodyForApiViewModel, InvoiceBodyViewModel>();
            CreateMap<InvoiceBodyViewModel, InvoiceBodyForApiViewModel>();

            CreateMap<InvoiceHead, InvoiceHeadViewModel>();
            CreateMap<InvoiceHeadViewModel, InvoiceHead>();

            CreateMap<InvoiceHeadForApiViewModel, InvoiceHeadViewModel>();
            CreateMap<InvoiceHeadViewModel, InvoiceHeadForApiViewModel>();

            CreateMap<ShoppingBasket, ShoppingBassketViewModel>();
            CreateMap<ShoppingBassketViewModel, ShoppingBasket>();

            CreateMap<ShoppingBasketDetail, ShoppingBassketDetailViewModel>();
            CreateMap<ShoppingBassketDetailViewModel, ShoppingBasketDetail>();

            CreateMap<ShoppingBassketDetailViewModel, ShoppingBassketDetailForApiViewModel>();
            CreateMap<ShoppingBassketDetailForApiViewModel, ShoppingBassketDetailViewModel>();

            CreateMap<DeliveryMethods, DeliveryViewModel>();
            CreateMap<DeliveryViewModel, DeliveryMethods>();

            CreateMap<DeliveryViewModel, DeliveryForApiViewModel>();
            CreateMap<DeliveryForApiViewModel, DeliveryViewModel>();

            CreateMap<Posts, PostViewModel>();
            CreateMap<PostViewModel, Posts>();

            CreateMap<Posts, PostViewModel>();
            CreateMap<PostViewModel, Posts>();

            CreateMap<Posts, PostsListViewModel>();
            CreateMap<PostsListViewModel, Posts>();

            CreateMap<PostForApiViewModel, PostViewModel>();
            CreateMap<PostViewModel, PostForApiViewModel>();

            CreateMap<PostType, PostTypeViewModel>();
            CreateMap<PostTypeViewModel, PostType>();

            CreateMap<PostTypeForApiViewModel, PostTypeViewModel>();
            CreateMap<PostTypeViewModel, PostTypeForApiViewModel>();

            CreateMap<PostComments, PostCommentViewModel>();
            CreateMap<PostCommentViewModel, PostComments>();

            CreateMap<PostCommentForApiViewModel, PostCommentViewModel>();
            CreateMap<PostCommentViewModel, PostCommentForApiViewModel>();

            CreateMap<ContectViewModel, Contect>();
            CreateMap<Contect, ContectViewModel>();

            CreateMap<ContectViewModel, ContectForApiViewModel>();
            CreateMap<ContectForApiViewModel, ContectViewModel>();

            CreateMap<SliderViewModel, SliderPic>();
            CreateMap<SliderPic, SliderViewModel>();

            CreateMap<SliderViewModel, SliderForApiViewModel>();
            CreateMap<SliderForApiViewModel, SliderViewModel>();

            CreateMap<LogoViewModel, Logo>();
            CreateMap<Logo, LogoViewModel>();

            CreateMap<LogoViewModel, LogoViewForApiModel>();
            CreateMap<LogoViewForApiModel, LogoViewModel>();

            CreateMap<DiscountCodeViewModel, DiscountCode>();
            CreateMap<DiscountCode, DiscountCodeViewModel>();

            CreateMap<DiscountCodeViewModel, DiscountCodeForApiViewModel>();
            CreateMap<DiscountCodeForApiViewModel, DiscountCodeViewModel>();

            CreateMap<TaxViewModel, TaxPercent>();
            CreateMap<TaxPercent, TaxViewModel>();

            CreateMap<TaxViewModel, TaxForApiViewModel>();
            CreateMap<TaxForApiViewModel, TaxViewModel>();

            CreateMap<UsedCodeViewModel, UsedCode>();
            CreateMap<UsedCode, UsedCodeViewModel>();

        }
    }
}

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

            CreateMap<UserListForApiViewModel, ProfileViewModel>();
            CreateMap<ProfileViewModel, UserListForApiViewModel>();

            CreateMap<SiteUser, ChangePasswordViewModel>();
            CreateMap<ChangePasswordViewModel, SiteUser>();

            CreateMap<SiteUser, AboutUserViewModel>();
            CreateMap<AboutUserViewModel, SiteUser>();

            CreateMap<SiteUser, ChangeEmailViewModel>();
            CreateMap<ChangeEmailViewModel, SiteUser>();

            CreateMap<SiteUser, LoginViewModel>();
            CreateMap<LoginViewModel, SiteUser>();

            CreateMap<SiteUser, UserRegisterViewModel>();
            CreateMap<UserRegisterViewModel, SiteUser>();

            CreateMap<UserListForApiViewModel, UserRegisterViewModel>();
            CreateMap<UserRegisterViewModel, UserListForApiViewModel>();

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

            CreateMap<DeliveryMethods, DeliveryViewModel>();
            CreateMap<DeliveryViewModel, DeliveryMethods>();

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

            CreateMap<SliderViewModel, SliderPic>();
            CreateMap<SliderPic, SliderViewModel>();
        }
    }
}

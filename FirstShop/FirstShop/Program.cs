using FirstShop.Core.Security;
using FirstShop.Core.Services.Blogs.Post;
using FirstShop.Core.Services.Blogs.PostComment;
using FirstShop.Core.Services.Blogs.PostTypes;
using FirstShop.Core.Services.Products.Brands;
using FirstShop.Core.Services.Products.Category;
using FirstShop.Core.Services.Products.Colors;
using FirstShop.Core.Services.Products.Product;
using FirstShop.Core.Services.Products.ProductComments;
using FirstShop.Core.Services.Sales.InvoiceBodies;
using FirstShop.Core.Services.Sales.InvoiceHeads;
using FirstShop.Core.Services.Sales.ShoppingBasketDetailServices;
using FirstShop.Core.Services.Sales.ShoppingBaskets;
using FirstShop.Core.Services.Settings;
using FirstShop.Core.Services.Settings.Contects;
using FirstShop.Core.Services.Settings.Sliders;
using FirstShop.Core.Services.User.PermissionServices;
using FirstShop.Core.Services.User.RoleServices;
using FirstShop.Core.Services.UserServices;
using FirstShop.Core.Tools;
using FirstShop.Core.ViewModels.Settings;
using FirstShop.Data.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddXmlSerializerFormatters();
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddMvc();
builder.Services.AddRazorPages();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FirstShop.Data.Context.AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("FirstShopConectionString"))
.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
, ServiceLifetime.Transient);

#region Authentication

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, config =>
    {
        config.Cookie.Name = "Shop.CookieAuth";
        config.LoginPath = "/Login";
        config.LogoutPath = "/logout";
        config.SlidingExpiration = true;
        config.Cookie.MaxAge = TimeSpan.FromMinutes(60);
        config.ExpireTimeSpan = TimeSpan.FromMinutes(60);
        config.Cookie.HttpOnly = false;
        config.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
        config.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.Always;
        config.Cookie.IsEssential = true;
    });

#endregion

builder.Services.AddSingleton(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddSingleton(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddTransient<IProductServices, ProductServices>();
builder.Services.AddTransient<ICategoryServices, CategoryServices>();
builder.Services.AddTransient<IBrandServices, BrandServices>();
builder.Services.AddTransient<IColorServices, ColorServices>();
builder.Services.AddTransient<IProductCommentServices, ProductCommentServices>();

builder.Services.AddTransient<IInvoiceBodyServices, InvoiceBodyServices>();
builder.Services.AddTransient<IInvoiceHeadServices, InvoiceHeadServices>();
builder.Services.AddTransient<IShoppingBasketDetailServices, ShoppingBasketDetailServices>();
builder.Services.AddTransient<IShoppingBasketServices, ShoppingBasketServices>();

builder.Services.AddTransient<IPostServices, PostServices>();
builder.Services.AddTransient<IPostCommentServices, PostCommentServices>();
builder.Services.AddTransient<IPostTypeServices, PostTypeServices>();

builder.Services.AddTransient<IContectServices, ContectServices>();
builder.Services.AddTransient<ISendMessageServices, SendMessageServices>();
builder.Services.AddTransient<ISliderPicServices, SliderPicServices>();

builder.Services.AddTransient<IUserServices, UserServices>();
builder.Services.AddTransient<IRoleServices, RoleServices>();
builder.Services.AddTransient<IPermissionServices, PermissionServices>();
builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<IViewRenderService, RenderViewToString>();

builder.Services.AddTransient(typeof(EncryptionUtility));
builder.Services.AddTransient(typeof(GoogleReCaptchaServices));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapRazorPages();


app.MapControllerRoute(
    name: "Areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

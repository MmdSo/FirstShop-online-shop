using AutoMapper;
using FirstShop.Core.Services.Products.Brands;
using FirstShop.Core.Services.Products.Category;
using FirstShop.Core.Tools;
using FirstShop.Core.ViewModels.Products;
using FirstShop.Data.Context;
using FirstShop.Data.Products;
using FirstShop.Data.Repository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.Services.Products.Product
{
    public class ProductServices : GenericRepository<Productss>, IProductServices
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IBrandServices _brandServices;
        private readonly ICategoryServices _categoryServices;

        public ProductServices(AppDbContext context, IMapper mapper, IBrandServices brandServices, ICategoryServices categoryServices) : base(context)
        {
            _context = context;
            _mapper = mapper;
            _brandServices = brandServices;
            _categoryServices = categoryServices;
        }

        public async Task<long> AddProducts(ProductViewModel product, IFormFile PImg)
        {
            if (PImg != null)
            {
                product.ProductImage = NameGenerator.GenerateUniqCode() + Path.GetExtension(PImg.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", product.ProductImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    PImg.CopyTo(stream);
                }
                Tools.ImageConverter ImgResizer = new Tools.ImageConverter();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", product.ProductImage);
            }
            var po = _mapper.Map<ProductViewModel, Productss>(product);
            await AddEntity(po);
            _context.SaveChanges();
            return product.Id;
        }

        public async Task DeleteProducts(long ProductId)
        {
            ProductViewModel po = await GetProductsByIdAsync(ProductId);

            var Product = _mapper.Map<ProductViewModel, Productss>(po);

            Product.IsDeleted = true;

            EditEntity(Product);
            SaveChanges();
        }

        public async Task EditProducts(ProductViewModel product, IFormFile PImg)
        {
            if (PImg != null)
            {
                product.ProductImage = NameGenerator.GenerateUniqCode() + Path.GetExtension(PImg.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", product.ProductImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    PImg.CopyTo(stream);
                }
                Tools.ImageConverter ImgResizer = new Tools.ImageConverter();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", product.ProductImage);
            }



            var pO = _mapper.Map<ProductViewModel, Productss>(product);
            EditEntity(pO);
            await SaveChanges();
        }

        public IEnumerable<ProductViewModel> GetAllProducts()
        {
            var po = _mapper.Map<IEnumerable<Productss>, IEnumerable<ProductViewModel>>(GetAll());
            return po;
        }

        public  ProductViewModel GetProductsById(long? id)
        {
            var po = _mapper.Map<Productss, ProductViewModel>(GetEntityById(id));

            po.BrandTitle = _brandServices.GetBrandsById(po.BrandId).Title;
            po.CategoryTitle = _categoryServices.GetCategoriesById(po.CategoryId).Title;

            return po;
        }

        public List<ProductViewModel> GetNineProducts()
        {
            var po = _mapper.Map< IEnumerable<Productss>, IEnumerable< ProductViewModel >>(GetAll().OrderBy(p => p.DataCreated).Take(9)).ToList();
            
            return po;  
        }

        public async Task<ProductViewModel> GetProductsByIdAsync(long? id)
        {
            var Go = _mapper.Map<Productss, ProductViewModel>(GetEntityById(id));

            Go.BrandTitle = _brandServices.GetBrandsById(Go.BrandId).Title;
            Go.CategoryTitle = _categoryServices.GetCategoriesById(Go.CategoryId).Title;

            return Go; ;
        }


        public async Task<IEnumerable<ProductViewModel>> GetProductsByTitleAsync(string? title)
        {
            var Go = GetAllProducts().Where(p => p.Title.ToLower().Contains(title.ToLower()));

            foreach (var item in Go)
            {
                item.BrandTitle = _brandServices.GetBrandsById(item.BrandId).Title;
                item.CategoryTitle = _categoryServices.GetCategoriesById(item.CategoryId).Title;
            }
            return Go; ;
        }


        public List<ProductViewModel> GetProductsByCategoryId(long id)
        {
            var po = _mapper.Map<IEnumerable<Productss>, IEnumerable<ProductViewModel>>(GetAll().Where(p => p.CategoryId == id)).ToList();
            return po;
        }
    }      
}

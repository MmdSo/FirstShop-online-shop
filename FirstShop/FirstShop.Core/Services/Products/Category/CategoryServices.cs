using AutoMapper;
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

namespace FirstShop.Core.Services.Products.Category
{
    public class CategoryServices : GenericRepository<Categories> , ICategoryServices
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CategoryServices(AppDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<long> AddCategories(CategoryViewModel category, IFormFile CImg)
        {

            if (CImg != null)
            {
                category.CategoryImage = NameGenerator.GenerateUniqCode() + Path.GetExtension(CImg.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", category.CategoryImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    CImg.CopyTo(stream);
                }
                Tools.ImageConverter ImgResizer = new Tools.ImageConverter();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", category.CategoryImage);
            }

            var ca = _mapper.Map<CategoryViewModel, Categories>(category);
            await AddEntity(ca);
            _context.SaveChanges();
            return category.Id;
        }

        public async Task DeleteCategories(long colorId)
        {
            CategoryViewModel cat = GetCategoriesById(colorId);

            var ca = _mapper.Map<CategoryViewModel, Categories>(cat);

            ca.IsDeleted = true;

            EditEntity(ca);
            await SaveChanges();
        }

        public async Task EditCategories(CategoryViewModel catagory, IFormFile CImg)
        {

            if (CImg != null)
            {
                catagory.CategoryImage = NameGenerator.GenerateUniqCode() + Path.GetExtension(CImg.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", catagory.CategoryImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    CImg.CopyTo(stream);
                }
                Tools.ImageConverter ImgResizer = new Tools.ImageConverter();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", catagory.CategoryImage);
            }

            var ca = _mapper.Map<CategoryViewModel, Categories>(catagory);
            EditEntity(ca);
            await SaveChanges();
        }

        public IEnumerable<CategoryViewModel> GetAllICategories()
        {
            var ca = _mapper.Map<IEnumerable<Categories>, IEnumerable<CategoryViewModel>>(GetAll());
            return ca;
        }

        public CategoryViewModel GetCategoriesById(long? id)
        {
            var cat = _mapper.Map<Categories, CategoryViewModel>(GetEntityById(id));
            return cat;
        }

        public async Task<CategoryViewModel> GetCategoriesByIdAsync(long? id)
        {
            var ca = _mapper.Map<Categories, CategoryViewModel>(GetEntityById(id));

            if (string.IsNullOrEmpty(ca.CategoryImage))
                ca.CategoryImage = "";
            return ca;
        }
    }
}

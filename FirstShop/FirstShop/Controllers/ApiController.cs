using AutoMapper;
using FirstShop.Core.Services.Products.Brands;
using FirstShop.Core.Services.Products.Category;
using FirstShop.Core.Services.Products.Colors;
using FirstShop.Core.Services.Products.Product;
using FirstShop.Core.Services.Products.ProductComments;
using FirstShop.Core.Tools;
using FirstShop.Core.ViewModels.Products;
using Microsoft.AspNetCore.Mvc;

namespace FirstShop.Controllers
{
    #region Product
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private IProductServices _productServices;
        private IMapper _mapper;
        public ProductsController(IProductServices productServices , IMapper mapper)
        {
            _productServices = productServices;
            _mapper = mapper;
        }

        public List<ProductViewModel> productsList { get; set; }

        [HttpGet]
        public List<ProductViewModel> GetProducts()
        {
            productsList = _productServices.GetAllProducts().ToList();
            return productsList;
        }

        [HttpGet("{id}")]
        public ProductViewModel GetProductById(long id)
        {
            return _productServices.GetProductsById(id);
        }

        [HttpPost]
        public long AddProductFromApi(long id)
        {
            return id;
        }

        [HttpPost("AddProductFromApiBody")]
        public async Task<long> AddProductFromApiBody(ProductForApiViewModel product , IFormFile PImg)
        {
            var pr = _mapper.Map<ProductForApiViewModel, ProductViewModel>(product);

            string fileName = NameGenerator.GenerateUniqCode() + Path.GetExtension(PImg.FileName);
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", fileName);

            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                await PImg.CopyToAsync(stream);
            }

            
            pr.ProductImage = "/Images/" + fileName;

            return await _productServices.AddProducts(pr , PImg);
        }

        [HttpPost("AddProductFromApiQuery")]
        public async Task<long> AddProductFromApiQuery([FromQuery] ProductForApiViewModel product, IFormFile PImg)
        {
            var pr = _mapper.Map<ProductForApiViewModel, ProductViewModel>(product);

            string fileName = NameGenerator.GenerateUniqCode() + Path.GetExtension(PImg.FileName);
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", fileName);

            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                await PImg.CopyToAsync(stream);
            }


            pr.ProductImage = "/Images/" + fileName;

            return await _productServices.AddProducts(pr , PImg);
        }

        [HttpPut("EditProductFromApi")]
        public async Task<IActionResult> EditProductFromApi( ProductForApiViewModel product, IFormFile PImg)
        {
            var pr = _mapper.Map<ProductForApiViewModel, ProductViewModel>(product);

            
                string fileName = NameGenerator.GenerateUniqCode() + Path.GetExtension(PImg.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", fileName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await PImg.CopyToAsync(stream);
                }

                pr.ProductImage = "/Images/" + fileName;
            

            await _productServices.EditProducts(pr, PImg);

            return Ok();
        }

        [HttpDelete("DeleteProductFromApi")]
        public async Task<IActionResult> DeleteProductFromApi(long id)
        {
            var pr = _productServices.GetProductsById(id);

            if (pr == null)
            {
                return NotFound(new { message = "Not found !" });
            }

            await _productServices.DeleteProducts(id);

            return Ok();
        }
    }
    #endregion

    #region Brand
    [ApiController]
    [Route("api/[controller]")]
    public class BrandController : ControllerBase
    {
        private IMapper _mapper; 
        private IBrandServices _brandServices;
        public BrandController(IBrandServices brandServices, IMapper mapper)
        {
            _brandServices = brandServices;
            _mapper = mapper;
        }

        public List<BrandViewModel> brandList { get; set; }

        [HttpGet]
        public List<BrandViewModel> GetBrands()
        {
            brandList = _brandServices.GetAllBrand().ToList();
            return brandList;
        }

        [HttpGet("{id}")]
        public ActionResult<BrandViewModel> GetBrandById(long id)
        {
            var brand = _brandServices.GetBrandsById(id);
            if (brand == null)
                return NotFound(brand);
            else
                return Ok(brand);
        }


        [HttpPost]
        public long AddBrandFromApi(long id)
        {
            return id;
        }

        [HttpPost("AddBrandFromApiBody")]
        public async Task<long> AddBrandFromApiBody(BrandForApiViewModel brand)
        {
            var br = _mapper.Map<BrandForApiViewModel, BrandViewModel>(brand);
            
            return await _brandServices.AddBrands(br);
        }

        [HttpPost("AddBrandFromApiQuery")]
        public async Task<long> AddBrandFromApiQuery([FromQuery] BrandForApiViewModel brand)
        {
            var br = _mapper.Map<BrandForApiViewModel, BrandViewModel>(brand);

            return await _brandServices.AddBrands(br);
        }


        [HttpPut("EditBrandFromApi")]
        public async Task<IActionResult> EditBrandFromApi(BrandForApiViewModel brand)
        {
            var br = _mapper.Map<BrandForApiViewModel, BrandViewModel>(brand);

            await _brandServices.EditBrands(br);

            return Ok();
        }

        [HttpDelete("DeleteBrandFromApi")]
        public async Task<IActionResult> DeleteBrandFromApi(long id)
        {
            var br = _brandServices.GetBrandsById(id);

            if (br == null)
            {
                return NotFound(new { message = "Not found !" });
            }

            await _brandServices.DeleteBrands(id);

            return Ok();
        }
    }
    #endregion

    #region Color
    [ApiController]
    [Route("api/[controller]")]
    public class ColorController : ControllerBase
    {
        private IMapper _mapper;
        private IColorServices _colorServices;
        public ColorController(IColorServices colorServices, IMapper mapper)
        {
            _colorServices = colorServices;
            _mapper = mapper;
        }

        public List<ColorViewModel> colorViewModel { get; set; }

        [HttpGet]
        public List<ColorViewModel> GetBrands()
        {
            colorViewModel = _colorServices.GetAllColor().ToList();
            return colorViewModel;
        }

        [HttpGet("{id}")]
        public ActionResult<ColorViewModel> GetColorById(long id)
        {
            var color = _colorServices.GetColorById(id);
            if (color == null)
                return NotFound(color);
            else
                return Ok(color);
        }


        [HttpPost]
        public long AddColorFromApi(long id)
        {
            return id;
        }

        [HttpPost("AddColorFromApiBody")]
        public async Task<long> AddColorFromApiBody(ColorForApiViewModel color)
        {
            var cr = _mapper.Map<ColorForApiViewModel, ColorViewModel>(color);

            return await _colorServices.AddColors(cr);
        }

        [HttpPost("AddColorFromApiQuery")]
        public async Task<long> AddColorFromApiQuery([FromQuery] ColorForApiViewModel color)
        {
            var cr = _mapper.Map<ColorForApiViewModel, ColorViewModel>(color);

            return await _colorServices.AddColors(cr);
        }


        [HttpPut("EditColorFromApi")]
        public async Task<IActionResult> EditColorFromApi(ColorForApiViewModel color)
        {
            var br = _mapper.Map<ColorForApiViewModel, ColorViewModel>(color);

            await _colorServices.EditColors(br);

            return Ok();
        }

        [HttpDelete("DeleteColorFromApi")]
        public async Task<IActionResult> DeleteColorFromApi(long id)
        {
            var br = _colorServices.DeleteColor(id);

            if (br == null)
            {
                return NotFound(new { message = "Not found !" });
            }

            await _colorServices.DeleteColor(id);

            return Ok();
        }
    }
    #endregion

    #region Category 
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private ICategoryServices _categoryServices;
        private IMapper _mapper;

        public CategoryController(ICategoryServices categoryServices , IMapper mapper)
        {
            _categoryServices = categoryServices;
            _mapper = mapper;
        }

        public List<CategoryViewModel> categoryViewModel { get; set; }

        [HttpGet]
        public List<CategoryViewModel> GetCategory()
        {
            categoryViewModel = _categoryServices.GetAllICategories().ToList();
            return categoryViewModel;
        }

        [HttpGet("{id}")]
        public ActionResult<CategoryViewModel> GetCategorydById(long id)
        {
            var category = _categoryServices.GetCategoriesById(id);
            if (category == null)
                return NotFound(category);
            else
                return Ok(category);
        }
        [HttpPost]
        public long AddCategoryFromApi(long id)
        {
            return id;
        }

        [HttpPost("AddCategoryFromApiBody")]
        public async Task<long> AddCategoryFromApiBody(CategoryForApiViewModel category, IFormFile CImg)
        {
            var cat = _mapper.Map<CategoryForApiViewModel, CategoryViewModel>(category);

            string fileName = NameGenerator.GenerateUniqCode() + Path.GetExtension(CImg.FileName);
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", fileName);

            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                await CImg.CopyToAsync(stream);
            }


            cat.CategoryImage = "/Images/" + fileName;

            return await _categoryServices.AddCategories(cat , CImg);
        }

        [HttpPost("AddCategoryFromApiQuery")]
        public async Task<long> AddCategoryFromApiQuery([FromQuery] CategoryForApiViewModel category, IFormFile CImg)
        {
            var cat = _mapper.Map<CategoryForApiViewModel, CategoryViewModel>(category);

            string fileName = NameGenerator.GenerateUniqCode() + Path.GetExtension(CImg.FileName);
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", fileName);

            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                await CImg.CopyToAsync(stream);
            }


            cat.CategoryImage = "/Images/" + fileName;

            return await _categoryServices.AddCategories(cat, CImg);
        }


        [HttpPut("EditCategoryFromApi")]
        public async Task<IActionResult> EditCategoryFromApi(CategoryForApiViewModel category, IFormFile CImg)
        {
            var cat = _mapper.Map<CategoryForApiViewModel, CategoryViewModel>(category);

            string fileName = NameGenerator.GenerateUniqCode() + Path.GetExtension(CImg.FileName);
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", fileName);

            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                await CImg.CopyToAsync(stream);
            }

            cat.CategoryImage = "/Images/" + fileName;

            await _categoryServices.EditCategories(cat ,CImg);

            return Ok();
        }

        [HttpDelete("DeleteCategoryFromApi")]
        public async Task<IActionResult> DeleteCategoryFromApi(long id)
        {
            var br = _categoryServices.GetCategoriesById(id);

            if (br == null)
            {
                return NotFound(new { message = "Not found !" });
            }

            await _categoryServices.DeleteCategories(id);

            return Ok();
        }

    }
    #endregion

    #region ProductComment
    [ApiController]
    [Route("api/[controller]")]
    public class ProductCommentController : ControllerBase
    {
        private IProductCommentServices _productCommentServices;
        private IMapper _mapper;

        public ProductCommentController(IProductCommentServices productCommentServices , IMapper mapper)
        {
            _productCommentServices = productCommentServices;
            _mapper = mapper;
        }

        public List<ProductCommentViewModel> productCommentViewModels { get; set; }

        [HttpGet]
        public List<ProductCommentViewModel> GetProductComments()
        {
            productCommentViewModels = _productCommentServices.GetAllProductComments().ToList();
            return productCommentViewModels;
        }

        [HttpGet("{id}")]
        public ActionResult<ProductCommentForApiViewModel> GetProductCommentById(long id)
        {
            var pc = _productCommentServices.GetCommentByProductId(id);
            if (pc == null)
                return NotFound(pc);
            else
                return Ok(pc);
        }
        [HttpPost]
        public long AddProductCommentFromApi(long id)
        {
            return id;
        }

        [HttpPost("AddProductCommentFromApiBody")]
        public async Task<long> AddProductCommentFromApiBody(ProductCommentForApiViewModel productComment)
        {
            var pc = _mapper.Map<ProductCommentForApiViewModel, ProductCommentViewModel>(productComment);

            return await _productCommentServices.AddProductComments(pc);
        }

        [HttpPost("AddProductCommentFromApiQuery")]
        public async Task<long> AddProductCommentFromApiQuery([FromQuery] ProductCommentForApiViewModel productComment)
        {
            var pc = _mapper.Map<ProductCommentForApiViewModel, ProductCommentViewModel>(productComment);

            return await _productCommentServices.AddProductComments(pc);
        }


        [HttpDelete("DeleteProductCommentFromApi")]
        public async Task<IActionResult> DeleteProductCommentFromApi(long id, ProductCommentForApiViewModel productComment)
        {
            var proComment = _mapper.Map<ProductCommentForApiViewModel, ProductCommentViewModel>(productComment);
            var pc = _productCommentServices.GetProductCommentsById(id);

            if (pc == null)
            {
                return NotFound(new { message = "Not found !" });
            }

            _productCommentServices.DeleteProductComments(proComment);

            return Ok();
        }

        [HttpPost("ApproveComment/{id}")]
        public IActionResult ApproveComment(long? id , bool IsApprove)
        {
            var pc =  _productCommentServices.ApprovedComment(id, IsApprove);

            if (pc)
            {
                return Ok();
            }
            else
            {
                return BadRequest(new { message = "Error in validation ! please try again ." });
            }
        }
    }
    #endregion
}

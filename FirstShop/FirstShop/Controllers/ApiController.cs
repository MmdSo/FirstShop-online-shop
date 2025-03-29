using AutoMapper;
using FirstShop.Core.Services.Products.Brands;
using FirstShop.Core.Services.Products.Product;
using FirstShop.Core.Services.UserServices;
using FirstShop.Core.Tools;
using FirstShop.Core.ViewModels.Products;
using FirstShop.Core.ViewModels.Users;
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

    }



}

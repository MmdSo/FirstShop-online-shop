using AutoMapper;
using FirstShop.Core.Services.Products.Brands;
using FirstShop.Core.Services.Products.Product;
using FirstShop.Core.Services.UserServices;
using FirstShop.Core.ViewModels.Products;
using FirstShop.Core.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;

namespace FirstShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private IProductServices _productServices;
        public ProductsController(IProductServices productServices)
        {
            _productServices = productServices;
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

    }


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

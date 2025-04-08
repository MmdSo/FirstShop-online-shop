using AutoMapper;
using FirstShop.Core.Services.Sales.Delivey;
using FirstShop.Core.Services.Sales.InvoiceBodies;
using FirstShop.Core.Services.Sales.InvoiceHeads;
using FirstShop.Core.Services.Sales.ShoppingBasketDetailServices;
using FirstShop.Core.Services.Sales.ShoppingBaskets;
using FirstShop.Core.Services.Sales.Taxes;
using FirstShop.Core.ViewModels.Sales;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstShop.Controllers
{
    #region Delivery
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryApiController : ControllerBase
    {

        private IMapper _mapper;
        private IDeliveryMethodServices _deliveryServices;
        public DeliveryApiController(IDeliveryMethodServices deliveryServices, IMapper mapper)
        {
            _deliveryServices = deliveryServices;
            _mapper = mapper;
        }

        public List<DeliveryViewModel> DeliveryList { get; set; }

        [HttpGet]
        public List<DeliveryViewModel> GetMethods()
        {
            DeliveryList = _deliveryServices.GetAllMethods().ToList();
            return DeliveryList;
        }

        [HttpGet("{id:long}")]
        public ActionResult<DeliveryForApiViewModel> GetMethodById(long id)
        {
            var method = _deliveryServices.GetDeliveryById(id);
            if (method == null)
                return NotFound(method);
            else
                return Ok(method);
        }

        [HttpGet("{name}")]
        public ActionResult<DeliveryForApiViewModel> GetMethodByName(string name)
        {
            var method = _deliveryServices.GetDeliveryIdByName(name);
            if (method == null)
                return NotFound(method);
            else
                return Ok(method);
        }


        [HttpPost]
        public long AddDeliveryFromApi(long id)
        {
            return id;
        }

        [HttpPost("AddMethodFromApiBody")]
        public async Task<long> AddMethodFromApiBody(DeliveryForApiViewModel method)
        {
            var dm = _mapper.Map<DeliveryForApiViewModel, DeliveryViewModel>(method);

            return await _deliveryServices.AddDelivery(dm);
        }

        [HttpPost("AddMethodFromApiQuery")]
        public async Task<long> AddMethodFromApiQuery([FromQuery] DeliveryForApiViewModel method)
        {
            var dm = _mapper.Map<DeliveryForApiViewModel, DeliveryViewModel>(method);

            return await _deliveryServices.AddDelivery(dm);
        }


        [HttpPut("EditMethodFromApi")]
        public async Task<IActionResult> EditMethodFromApi(DeliveryForApiViewModel method)
        {
            var dm = _mapper.Map<DeliveryForApiViewModel, DeliveryViewModel>(method);

            await _deliveryServices.EditDelivery(dm);

            return Ok();
        }

        [HttpDelete("DeleteMethodFromApi")]
        public async Task<IActionResult> DeleteMethodFromApi(long id)
        {
            var dm = _deliveryServices.GetDeliveryById(id);

            if (dm == null)
            {
                return NotFound(new { message = "Not found !" });
            }

            await _deliveryServices.DeleteDelivery(id);

            return Ok();
        }

    }
    #endregion

    #region InvoiceHead
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceHeadApiController : ControllerBase
    {

        private IMapper _mapper;
        private IInvoiceHeadServices _invoiceHeadServices;
        public InvoiceHeadApiController(IInvoiceHeadServices invoiceHeadServices, IMapper mapper)
        {
            _invoiceHeadServices = invoiceHeadServices;
            _mapper = mapper;
        }

        public List<InvoiceHeadViewModel> invoiceHeadList { get; set; }

        [HttpGet]
        public List<InvoiceHeadViewModel> GetInvoiceHead()
        {
            invoiceHeadList = _invoiceHeadServices.GetAllInvoiceHead().ToList();
            return invoiceHeadList;
        }

        [HttpGet("{id}")]
        public ActionResult<InvoiceHeadForApiViewModel> GetInvoiceHeadById(long id)
        {
            var ih = _invoiceHeadServices.GetInvoiceHeadByIdAsync(id);
            if (ih == null)
                return NotFound(ih);
            else
                return Ok(ih);
        }

    }
    #endregion

    #region InvoiceBody
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceBodyApiController : ControllerBase
    {

        private IMapper _mapper;
        private IInvoiceBodyServices _invoiceBodyServices;
        public InvoiceBodyApiController(IInvoiceBodyServices invoiceBodyServices, IMapper mapper)
        {
            _invoiceBodyServices = invoiceBodyServices;
            _mapper = mapper;
        }

        public List<InvoiceBodyViewModel> invoiceBodyList { get; set; }

        [HttpGet]
        public List<InvoiceBodyViewModel> GetInvoiceHead()
        {
            invoiceBodyList = _invoiceBodyServices.GetAllInvoiceBody().ToList();
            return invoiceBodyList;
        }

        [HttpGet("{id}")]
        public ActionResult<InvoiceBodyForApiViewModel> GetInvoiceBodyById(long id)
        {
            var ib = _invoiceBodyServices.GetInvoiceBodyByHeadIdAsync(id);
            if (ib == null)
                return NotFound(ib);
            else
                return Ok(ib);
        }

    }
    #endregion

    #region SB
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingbasketApiController : ControllerBase
    {

        private IMapper _mapper;
        private IShoppingBasketServices _shoppingBasketServices;
        public ShoppingbasketApiController(IShoppingBasketServices shoppingBasketServices, IMapper mapper)
        {
            _shoppingBasketServices = shoppingBasketServices;
            _mapper = mapper;
        }

        public List<ShoppingBassketViewModel> ShoppingBassketList { get; set; }

        [HttpGet]
        public List<ShoppingBassketViewModel> GetShoppingBasket()
        {
            ShoppingBassketList = _shoppingBasketServices.GetAllShoppingBaskets().ToList();
            return ShoppingBassketList;
        }

        [HttpGet("{id}")]
        public ActionResult<ShoppingBassketForApiViewModel> GetShoppingBasketById(long id)
        {
            var sb = _shoppingBasketServices.GetShoppingBasketById(id);
            if (sb == null)
                return NotFound(sb);
            else
                return Ok(sb);
        }

    }
    #endregion

    #region SBD
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingbasketDerailApiController : ControllerBase
    {

        private IMapper _mapper;
        private IShoppingBasketDetailServices _shoppingBasketDetailServices;
        public ShoppingbasketDerailApiController(IShoppingBasketDetailServices shoppingBasketDetailServices, IMapper mapper)
        {
            _shoppingBasketDetailServices = shoppingBasketDetailServices;
            _mapper = mapper;
        }

        public List<ShoppingBassketDetailViewModel> ShoppingBassketDetailList { get; set; }

        [HttpGet]
        public List<ShoppingBassketDetailViewModel> GetShoppingbasketDetail()
        {
            ShoppingBassketDetailList = _shoppingBasketDetailServices.GetAllShoppingBasketsDetail().ToList();
            return ShoppingBassketDetailList;
        }

        [HttpGet("{id}")]
        public ActionResult<ShoppingBassketDetailForApiViewModel> GetShoppingBasketDetailById(long id)
        {
            var sbd = _shoppingBasketDetailServices.GetShoppingBasketDetailByBasketIdAsync(id);
            if (sbd == null)
                return NotFound(sbd);
            else
                return Ok(sbd);
        }

    }
    #endregion

    #region Tax
    [Route("api/[controller]")]
    [ApiController]
    public class TaxApiController : ControllerBase
    {

        private IMapper _mapper;
        private ITaxServices _taxServices;
        public TaxApiController(ITaxServices taxServices, IMapper mapper)
        {
            _taxServices = taxServices;
            _mapper = mapper;
        }

        public List<TaxViewModel> taxList { get; set; }

        [HttpGet]
        public List<TaxViewModel> GetTax()
        {
            taxList = _taxServices.GetAllTax().ToList();
            return taxList;
        }

        [HttpGet("{id:long}")]
        public ActionResult<TaxForApiViewModel> GetTaxById(long id)
        {
            var tax = _taxServices.GetTaxById(id);
            if (tax == null)
                return NotFound(tax);
            else
                return Ok(tax);
        }

        [HttpPost]
        public long AddTaxFromApi(long id)
        {
            return id;
        }

        [HttpPost("AddTaxFromApiBody")]
        public async Task<long> AddTaxFromApiBody(TaxForApiViewModel tax)
        {
            var ta = _mapper.Map<TaxForApiViewModel, TaxViewModel>(tax);

            return await _taxServices.AddTax(ta);
        }

        [HttpPost("AddTaxFromApiQuery")]
        public async Task<long> AddTaxFromApiQuery([FromQuery] TaxForApiViewModel tax)
        {
            var ta = _mapper.Map<TaxForApiViewModel, TaxViewModel>(tax);

            return await _taxServices.AddTax(ta);
        }


        [HttpPut("EditMethodFromApi")]
        public async Task<IActionResult> EditMethodFromApi(TaxForApiViewModel tax)
        {
            var ta = _mapper.Map<TaxForApiViewModel, TaxViewModel>(tax);

            await _taxServices.EditTax(ta);

            return Ok();
        }
    }
        #endregion
    }


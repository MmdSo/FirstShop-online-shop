using AutoMapper;
using FirstShop.Core.Services.Settings;
using FirstShop.Core.Services.Settings.Contects;
using FirstShop.Core.Services.Settings.Discount;
using FirstShop.Core.Services.Settings.Logos;
using FirstShop.Core.Services.Settings.Sliders;
using FirstShop.Core.Tools;
using FirstShop.Core.ViewModels.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstShop.Controllers
{
    #region Contect
    [Route("api/[controller]")]
    [ApiController]
    public class ContactApiController : ControllerBase
    {
            private IMapper _mapper;
            private IContectServices _contactServices;
            public ContactApiController(IContectServices contactServices, IMapper mapper)
            {
                _contactServices = contactServices ;
                _mapper = mapper;
            }

            public List<ContectViewModel> ContactList { get; set; }

            [HttpGet]
            public List<ContectViewModel> GetContact()
            {
            ContactList = _contactServices.GetAllContects().ToList();
                return ContactList;
            }

            [HttpGet("{id}")]
            public ActionResult<ContectForApiViewModel> GetContectById(long id)
            {
                var contect = _contactServices.GetContectById(id);
                if (contect == null)
                    return NotFound(contect);
                else
                    return Ok(contect);
            }

            [HttpPost]
            public long AddContectFromApi(long id)
            {
                return id;
            }

            [HttpPost("AddContectFromApiBody")]
            public async Task<ContectViewModel> AddContectFromApiBody(ContectForApiViewModel Contect)
            {
                var co = _mapper.Map<ContectForApiViewModel, ContectViewModel>(Contect);

                return await _contactServices.AddContect(co);
            }

            [HttpPost("AddContectFromApiQuery")]
            public async Task<ContectViewModel> AddContectFromApiQuery([FromQuery] ContectForApiViewModel Contect)
            {
                var co = _mapper.Map<ContectForApiViewModel, ContectViewModel>(Contect);

                return await _contactServices.AddContect(co);
            }

        [HttpPut("EditContectFromApi")]
        public async Task<IActionResult> EditContectFromApi(ContectForApiViewModel Contect)
        {
            var existContect = _contactServices.GetAllContects().FirstOrDefault();

            await _contactServices.EditContect(existContect);

            return Ok();
        }
    }
    #endregion

    #region Discount
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountApiController : ControllerBase
    {

        private IMapper _mapper;
        private IDiscountServices _discountServices;
        public DiscountApiController(IDiscountServices discountServices, IMapper mapper)
        {
            _discountServices = discountServices;
            _mapper = mapper;
        }

        public List<DiscountCodeViewModel> DiscountList { get; set; }

        [HttpGet]
        public List<DiscountCodeViewModel> GetCodes()
        {
            DiscountList = _discountServices.GetAllCodes().ToList();
            return DiscountList;
        }

        [HttpGet("{id:long}")]
        public ActionResult<DiscountCodeForApiViewModel> GetCodeById(long id)
        {
            var code = _discountServices.GetCodesByIdAsync(id);
            if (code == null)
                return NotFound(code);
            else
                return Ok(code);
        }

        [HttpGet("{code}")]
        public ActionResult<DiscountCodeForApiViewModel> GetCodeByCode(string code)
        {
            var co = _discountServices.GetCodesByCodeAsync(code);
            if (co == null)
                return NotFound(co);
            else
                return Ok(co);
        }


        [HttpPost]
        public long AddCodeFromApi(long id)
        {
            return id;
        }

        [HttpPost("AddCodeFromApiBody")]
        public async Task<long> AddCodeFromApiBody(DiscountCodeForApiViewModel code)
        {
            var dc = _mapper.Map<DiscountCodeForApiViewModel, DiscountCodeViewModel>(code);

            return await _discountServices.AddCodes(dc);
        }

        [HttpPost("AddcodeFromApiQuery")]
        public async Task<long> AddcodeFromApiQuery([FromQuery] DiscountCodeForApiViewModel code)
        {
            var dc = _mapper.Map<DiscountCodeForApiViewModel, DiscountCodeViewModel>(code);

            return await _discountServices.AddCodes(dc);
        }


        [HttpPut("EditCodeFromApi")]
        public async Task<IActionResult> EditCodeFromApi(long id ,[FromForm]DiscountCodeForApiViewModel code)
        {
            var existCode =await _discountServices.GetCodesByIdAsync(id);
            if(existCode == null)
            {
                return NotFound("Code is not found");
            }

            existCode.Code = code.Code;
            existCode.Percent = code.Percent;

            _discountServices.EditCodes(existCode);

            return Ok();
        }

        [HttpDelete("DeleteCodeFromApi")]
        public async Task<IActionResult> DeleteCodeFromApi(long id)
        {
            var dm = _discountServices.GetCodesByIdAsync(id);

            if (dm == null)
            {
                return NotFound(new { message = "Not found !" });
            }

            await _discountServices.DeleteCodes(id);

            return Ok();
        }

    }
    #endregion

    #region Logo
    [Route("api/[controller]")]
    [ApiController]
    public class LogoApiController : ControllerBase
    {
        private IMapper _mapper;
        private ILogoServices _logoServices;
        public LogoApiController(ILogoServices logoServices, IMapper mapper)
        {
            _logoServices = logoServices;
            _mapper = mapper;
        }

        public List<LogoViewModel> logoViewModel { get; set; }

        [HttpGet]
        public List<LogoViewModel> GetLogo()
        {
            logoViewModel = _logoServices.GetAllLogo().ToList();
            return logoViewModel;
        }

        [HttpGet("{id}")]
        public ActionResult<LogoViewForApiModel> GetLogoById(long id)
        {
            var logo = _logoServices.GetLogoById(id);
            if (logo == null)
                return NotFound(logo);
            else
                return Ok(logo);
        }

        [HttpPost]
        public long AddLogoFromApi(long id)
        {
            return id;
        }

        [HttpPost("AddLogoFromApiBody")]
        public async Task<LogoViewModel> AddLogoFromApiBody(LogoViewForApiModel logo , IFormFile logoImg)
        {
            var lo = _mapper.Map<LogoViewForApiModel, LogoViewModel>(logo);

            string fileName = NameGenerator.GenerateUniqCode() + Path.GetExtension(logoImg.FileName);
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", fileName);

            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                await logoImg.CopyToAsync(stream);
            }


            lo.LogoImage = "/Images/" + fileName;

            return await _logoServices.AddLogo(lo , logoImg);
        }

        [HttpPost("AddLogoFromApiQuery")]
        public async Task<LogoViewModel> AddLogoFromApiQuery([FromQuery] LogoViewForApiModel logo, IFormFile logoImg)
        {
            var lo = _mapper.Map<LogoViewForApiModel, LogoViewModel>(logo);

            string fileName = NameGenerator.GenerateUniqCode() + Path.GetExtension(logoImg.FileName);
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", fileName);

            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                await logoImg.CopyToAsync(stream);
            }


            lo.LogoImage = "/Images/" + fileName;

            return await _logoServices.AddLogo(lo, logoImg);
        }

        [HttpPut("EditlogoFromApi")]
        public async Task<IActionResult> EditlogoFromApi(LogoViewForApiModel logo, IFormFile logoImg)
        {
            var lo = _logoServices.GetAllLogo().FirstOrDefault();

            string fileName = NameGenerator.GenerateUniqCode() + Path.GetExtension(logoImg.FileName);
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", fileName);

            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                await logoImg.CopyToAsync(stream);
            }


            lo.LogoImage = "/Images/" + fileName;

            await _logoServices.EditLogo(lo , null);

            return Ok();
        }
    }
    #endregion

    #region Slider
     [Route("api/[controller]")]
    [ApiController]
    public class SliderApiController : ControllerBase
    {
        private IMapper _mapper;
        private ISliderPicServices _sliderServices;
        public SliderApiController(ISliderPicServices sliderServices, IMapper mapper)
        {
            _sliderServices = sliderServices;
            _mapper = mapper;
        }

        public List<SliderViewModel> sliderList { get; set; }

        [HttpGet]
        public List<SliderViewModel> GetSlider()
        {
            sliderList = _sliderServices.GetAllPhotos().ToList();
            return sliderList;
        }

        [HttpGet("{id}")]
        public ActionResult<SliderForApiViewModel> GetSliderById(long id)
        {
            var photo = _sliderServices.GetAllPhotosById(id);
            if (photo == null)
                return NotFound(photo);
            else
                return Ok(photo);
        }

        [HttpGet("GetFiveSlider")]
        public ActionResult<SliderForApiViewModel> GetFiveSlider()
        {
            var photo = _sliderServices.GetFivephoto();
            if (photo == null)
                return NotFound(photo);
            else
                return Ok(photo);
        }

        [HttpPost]
        public long AddSliderFromApi(long id)
        {
            return id;
        }

        [HttpPost("AddSliderFromApiBody")]
        public async Task<long> AddSliderFromApiBody(SliderForApiViewModel photo , IFormFile pImg)
        {
            var slider = _mapper.Map<SliderForApiViewModel, SliderViewModel>(photo);

            string fileName = NameGenerator.GenerateUniqCode() + Path.GetExtension(pImg.FileName);
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", fileName);

            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                await pImg.CopyToAsync(stream);
            }


            slider.SliderPhoto = "/Images/" + fileName;

            return await _sliderServices.AddPhoto(slider, pImg);
        }

        [HttpPost("AddSliderFromApiQuery")]
        public async Task<long> AddSliderFromApiQuery([FromQuery] SliderForApiViewModel photo, IFormFile pImg)
        {
            var slider = _mapper.Map<SliderForApiViewModel, SliderViewModel>(photo);

            string fileName = NameGenerator.GenerateUniqCode() + Path.GetExtension(pImg.FileName);
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", fileName);

            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                await pImg.CopyToAsync(stream);
            }


            slider.SliderPhoto = "/Images/" + fileName;

            return await _sliderServices.AddPhoto(slider, pImg);
        }

        [HttpPut("EditSliderFromApi")]
        public async Task<IActionResult> EditSliderFromApi(long id ,[FromForm]SliderForApiViewModel photo, IFormFile pImg)
        {
            var existPhoto = _sliderServices.GetAllPhotosById(id);

            existPhoto.Link = photo.Link;
            existPhoto.PhotoName = photo.PhotoName;
            existPhoto.SliderDescription = photo.SliderDescription;
            
            string fileName = NameGenerator.GenerateUniqCode() + Path.GetExtension(pImg.FileName);
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", fileName);

            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                await pImg.CopyToAsync(stream);
            }


            existPhoto.SliderPhoto = "/Images/" + fileName;

            await _sliderServices.AddPhoto(existPhoto, null);

            return Ok();
        }

        [HttpDelete("DeleteSliderFromApi")]
        public async Task<IActionResult> DeleteSliderFromApi(long id)
        {
            var dm = _sliderServices.GetAllPhotosById(id);

            if (dm == null)
            {
                return NotFound(new { message = "Not found !" });
            }

            await _sliderServices.DeletePhoto(id);

            return Ok();
        }
    }
    #endregion

    #region Message
    [Route("api/[controller]")]
    [ApiController]
    public class MessageApiController : ControllerBase
    {
        private IMapper _mapper;
        private ISendMessageServices _messageServices;
        public MessageApiController(ISendMessageServices messageServices, IMapper mapper)
        {
            _messageServices = messageServices;
            _mapper = mapper;
        }

        public List<SendMessagesViewModel> messageList { get; set; }

        [HttpGet]
        public List<SendMessagesViewModel> GetMessage()
        {
            messageList = _messageServices.GetAllMessages().ToList();
            return messageList;
        }

        [HttpPost("AddMessageFromApiQuery")]
        public async Task<SendMessagesViewModel> AddMessageFromApiQuery([FromQuery] SendMessagesForApiViewModel message)
        {
            var sm = _mapper.Map<SendMessagesForApiViewModel, SendMessagesViewModel>(message);

            return await _messageServices.AddMessages(sm);
        }

        [HttpPut("EditMessageFromApi")]
        public async Task<IActionResult> EditMessageFromApi(SendMessagesForApiViewModel message)
        {
            var sm = _mapper.Map<SendMessagesForApiViewModel, SendMessagesViewModel>(message);

            await _messageServices.EditMessages(sm);

            return Ok();
        }

        [HttpPost("sendPublicMessage")]
        public async Task<IActionResult> sendPublicMessage(string PhoneNumber, string Message)
        {
            try
            {
                await _messageServices.SendPublicSMS(PhoneNumber, Message);
                return Ok("SMS sent successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
        [HttpPost("SendLookUpsms")]
        public async Task<IActionResult> SendLookUpsms(string PhoneNumber, string TemplateName, string token1, string? token2 = "", string? token3 = "")
        {

            try
            {
                await _messageServices.SendLookUpSms(PhoneNumber, TemplateName, token1, token2, token3);
                return Ok("LookUp SMS sent successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }

        #endregion
    }
    

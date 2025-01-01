using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.ViewModels
{
    public class googleReCaptchaViewModel
    {
        [Required]
        public string captchaToken { get; set; }
    }
}

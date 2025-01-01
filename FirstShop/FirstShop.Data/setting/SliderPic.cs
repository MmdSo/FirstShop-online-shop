using FirstShop.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Data.setting
{
    public class SliderPic : BaseEntities
    {
        public string SliderPhoto { get; set; }
        public string PhotoName { get; set; }
        public string Link { get; set; }
        public string? SliderDescription { get; set; }
    }
}

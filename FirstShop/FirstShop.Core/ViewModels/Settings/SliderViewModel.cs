using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.ViewModels.Settings
{
    public class SliderViewModel
    {
        public long Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsDeleted { get; set; }

        public string? SliderPhoto { get; set; }
        public string PhotoName { get; set; }
        public string Link { get; set; }
        public string? SliderDescription { get; set; }

    }
}

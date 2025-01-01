using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.ViewModels.Products
{
    public class ProductCommentForApiViewModel
    {

        public string Title { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public bool IsApproved { get; set; }
    }
}

using FirstShop.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Data.setting
{
    public class UsedCode : BaseEntities
    {
        public long CodeId { get; set; }
        public long UserId { get; set; }
    }
}

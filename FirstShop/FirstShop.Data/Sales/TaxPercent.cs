﻿using FirstShop.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Data.Sales
{
    public class TaxPercent : BaseEntities
    {
        public decimal Percent { get; set; }
    }
}

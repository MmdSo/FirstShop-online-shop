using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Data.Context
{
    public class BaseEntities
    {
        [Key]
        public long id { get; set; }
        public DateTime DataCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsDeleted { get; set; }

    }

    public class ErorrMessage
    {
        public string type;
        public string message;
    }
}

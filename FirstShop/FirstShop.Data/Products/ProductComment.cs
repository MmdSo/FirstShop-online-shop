using FirstShop.Data.Context;
using FirstShop.Data.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Data.Products
{
    public class IProductComment :BaseEntities
    {
        public string? Title { get; set; }
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }
        public long ProductsId { get; set; }
        public bool IsApproved { get; set; }
        public long? CommentID { get; set; }
        //public long? UserID { get; set; }



        #region relation
        [ForeignKey("ProductsId")]
        public Productss products { get; set; }

        //[ForeignKey("UserId")]
        //public SiteUser SiteUser { get; set; }

        [ForeignKey("CommentID")]
        public IProductComment productComment { get; set; }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.ViewModels.Blogs
{
    public class PostForApiViewModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Subject { get; set; }
        public string Summary { get; set; }
        public string Body { get; set; }
        public string? PostImage { get; set; }
        public string? PostIndexImage { get; set; }
        public string? PostType { get; set; }
    }
}

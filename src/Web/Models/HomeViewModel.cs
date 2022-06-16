using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Web.Models
{
    public class HomeViewModel
    {
        public List<ProductViewModel> Products { get; set; }
        public List<SelectListItem> Brands { get; set; }
        public List<SelectListItem> Categories { get; set; }

        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }

        public PagenationInfoViewModel PagenationInfo { get; set; }
    }
}

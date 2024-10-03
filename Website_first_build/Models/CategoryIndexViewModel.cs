using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website_first_build.Models
{
    public class CategoryIndexViewModel
    {
        public List<New> FirstNews { get; set; }
        public PagedList.IPagedList<New> PagedNews { get; set; } 
    }
}
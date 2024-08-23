using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website_first_build.Models
{
    public class NewsViewModel
    {
        public New SingleNews { get; set; }   // For the single item
        public IEnumerable<New> NewsList { get; set; }  // For the list
    }
}
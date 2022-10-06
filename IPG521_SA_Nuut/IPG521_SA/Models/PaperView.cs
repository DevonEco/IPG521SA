using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPG521_SA.Models
{
    public class PaperView
    {
        public IEnumerable<Papers> papers { get; set; }
        public IEnumerable<Topics> topics { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace IPG521_SA.Models
{
    public class Papers
    {
        [Key]
        [BindNever]
        [Display(Name = "ID")]
        public int PaperId { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string PaperTitle { get; set; }

        [Required]
        [Display(Name = "Abstract")]
        public string PaperAbstract { get; set; }

        
        [Display(Name = "Author")]
        public string PaperAuthor { get; set; }

        
        [Display(Name = "Submission Date")]
        public string PaperDateSubmitted { get; set; }

        
        [BindNever]
        [Display(Name = "Topic")]
        public int TopicID { get; set; }

    }
}
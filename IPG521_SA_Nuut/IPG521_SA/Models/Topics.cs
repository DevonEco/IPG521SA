using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace IPG521_SA.Models
{
    public class Topics
    {
        [Key]
        [BindNever]
        public int TopicID { get; set; }
        [Display(Name = "Topic")]
        [Required]
        public string TopicName { get; set; }

    }
}
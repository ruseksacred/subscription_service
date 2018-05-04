using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SubscriptionService.Models
{
    public class Newsletter
    {
        [Required(ErrorMessage="Temat jest wymagany")]
        [Display(Name ="Temat")]
        [StringLength(20,ErrorMessage ="Tekst nie może być dłuższy niż 20 znaków")]
        public string Subject { get; set; }
        [Required(ErrorMessage ="Treść jest wymagana")]
        [Display(Name ="Treść")]
        [StringLength(200,ErrorMessage ="Treść nie może być dłuższa niż 200 znaków")]
        public string Content { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SubscriptionService.Models
{
    public class Subscriber
    {
        [ScaffoldColumn(false)]
        public long ID { get; set; }
        [StringLength(50,ErrorMessage ="Imię może mieć max 50 znaków")]
        [Required(ErrorMessage ="Imię jest wymagane")]
        [Display(Name ="Imie")]
        public string Name { get; set; }
        [StringLength(50, ErrorMessage = "Nazwisko może mieć max 50 znaków")]
        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        [Display(Name = "Nazwsko")]
        public string Surname { get; set; }
        public string Email { get; set; }
        [Display(Name="Data Rejestracji")]
        [DataType(DataType.DateTime)]
        public DateTime RegistrationDate { get; set; }
    }
}
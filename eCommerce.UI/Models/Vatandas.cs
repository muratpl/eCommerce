using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eCommerce.UI.Models
{
    public class Vatandas
    {
        [Display(Name = "TC Kimlik Numarası:")]
        public long TcKimlikNo { get; set; }
        public string Ad { get; set; }
        public string Surname { get; set; }
        [Display(Name="Doğum Yılı")]
        public int dogumYili { get; set; }
    }
}
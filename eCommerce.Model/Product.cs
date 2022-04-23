using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eCommerce.Model
{
    public class Product : Base
    {
        [Required]
        [Display(Name ="Product Name")]
        public string Name { get; set; } //Sadece stringlere null gelebilir.

        public double Price { get; set; }

        //[ForeignKey("Category")] //Asagidakiyle ayni gorevi gorur. Category id ile değil, ismiyle cagirilmasini saglar.
        public int CategoryId { get; set; }

        //navigation properties
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eCommerce.Model
{
    public class Category : Base
    {
        public Category()
        {
            this.Products = new HashSet<Product>(); //Hashset List'lere gore daha hizli calisir.

        }


        [Display(Name ="Category Name")]
        [Required]
        public string Name { get; set; } //Sadece stringlere null gelebilir.

        //navigation properties
        public virtual ICollection<Product> Products { get; private set; } //Dogrudan hashset yerine icolection kullanilmasinin sebebi kod verimini ve performansini artırmak. (Solid Prensipleri!)
    }
}
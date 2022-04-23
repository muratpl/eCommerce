using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eCommerce.Model
{
    public class Base
    {
        public Base()
        {
            RegistrationDate = DateTime.Now;
        }

        
        [Key] // Primary key anlamında..
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime? RegistrationDate { get; private set; } //Soru isareti nullable anlaminda..
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Q_LESS_Transport.ClientApp.Models
{
    public class CardTypeDetailsResource
    {
        [Display(Name = "Q-LESS Card Type")]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsSenior { get; set; }
        [Display(Name = "Discount Card ID")]
        [Required]
        public string DiscountCardID { get; set; }
    }
}

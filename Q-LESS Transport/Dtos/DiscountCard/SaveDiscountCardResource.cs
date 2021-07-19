using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Q_LESS_Transport.Dtos.DiscountCard
{
    public class SaveDiscountCardResource
    {
        [Key]
        [Required]
        [MaxLength(14)]
        public string Id { get; set; }
        public bool IsSenior { get; set; }

        // Foreign properties
        // Foreign key
        public Guid CardId { get; set; }
    }
}

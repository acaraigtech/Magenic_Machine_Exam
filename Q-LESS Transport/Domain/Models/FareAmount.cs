using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Q_LESS_Transport.Domain.Models
{
    public class FareAmount
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public double Amount { get; set; }

        // Foreign properties
        // Foreign key
        public CardType CardType { get; set; }
    }
}

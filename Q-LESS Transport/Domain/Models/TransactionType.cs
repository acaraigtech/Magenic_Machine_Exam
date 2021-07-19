using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Q_LESS_Transport.Domain.Models
{
    public class TransactionType
    {
        [Key]
        [Required]
        [MaxLength(6)]
        public string Code { get; set; }
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        // Foreign properties
        // Foreign key
        public List<Transaction> Transaction { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Q_LESS_Transport.ClientApp.Models
{
    public class TransactionResource
    {
        public Guid Id { get; set; }
        [Required]
        [Range(100, 1000, ErrorMessage = "Please input 100 to 1000 only")]
        public double Amount { get; set; }
        public DateTime Date { get; set; }

        // Foreign properties
        // Foreign key
        public Guid CardId { get; set; }
        public Guid CardTypeDetailsId { get; set; }
        public string TransactionCode { get; set; }

        // Additional Properties
        [Required]
        [Range(0, 10000, ErrorMessage = "Please input 0 to 10000 only")]
        public double CustomerMoney { get; set; }
        public double Change { get; set; }
        public double NewBalance { get; set; }
    }
}

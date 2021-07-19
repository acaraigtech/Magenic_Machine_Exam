using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q_LESS_Transport.Dtos.Transaction
{
    public class TransactionRequestResource
    {
        public double Amount { get; set; }
        public DateTime Date { get; set; }

        // Foreign properties
        // Foreign key
        public Guid CardId { get; set; }

        public Guid CardTypeDetailsId { get; set; }
        public string TransactionCode { get; set; }

        // Additional Properties
        public double CustomerMoney { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q_LESS_Transport.Dtos.Transaction
{
    public class SaveTransactionResource
    {
        public double Amount { get; set; }
        public DateTime Date { get; set; }

        // Foreign properties
        // Foreign key
        public Guid CardId { get; set; }
        public string TransactionCode { get; set; }

        // Additional Properties
        public double CustomerMoney { get; set; }
        public double Change { get; set; }
        public double NewBalance { get; set; }
    }
}

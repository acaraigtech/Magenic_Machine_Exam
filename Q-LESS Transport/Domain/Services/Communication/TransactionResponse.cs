using Q_LESS_Transport.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q_LESS_Transport.Domain.Services.Communication
{
    public class TransactionResponse : BaseResponse<Transaction>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="transaction">Saved transaction.</param>
        /// <returns>Response.</returns>
        public TransactionResponse(Transaction transaction) : base(transaction)
        { }



        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public TransactionResponse(string message) : base(message)
        { }
    }
}

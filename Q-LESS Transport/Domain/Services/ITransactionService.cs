using Q_LESS_Transport.Domain.Models;
using Q_LESS_Transport.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q_LESS_Transport.Domain.Services
{
    public interface ITransactionService
    {
        Task<TransactionResponse> SaveAsync(Transaction transaction);
    }
}

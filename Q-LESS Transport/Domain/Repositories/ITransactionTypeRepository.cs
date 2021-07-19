using Q_LESS_Transport.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q_LESS_Transport.Domain.Repositories
{
    public interface ITransactionTypeRepository
    {
        Task<TransactionType> SelectByCodeAsync(string code);
    }
}

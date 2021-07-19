using Q_LESS_Transport.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q_LESS_Transport.Domain.Repositories
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transaction>> SelectByCardIdAndDateAsync(Guid cardId, DateTime datetime);
        void Insert(Transaction transaction);
    }
}

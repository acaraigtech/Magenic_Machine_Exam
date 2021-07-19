using Microsoft.EntityFrameworkCore;
using Q_LESS_Transport.Domain.Models;
using Q_LESS_Transport.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q_LESS_Transport.Presistence.Repositories
{
    public class TransactionRepository : BaseRepository, ITransactionRepository
    {
        public TransactionRepository(QLESSTransportAPIContextDb context) : base(context) { }
        public void Insert(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
        }

        public async Task<IEnumerable<Transaction>> SelectByCardIdAndDateAsync(Guid cardId, DateTime datetime)
        {
            return await _context.Transactions
                .Where(c => c.CardId == cardId && c.Date == datetime)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}

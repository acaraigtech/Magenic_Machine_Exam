using Microsoft.EntityFrameworkCore;
using Q_LESS_Transport.Domain.Models;
using Q_LESS_Transport.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q_LESS_Transport.Presistence.Repositories
{
    public class TransactionTypeRepository : BaseRepository, ITransactionTypeRepository
    {
        public TransactionTypeRepository(QLESSTransportAPIContextDb context) : base(context) { }

        public async Task<TransactionType> SelectByCodeAsync(string code)
        {
            return await _context.TransactionTypes.Where(c => c.Code == code).FirstOrDefaultAsync();
        }
    }
}

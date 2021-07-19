using Microsoft.EntityFrameworkCore;
using Q_LESS_Transport.Domain.Models;
using Q_LESS_Transport.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q_LESS_Transport.Presistence.Repositories
{
    public class CardTypeDetailsRepository : BaseRepository, ICardTypeDetailsRepository
    {
        public CardTypeDetailsRepository(QLESSTransportAPIContextDb context) : base(context) { }
        public async Task<IEnumerable<CardTypeDetails>> SelectAllAsync()
        {
            return await _context.CardTypeDetails
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<CardTypeDetails> SelectByIdAsync(Guid id)
        {
            return await _context.CardTypeDetails.FindAsync(id);
        }
        public void Insert(CardTypeDetails cardType)
        {
            _context.CardTypeDetails.Add(cardType);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Q_LESS_Transport.Domain.Models;
using Q_LESS_Transport.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q_LESS_Transport.Presistence.Repositories
{
    public class CardRepository : BaseRepository, ICardRepository
    {
        public CardRepository(QLESSTransportAPIContextDb context) : base(context) { }
        public async Task<IEnumerable<Card>> SelectAllAsync()
        {
            return await _context.Cards
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<IEnumerable<Card>> SelectAllByIdAsync(Guid id)
        {
            return await _context.Cards.Where(c => c.Id == id).AsNoTracking().ToListAsync();
        }
        public async Task<Card> SelectByIdAsync(Guid id)
        {
            return await _context.Cards.FindAsync(id);
        }
        public void Insert(Card card)
        {
            _context.Cards.Add(card);
        }

        public void Update(Card card)
        {
            _context.Cards.Update(card);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Q_LESS_Transport.Domain.Models;
using Q_LESS_Transport.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q_LESS_Transport.Presistence.Repositories
{
    public class DiscountCardRepository : BaseRepository, IDiscountCardRepository
    {
        public DiscountCardRepository(QLESSTransportAPIContextDb context) : base(context) { }
        public async Task<DiscountCard> SelectByCardIdAsync(Guid cardId)
        {
            return await _context.DiscountCards.Where(c => c.CardId == cardId).FirstOrDefaultAsync();
        }
        public void Insert(DiscountCard discountCard)
        {
            _context.DiscountCards.Add(discountCard);
        }
    }
}

using Q_LESS_Transport.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q_LESS_Transport.Domain.Repositories
{
    public interface IDiscountCardRepository
    {
        Task<DiscountCard> SelectByCardIdAsync(Guid cardId);
        void Insert(DiscountCard discountCard);
    }
}

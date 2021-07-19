using Q_LESS_Transport.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q_LESS_Transport.Domain.Repositories
{
    public interface ICardRepository
    {
        Task<IEnumerable<Card>> SelectAllAsync();
        Task<IEnumerable<Card>> SelectAllByIdAsync(Guid id);
        Task<Card> SelectByIdAsync(Guid id);
        void Insert(Card card);
        void Update(Card card);
    }
}

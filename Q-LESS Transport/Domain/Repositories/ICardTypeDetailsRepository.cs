using Q_LESS_Transport.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q_LESS_Transport.Domain.Repositories
{
    public interface ICardTypeDetailsRepository
    {
        Task<IEnumerable<CardTypeDetails>> SelectAllAsync();
        Task<CardTypeDetails> SelectByIdAsync(Guid id);
        void Insert(CardTypeDetails cardType);
    }
}

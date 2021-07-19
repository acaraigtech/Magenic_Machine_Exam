using Q_LESS_Transport.Domain.Models;
using Q_LESS_Transport.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q_LESS_Transport.Domain.Services
{
    public interface ICardService
    {
        Task<IEnumerable<Card>> ListAsync();
        Task<IEnumerable<Card>> ListByIdAsync(Guid id);
        Task<Card> GetByIdAsync(Guid id);
        Task<CardResponse> SaveAsync(Card card);
        Task<CardResponse> EditAsync(Guid id, Card card);
    }
}

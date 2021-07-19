using Q_LESS_Transport.Domain.Models;
using Q_LESS_Transport.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q_LESS_Transport.Domain.Services
{
    public interface IDiscountCardService
    {
        Task<DiscountCardResponse> SaveAsync(DiscountCard discountCard);
    }
}

using Q_LESS_Transport.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q_LESS_Transport.Domain.Services.Communication
{
    public class DiscountCardResponse : BaseResponse<DiscountCard>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="discountCard">Saved discount card.</param>
        /// <returns>Response.</returns>
        public DiscountCardResponse(DiscountCard discountCard) : base(discountCard)
        { }



        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public DiscountCardResponse(string message) : base(message)
        { }
    }
}

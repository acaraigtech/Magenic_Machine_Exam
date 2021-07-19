using Q_LESS_Transport.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q_LESS_Transport.Domain.Services.Communication
{
    public class CardResponse : BaseResponse<Card>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="card">Saved card.</param>
        /// <returns>Response.</returns>
        public CardResponse(Card card) : base(card)
        { }



        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public CardResponse(string message) : base(message)
        { }
    }
}

using Q_LESS_Transport.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q_LESS_Transport.Domain.Services.Communication
{
    public class CardTypeResponse : BaseResponse<CardTypeDetails>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="card">Saved card type.</param>
        /// <returns>Response.</returns>
        public CardTypeResponse(CardTypeDetails cardType) : base(cardType)
        { }



        /// <summary>
        /// Creates a error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public CardTypeResponse(string message) : base(message)
        { }
    }
}

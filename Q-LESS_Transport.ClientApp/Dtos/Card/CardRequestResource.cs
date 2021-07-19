using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q_LESS_Transport.Dtos.Card
{
    public class CardRequestResource
    {
        public Guid CardTypeDetailsId { get; set; }
        public bool IsSenior { get; set; }
        public string DiscountCardId { get; set; }

    }
}

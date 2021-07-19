using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q_LESS_Transport.ClientApp.Models
{
    public class Card
    {
        public Guid Id { get; set; }
        public double Balance { get; set; }
        public DateTime ValidUntil { get; set; }
        public Guid CardTypeDetailsId { get; set; }
    }
}

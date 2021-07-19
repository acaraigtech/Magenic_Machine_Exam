using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Q_LESS_Transport.Dtos.Card
{
    public class CardResource
    {
        public Guid Id { get; set; }
        public double Balance { get; set; }
        public DateTime ValidUntil { get; set; }

        // Foreign properties
        // Foreign key
        public Guid CardTypeDetailsId { get; set; }
    }
}

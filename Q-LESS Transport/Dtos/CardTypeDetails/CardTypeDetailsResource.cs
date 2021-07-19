using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Q_LESS_Transport.Dtos.CardTypeDetails
{
    public class CardTypeDetailsResource
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int YearOfValidity { get; set; }
        public double InitialLoad { get; set; }
        public double FareAmount { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Q_LESS_Transport.Dtos.Card
{
    public class SaveCardResource
    {
        public double Balance { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ValidUntil { get; set; }

        // Foreign properties
        // Foreign key
        public Guid CardTypeDetailsId { get; set; }
    }
}

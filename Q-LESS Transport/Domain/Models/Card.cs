using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Q_LESS_Transport.Domain.Models
{
    public class Card
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public double Balance { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ValidUntil { get; set; }
        public Guid CardTypeDetailsId { get; set; }
        public CardTypeDetails CardTypeDetails { get; set; }
        public List<DiscountCard> DiscountCard { get; set; }
        public List<Transaction> Transaction { get; set; }

    }
}

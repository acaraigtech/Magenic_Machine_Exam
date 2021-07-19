using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Q_LESS_Transport.Domain.Models
{
    public class CardTypeDetails
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public int YearOfValidity { get; set; }
        public double InitialLoad { get; set; }
        public double FareAmount { get; set; }

        // Foreign properties
        // Foreign key
        public List<Card> Card { get; set; }
    }
}

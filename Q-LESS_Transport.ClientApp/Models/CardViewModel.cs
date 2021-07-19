using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q_LESS_Transport.ClientApp.Models
{
    public class CardViewModel
    {
        public Guid CardId { get; set; }
        public List<SelectListItem> ListOfCards { get; set; }
    }
}

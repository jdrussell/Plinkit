using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Plinkit.Domain.Models.Links;

namespace Plinkit.Domain.Models
{
    public class DailyLinksContainer
    {
        [Key]        
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<DailyLink> Links { get; set; }
    }
}

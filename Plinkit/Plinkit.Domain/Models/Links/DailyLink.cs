using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Plinkit.Domain.Enums;
using Plinkit.Domain.Extensions;

namespace Plinkit.Domain.Models.Links
{
    public abstract class DailyLink
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Container")]
        public int ContainerId { get; set; }        
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }

        public DailyLinksContainer Container { get; set; }       
 
        public virtual string GetCategory()
        {
            return LinkCategories.Undefined.GetDescription();
        }

        public string GetSite()
        {
            var linkComponents = Link.Split('/');
            return linkComponents[2];
        }
    }
}

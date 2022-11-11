using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlumbingShopDatabaseImplement.Models
{
    public class SanitaryEngineering
    {
        public int Id { get; set; }
        [Required]
        public string SanitaryEngineeringName { get; set; }
        [Required]
        public decimal Price { get; set; }
        [ForeignKey("SanitaryEngineeringId")]
        public virtual List<SanitaryEngineeringComponent> SanitaryEngineeringComponents { get; set; }
        [ForeignKey("SanitaryEngineeringId")]
        public virtual List<Order> Orders { get; set; }
    }
}

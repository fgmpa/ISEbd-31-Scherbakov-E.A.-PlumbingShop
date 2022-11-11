using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlumbingShopFileImplement.Models
{
    public class SanitaryEngineering
    {
        public int Id { get; set; }
        public string SanitaryEngineeringName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, int> SanitaryEngineeringComponents { get; set; }
    }
}

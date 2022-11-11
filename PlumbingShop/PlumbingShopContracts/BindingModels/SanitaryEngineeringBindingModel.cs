using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlumbingShopContracts.BindingModels
{
    public class SanitaryEngineeringBindingModel
    {
        public int? Id { get; set; }
        public string SanitaryEngineeringName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> SanitaryEngineeringComponents { get; set; }
    }
}

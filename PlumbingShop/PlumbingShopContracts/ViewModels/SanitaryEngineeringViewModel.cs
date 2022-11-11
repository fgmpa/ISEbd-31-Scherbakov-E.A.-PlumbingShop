using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlumbingShopContracts.ViewModels
{
    public class SanitaryEngineeringViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название изделия")]
        public string SanitaryEngineeringName { get; set; }

        [DisplayName("Цена")]
        public decimal Price { get; set; }

        public Dictionary<int, (string, int)> SanitaryEngineeringComponents { get; set; }
    }
}

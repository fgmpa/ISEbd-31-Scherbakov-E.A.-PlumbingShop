using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlumbingShopContracts.ViewModels
{
   public class ReportSanitaryEngineeringComponentViewModel
    {
        public string SanitaryEngineeringName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> Components { get; set; }
    }
}

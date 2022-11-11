using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlumbingShopContracts.Attributes;

namespace PlumbingShopContracts.ViewModels
{
    public class SanitaryEngineeringViewModel
    {
        [Column(title: "Номер", width: 100, visible: false)]
        public int Id { get; set; }

        [Column(title: "Название сантехники", width: 150)]
        public string SanitaryEngineeringName { get; set; }

        [Column(title: "Цена", width: 100)]
        public decimal Price { get; set; }
        [Column(title: "Компоненты", gridViewAutoSize: GridViewAutoSize.Fill)]
        public Dictionary<int, (string, int)> SanitaryEngineeringComponents { get; set; }
        public string GetComponents()
        {
            string stringComponents = string.Empty;
            if (SanitaryEngineeringComponents != null)
            {
                foreach (var ingr in SanitaryEngineeringComponents)
                {
                    stringComponents += ingr.Key + ") " + ingr.Value.Item1 + ": " + ingr.Value.Item2 + ", ";
                }
            }
            return stringComponents;
        }
    }
}

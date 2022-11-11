using PlumbingShopContracts.BindingModels;
using PlumbingShopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlumbingShopContracts.StoragesContracts
{
    public interface ISanitaryEngineeringStorage
    {
        List<SanitaryEngineeringViewModel> GetFullList();
        List<SanitaryEngineeringViewModel> GetFilteredList(SanitaryEngineeringBindingModel model);
        SanitaryEngineeringViewModel GetElement(SanitaryEngineeringBindingModel model);
        void Insert(SanitaryEngineeringBindingModel model);
        void Update(SanitaryEngineeringBindingModel model);
        void Delete(SanitaryEngineeringBindingModel model);
    }
}

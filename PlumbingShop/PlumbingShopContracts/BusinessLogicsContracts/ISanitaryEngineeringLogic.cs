using PlumbingShopContracts.BindingModels;
using PlumbingShopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlumbingShopContracts.BusinessLogicsContracts
{
    public interface ISanitaryEngineeringLogic
    {
        List<SanitaryEngineeringViewModel> Read(SanitaryEngineeringBindingModel model);

        void CreateOrUpdate(SanitaryEngineeringBindingModel model);

        void Delete(SanitaryEngineeringBindingModel model);
    }
}

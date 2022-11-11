using PlumbingShopContracts.BindingModels;
using PlumbingShopContracts.BusinessLogicsContracts;
using PlumbingShopContracts.StoragesContracts;
using PlumbingShopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlumbingShopBusinessLogic.BusinessLogics
{
    public class SanitaryEngineeringLogic : ISanitaryEngineeringLogic
    {
        private readonly ISanitaryEngineeringStorage sanitaryEngineeringStorage;

        public SanitaryEngineeringLogic(ISanitaryEngineeringStorage _sanitaryEngineeringStorage)
        {
            sanitaryEngineeringStorage = _sanitaryEngineeringStorage;
        }

        public List<SanitaryEngineeringViewModel> Read(SanitaryEngineeringBindingModel model)
        {
            if (model == null)
            {
                return sanitaryEngineeringStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<SanitaryEngineeringViewModel> { sanitaryEngineeringStorage.GetElement(model) };
            }
            return sanitaryEngineeringStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(SanitaryEngineeringBindingModel model)
        {
            var element = sanitaryEngineeringStorage.GetElement(new SanitaryEngineeringBindingModel { SanitaryEngineeringName = model.SanitaryEngineeringName });

            if (element != null && element.Id != model.Id) throw new Exception("Уже есть компонент с таким названием");

            if (model.Id.HasValue)
            {
                sanitaryEngineeringStorage.Update(model);
            }
            else
            {
                sanitaryEngineeringStorage.Insert(model);
            }
        }

        public void Delete(SanitaryEngineeringBindingModel model)
        {
            var element = sanitaryEngineeringStorage.GetElement(new SanitaryEngineeringBindingModel { Id = model.Id });

            if (element == null) throw new Exception("Элемент не найден");

            sanitaryEngineeringStorage.Delete(model);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlumbingShopFileImplement.Models;
using PlumbingShopContracts.BindingModels;
using PlumbingShopContracts.StoragesContracts;
using PlumbingShopContracts.ViewModels;

namespace PlumbingShopFileImplement.Implements
{
    public class SanitaryEngineeringStorage : ISanitaryEngineeringStorage
    {
        private readonly FileDataListSingleton source;

        public SanitaryEngineeringStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public List<SanitaryEngineeringViewModel> GetFullList()
        {
            return source.SanitaryEngineerings.Select(CreateModel).ToList();
        }

        public List<SanitaryEngineeringViewModel> GetFilteredList(SanitaryEngineeringBindingModel model)
        {
            if (model == null) return null;
            return source.SanitaryEngineerings.Where(rec => rec.SanitaryEngineeringName.Contains(model.SanitaryEngineeringName)).Select(CreateModel).ToList();
        }

        public SanitaryEngineeringViewModel GetElement(SanitaryEngineeringBindingModel model)
        {
            if (model == null) return null;
            var sanitaryEngineering = source.SanitaryEngineerings.FirstOrDefault(rec => rec.SanitaryEngineeringName == model.SanitaryEngineeringName || rec.Id == model.Id);
            return sanitaryEngineering != null ? CreateModel(sanitaryEngineering) : null;
        }

        public void Insert(SanitaryEngineeringBindingModel model)
        {
            int maxId = source.SanitaryEngineerings.Count > 0 ? source.SanitaryEngineerings.Max(rec => rec.Id) : 0;
            var element = new SanitaryEngineering { Id = maxId + 1, SanitaryEngineeringComponents = new Dictionary<int, int>() };
            source.SanitaryEngineerings.Add(CreateModel(model, element));
        }

        public void Update(SanitaryEngineeringBindingModel model)
        {
            var element = source.SanitaryEngineerings.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null) throw new Exception("Элемент не найден");
            CreateModel(model, element);
        }

        public void Delete(SanitaryEngineeringBindingModel model)
        {
            SanitaryEngineering element = source.SanitaryEngineerings.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null) source.SanitaryEngineerings.Remove(element);
            else throw new Exception("Элемент не найден");
        }

        private static SanitaryEngineering CreateModel(SanitaryEngineeringBindingModel model, SanitaryEngineering sanitaryEngineering)
        {
            sanitaryEngineering.SanitaryEngineeringName = model.SanitaryEngineeringName;
            sanitaryEngineering.Price = model.Price;

            foreach (var key in sanitaryEngineering.SanitaryEngineeringComponents.Keys.ToList())
            {
                if (!model.SanitaryEngineeringComponents.ContainsKey(key))
                    sanitaryEngineering.SanitaryEngineeringComponents.Remove(key);
            }
            foreach (var component in model.SanitaryEngineeringComponents)
            {
                if (sanitaryEngineering.SanitaryEngineeringComponents.ContainsKey(component.Key))
                    sanitaryEngineering.SanitaryEngineeringComponents[component.Key] = model.SanitaryEngineeringComponents[component.Key].Item2;
                else
                    sanitaryEngineering.SanitaryEngineeringComponents.Add(component.Key, model.SanitaryEngineeringComponents[component.Key].Item2);
            }
            return sanitaryEngineering;
        }

        private SanitaryEngineeringViewModel CreateModel(SanitaryEngineering sanitaryEngineering)
        {
            return new SanitaryEngineeringViewModel
            {
                Id = sanitaryEngineering.Id,
                SanitaryEngineeringName = sanitaryEngineering.SanitaryEngineeringName,
                Price = sanitaryEngineering.Price,
                SanitaryEngineeringComponents = sanitaryEngineering.SanitaryEngineeringComponents
                    .ToDictionary(recPC => recPC.Key, recPC =>
                        (source.Components.FirstOrDefault(recC => recC.Id == recPC.Key)?.ComponentName, recPC.Value))
            };
        }
    }
}

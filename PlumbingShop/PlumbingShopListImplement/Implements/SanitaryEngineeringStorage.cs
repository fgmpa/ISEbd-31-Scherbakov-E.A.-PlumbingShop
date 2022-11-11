using PlumbingShopContracts.BindingModels;
using PlumbingShopContracts.StoragesContracts;
using PlumbingShopContracts.ViewModels;
using PlumbingShopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlumbingShopListImplement.Implements
{
    public class SanitaryEngineeringStorage : ISanitaryEngineeringStorage
    {
        private readonly DataListSingleton source;

        public SanitaryEngineeringStorage()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<SanitaryEngineeringViewModel> GetFullList()
        {
            var result = new List<SanitaryEngineeringViewModel>();
            foreach (var sanitaryEngineering in source.SanitaryEngineerings)
            {
                result.Add(CreateModel(sanitaryEngineering));
            }
            return result;
        }

        public List<SanitaryEngineeringViewModel> GetFilteredList(SanitaryEngineeringBindingModel model)
        {
            if (model == null) return null;

            var result = new List<SanitaryEngineeringViewModel>();
            foreach (var sanitaryEngineering in source.SanitaryEngineerings)
            {
                if (sanitaryEngineering.SanitaryEngineeringName.Contains(model.SanitaryEngineeringName))
                {
                    result.Add(CreateModel(sanitaryEngineering));
                }
            }
            return result;
        }

        public SanitaryEngineeringViewModel GetElement(SanitaryEngineeringBindingModel model)
        {
            if (model == null) return null;

            foreach (var sanitaryEngineering in source.SanitaryEngineerings)
            {
                if (sanitaryEngineering.Id == model.Id || sanitaryEngineering.SanitaryEngineeringName == model.SanitaryEngineeringName)
                {
                    return CreateModel(sanitaryEngineering);
                }
            }
            return null;
        }

        public void Insert(SanitaryEngineeringBindingModel model)
        {
            var tempSanitaryEngineering = new SanitaryEngineering { Id = 1, SanitaryEngineeringComponents = new Dictionary<int, int>() };
            foreach (var sanitaryEngineering in source.SanitaryEngineerings)
            {
                if (sanitaryEngineering.Id >= tempSanitaryEngineering.Id) tempSanitaryEngineering.Id = sanitaryEngineering.Id + 1;
            }
            source.SanitaryEngineerings.Add(CreateModel(model, tempSanitaryEngineering));
        }

        public void Update(SanitaryEngineeringBindingModel model)
        {
            SanitaryEngineering tempSanitaryEngineering = null;
            foreach (var sanitaryEngineering in source.SanitaryEngineerings)
            {
                if (sanitaryEngineering.Id == model.Id) tempSanitaryEngineering = sanitaryEngineering;
            }

            if (tempSanitaryEngineering == null) throw new Exception("Элемент не найден");

            CreateModel(model, tempSanitaryEngineering);
        }

        public void Delete(SanitaryEngineeringBindingModel model)
        {
            for (int i = 0; i < source.SanitaryEngineerings.Count; ++i)
            {
                if (source.SanitaryEngineerings[i].Id == model.Id)
                {
                    source.SanitaryEngineerings.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        private static SanitaryEngineering CreateModel(SanitaryEngineeringBindingModel model, SanitaryEngineering sanitaryEngineering)
        {
            sanitaryEngineering.SanitaryEngineeringName = model.SanitaryEngineeringName;
            sanitaryEngineering.Price = model.Price;

            foreach (var key in sanitaryEngineering.SanitaryEngineeringComponents.Keys)
            {
                if (!model.SanitaryEngineeringComponents.ContainsKey(key))
                {
                    sanitaryEngineering.SanitaryEngineeringComponents.Remove(key);
                }
            }
            foreach (var component in model.SanitaryEngineeringComponents)
            {
                if (sanitaryEngineering.SanitaryEngineeringComponents.ContainsKey(component.Key))
                {
                    sanitaryEngineering.SanitaryEngineeringComponents[component.Key] = model.SanitaryEngineeringComponents[component.Key].Item2;
                }
                else
                {
                    sanitaryEngineering.SanitaryEngineeringComponents.Add(component.Key, model.SanitaryEngineeringComponents[component.Key].Item2);
                }
            }
            return sanitaryEngineering;
        }

        private SanitaryEngineeringViewModel CreateModel(SanitaryEngineering product)
        {
            var sanitaryEngineeringComponents = new Dictionary<int, (string, int)>();
            foreach (var se in product.SanitaryEngineeringComponents)
            {
                string componentName = string.Empty;
                foreach (var component in source.Components)
                {
                    if (se.Key == component.Id)
                    {
                        componentName = component.ComponentName;
                        break;
                    }
                }
                sanitaryEngineeringComponents.Add(se.Key, (componentName, se.Value));
            }
            return new SanitaryEngineeringViewModel
            {
                Id = product.Id,
                SanitaryEngineeringName = product.SanitaryEngineeringName,
                Price = product.Price,
                SanitaryEngineeringComponents = sanitaryEngineeringComponents
            };
        }
    }
}

using PlumbingShopContracts.StoragesContracts;
using PlumbingShopContracts.BindingModels;
using PlumbingShopContracts.ViewModels;
using PlumbingShopDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlumbingShopDatabaseImplement.Implements
{
    public class ComponentStorage : IComponentStorage
    {
        public void Delete(ComponentBindingModel model)
        {
            using var context = new PlumbingShopDatabase();
            Component element = context.Components.FirstOrDefault(rec => rec.Id ==
           model.Id);
            if (element != null)
            {
                context.Components.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        public ComponentViewModel GetElement(ComponentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new PlumbingShopDatabase();
            var component = context.Components
            .FirstOrDefault(rec => rec.ComponentName == model.ComponentName || rec.Id
           == model.Id);
            return component != null ? CreateModel(component) : null;

        }

        public List<ComponentViewModel> GetFilteredList(ComponentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new PlumbingShopDatabase();
            return context.Components
            .Where(rec => rec.ComponentName.Contains(model.ComponentName))
            .Select(CreateModel)
            .ToList();

        }

        public List<ComponentViewModel> GetFullList()
        {
            using var context = new PlumbingShopDatabase();
            return context.Components
            .Select(CreateModel)
            .ToList();
        }

        public void Insert(ComponentBindingModel model)
        {
            using var context = new PlumbingShopDatabase();
            context.Components.Add(CreateModel(model, new Component()));
            context.SaveChanges();
        }

        public void Update(ComponentBindingModel model)
        {
            using var context = new PlumbingShopDatabase();
            var element = context.Components.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
            context.SaveChanges();
        }
        private static Component CreateModel(ComponentBindingModel model, Component Component)
        {
            Component.ComponentName = model.ComponentName;
            return Component;
        }
        private static ComponentViewModel CreateModel(Component Component)
        {
            return new ComponentViewModel
            {
                Id = Component.Id,
                ComponentName = Component.ComponentName
            };
        }
    }
}

using PlumbingShopContracts.StoragesContracts;
using PlumbingShopContracts.BindingModels;
using PlumbingShopContracts.ViewModels;
using PlumbingShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlumbingShopDatabaseImplement.Implements
{
    public class SanitaryEngineeringStorage : ISanitaryEngineeringStorage
    {
        public void Delete(SanitaryEngineeringBindingModel model)
        {
            using var context = new PlumbingShopDatabase();
            SanitaryEngineering element = context.SanitaryEngineerings.FirstOrDefault(rec => rec.Id ==
            model.Id);
            if (element != null)
            {
                context.SanitaryEngineerings.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }

        }

        public SanitaryEngineeringViewModel GetElement(SanitaryEngineeringBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new PlumbingShopDatabase();
            var product = context.SanitaryEngineerings
            .Include(rec => rec.SanitaryEngineeringComponents)
            .ThenInclude(rec => rec.Component)
            .FirstOrDefault(rec => rec.SanitaryEngineeringName == model.SanitaryEngineeringName ||
            rec.Id == model.Id);
            return product != null ? CreateModel(product) : null;
        }

        public List<SanitaryEngineeringViewModel> GetFilteredList(SanitaryEngineeringBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new PlumbingShopDatabase();
            return context.SanitaryEngineerings
            .Include(rec => rec.SanitaryEngineeringComponents)
            .ThenInclude(rec => rec.Component)
            .Where(rec => rec.SanitaryEngineeringName.Contains(model.SanitaryEngineeringName))
            .ToList()
            .Select(CreateModel)
            .ToList();
        }

        public List<SanitaryEngineeringViewModel> GetFullList()
        {
            using var context = new PlumbingShopDatabase();
            return context.SanitaryEngineerings
            .Include(rec => rec.SanitaryEngineeringComponents)
            .ThenInclude(rec => rec.Component)
            .ToList()
            .Select(CreateModel)
            .ToList();

        }

        public void Insert(SanitaryEngineeringBindingModel model)
        {
            using var context = new PlumbingShopDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                SanitaryEngineering SanitaryEngineering = new SanitaryEngineering()
                {
                    SanitaryEngineeringName = model.SanitaryEngineeringName,
                    Price = model.Price

                };
                context.SanitaryEngineerings.Add(SanitaryEngineering);
                context.SaveChanges();
                CreateModel(model, SanitaryEngineering, context);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Update(SanitaryEngineeringBindingModel model)
        {
            using var context = new PlumbingShopDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var element = context.SanitaryEngineerings.FirstOrDefault(rec => rec.Id ==
                model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element, context);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }

        }
        private static SanitaryEngineering CreateModel(SanitaryEngineeringBindingModel model, SanitaryEngineering SanitaryEngineering, PlumbingShopDatabase context)
        {
            SanitaryEngineering.SanitaryEngineeringName = model.SanitaryEngineeringName;
            SanitaryEngineering.Price = model.Price;
            if (model.Id.HasValue)
            {
                var SanitaryEngineeringComponents = context.SanitaryEngineeringComponents.Where(rec =>
               rec.SanitaryEngineeringId == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.SanitaryEngineeringComponents.RemoveRange(SanitaryEngineeringComponents.Where(rec =>
               !model.SanitaryEngineeringComponents.ContainsKey(rec.ComponentId)).ToList());
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateComponent in SanitaryEngineeringComponents)
                {
                    updateComponent.Count =
                   model.SanitaryEngineeringComponents[updateComponent.ComponentId].Item2;
                    model.SanitaryEngineeringComponents.Remove(updateComponent.ComponentId);
                }
                context.SaveChanges();
            }
            foreach (var ii in model.SanitaryEngineeringComponents)
            {
                context.SanitaryEngineeringComponents.Add(new SanitaryEngineeringComponent
                {
                    SanitaryEngineeringId = SanitaryEngineering.Id,
                    ComponentId = ii.Key,
                    Count = ii.Value.Item2
                });
                context.SaveChanges();
            }
            return SanitaryEngineering;
        }
        private static SanitaryEngineeringViewModel CreateModel(SanitaryEngineering SanitaryEngineering)
        {
            return new SanitaryEngineeringViewModel
            {
                Id = SanitaryEngineering.Id,
                SanitaryEngineeringName = SanitaryEngineering.SanitaryEngineeringName,
                Price = SanitaryEngineering.Price,
                SanitaryEngineeringComponents = SanitaryEngineering.SanitaryEngineeringComponents
            .ToDictionary(recII => recII.ComponentId,
            recII => (recII.Component?.ComponentName, recII.Count))
            };
        }
    }
}

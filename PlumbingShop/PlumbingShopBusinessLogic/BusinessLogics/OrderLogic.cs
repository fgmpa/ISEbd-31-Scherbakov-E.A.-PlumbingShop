using PlumbingShopContracts.BindingModels;
using PlumbingShopContracts.BusinessLogicsContracts;
using PlumbingShopContracts.Enums;
using PlumbingShopContracts.StoragesContracts;
using PlumbingShopContracts.ViewModels;
using System;
using System.Collections.Generic;
using PlumbingShopBusinessLogic.MailWorker;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlumbingShopBusinessLogic.BusinessLogics
{
    public class OrderLogic : IOrderLogic
    {
        private readonly IOrderStorage orderStorage;
        private readonly IClientStorage clientStorage;
        private readonly AbstractMailWorker abstractMailWorker;

        public OrderLogic(IOrderStorage _orderStorage, IClientStorage _clientStorage, AbstractMailWorker _abstractMailWorker)
        {
            orderStorage = _orderStorage;
            clientStorage = _clientStorage;
            abstractMailWorker = _abstractMailWorker;
        }

        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            if (model == null)
            {
                return orderStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<OrderViewModel> { orderStorage.GetElement(model) };
            }
            return orderStorage.GetFilteredList(model);
        }

        public void CreateOrder(CreateOrderBindingModel model)
        {
            OrderBindingModel order = new OrderBindingModel
            { 
                SanitaryEngineeringId = model.SanitaryEngineeringId,
                ClientId = model.ClientId,
                Count = model.Count, 
                Sum = model.Sum, 
                Status = 0, 
                DateCreate = DateTime.Now 
            };

            orderStorage.Insert(order);

            abstractMailWorker.MailSendAsync(new MailSendInfoBindingModel
            {
                MailAddress = clientStorage.GetElement(new ClientBindingModel
                {
                    Id = model.ClientId
                })?.Email,
                Subject = $"Создан новый заказ",
                Text = $"Заказ от {DateTime.Now} на сумму {model.Sum:N2} принят."
            });
        }

        public void TakeOrderInWork(ChangeStatusBindingModel model)
        {
            var element = orderStorage.GetElement(new OrderBindingModel { Id = model.OrderId });

            if (element == null) throw new Exception("Элемент не найден");

            if (!element.Status.Contains(OrderStatus.Принят.ToString())) throw new Exception("Не в статусе \"Принят\"");

            orderStorage.Update(new OrderBindingModel
            {
                Id = model.OrderId,
                ImplementerId = model.ImplementerId,
                ClientId = element.ClientId,
                Status = OrderStatus.Выполняется,
                SanitaryEngineeringId = element.SanitaryEngineeringId,
                Count = element.Count,
                Sum = element.Sum,
                DateCreate = element.DateCreate,
                DateImplement = DateTime.Now
            });

            abstractMailWorker.MailSendAsync(new MailSendInfoBindingModel
            {
                MailAddress = clientStorage.GetElement(new ClientBindingModel
                {
                    Id = element.ClientId
                })?.Email,
                Subject = $"Заказ №{element.Id}",
                Text = $"Заказ №{element.Id} передан в работу."
            });
        }

        public void FinishOrder(ChangeStatusBindingModel model)
        {
            var element = orderStorage.GetElement(new OrderBindingModel { Id = model.OrderId });

            if (element == null) throw new Exception("Элемент не найден");

            if (!element.Status.Contains(OrderStatus.Выполняется.ToString())) throw new Exception("Не в статусе \"Выполняется\"");

            orderStorage.Update(new OrderBindingModel
            {
                Id = model.OrderId,
                ImplementerId = element.ImplementerId,
                ClientId = element.ClientId,
                Status = OrderStatus.Готов,
                DateImplement = element.DateImplement,
                SanitaryEngineeringId = element.SanitaryEngineeringId,
                Count = element.Count,
                Sum = element.Sum,
                DateCreate = element.DateCreate
            });

            abstractMailWorker.MailSendAsync(new MailSendInfoBindingModel
            {
                MailAddress = clientStorage.GetElement(new ClientBindingModel
                {
                    Id = element.ClientId
                })?.Email,
                Subject = $"Заказ №{element.Id}",
                Text = $"Заказ №{element.Id} выполнен."
            });
        }

        public void DeliveryOrder(ChangeStatusBindingModel model)
        {
            var element = orderStorage.GetElement(new OrderBindingModel { Id = model.OrderId });

            if (element == null) throw new Exception("Элемент не найден");

            if (!element.Status.Contains(OrderStatus.Готов.ToString())) throw new Exception("Не в статусе \"Готов\"");

            orderStorage.Update(new OrderBindingModel
            {
                Id = model.OrderId,
                ClientId = element.ClientId,
                ImplementerId = element.ImplementerId,
                Status = OrderStatus.Выдан,
                DateImplement = element.DateImplement,
                SanitaryEngineeringId = element.SanitaryEngineeringId,
                Count = element.Count,
                Sum = element.Sum,
                DateCreate = element.DateCreate
            });

            abstractMailWorker.MailSendAsync(new MailSendInfoBindingModel
            {
                MailAddress = clientStorage.GetElement(new ClientBindingModel
                {
                    Id = element.ClientId
                })?.Email,
                Subject = $"Заказ №{element.Id}",
                Text = $"Заказ №{element.Id} выдан."
            });
        }
    }
}

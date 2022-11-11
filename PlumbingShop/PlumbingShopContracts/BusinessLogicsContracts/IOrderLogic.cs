using PlumbingShopContracts.BindingModels;
using PlumbingShopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlumbingShopContracts.BusinessLogicsContracts
{
    public interface IOrderLogic
    {
        List<OrderViewModel> Read(OrderBindingModel model);

        void CreateOrder(CreateOrderBindingModel model);

        void TakeOrderInWork(ChangeStatusBindingModel model);

        void FinishOrder(ChangeStatusBindingModel model);

        void DeliveryOrder(ChangeStatusBindingModel model);
    }
}

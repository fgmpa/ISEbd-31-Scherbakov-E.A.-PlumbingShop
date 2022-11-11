using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using PlumbingShopContracts.BindingModels;
using PlumbingShopContracts.BusinessLogicsContracts;
using PlumbingShopContracts.ViewModels;

namespace PlumbingShopRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IOrderLogic _order;
        private readonly ISanitaryEngineeringLogic _sanitaryEngineering;
        private readonly IMessageInfoLogic _messageInfo;
        public MainController(IOrderLogic order, ISanitaryEngineeringLogic sanitaryEngineering, IMessageInfoLogic messageInfo)
        {
            _order = order;
            _sanitaryEngineering = sanitaryEngineering;
            _messageInfo = messageInfo;
        }
        [HttpGet]
        public List<SanitaryEngineeringViewModel> GetSanitaryEngineeringList() => _sanitaryEngineering.Read(null)?.ToList();
        [HttpGet]
        public SanitaryEngineeringViewModel GetSanitaryEngineering(int sanitaryEngineeringId) => _sanitaryEngineering.Read(new SanitaryEngineeringBindingModel { Id = sanitaryEngineeringId })?[0];
        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new OrderBindingModel { ClientId = clientId });
        [HttpGet]
        public List<MessageInfoViewModel> GetMessages(int clientId) => _messageInfo.Read(new MessageInfoBindingModel { ClientId = clientId });
        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) => _order.CreateOrder(model);
    }
}

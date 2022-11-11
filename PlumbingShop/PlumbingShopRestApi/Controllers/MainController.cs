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
        public MainController(IOrderLogic order, ISanitaryEngineeringLogic sanitaryEngineering)
        {
            _order = order;
            _sanitaryEngineering = sanitaryEngineering;
        }
        [HttpGet]
        public List<SanitaryEngineeringViewModel> GetSanitaryEngineeringList() => _sanitaryEngineering.Read(null)?.ToList();
        [HttpGet]
        public SanitaryEngineeringViewModel GetSanitaryEngineering(int sanitaryEngineeringId) => _sanitaryEngineering.Read(new
       SanitaryEngineeringBindingModel
        { Id = sanitaryEngineeringId })?[0];
        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new
       OrderBindingModel
        { ClientId = clientId });
        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) =>
       _order.CreateOrder(model);
    }
}

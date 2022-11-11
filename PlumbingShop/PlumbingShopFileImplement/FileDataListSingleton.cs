using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using PlumbingShopContracts.Enums;
using PlumbingShopFileImplement.Models;

namespace PlumbingShopFileImplement
{
    public class FileDataListSingleton
    {
        private static FileDataListSingleton instance;
        private readonly string ComponentFileName = "Component.xml";
        private readonly string OrderFileName = "Order.xml";
        private readonly string SanitaryEngineeringFileName = "SanitaryEngineering.xml";

        public List<Component> Components { get; set; }
        public List<Order> Orders { get; set; }
        public List<SanitaryEngineering> SanitaryEngineerings { get; set; }

        private FileDataListSingleton()
        {
            Components = LoadComponents();
            Orders = LoadOrders();
            SanitaryEngineerings = LoadSanitaryEngineerings();
        }

        public static FileDataListSingleton GetInstance()
        {
            if (instance == null) instance = new FileDataListSingleton();
            return instance;
        }

        public static void SaveData()
        {
            instance.SaveComponents();
            instance.SaveOrders();
            instance.SaveSanitaryEngineerings();
        }

        private List<Component> LoadComponents()
        {
            var list = new List<Component>();

            if (File.Exists(ComponentFileName))
            {
                var xDocument = XDocument.Load(ComponentFileName);
                var xElements = xDocument.Root.Elements("Component").ToList();

                foreach (var elem in xElements)
                {
                    list.Add(new Component
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ComponentName = elem.Element("ComponentName").Value
                    });
                }
            }
            return list;
        }

        private List<Order> LoadOrders()
        {
            var list = new List<Order>();

            if (File.Exists(OrderFileName))
            {
                var xDocument = XDocument.Load(OrderFileName);
                var xElements = xDocument.Root.Elements("Order").ToList();

                foreach (var elem in xElements)
                {
                    if (!Enum.TryParse(elem.Element("Status").Value, out OrderStatus orderStatus))
                    {
                        orderStatus = OrderStatus.Принят;
                    }

                    DateTime? orderDateImplement;
                    if (elem.Element("DateImplement").Value == null || elem.Element("DateImplement").Value == "")
                    {
                        orderDateImplement = null;
                    }
                    else
                    {
                        orderDateImplement = Convert.ToDateTime(elem.Element("DateImplement").Value);
                    }

                    list.Add(new Order
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        SanitaryEngineeringId = Convert.ToInt32(elem.Element("SanitaryEngineeringId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value),
                        Sum = Convert.ToDecimal(elem.Element("Sum").Value),
                        Status = orderStatus,
                        DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
                        DateImplement = orderDateImplement
                    });
                }
            }
            return list;
        }

        private List<SanitaryEngineering> LoadSanitaryEngineerings()
        {
            var list = new List<SanitaryEngineering>();

            if (File.Exists(SanitaryEngineeringFileName))
            {
                var xDocument = XDocument.Load(SanitaryEngineeringFileName);
                var xElements = xDocument.Root.Elements("SanitaryEngineering").ToList();

                foreach (var elem in xElements)
                {
                    var sanitaryEngineeringComp = new Dictionary<int, int>();
                    foreach (var component in elem.Element("SanitaryEngineeringComponents").Elements("SanitaryEngineeringComponent").ToList())
                    {
                        sanitaryEngineeringComp.Add(Convert.ToInt32(component.Element("Key").Value),
                            Convert.ToInt32(component.Element("Value").Value));
                    }
                    list.Add(new Models.SanitaryEngineering
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        SanitaryEngineeringName = elem.Element("SanitaryEngineeringName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value),
                        SanitaryEngineeringComponents = sanitaryEngineeringComp
                    });
                }
            }
            return list;
        }

        private void SaveComponents()
        {
            if (Components != null)
            {
                var xElement = new XElement("Components");
                foreach (var component in Components)
                {
                    xElement.Add(new XElement("Component",
                        new XAttribute("Id", component.Id),
                        new XElement("ComponentName", component.ComponentName)));
                }

                var xDocument = new XDocument(xElement);
                xDocument.Save(ComponentFileName);
            }
        }

        private void SaveOrders()
        {
            if (Orders != null)
            {
                var xElement = new XElement("Orders");
                foreach (var order in Orders)
                {
                    xElement.Add(new XElement("Order",
                        new XAttribute("Id", order.Id),
                        new XElement("SanitaryEngineeringId", order.SanitaryEngineeringId),
                        new XElement("Count", order.Count),
                        new XElement("Sum", order.Sum),
                        new XElement("Status", order.Status),
                        new XElement("DateCreate", order.DateCreate),
                        new XElement("DateImplement", order.DateImplement)));
                }

                var xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }

        private void SaveSanitaryEngineerings()
        {
            if (SanitaryEngineerings != null)
            {
                var xElement = new XElement("SanitaryEngineerings");
                foreach (var sanitaryEngineering in SanitaryEngineerings)
                {
                    var compElement = new XElement("SanitaryEngineeringComponents");
                    foreach (var component in sanitaryEngineering.SanitaryEngineeringComponents)
                    {
                        compElement.Add(new XElement("SanitaryEngineeringComponent",
                            new XElement("Key", component.Key),
                            new XElement("Value", component.Value)));
                    }
                    xElement.Add(new XElement("SanitaryEngineering",
                        new XAttribute("Id", sanitaryEngineering.Id),
                        new XElement("SanitaryEngineeringName", sanitaryEngineering.SanitaryEngineeringName),
                        new XElement("Price", sanitaryEngineering.Price),
                        compElement));
                }

                var xDocument = new XDocument(xElement);
                xDocument.Save(SanitaryEngineeringFileName);
            }
        }
    }
}

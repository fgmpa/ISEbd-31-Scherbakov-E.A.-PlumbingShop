using PlumbingShopBusinessLogic.OfficePackage;
using PlumbingShopBusinessLogic.OfficePackage.HelperModels;
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
    public class ReportLogic : IReportLogic
    {
        private readonly IComponentStorage _componentStorage;
        private readonly ISanitaryEngineeringStorage _sanitaryEngineeringStorage;
        private readonly IOrderStorage _orderStorage;
        private readonly AbstractSaveToExcel _saveToExcel;
        private readonly AbstractSaveToWord _saveToWord;
        private readonly AbstractSaveToPdf _saveToPdf;
        public ReportLogic(ISanitaryEngineeringStorage sanitaryEngineeringStorage, IComponentStorage
       componentStorage, IOrderStorage orderStorage,
        AbstractSaveToExcel saveToExcel, AbstractSaveToWord saveToWord,
       AbstractSaveToPdf saveToPdf)
        {
            _sanitaryEngineeringStorage = sanitaryEngineeringStorage;
            _componentStorage = componentStorage;
            _orderStorage = orderStorage;
            _saveToExcel = saveToExcel;
            _saveToWord = saveToWord;
            _saveToPdf = saveToPdf;
        }
        /// <summary>
        /// Получение списка компонент с указанием, в каких изделиях используются
        /// </summary>/// <returns></returns>
        public List<ReportSanitaryEngineeringComponentViewModel> GetSanitaryEngineeringComponent()
        {
            var sanitaryEngineerings = _sanitaryEngineeringStorage.GetFullList();
            var list = new List<ReportSanitaryEngineeringComponentViewModel>();
            foreach (var ic in sanitaryEngineerings)
            {
                var record = new ReportSanitaryEngineeringComponentViewModel
                {
                    SanitaryEngineeringName = ic.SanitaryEngineeringName,
                    Components = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var ingr in ic.SanitaryEngineeringComponents)
                {
                    record.Components.Add(new Tuple<string, int>(ingr.Value.Item1, ingr.Value.Item2));
                    record.TotalCount += ingr.Value.Item2;
                }
                list.Add(record);
            }
            return list;
        }
        /// <summary>
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return _orderStorage.GetFilteredList(new OrderBindingModel
            {
                DateFrom =
           model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                SanitaryEngineeringName = x.SanitaryEngineeringName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            })
           .ToList();
        }
        /// <summary>
        /// Сохранение компонент в файл-Word
        /// </summary>
        /// <param name="model"></param>
        public void SaveSanitaryEngineeringsToWordFile(ReportBindingModel model)
        {
            _saveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список сантехники",
                SanitaryEngineerings = _sanitaryEngineeringStorage.GetFullList()
            });
        }
        /// <summary>
        /// Сохранение компонент с указаеним продуктов в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        public void SaveSanitaryEngineeringComponentToExcelFile(ReportBindingModel model)
        {
            _saveToExcel.CreateReport(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список сантехники",
                SanitaryEngineeringComponents = GetSanitaryEngineeringComponent()
            });
        }
        /// <summary>
        /// Сохранение заказов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            _saveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Orders = GetOrders(model)
            });
        }
    }
}

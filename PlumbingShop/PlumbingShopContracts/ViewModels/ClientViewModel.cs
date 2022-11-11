using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using PlumbingShopContracts.Attributes;

namespace PlumbingShopContracts.ViewModels
{
    public class ClientViewModel
    {
        [Column(title: "Номер", width: 50, visible: false)]
        public int Id { get; set; }
        [Column(title: "ФИО", width: 150)]
        public string ClientFIO { get; set; }
        [Column(title: "Логин", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Email { get; set; }
        [Column(title: "Пароль", width: 150)]
        public string Password { get; set; }
    }
}

using System;
using PlumbingShopContracts.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PlumbingShopDatabaseImplement.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int SanitaryEngineeringId { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public decimal Sum { get; set; }
        [Required]
        public OrderStatus Status { get; set; }
        [Required]
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
        public virtual SanitaryEngineering SanitaryEngineering { get; set; }
    }
}

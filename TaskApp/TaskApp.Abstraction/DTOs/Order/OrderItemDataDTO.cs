using XMLApp.Dictionaries;
using XMLApp.Utils;
using XMLApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLApp.Data
{
    public class OrderItemDataDTO
    {
        public OrderStatusEnum OrderStatus { get; set; }
        public OrderStatusEnum AppetizerStatus { get; set; }
        public OrderStatusEnum MainCourseStatus { get; set; }
        public OrderStatusEnum DessertsStatus { get; set; }
        public OrderStatusEnum DrinksStatus { get; set; }
        public int OrderId { get; set; }
        public string Table { get; set; }
        public DateTime TimeOfOrder { get; set; }

    }
}


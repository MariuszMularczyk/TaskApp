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
    public class ProductItemDTO
    {
        public ProductType? ProductType { get; set; }
        public int? Quantity { get; set; }
        public int? OrderId { get; set; }
        public string ProductName { get; set; }
        public int? ProductId { get; set; }

    }
}


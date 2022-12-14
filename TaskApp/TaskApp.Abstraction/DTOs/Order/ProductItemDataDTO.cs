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
    public class ProductItemDataDTO
    {
        public int Id { get; set; }
        public ProductType ProductType { get; set; }
        public int? Priority { get; set; }
        public decimal? Measure { get; set; }
        public int OrderId { get; set; }
        public string Table { get; set; }
        public string ProductName { get; set; }
        public string ProductTypeName { get; set; }
        public decimal TimeOfPreparation { get; set; }

    }
}


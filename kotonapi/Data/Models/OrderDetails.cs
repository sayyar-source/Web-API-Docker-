using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace koton.api.Data.Models
{
    public class OrderDetails
    {
        [Key]
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        public int Total { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public Order Orders{ get; set; }
        public Product Products { get; set; }

    }
}

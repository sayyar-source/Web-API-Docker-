using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace koton.api.Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public int Discount { get; set; }
        public decimal UnitWeight { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder{ get; set; }
        public bool ProductAvailable { get; set; }
        public bool DiscountAvailable { get; set; }
        public int CategoryId { get; set; }
        public Category Categories { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }

    }
}

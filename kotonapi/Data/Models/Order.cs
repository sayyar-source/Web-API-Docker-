using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace koton.api.Data.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal SalesTax { get; set; }
        public int CusstomerId { get; set; }
        public int PaymentId { get; set; }
        public Customer Customers { get; set; }
        public Payment  Payments{ get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
    
}

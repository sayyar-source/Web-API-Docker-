using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.api.Data.Dtos
{
   public class OrderRequestDto
    {
        public int productId { get; set; }
        public int quantity { get; set; }
        public int stock { get; set; }
        public Customer customer { get; set; }
        public Billing billing { get; set; }
        public string status { get; set; }
    }
    public class Customer
    {
        public string customerId { get; set; }
        public string addressId { get; set; }
    }

    public class Discount
    {
        public string code { get; set; }
        public string type { get; set; }
        public string amount { get; set; }
    }

    public class Tax
    {
        public double rate { get; set; }
        public double price { get; set; }
        public string title { get; set; }
    }

    public class Billing
    {
        public int itemPrice { get; set; }
        public List<Discount> discount { get; set; }
        public List<Tax> taxes { get; set; }
        public double totalCost { get; set; }
    }
}

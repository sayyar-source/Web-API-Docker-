using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace koton.api.Data.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public string PaymentType { get; set; }
        public bool Allowed { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}

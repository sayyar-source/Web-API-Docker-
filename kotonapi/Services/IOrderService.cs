using koton.api.Data.Models;
using Koton.api.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.api.Services
{
   public interface IOrderService
    {
        public OrderRequestDto OrderRequest(OrderRequestDto orderRequest);
        public Product GetProductById(int Id);
        public List<Product> GetAllProduct();
    }
}

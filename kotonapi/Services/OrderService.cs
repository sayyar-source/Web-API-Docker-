
using koton.api.Data.Models;
using Koton.api.Data;
using Koton.api.Data.Dtos;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.api.Services
{
    public class OrderService : IOrderService
    {
        private readonly KotonDBContext _db;
        private readonly ILogger<OrderService> _logger;
        public OrderService(KotonDBContext db, ILogger<OrderService> logger)
        {
            _db = db;
            _logger = logger;
        }

        public OrderRequestDto OrderRequest(OrderRequestDto orderRequest)
        {
            try
            {
                var product = GetProductById(orderRequest.productId);
                if (product != null)
                {
                    if (product.UnitsInStock >= orderRequest.quantity)
                    {
                        product.UnitsInStock = product.UnitsInStock - orderRequest.quantity;
                        orderRequest.stock = product.UnitsInStock;
                        orderRequest.status = "success";
                        _db.Products.Update(product);
                        _db.SaveChanges();
                        _logger.LogInformation($"stock changed on product by id {orderRequest.productId}");
                    }
                    else
                    {
                        orderRequest.status = "failure";
                        _logger.LogWarning($"have not enough stock on product by id {orderRequest.productId}");
                    }
                   
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
              
            }
            return orderRequest;
        }
        public Product GetProductById(int Id)
        {
            try
            {
                var product = _db.Products.Where(p => p.Id == Id).FirstOrDefault();
                _logger.LogInformation($"get product by id {Id}");
                return product;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }

        }

        public List<Product> GetAllProduct()
        {
            try
            {
                var productlst = _db.Products.ToList();
                _logger.LogInformation($"get all product");
                return productlst;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
    }
}

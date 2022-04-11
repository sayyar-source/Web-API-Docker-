using AutoMapper;
using koton.api.Services;
using Koton.api.Data.Dtos;
using Koton.api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace koton.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<OrderController> _logger;
        private readonly IMapper _mapper;
        private readonly IMessageProducer _messagePublisher;
        public OrderController(IOrderService orderService, ILogger<OrderController> logger, IMapper mapper, IMessageProducer messagePublisher)
        {
            _orderService = orderService;
            _logger = logger;
            _mapper = mapper;
            _messagePublisher = messagePublisher;
        }



        [HttpPost("createorder")]
        public OrderRequestDto CreateOrder(OrderRequestDto orderRequest)
        {
            try
            {
                _logger.LogInformation($"send order by product id {orderRequest.productId}");
                var order = _orderService.OrderRequest(orderRequest);
                _messagePublisher.SendMessage(order);
                _logger.LogInformation($"push order by product id {orderRequest.productId} to Rabbit MQ");
                return (order);

            }
            catch (Exception ex)
            {
                _logger.LogError($"product with id {orderRequest.productId} is this exception: {ex.Message}");
                return null;
            }
         

        }

        [HttpGet]
        [Route("getproduct")]
        public ProductDto GetProduct(int Id)
        {
            try
            {
                 var product = _orderService.GetProductById(Id);
                 var productdto = _mapper.Map<ProductDto>(product);
                _logger.LogInformation($"get product by id {Id}");
                return (productdto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"product with id {Id} not found {ex.Message}");
                return null;
            }

        }

        [HttpGet]
        [Route("getall")]
        public List<ProductDto> GetAllroduct()
        {
            try
            {
                var productlst = _orderService.GetAllProduct();
                var productdto = _mapper.Map<List<ProductDto>>(productlst);
                _logger.LogInformation($"get all product");
                return (productdto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"get all product not found {ex.Message}");
                return null;
            }

        }

    }
}

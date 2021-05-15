using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WarehouseService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id:int}")]
        public string ThrowErrorMessage(int id)
        {
            try
            {
                if (id < 20)
                    throw new Exception($"product id cannot be less than 20. value passed is {id}");
                return "wrong id";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
            return $"product with id {id}";
        }

        [HttpGet("random")]
        public string GetRandom()
        {
            var random = new Random();
            var randomValue = random.Next(0, 100);
            var result = $"product with id {randomValue}";
            _logger.LogInformation($"{result}");
            return result;
        }

        [HttpGet]
        public IEnumerable<string> GetAll()
        {
            _logger.LogInformation($"\"Stake\", \"Beer\"");
            return new[] { "Stake", "Beer", };
        }

    }
}

using CurrencyConvertor.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using static CurrencyConvertor.Model.CurrencyType;

namespace CurrencyConvertor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<CurrencyController> _logger;
        public CurrencyController(IConfiguration configuration, ILogger<CurrencyController> logger )
        {
            _configuration = configuration;
            _logger = logger;
        }

        [HttpGet("Currency")]
        public  ActionResult<CurrencyResponse> GetCurrencyValue([FromQuery] CurrencyConvert currencyConvert)
        {
            try
            {
                decimal exchangeAmount = Convert.ToDecimal(_configuration.GetValue<string>($"exchangeRate:{currencyConvert.targetcurrency}"));
                string targetCurrency= currencyConvert.targetcurrency.ToString();
                CurrencyResponse response = new CurrencyResponse();
                response.convertedAmount = (currencyConvert.amount * exchangeAmount);
                response.exchangeRate = exchangeAmount;
                return response;


                //if (currencyConvert.targetcurrency.Equals(TargetCurrency.USD_TO_INR))
                //{
                //    response.convertedAmount = (currencyConvert.amount * exchangeAmount);
                //}

            }

            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw ;
            }
        }
    }
}

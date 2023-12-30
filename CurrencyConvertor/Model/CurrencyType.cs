using System.Text.Json.Serialization;

namespace CurrencyConvertor.Model
{
    public class CurrencyType
    {
        public class CurrencyConvert 
        {
            public SourcseCurrency sourcsecurrency { get; set; }
            public TargetCurrency targetcurrency { get; set; }
            public decimal amount { get; set; }
        }

        public class CurrencyResponse
        {
            public decimal exchangeRate { get; set; }
            public decimal convertedAmount { get; set; }
        }

        public enum SourcseCurrency
        {
            USD,
            INR,
            EUR,
            
        }

        public enum TargetCurrency
        {
            USD_TO_INR,
            INR_TO_USD,
            USD_TO_EUR,
            EUR_TO_USD,
            INR_TO_EUR,
            EUR_TO_INR,
        }
    }
}

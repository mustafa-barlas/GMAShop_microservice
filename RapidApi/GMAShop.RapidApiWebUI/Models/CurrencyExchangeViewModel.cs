
namespace GMAShop.RapidApiWebUI.Models
{
    public class CurrencyExchangeViewModel
    {
        public string FromSymbol { get; set; } // Örneğin: USD
        public string ToSymbol { get; set; }   // Örneğin: TRY
        public decimal ExchangeRate { get; set; } // Döviz kuru (örneğin: 36.2764)
        public decimal PreviousClose { get; set; } // Önceki kapanış (örneğin: 36.2465)
        public string LastUpdateUtc { get; set; } // Son güncelleme zamanı (örneğin: 2025-02-18 19:29:05)
    }
}


namespace OneSolutionV3.Common.Extension
{
    public static class CurrencyExtension
    {
        public static string toCurrency(this double value)
        {
            return value.ToString("###,###,###,##0.00");
        }
    }
}

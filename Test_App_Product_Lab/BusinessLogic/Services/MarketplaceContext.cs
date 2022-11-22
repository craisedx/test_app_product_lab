using System.Threading.Tasks;
using Test_App_Product_Lab.BusinessLogic.Interfaces;

namespace Test_App_Product_Lab.BusinessLogic.Services
{
    public class MarketplaceContext
    {
        private readonly IMarketplace _marketplace;

        public MarketplaceContext(IMarketplace marketplace)
        {
            _marketplace = marketplace;
        }

        /// <summary>
        /// Getting products and saving them in excel.
        /// </summary>
        /// <param name="searchParameterName">The parameter by which the search will be performed.</param>
        /// <returns></returns>
        public async Task ParseProductListToExcelBySearchParameterName(string searchParameterName)
        {
            await _marketplace.ParseProductListToExcelBySearchParameterName(searchParameterName);
        }
    }
}

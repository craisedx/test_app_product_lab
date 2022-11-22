using System.Threading.Tasks;

namespace Test_App_Product_Lab.BusinessLogic.Interfaces
{
    public interface IMarketplace
    {
        /// <summary>
        /// <para>Getting products and saving them in excel.</para>
        /// </summary>
        /// <param name="searchParameterName">The parameter by which the search will be performed.</param>
        /// <returns></returns>
        Task ParseProductListToExcelBySearchParameterName(string searchParameterName);
    }
}

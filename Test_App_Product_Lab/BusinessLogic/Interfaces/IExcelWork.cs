using System.Threading.Tasks;
using Test_App_Product_Lab.Models;

namespace Test_App_Product_Lab.BusinessLogic.Interfaces
{
    public interface IExcelWork
    {
        /// <summary>
        /// Saving all products in Excel.
        /// </summary>
        /// <param name="allProducts">All products.</param>
        /// <param name="searchParameterName">The parameter by which the search will be performed.</param>
        /// <returns></returns>
        Task SaveToExcelBySearchParameterName(AllProductData allProducts, string searchParameterName);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_App_Product_Lab.BusinessLogic.Interfaces
{
    public interface IFileWork
    {
        /// <summary>
        /// Gets all lines in file.
        /// </summary>
        /// <param name="encoding">Character encoding</param>
        /// <returns>All lines in file.</returns>
        Task<string[]> GetNamesToSearch(Encoding encoding);

        /// <summary>
        /// Gets all lines in file.
        /// </summary>
        /// <returns>All lines in file.</returns>
        Task<string[]> GetNamesToSearch();
    }
}

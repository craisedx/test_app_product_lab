using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_App_Product_Lab.BusinessLogic.Interfaces;
using Test_App_Product_Lab.Constants;

namespace Test_App_Product_Lab.BusinessLogic.Services.FileWork
{
    public class FileWork : IFileWork
    {
        private readonly string _path;
        private const int DefaultBufferSize = 4096;
        private const FileOptions DefaultOptions = FileOptions.Asynchronous | FileOptions.SequentialScan;
        public FileWork(string path)
        {
            _path = path;
        }

        /// <summary>
        /// Implements <see cref="IFileWork.GetNamesToSearch(Encoding)"/>
        /// <para>Gets all lines in file.</para>
        /// </summary>
        /// <param name="encoding">Character encoding</param>
        /// <returns>All lines in file.</returns>
        public async Task<string[]> GetNamesToSearch(Encoding encoding)
        {
            var lines = new List<string>();
            try
            {
                using (var stream = new FileStream(_path, FileMode.Open, FileAccess.Read, FileShare.Read, DefaultBufferSize, DefaultOptions))
                {
                    using (var reader = new StreamReader(stream, encoding))
                    {
                        string line;
                        while ((line = await reader.ReadLineAsync()) != null)
                        {
                            lines.Add(line);
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException(ExceptionConstants.FileReadingNotFound);
            }

            return lines.ToArray();
        }

        /// <summary>
        /// Implements <see cref="IFileWork.GetNamesToSearch()"/>
        /// <para>Gets all lines in file.</para>
        /// </summary>
        /// <returns>All lines in file.</returns>
        public Task<string[]> GetNamesToSearch()
        {
            return GetNamesToSearch(Encoding.UTF8);
        }
    }
}

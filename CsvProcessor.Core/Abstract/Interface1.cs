using System.Collections.Generic;

namespace CsvProcessor.Core.Abstract
{
    interface ICsvProcessor
    {
        IEnumerable<T> Process<T>(string entityName, string csvData) where T : new();
    }
}

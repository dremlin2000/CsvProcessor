using System.Collections.Generic;

namespace CsvProcessor.Core.Abstract
{
    public interface IMapper
    {
        IEnumerable<T> Map<T>(string CsvData) where T : new();
    }
}

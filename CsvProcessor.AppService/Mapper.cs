using CsvProcessor.Core.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CsvProcessor.AppService
{
    public class Mapper: IMapper
    {
        public IEnumerable<T> Map<T>(string CsvData) where T: new()
        {
            var result = new List<T>();

            var lines = CsvData.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
            var headers = lines[0].Split(",", StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines.Skip(1))
            {
                var lineData = line.Split(",", StringSplitOptions.RemoveEmptyEntries);
                var obj = new T();
                for (int i = 0; i < lineData.Length; i++)
                {
                    var propertyInfo = obj.GetType().GetProperties()
                        .FirstOrDefault(x => x.GetCustomAttributes(false)
                            .Any(y => y is ColumnAttribute && ((ColumnAttribute)y).Name.Equals(headers[i], StringComparison.InvariantCultureIgnoreCase)));

                    if (propertyInfo != null)
                        propertyInfo.SetValue(obj, Convert.ChangeType(lineData[i], propertyInfo.PropertyType), null);
                }
                result.Add(obj);
            }

            return result;
        }
    }
}

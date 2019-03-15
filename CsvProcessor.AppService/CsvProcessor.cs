using CsvProcessor.Core.Abstract;
using ScvProcessor.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace CsvProcessor.AppService
{
    public class CsvProcessor
    {
        private readonly IMapper _mapper;
        private readonly IAppRepository _appRepository;

        public CsvProcessor(IMapper mapper, IAppRepository appRepository)
        {
            _mapper = mapper;
            _appRepository = appRepository;
        }

        public void Process<T>(string entityName, string csvData) where T: new()
        {
            var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes());

            var type = types
                    .FirstOrDefault(t => t.GetCustomAttributes(false)
                        .Any(x => x is TableAttribute && ((TableAttribute)x).Name.Equals(entityName, StringComparison.InvariantCultureIgnoreCase)));

            var method = _mapper.GetType().GetMethod("Map");
            var generic = method.MakeGenericMethod(type);

            var entities = (IEnumerable<T>)generic.Invoke(_mapper, new object[] { csvData });

            foreach (var entity in entities)
            {
                var createMethod = _appRepository.GetType().GetMethod("Create");
                var createGeneric = createMethod.MakeGenericMethod(entity.GetType());

                createGeneric.Invoke(_appRepository, new object[] { entity });
            }

            _appRepository.Save();
        }
    }
}

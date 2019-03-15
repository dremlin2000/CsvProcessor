using CsvProcessor.AppService;
using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using CsvProcessor.Repository;
using Microsoft.EntityFrameworkCore;

namespace CsvProcessor.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var mapper = new Mapper();
            var db = new DbContextOptions<AppDbContext>();

            var dbContextBuilder = new DbContextOptionsBuilder<AppDbContext>();
            dbContextBuilder.UseSqlServer(configuration.GetConnectionString("DbConnection"));

            var repo = new AppEfRepository(new AppDbContext(dbContextBuilder.Options));

            var processor = new AppService.CsvProcessor(mapper, repo);

            var dirInfo = new DirectoryInfo("AppData");
            var files = dirInfo.GetFiles("*.csv"); //Getting CSV files

            foreach (var file in files)
            {
                var fileData = File.ReadAllText(file.FullName);

                var method = processor.GetType().GetMethod("Process");
                var generic = method.MakeGenericMethod(typeof(object));
                var result = generic.Invoke(processor, new object[] { Path.GetFileNameWithoutExtension(file.Name), fileData });
            }

            Console.WriteLine("CSV Data uploaded!");
            Console.ReadKey();
        }
    }
}

using CsvProcessor.Core.Abstract;
using Data.EFRepository.Base;


namespace CsvProcessor.Repository
{
    public partial class AppEfRepository : EntityFrameworkRepository<AppDbContext>, IAppRepository
    {
        public AppEfRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}

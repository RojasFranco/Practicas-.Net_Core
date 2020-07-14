using GyL.DDD.DotNet.Domain.Repositories;
using System.Threading.Tasks;

namespace GyL.DDD.DotNet.Persistance
{
    public class SampleUnitOfWork : IUnitOfWork
    {
        private readonly SampleDbContext _context;

        public SampleUnitOfWork(SampleDbContext context)
        {
            this._context = context;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}

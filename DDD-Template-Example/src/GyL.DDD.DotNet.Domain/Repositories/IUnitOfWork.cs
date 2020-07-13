using System.Threading.Tasks;

namespace GyL.DDD.DotNet.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}

using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GyL.DDD.DotNet.Domain.Repositories
{
	public interface ISampleRepository
	{
        T GetById<T>(object id) where T : class;
        T Get<T>(Func<T, bool> predicate) where T : class;
        T Get<T, W>(Func<T, bool> predicate, Expression<Func<T, W>> include) where T : class where W : class;
        IEnumerable<T> GetAll<T>() where T : class;
        IEnumerable<T> GetAll<T>(Func<T, bool> predicate) where T : class;
        EntityEntry<T> Add<T>(T entity) where T : class;
        Task<EntityEntry<T>> AddAsync<T>(T entity) where T : class;
        void AddRange<T>(IEnumerable<T> entity) where T : class;
        EntityEntry<T> Update<T>(T entity) where T : class;
        void UpdateRange<T>(IEnumerable<T> entity) where T : class;
        EntityEntry<T> Delete<T>(T entity) where T : class;
        void UpdateIgnoringProperty<T, W>(T entity, Expression<Func<T, W>> property) where T : class where W : struct;
        Task<int> SaveChangesAsync();
        int SaveChanges();
        IDbContextTransaction BeginTransaction();
    }
}

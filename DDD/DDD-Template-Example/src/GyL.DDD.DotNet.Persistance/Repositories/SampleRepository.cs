using GyL.DDD.DotNet.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GyL.DDD.DotNet.Persistance.Repositories
{
    public class SampleRepository : ISampleRepository
	{
        private readonly SampleDbContext _context;
        
        public SampleRepository(SampleDbContext context)
        {
            _context = context;
        }

        public virtual T GetById<T>(object id) where T : class
        {
            return _context.Set<T>().Find(id);
        }
        public virtual T Get<T>(Func<T, bool> predicate) where T : class
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }
        public virtual T Get<T, W>(Func<T, bool> predicate, Expression<Func<T, W>> include) where T : class where W : class
        {
            return _context.Set<T>().Include(include).FirstOrDefault(predicate);
        }

        public virtual IEnumerable<T> GetAll<T>() where T : class
        {
            var result = _context.Set<T>().AsEnumerable<T>().ToList();
            return result;
        }

        public IEnumerable<T> GetAll<T>(Func<T, bool> predicate) where T : class
        {
            return _context.Set<T>().Where(predicate);
        }
        public virtual EntityEntry<T> Add<T>(T entity) where T : class
        {
            return _context.Set<T>().Add(entity);
        }

        public async virtual Task<EntityEntry<T>> AddAsync<T>(T entity) where T : class
        {
            return await _context.Set<T>().AddAsync(entity);
        }

        public virtual EntityEntry<T> Update<T>(T entity) where T : class
        {
            return _context.Set<T>().Update(entity);
        }
        public virtual EntityEntry<T> Delete<T>(T entity) where T : class
        {
            return _context.Set<T>().Remove(entity);
        }

        public virtual void AddRange<T>(IEnumerable<T> entity) where T : class
        {
            _context.Set<T>().AddRange(entity);
        }

        public virtual void UpdateIgnoringProperty<T, W>(T entity, Expression<Func<T, W>> property) where T : class where W : struct
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Entry(entity).Property(property).IsModified = false;
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public virtual int SaveChanges()
        {
            return _context.SaveChanges();
        }
        public virtual Task<int> SaveChangesAsync()
        {
            return  _context.SaveChangesAsync();
        }

        public void UpdateRange<T>(IEnumerable<T> entity) where T : class
        {
            _context.Set<T>().UpdateRange(entity);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BeautyBook.DAL.Context;
using BeautyBook.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BeautyBook.DAL.Repository
{
    public abstract class BaseRepository<T, TPrimaryKey> : IGenericRepository<T, TPrimaryKey> where T : class
    {
        private readonly MyDbContext _myDbContext;
        private readonly DbSet<T> entities;
        public BaseRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
            entities = _myDbContext.Set<T>();
        }
        public async Task DeleteAsync(TPrimaryKey primaryKey)
        {
            var entity = await entities.FindAsync(primaryKey);
            if (entity is null) return;
            else entities.Remove(entity);
            await _myDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await entities.ToListAsync();

        }

        public async Task<IEnumerable<T>> GetAllFindAsync(Expression<Func<T, bool>> expression)
        {
            return await entities.Where(expression).ToListAsync();
        }

        public async Task<T> GetAsync(TPrimaryKey primaryKey)
        {
            return await entities.FindAsync(primaryKey);
        }

        public async Task<T> GetFirstAsync(Expression<Func<T, bool>> expression)
        {
            return await entities.FirstOrDefaultAsync(expression);
        }

        public async Task InsertAsync(T t)
        {
            await entities.AddAsync(t);
            await _myDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TPrimaryKey primaryKey, T t)
        {
            var entity = await GetAsync(primaryKey);
            if (entity is not null)
                _myDbContext.Entry(entity).State = EntityState.Detached;
            _myDbContext.Entry(t).State = EntityState.Modified;
            await _myDbContext.SaveChangesAsync();

        }
    }
}
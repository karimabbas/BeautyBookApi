using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyBook.DAL.Interfaces
{
    //Generic repository to all entities
    //TPrimaryKey is the primary key for entity
    public interface IGenericRepository<T, in TPrimaryKey> where T : class
    {
        public Task<T> GetAsync(TPrimaryKey primaryKey);
        public Task<T> GetFirstAsync(Expression<Func<T, bool>> expression);
        public Task<IEnumerable<T>> GetAllFindAsync(Expression<Func<T, bool>> expression);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task  InsertAsync(T t);
        public Task DeleteAsync(TPrimaryKey primaryKey);
        public Task UpdateAsync(TPrimaryKey primaryKey, T t);


    }
}
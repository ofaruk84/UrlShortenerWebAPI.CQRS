using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Domain.Core.Entities;

namespace UrlShortener.Domain.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        //push Fix

        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);

        Task<T> GetAsync(Expression<Func<T, bool>> filter);

        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);




    }
}

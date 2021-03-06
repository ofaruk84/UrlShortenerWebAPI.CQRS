using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UrlShortener.Domain.Core.Entities;

namespace UrlShortener.Domain.Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
         where TEntity : class, IEntity, new()
           where TContext : DbContext, new()

    {
        public async Task AddAsync(TEntity entity)
        {
            await using TContext context = new TContext();

            await Task.Run(() =>
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
            });


            await context.SaveChangesAsync();

        }

        public async Task DeleteAsync(TEntity entity)
        {
            await using TContext context = new TContext();

            await Task.Run(() =>
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
            });


            await context.SaveChangesAsync();

        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            await using TContext context = new TContext();
            return await context.Set<TEntity>().SingleOrDefaultAsync(filter);

        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            await using TContext context = new TContext();
            return filter == null
                ? await context.Set<TEntity>().ToListAsync()
                : await context.Set<TEntity>().Where(filter).ToListAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await using TContext context = new TContext();

            await Task.Run(() =>
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
            });

            await context.SaveChangesAsync();

        }
    }
}

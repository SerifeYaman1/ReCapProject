using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>
        where TEntity : class,IEntity, new()
        where TContext:DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var ctx = new TContext())
            {
                var deletedEntity = ctx.Entry(entity);
                deletedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                ctx.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var ctx = new TContext())
            {
                return ctx.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var ctx = new TContext())
            {
                return filter == null
                    ? ctx.Set<TEntity>().ToList()
                    : ctx.Set<TEntity>().Where(filter).ToList();
            }

        }
        public void Update(TEntity entity)
        {
            using (var ctx = new TContext())
            {
                var updatedEntity = ctx.Entry(entity);
                updatedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                ctx.SaveChanges();
            }


        }
    }
}

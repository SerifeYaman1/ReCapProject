using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using(MyDatabaseContext context=new MyDatabaseContext())
            {
                var addedEntity=context.Entry(entity);
                addedEntity.State=Microsoft.EntityFrameworkCore.EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (var ctx=new MyDatabaseContext())
            {
                var deletedEntity = ctx.Entry(entity);
                deletedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                ctx.SaveChanges();

            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using(var ctx=new MyDatabaseContext())
            {
                return ctx.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (var ctx = new MyDatabaseContext())
            {
                return filter == null
                    ? ctx.Set<Car>().ToList() 
                    : ctx.Set<Car>().Where(filter).ToList();
            }
        
        }
        public void Update(Car entity)
        {
            using(var ctx = new MyDatabaseContext())
            {
                var updatedEntity = ctx.Entry(entity);
                updatedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                ctx.SaveChanges();
            }

            
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YourJarvis.ApplicationCore.InterfacesDa;

namespace YourJarvis.Infrastructure.DataAccess.EfCore
{
    public class EfCoreDaRepository<T, TContext> : IRepositoryDa<T>
        where T : class
        where TContext : DbContext, new()
    {
        public virtual void Create(T entity)
        {
            using (var context = new TContext())
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
            }
        }

        public virtual void Delete(T entity)
        {
            using (var context = new TContext())
            {
                context.Set<T>().Remove(entity);
                context.SaveChanges();
            }
        }

        public virtual List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null
                         ? context.Set<T>().ToList()
                         : context.Set<T>().Where(filter).ToList();
            }
        }

        public virtual T GetById(int id)
        {
            using (var context = new TContext())
            {
                return context.Set<T>().Find(id);
            }
        }


        public virtual void Update(T entity)
        {
            using (var context = new TContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        #region IDCUD

        public virtual async Task<List<T>> Index()
        {
            using (var context = new TContext())
            {
                return await context.Set<T>().ToListAsync();
            }
        }

        public virtual async Task<T> Details(int id)
        {
            using (var context = new TContext())
            {
                return await context.Set<T>().FindAsync(id);
            }
        }

        public virtual void CreateY(T entity) 
        {
            using (var context = new TContext())
            {
                context.Set<T>().Add(entity);
                context.SaveChangesAsync();
            }
        }

        public virtual async Task<T> Edit(int? id)
        {
            using (var context = new TContext())
            {
                return await context.Set<T>().FindAsync(id);
            }
        }


        public void EditY(T entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteY(T entity)
        {
            throw new NotImplementedException();
        }

        

        #endregion
    }
}

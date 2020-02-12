using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YourJarvis.ApplicationCore.InterfacesDa;

namespace YourJarvis.Infrastructure.DataAccess.EfCoreDa 
{
    public class EfCoreDaRepository<T, TContext> : IRepositoryDa<T>
        where T : class
        where TContext : DbContext, new()
    {
        #region IDCUD

        public virtual List<T> Index()
        {
            using (var context = new TContext())
            {
                return context.Set<T>().ToList();
            }
        }

        public virtual T Details(int id)
        {
            using (var context = new TContext())
            {
                return context.Set<T>().Find(id);
            }
        }

        public virtual void Create(T entity)
        {
            using (var context = new TContext())
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
            }
        }

        public virtual void Edit(T entity)
        {
            using (var context = new TContext())
            {
                context.Entry(entity).State = EntityState.Modified;
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

        #endregion

    }
}

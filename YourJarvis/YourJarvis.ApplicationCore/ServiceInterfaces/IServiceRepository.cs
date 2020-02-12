using System;
using System.Collections.Generic;
using System.Text;
using YourJarvis.ApplicationCore.Entities;

namespace YourJarvis.ApplicationCore.ServiceInterfaces
{
    public interface IServiceRepository<T>  where T : class
    {
        List<T> Index(); 
        T Details(int id); 
        void Create(T entity);
        void Edit(T entity); 
        void Delete(T entity);
    }
}

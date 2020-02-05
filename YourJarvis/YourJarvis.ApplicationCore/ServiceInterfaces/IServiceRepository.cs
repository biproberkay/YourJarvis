using System;
using System.Collections.Generic;
using System.Text;
using YourJarvis.ApplicationCore.Entities;

namespace YourJarvis.ApplicationCore.ServiceInterfaces
{
    public interface IServiceRepository<T>  where T : class
    {
        T GetById(int id);
        List<T> GetAll();
        bool Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace YourJarvis.ApplicationCore.InterfacesDa
{
    public interface IRepositoryDa<T>
    {
        #region IDCED
        List<T> Index();
        T Details(int id);
        void Create(T entity); 
        void Edit(T entity);
        void Delete(T entity); 
        #endregion
    }
}

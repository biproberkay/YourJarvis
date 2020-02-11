﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace YourJarvis.ApplicationCore.InterfacesDa
{
    public interface IRepositoryDa<T>
    {
        T GetById(int id);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);

        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);

        #region IDCED
        List<T> Index();
        T Details(int id);
        void CreateY(T entity);
        void EditY(T entity);
        void DeleteY(T entity); 
        #endregion
    }
}

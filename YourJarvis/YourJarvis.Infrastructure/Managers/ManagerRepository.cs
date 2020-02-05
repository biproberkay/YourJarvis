using System;
using System.Collections.Generic;
using System.Text;
using YourJarvis.ApplicationCore.InterfacesDa;
using YourJarvis.ApplicationCore.ServiceInterfaces;

namespace YourJarvis.Infrastructure.Managers
{
    public class ManagerRepository<T> : IServiceRepository<T> where T : class
    {
        private IRepositoryDa<T> _daRepository;

        public ManagerRepository(IRepositoryDa<T> daRepository)
        {
            _daRepository = daRepository;
        }
        public bool Create(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            return _daRepository.GetAll();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}

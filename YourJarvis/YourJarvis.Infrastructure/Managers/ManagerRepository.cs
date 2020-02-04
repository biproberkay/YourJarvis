using System;
using System.Collections.Generic;
using System.Text;
using YourJarvis.ApplicationCore.ServiceInterfaces;

namespace YourJarvis.Infrastructure.Managers
{
    public class ManagerRepository<T> : IServiceRepository<T> where T : class
    {
        private IServiceRepository<T> _serviceRepository;

        public ManagerRepository(IServiceRepository<T> serviceRepository)
        {
            _serviceRepository = serviceRepository;
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
            return _serviceRepository.GetAll();
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

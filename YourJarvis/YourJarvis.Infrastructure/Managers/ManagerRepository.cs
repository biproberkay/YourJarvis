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
        public List<T> Index()
        {
            return _daRepository.Index();
        }

        public T Details(int id)
        {
            return _daRepository.Details(id);
        }

        public void Create(T entity)
        {
            _daRepository.Create(entity);
        }

        public void Edit(T entity)
        {
            _daRepository.Edit(entity);
        }

        public void Delete(T entity)
        {
            _daRepository.Delete(entity);
        }


    }
}

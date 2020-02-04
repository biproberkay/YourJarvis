using System;
using System.Collections.Generic;
using System.Text;
using YourJarvis.ApplicationCore.Entities;
using YourJarvis.ApplicationCore.ServiceInterfaces;

namespace YourJarvis.Infrastructure.Managers
{
    public class AlanManager : IAlanService
    {
        private IAlanService _alanService;

        public AlanManager(IAlanService alanService)
        {
            _alanService = alanService;
        }
        public bool Create(Alan entity)
        {
            _alanService.Create(entity);
            return true;
        }

        public void Delete(Alan entity)
        {
            throw new NotImplementedException();
        }

        public List<Alan> GetAll()
        {
            return _alanService.GetAll();
        }

        public Alan GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Alan entity)
        {
            throw new NotImplementedException();
        }
    }
}

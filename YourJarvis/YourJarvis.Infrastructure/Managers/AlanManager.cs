using System;
using System.Collections.Generic;
using System.Text;
using YourJarvis.ApplicationCore.Entities;
using YourJarvis.ApplicationCore.InterfacesDa;
using YourJarvis.ApplicationCore.ServiceInterfaces;

namespace YourJarvis.Infrastructure.Managers
{
    public class AlanManager : IAlanService
    {
        private IAlanDa _alanDa;

        public AlanManager(IAlanDa alanDa)
        {
            _alanDa = alanDa;
        }
        public bool Create(Alan entity)
        {
            _alanDa.Create(entity);
            return true;
        }

        public void Delete(Alan entity)
        {
            throw new NotImplementedException();
        }

        public List<Alan> GetAll()
        {
            return _alanDa.GetAll();
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

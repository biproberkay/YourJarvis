using System;
using System.Collections.Generic;
using System.Text;
using YourJarvis.ApplicationCore.Entities;

namespace YourJarvis.ApplicationCore.ServiceInterfaces
{
    public interface IAlanService
    {
        Alan GetById(int id);
        List<Alan> GetAll();
        bool Create(Alan entity);
        void Update(Alan entity);
        void Delete(Alan entity);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using YourJarvis.ApplicationCore.Entities;
using YourJarvis.ApplicationCore.InterfacesDa;
using YourJarvis.Infrastructure.Data.EfCore;

namespace YourJarvis.Infrastructure.DataAccess.EfCoreDa
{
    public class EfCoreDaAlan : EfCoreDaRepository<Alan, YourJarvisContext>, IAlanDa
    {
    }
}

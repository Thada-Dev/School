using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Installers
{
    public interface IInstallers
    {
        void InstallServices(IServiceCollection services, IConfiguration configuration);
    }
}
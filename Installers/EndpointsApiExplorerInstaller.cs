using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Installers
{
    public class EndpointsApiExplorerInstaller : IInstallers
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddEndpointsApiExplorer();
        }
    }
}
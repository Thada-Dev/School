using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using School.Database;
using Microsoft.EntityFrameworkCore;

namespace School.Installers
{
    public class DatabaseInstaller : IInstallers
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("ConnectionSQLServer"))
            );
        }
    }
}
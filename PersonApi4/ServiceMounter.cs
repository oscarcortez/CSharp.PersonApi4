using Microsoft.Extensions.DependencyInjection; // IserviceCollection
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using PersonApi4.Models;
using PersonApi4.Toolkit;
using PersonApi4.DataAccess;

namespace PersonApi4.Services
{
    public static class ServiceMounter
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IBusinessObject<ViewFormattedPerson>, BusinessObject<ViewFormattedPerson>>();
            services.AddSingleton<IStorageProvider<ViewFormattedPerson>, StorageProvider<ViewFormattedPerson>>();

            services.AddSingleton<IBusinessObject<IdentityType>, BusinessObject<IdentityType>>();
            services.AddSingleton<IStorageProvider<IdentityType>, StorageProvider<IdentityType>>();

            services.AddSingleton<IBusinessObject<Rol>, BusinessObject<Rol>>();
            services.AddSingleton<IStorageProvider<Rol>, StorageProvider<Rol>>();
        }
    }
}

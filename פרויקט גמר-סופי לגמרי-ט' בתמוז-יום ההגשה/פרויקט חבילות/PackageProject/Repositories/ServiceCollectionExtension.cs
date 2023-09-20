using Microsoft.Extensions.DependencyInjection;
//using Repositories.Entities;
using Repositories.Entities;
using Repositories.Interface;
using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public static class ServiceCollectionExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<BusinessDay>, BusinessDaysRepository>();
            services.AddScoped<IRepository<Client>, ClientsRepository>();
            //services.AddScoped<IRepository<Delivery>, DeliveriesRepository>();
            services.AddScoped<IRepository<Employee>, EmployeesRepository>();
            services.AddScoped<IRepository<Package>, PackagesRepository>();
            services.AddScoped<IRepository<PartialDelivery>, PartialDeliveryRepository>();
            services.AddScoped<IRepository<PartialDeliveryToPackage>,PartialDeliveryToPackageRepository>();
            services.AddScoped<IRepository<CollectingPoint>, CollectingPointRepository>();
        }
    }
}

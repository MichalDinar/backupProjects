using Common.DTOs;
using Microsoft.Extensions.DependencyInjection;
using Repositories;
using Services.Interface;
using Services.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Services.Algoritm;

namespace Services
{
    public static class ServiceCollectionExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IService<BusinessDayDto>, BusinessDayService>();
            services.AddScoped<IService<ClientDto>, ClientService>();
            services.AddScoped<IService<EmployeeDto>, EmployeeService>();
            services.AddScoped<IService<PackageDto>, PackageService>();
            services.AddScoped<IService<PartialDeliveryDto>, PartialDeliveryService>();
            services.AddScoped<IService<PartialDeliveryToPackageDto>, PartialDeliveryToPackageService>();
            services.AddScoped<IService<CollectingPointDto>, CollectingPointService>();
            services.AddScoped<IAlgorithm, Algoritm.Algorithm>();
            //services.AddScoped<IAlgoritm, Algorithm>();
            services.AddAutoMapper(typeof(Mapper));
            services.AddRepositories();
        }
    }
}

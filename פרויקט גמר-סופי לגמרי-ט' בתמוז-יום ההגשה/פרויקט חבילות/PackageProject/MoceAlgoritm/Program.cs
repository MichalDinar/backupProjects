
//אם רוצים שיהיה אפשר להריץ את האלגוריתם מפרויקט זה
//צריך לשחרר את הקוד הבא
//וכן לשנות את התלויות מכאן לסרויסז


using AutoMapper;
//using DBContext.Context;
using Repositories.Entities;
using Repositories;
using AutoMapper;
//using DBContext.Context;
using DBContext;
using Common.DTOs;
using Repositories;
using Repositories.Entities;
using Repositories.Interface;
using Services.Services;
using Repositories.Repositories;
using Mappper = Services.Mapper;
using System.IO.Packaging;
using Microsoft.EntityFrameworkCore.Internal;
using Algoritm;

namespace DBContext
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var config = new MapperConfiguration(cfg => { cfg.AddProfile<Mappper>(); });
            IMapper mapper = config.CreateMapper();
            IContext context = new PackageProject4Context();

            BusinessDaysRepository businessDaysRepository = new(context);
            BusinessDayService businessDayService = new(businessDaysRepository, mapper);

            ClientsRepository clientsRepository = new(context);
            ClientService clientService = new(clientsRepository, mapper);

            EmployeesRepository employeesRepository = new(context);
            EmployeeService employeeService = new(employeesRepository, mapper);

            CollectingPointRepository collectingPointRepository = new(context);
            CollectingPointService collectingPointService = new(collectingPointRepository, mapper);

            PackagesRepository packagesRepository = new(context);
            PackageService packageService = new(packagesRepository, mapper);

            PartialDeliveryRepository partialDeliveryRepository = new(context);
            PartialDeliveryService partialDeliveryService = new(partialDeliveryRepository, mapper);

            PartialDeliveryToPackageRepository prtialDeliveryToPackageRepository = new(context);
            PartialDeliveryToPackageService partialDeliveryToPackageService = new(prtialDeliveryToPackageRepository, mapper);
            DateTime open = new DateTime(1,1,1,8,30,0), close = new DateTime(1,1,1,10, 30,0);
            Algoritm.Algoritm a = new Algoritm.Algoritm(clientService, collectingPointService, employeeService, packageService, partialDeliveryService, partialDeliveryToPackageService, open, close);

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());

        }

    }
}
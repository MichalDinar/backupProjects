using AutoMapper;
using Common.DTOs;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client.Extensions.Msal;
using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Services
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<BusinessDay, BusinessDayDto>().ReverseMap();
            //reateMap<PackageInCollectingPoint, PAck>().ReverseMap();
            CreateMap<Client, ClientDto>().ReverseMap();
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Package, PackageDto>().ReverseMap();
            //CreateMap<PartialDelivery, PartialDeliveryDto>().ForMember(dest=>dest.EstimatedTimeOfArrival,opt=>opt.MapFrom(src=>Parse(src.EstimatedTimeOfArrival))).ReverseMap();
            CreateMap<PartialDelivery, PartialDeliveryDto>().ReverseMap();
            CreateMap<PartialDeliveryToPackage, PartialDeliveryToPackageDto>().ReverseMap();
            CreateMap<CollectingPoint, CollectingPointDto>()
                .ForMember(dest => dest.PackagesInCollectingPoint, opt => opt.Ignore()).ReverseMap();

        }
       
    }
}
